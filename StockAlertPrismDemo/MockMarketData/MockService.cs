using Microsoft.Practices.Prism.Events;
using StockAlert.Infra.Events;
using StockAlert.Infra.Services;
using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MockMarketData
{
    public class MockService : IMarketDataService
    {
        private Dictionary<string, MarketDataTick> ticks_;
        private Dictionary<string, int> counts_;
        private MarketDataTickEvent evt_;
        private bool isRunning_;

        public MockService(IEventAggregator evtAgg)
        {
            ticks_ = new Dictionary<string, MarketDataTick>();
            counts_ = new Dictionary<string, int>();
            evt_ = evtAgg.GetEvent<MarketDataTickEvent>();
            Interval = 3000;
        }

        public string Name
        {
            get { return "MockMarketData"; }
        }

        public IDisposable Subscribe(string symbol)
        {
            lock (this)
            {
                int count;
                if (counts_.TryGetValue(symbol, out count))
                {
                    // Symbol already subscribed, just increment reference count.
                    count++;
                    counts_[symbol] = count;
                }
                else
                {
                    // New symbol.  Add to dicts
                    Random rnd = new Random();
                    counts_.Add(symbol, 1);
                    decimal last = rnd.Next(10, 100);
                    ticks_.Add(symbol, new MarketDataTick()
                    {
                        Ask = last + 1,
                        Bid = last - 1,
                        Last = last,
                        PreviousClose = last - rnd.Next(3) + 2,
                        Symbol = symbol,
                        Volume = rnd.Next(1, 100) * 100,
                    });
                }

                return Disposable.Create(() => CheckDispose(symbol));
            }
        }

        public bool TryGetTick(string symbol, out StockAlert.Infra.Types.MarketDataTick tick)
        {
            lock (this)
            {
                return ticks_.TryGetValue(symbol, out tick);
            }
        }

        /// <summary>
        /// Start generating ticks periodically.
        /// </summary>
        public void Start()
        {
            if (isRunning_)
            {
                return;
            }
            isRunning_ = true;

            Task.Factory.StartNew(() =>
            {
                while (isRunning_)
                {
                    Thread.Sleep(Interval);
                    Random rnd = new Random();
                    List<MarketDataTick> tickToPub = new List<MarketDataTick>();

                    lock (this)
                    {
                        foreach (var tick in ticks_.Values)
                        {
                            // Adjust tick:
                            // * increase volume by 100 to 500
                            // * change last, bid, ask
                            tick.Volume += rnd.Next(1, 5) * 100;
                            tick.Last += rnd.Next(-5, 5) * 0.125M;
                            if (tick.Last < 2)
                            {
                                tick.Last = 2;
                            }
                            tick.Bid = tick.Last - 1;
                            tick.Ask = tick.Last + 1;

                            // Add tick to publish.  Don't want to do publishing while
                            // locking THIS object.
                            tickToPub.Add(tick);
                        }
                    }

                    // Publish all ticks
                    foreach (var tick in tickToPub)
                    {
                        evt_.Publish(tick);
                    } 
                }

            });
        }

        /// <summary>
        /// Stop generating ticks
        /// </summary>
        public void Stop()
        {
            isRunning_ = false;
        }

        /// <summary>
        /// Return true if ticks are being generated periodically, false otherwise.
        /// </summary>
        public bool IsRunning
        {
            get { return isRunning_; }
        }

        /// <summary>
        /// How often to generate fake ticks for all symbols, measured in milliseconds
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Remove symbol from ticks_ and counts_ if reference count reaches
        /// 0.
        /// </summary>
        /// <param name="symbol"></param>
        private void CheckDispose(string symbol)
        {
            lock (this)
            {
                int count;
                if (counts_.TryGetValue(symbol, out count))
                {
                    if (count == 1)
                    {
                        // Remove symbol if this is the last ref count
                        ticks_.Remove(symbol);
                        counts_.Remove(symbol);
                    }
                    else
                    {
                        // Decrement reference count by 1
                        counts_[symbol] = count - 1;
                    }
                }
            }
        }
    }
}
