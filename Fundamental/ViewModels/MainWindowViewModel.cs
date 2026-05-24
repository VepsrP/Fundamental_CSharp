using System.Windows;

namespace Fundamental.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private readonly string _title = "Fundamental";

        /// <summary>Заголовок окна</summary>
        public string Title => _title;

        #endregion

        #region LoadingPanelVisible : bool - Определение отображения панели

        /// <summary>Определение отображения панели</summary>

        /// <summary>Заголовок окна</summary>
        public Visibility LoadingPanelVisible { get; set; } = Visibility.Collapsed;

        #endregion

        #region MainContent : Visibility - Определение отображения главного контента

        /// <summary>Определение отображения главного контента</summary>
        public Visibility MainContent { get; set; } = Visibility.Collapsed;

        #endregion
    }
}
