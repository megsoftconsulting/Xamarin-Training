using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XForms.Screens.TransactionDetail
{
    public class TransactionDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Title { get; set; }
        public string ToHeader { get; set; }
        public string To { get; set; }
        public string TransactionTypeHeader { get; set; }
        public string TransactionType { get; set; }
        public string PerformedWithHeader { get; set; }
        public string PerformedWith { get; set; }
        public string AmountOfHeader { get; set; }
        public string AmountOf { get; set; }
        public string TransactionNotesHeader { get; set; }
        public string TransactionNotes { get; set; }

        public TransactionDetailViewModel()
        {
            Title = "Transaction 921312";

            ToHeader = "To";

            To = "luis@mipal.com";

            TransactionTypeHeader = "Transaction Type";
            
            TransactionType = "Send Money";

            PerformedWithHeader = "Peformed With";

            PerformedWith = "Debit Card (Visa ****4394)";

            AmountOfHeader = "Transaction Amount";

            AmountOf = "$250,000";

            TransactionNotesHeader = "Transaction Notes";

            TransactionNotes = "There you go!";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
