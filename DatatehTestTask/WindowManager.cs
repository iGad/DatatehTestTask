using System;
using System.Collections.Generic;
using System.Windows;

namespace DatatehTestTask
{
    public class WindowManager : IWindowManager
    {

        public WindowManager()
        {
            ActiveWindows = new Dictionary<ViewModel, Window>();
            ModelWindowDictionary = new Dictionary<Type, Type>();
        }

        public virtual Window ShowWindow(ViewModel viewModel, bool asDialog)
        {
            if(!this.ModelWindowDictionary.ContainsKey(viewModel.GetType()))
                throw new ArgumentException("Not registered ViewModel type");
            var window = Activator.CreateInstance(this.ModelWindowDictionary[viewModel.GetType()]) as Window;
            this.ActiveWindows.Add(viewModel, window);
            viewModel.CloseEvent+= OnViewModelCloseEvent;
            if (window != null)
            {
                window.DataContext = viewModel;
                if(asDialog)
                    window.ShowDialog();
                else
                {
                    window.Show();
                }
            }
            return window;
        }

        protected void Subscribe(ViewModel viewModel)
        {
            viewModel.CloseEvent += OnViewModelCloseEvent;
        }

        private void OnViewModelCloseEvent(object sender, EventArgs eventArgs)
        {
            ViewModel viewModel = sender as ViewModel;
            if (viewModel != null)
            {
                viewModel.CloseEvent -= OnViewModelCloseEvent;
                this.ActiveWindows.Remove((ViewModel) sender);
            }
        }

        public void AddPair(Type viewModelType, Type windowType)
        {
            this.ModelWindowDictionary.Add(viewModelType, windowType);
        }

        public IEnumerable<ViewModel> GetActiveViewModels()
        {
            return this.ActiveWindows.Keys;
        }

        protected Dictionary<Type, Type> ModelWindowDictionary { get; private set; }

        protected Dictionary<ViewModel, Window> ActiveWindows { get; private set; }
    }
}
