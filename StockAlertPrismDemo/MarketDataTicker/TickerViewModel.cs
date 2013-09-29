using Microsoft.Practices.Prism.Events;
using StockAlert.Infra.Events;
using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MarketDataTicker
{
    public class TickerViewModel : INotifyPropertyChanged
    {
        private MarketDataTickEvent tickEvt_;
        private List<MarketDataTick> ticks_;
        private DispatcherTimer timer_;

        private void OnMarketDataTick(MarketDataTick tick)
        {
            ticks_.Add(tick);
        }

        public TickerViewModel(IEventAggregator evtAggr)
        {
            // Set up list to remember ticks yet to be displayed.
            ticks_ = new List<MarketDataTick>();

            // Listen for market data ticks
            tickEvt_ = evtAggr.GetEvent<MarketDataTickEvent>();
            tickEvt_.Subscribe(OnMarketDataTick, ThreadOption.UIThread);

            // Set up timer to move tape
            timer_ = new DispatcherTimer();
            timer_.Tick += timer_Tick;
            timer_.Interval = TimeSpan.FromSeconds(3);
            timer_.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ticks_.Count == 0)
            {
                return;
            }

            // Helper function to generate u|d|- based on tick.Change
            Func<MarketDataTick, char> upOrDown = (tick) =>
            {
                return (tick.Change > 0 ? 'u' : (tick.Change == 0 ? '-' : 'd'));
            };

            // Generate the tape
            Tape = ticks_.Aggregate(new StringBuilder(),
                (acc, tick) => acc.AppendFormat("{0} {1} {2}|", upOrDown(tick), tick.Symbol, tick.Last),
                acc => acc.ToString());

            // Remove first tick.
            ticks_.RemoveAt(0);

            // Notify change
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Tape"));
            }
        }

        /// <summary>
        /// Tape is of the form:
        ///   Field1|Field2|....|FieldN
        /// where:
        ///   Fieldn := u|d message (for example u AAPL 101.25)
        /// </summary>
        public string Tape { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
