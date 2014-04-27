using System.Collections.Generic;

namespace IDevign.M3.CAVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IEnumerable<string> images;
        public IEnumerable<string> Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
                OnPropertyChanged();
            }
        }
    }
}