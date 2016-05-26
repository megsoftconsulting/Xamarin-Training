using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XForms.Screens.TransactionDetail.XAML
{
    public partial class TransactionDetailScreenXaml : ContentPage
    {
        public TransactionDetailScreenXaml()
        {
            InitializeComponent();

            BindingContext = new TransactionDetailViewModel();
        }
    }
}
