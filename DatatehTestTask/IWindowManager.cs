using System;
using System.Collections.Generic;
using System.Windows;

namespace DatatehTestTask
{
    /// <summary>
    /// Интерфейс для менеджера окон, для разрыва зависимости между конкретной реализацией и клиентами
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        /// Создать и отобразить окно для указанной модели
        /// </summary>
        /// <param name="viewModel">Модель окна</param>
        /// <param name="asDialog">Создать новое окно модально или нет</param>
        /// <returns>Созданное окно</returns>
        Window ShowWindow(ViewModel viewModel, bool asDialog);

        /// <summary>
        /// Зерегистрировать новую пару модель-окно
        /// </summary>
        /// <param name="viewModelType">Тип модели</param>
        /// <param name="windowType">Тип окна</param>
        void AddPair(Type viewModelType, Type windowType);

        /// <summary>
        /// Получить модели всех текущих открытых окон
        /// </summary>
        /// <returns></returns>
        IEnumerable<ViewModel> GetActiveViewModels();
    }
}