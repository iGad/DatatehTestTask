using System;
using Prism.Mvvm;

namespace DatatehTestTask
{
    /// <summary>
    /// Базовый класс для моделей, содержит логику, облегчающую вызов PropertyChanged
    /// </summary>
    public abstract class ViewModel : BindableBase
    {
        /// <summary>
        /// Конструктор с контекстом.
        /// </summary>
        /// <param name="context">Контекст</param>
        protected ViewModel(IContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

        /// <summary>
        /// Контекст
        /// </summary>
        public IContext Context { get; private set; }

        /// <summary>
        /// Событие закрытия View
        /// </summary>
        public event EventHandler CloseEvent;

        /// <summary>
        /// Вызвать событие Close
        /// </summary>
        private void RaiseCloseEvent()
        {
            var handle = CloseEvent;
            if (handle != null)
            {
                handle(this, EventArgs.Empty);
            }
        }

        public void Close()
        {
            RaiseCloseEvent();
        }
    }
}
