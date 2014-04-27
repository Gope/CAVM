using System;
using System.Windows;
using System.Windows.Controls;
using IDevign.M3.CAVM.ViewModels;

namespace IDevign.M3.CAVM.Controls
{
    /// <summary>
    /// The Base-Class for Controls holding an internal ViewModel
    /// </summary>
    public class ViewModelAwareControlBase<T> : Control
    {
        #region Dependency Properties

        /// <summary>
        /// 	The <see cref="DependencyProperty"/> for the list of images shown within the control.
        /// </summary>
        public static readonly DependencyProperty ContextProperty = DependencyProperty.Register(
            "Context",
            typeof(T),
            typeof(ViewModelAwareControlBase<T>),
            new FrameworkPropertyMetadata(null));

        /// <summary>
        /// CLR Property for the <see cref="Context"/> DP.
        /// </summary>
        public T Context
        {
            get { return (T)this.GetValue(ContextProperty); }
            set { this.SetValue(ContextProperty, value); }
        }

        #endregion
    }
}