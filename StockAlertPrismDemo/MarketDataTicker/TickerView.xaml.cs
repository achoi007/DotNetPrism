using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using StockAlert.Infra.Events;
using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MarketDataTicker
{
    /// <summary>
    /// Interaction logic for TickerView.xaml
    /// </summary>
    public partial class TickerView : UserControl
    {
        public TickerView(TickerViewModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
