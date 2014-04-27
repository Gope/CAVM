using System.Windows.Data;
using IDevign.M3.CAVM.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace IDevign.M3.CAVM.Controls
{
    public class PictureViewerViewModel : ViewModelBase
    {
        private SortDirection currentSortDirection;
        private ObservableCollection<string> imageList;

        public PictureViewerViewModel()
        {
            this.CurrentListSortDirection = SortDirection.Regular;
        }

        internal void ControlLoaded()
        {
            // Needed for correct parameter.
            this.OnPropertyChanged("ChangeOrderCommand");
        }

        public SortDirection CurrentListSortDirection
        {
            get { return currentSortDirection; }
            set
            {
                currentSortDirection = value;
                OnPropertyChanged();
            }
        }       

        public ObservableCollection<string> ImageList
        {
            get
            {
                return imageList;
            }
            set
            {
                if (imageList != value)
                {
                    imageList = value;
                    OnImageListChanged();
                    OnPropertyChanged();
                }                
            }
        }

        private void OnImageListChanged()
        {
            if (this.ImageList == null)
                return;

            this.ImageList.Add("More/Bird.jpg");
        }

        public ICommand ChangeOrderCommand
        {
            get
            {
                return new DelegateCommand(
                    parameter =>
                        {
                            // Work the ImageList
                            var temp = new List<string>(this.ImageList);
                            this.ImageList.Clear();
                            temp.Reverse();
                            temp.ForEach(ImageList.Add);
                            // Reset CurrentItem to first element
                            CollectionViewSource.GetDefaultView(ImageList).MoveCurrentToFirst();
                            this.CurrentListSortDirection = (SortDirection)parameter;
                            // Update CanExecute - a bit brute though
                            this.OnPropertyChanged("ChangeOrderCommand");
                        }, 
                        parameter => 
                        {
                            if (parameter == null)
                                return false;

                            return this.CurrentListSortDirection != (SortDirection)parameter;
                        });
            }
        }
    }    
}