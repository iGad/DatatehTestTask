using System;
using System.Collections.Generic;
using System.Windows;

namespace DatatehTestTask
{
    /// <summary>
    /// Реализация менеджера окон
    /// </summary>
    public class WindowManager : IWindowManager
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public WindowManager()
        {
            ActiveWindows = new Dictionary<ViewModel, Window>();
            ModelWindowDictionary = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Создать и отобразить окно для указанной модели
        /// </summary>
        /// <param name="viewModel">Модель окна</param>
        /// <param name="asDialog">Создать новое окно модально или нет</param>
        /// <returns>Созданное окно</returns>
        public virtual void ShowWindow(ViewModel viewModel, bool asDialog)
        {
            if(!ModelWindowDictionary.ContainsKey(viewModel.GetType()))
                throw new ArgumentException("Not registered ViewModel type");
            var window = Activator.CreateInstance(ModelWindowDictionary[viewModel.GetType()]) as Window;
            ActiveWindows.Add(viewModel, window);
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
                ActiveWindows.Remove((ViewModel) sender);
            }
        }

        /// <summary>
        /// Зерегистрировать новую пару модель-окно. Модель должна быть унаследована от базового типа ViewModel, а окно от Window
        /// </summary>
        /// <param name="viewModelType">Тип модели</param>
        /// <param name="windowType">Тип окна</param>
        public void AddPair(Type viewModelType, Type windowType)
        {
            if(!IsObjectTypeCorrespondsToExpetedType(viewModelType, typeof(ViewModel)) || !IsObjectTypeCorrespondsToExpetedType(windowType, typeof(Window)))
                throw new ArgumentException("Wrong object type");
            ModelWindowDictionary.Add(viewModelType, windowType);
        }

        private static bool IsObjectTypeCorrespondsToExpetedType(Type checkedType, Type expectedType)
        {
            if (checkedType == null)
                return false;
            return checkedType == expectedType || IsObjectTypeCorrespondsToExpetedType(checkedType.BaseType, expectedType);
        }

        /// <summary>
        /// Получить модели всех текущих открытых окон
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ViewModel> GetActiveViewModels()
        {
            return ActiveWindows.Keys;
        }

        /// <summary>
        /// Набор зарегистрированных пар
        /// </summary>
        protected Dictionary<Type, Type> ModelWindowDictionary { get; private set; }

        /// <summary>
        /// Набор созданных окон
        /// </summary>
        protected Dictionary<ViewModel, Window> ActiveWindows { get; private set; }
    }
}
