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
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected ViewModel(IContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public IContext Context { get; private set; }

        /// <summary>
        /// Событие закрытия View
        /// </summary>
        public event EventHandler CloseEvent;

        /// <summary>
        /// Вызвать событие Close
        /// </summary>
        protected void RaiseCloseEvent()
        {
            var handle = CloseEvent;
            if (handle != null)
            {
                handle(this, EventArgs.Empty);
            }
        }

        public virtual void Close()
        {
            RaiseCloseEvent();
        }
    }
}
