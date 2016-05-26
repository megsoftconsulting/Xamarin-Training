using System;
using System.Linq.Expressions;
using Xamarin.Forms;

namespace XForms.Screens.TransactionDetail
{
    public class TransactionDetailScreen : ContentPage
    {
        public TransactionDetailScreen()
        {
            Content = CreateContent();

            BindingContext = new TransactionDetailViewModel();
        }

        private View CreateContent()
        {
            this.SetBinding<TransactionDetailViewModel>(TitleProperty, m => m.Title);

            var entityName = CreateDash(m => m.ToHeader, m => m.To);

            var actionGiven = CreateDash(m => m.TransactionTypeHeader, m => m.TransactionType);

            var performedWith = CreateDash(m => m.PerformedWithHeader, m => m.PerformedWith);

            var amountOf = CreateDash(m => m.AmountOfHeader, m => m.AmountOf);

            var transactionNote = CreateDash(m => m.TransactionNotesHeader, m => m.TransactionNotes);

            return new StackLayout
            {
                Children =
                {
                    entityName,
                    actionGiven,
                    performedWith,
                    amountOf,
                    transactionNote
                }
            };
        }

        View CreateDash(Expression<Func<TransactionDetailViewModel, object>> title,
            Expression<Func<TransactionDetailViewModel, object>> subtitle)
        {
            var header = new Label
            {
                FontSize = 12,
                TextColor = Color.Gray
            };

            header.SetBinding(Label.TextProperty, title);

            var value = new Label
            {
                FontSize = 16
            };

            value.SetBinding(Label.TextProperty, subtitle);

            return new StackLayout
            {
                Padding = new Thickness(20),
                Children =
                {
                    new StackLayout
            {
                Spacing = 16,
                Children =
                {
                    header,
                    value
                }
            },
                    new BoxView
                    {
                        Color = Color.Gray,
                        HeightRequest = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    }
                }
            };
        }
    }
}
