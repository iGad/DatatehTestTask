using System;

namespace DatatehTestTask.States
{
    /// <summary>
    /// Базовый класс для состояний
    /// </summary>
    public abstract class StateBase : IState
    {
        /// <summary>
        /// Выполнение каких-либо действий
        /// </summary>
        /// <param name="context">Контекст</param>
        public void Handle(IContext context)
        {
            if(context == null)
                throw new ArgumentNullException("context");
            DoHandle(context);
        }

        /// <summary>
        /// Выполнение действий состояния для переопределения в наследуемых классах
        /// </summary>
        /// <param name="context">Контекст</param>
        protected abstract void DoHandle(IContext context);
    }

    /// <summary>
    /// Базовый класс для состояний, изменяющих ViewModel
    /// </summary>
    /// <typeparam name="TModel">Конкретный тип модели</typeparam>
    public abstract class ViewModelState<TModel> : StateBase where TModel : ViewModel
    {
        /// <summary>
        /// Конструктор с моделью
        /// </summary>
        /// <param name="viewModel">Модель</param>
        protected ViewModelState(TModel viewModel)
        {
            if(viewModel == null)
                throw new ArgumentNullException("viewModel");
            Model = viewModel;
        } 

        /// <summary>
        /// Модель
        /// </summary>
        protected TModel Model { get; private set; }
    }
}
