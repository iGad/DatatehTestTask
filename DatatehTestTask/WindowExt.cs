using System;
using System.Windows;

namespace DatatehTestTask
{
    public class WindowExt : Window
    {
        public WindowExt()
        {
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            Unsubscribe(dependencyPropertyChangedEventArgs.OldValue as ViewModel);
            Subscribe(dependencyPropertyChangedEventArgs.NewValue as ViewModel);
        }

        private void Subscribe(ViewModel viewModel)
        {
            if (viewModel != null)
            {
                viewModel.CloseEvent += OnViewModelClose;
            }
        }

        private void OnViewModelClose(object sender, EventArgs eventArgs)
        {
            Unsubscribe(sender as ViewModel);
            Close();
        }

        private void Unsubscribe(ViewModel viewModel)
        {
            if (viewModel != null)
            {
                viewModel.CloseEvent -= OnViewModelClose;
            }
        }
    }
}
