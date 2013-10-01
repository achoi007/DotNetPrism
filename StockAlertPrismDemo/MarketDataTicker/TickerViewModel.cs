using Microsoft.Practices.Prism.Events;
using StockAlert.Infra.Events;
using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MarketDataTicker
{
    public class TickerViewModel : INotifyPropertyChanged
    {
        private MarketDataTickEvent tickEvt_;
        private DispatcherTimer timer_;
        private List<char> tape_;
        private string tapeStr_;

        private void OnMarketTick(MarketDataTick tick)
        {
            // Add chars to tape_
            tape_.AddRange(string.Format("{0} {1}|", tick.Symbol, tick.Last));
        }

        private void OnTimer(object sender, EventArgs e)
        {
            // No pending tick?  Done
            if (tape_.Count == 0)
            {
                return;
            }

            // Remove first character
            tape_.RemoveAt(0);

            // Set the tape
            Tape = tape_.Take(TapeLength).Aggregate(new StringBuilder(),
                    (sb, ch) => sb.Append(ch),
                    sb => sb.ToString());
        }

        private void NotifyPropertyChange([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public TickerViewModel(IEventAggregator evtAggr)
        {
            // Initialize tape
            tape_ = new List<char>();
            TapeLength = 80;

            // Listen for market data ticks
            tickEvt_ = evtAggr.GetEvent<MarketDataTickEvent>();
            tickEvt_.Subscribe(OnMarketTick, ThreadOption.UIThread);

            // Set up timer to move tape
            timer_ = new DispatcherTimer();
            timer_.Tick += OnTimer;
        }

        /// <summary>
        /// Start strolling ticker
        /// </summary>
        public void Start()
        {
            timer_.Start();
        }

        /// <summary>
        /// Stop strolling ticker
        /// </summary>
        public void Stop()
        {
            timer_.Stop();
        }

        /// <summary>
        /// How often does ticker stroll
        /// </summary>
        public TimeSpan StrollInterval
        {
            get { return timer_.Interval; }
            set { timer_.Interval = value; }
        }

        /// <summary>
        /// Tape is of the form: Symbol Price|Symbol Price|....
        /// </summary>
        public string Tape
        {
            get { return tapeStr_; }
            set
            {
                tapeStr_ = value;
                NotifyPropertyChange();
            }
        }

        /// <summary>
        /// How many chars to display on tape.
        /// </summary>
        public int TapeLength { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
