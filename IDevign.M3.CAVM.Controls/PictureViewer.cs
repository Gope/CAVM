using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IDevign.M3.CAVM.ViewModels.Annotations;

namespace IDevign.M3.CAVM.Controls
{
    public class PictureViewer : ViewModelAwareControlBase<PictureViewerViewModel>
    {
        #region Constructors 

        static PictureViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (PictureViewer),
                                                     new FrameworkPropertyMetadata(typeof (PictureViewer)));
        }

        public PictureViewer()
        {
            this.Loaded += PictureViewer_Loaded;
        }

        void PictureViewer_Loaded(object sender, RoutedEventArgs e)
        {
            this.Context.ControlLoaded();
        }

        #endregion

        #region DependencyProperties 

        /// <summary>
        /// 	The <see cref="DependencyProperty"/> for the list of images shown within the control.
        /// </summary>
        public static readonly DependencyProperty ImageListProperty = DependencyProperty.Register(
            "ImageList",
            typeof(ObservableCollection<string>),
            typeof(PictureViewer),
            new FrameworkPropertyMetadata(null, OnImageListPropertyChanged));

        /// <summary>
        /// CLR Property for the <see cref="ImageListProperty"/> DP.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> ImageList
        {
            get { return (ObservableCollection<string>)this.GetValue(ImageListProperty); }
            set { this.SetValue(ImageListProperty, value); }
        }

        /// <summary>
        /// Called whenever the value of <see cref="ImageList"/> is changed.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnImageListPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewer = d as PictureViewer;
            if (viewer != null && viewer.Context != null)
            {
                viewer.Context.ImageList = (ObservableCollection<string>) e.NewValue;
            }
        }

        #endregion

        
    }
}
