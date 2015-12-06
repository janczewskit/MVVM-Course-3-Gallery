using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MVVM_3_ObservableCollection.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace MVVM_3_ObservableCollection.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Propeties

        private ObservableCollection<GalleryItem> _images;
        public ObservableCollection<GalleryItem> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                OnPropertyChanged(() => Images);
            }
        }

        private string _selectedItemName;

        public string SelectedItemName
        {
            get { return _selectedItemName; }
            set
            {
                _selectedItemName = value;
                OnPropertyChanged(() => SelectedItemName);
            }
        }


        #endregion

        #region Commands

        public ICommand OnListItemClick { get; set; }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            OnListItemClick = new DelegateCommand<GalleryItem>(OnListItemAction);
            GenerateElementsToListView();
        }

        private void GenerateElementsToListView()
        {
            Images = new ObservableCollection<GalleryItem>
            {
                new GalleryItem
                {
                    Image =
                        new BitmapImage(
                            new Uri("Assets/photographer.jpg", UriKind.Relative)),
                    Text = "Fotograf 1"
                },
                new GalleryItem
                {
                    Image =
                        new BitmapImage(
                            new Uri("Assets/photographer-2.jpg", UriKind.Relative)),
                    Text = "Fotograf 2"
                },
                new GalleryItem
                {
                    Image =
                        new BitmapImage(
                            new Uri("Assets/photographer-3.jpg", UriKind.Relative)),
                    Text = "Fotograf 3"
                }
            };
            //Images = tempImages;
        }

        #endregion

        #region Actions

        private void OnListItemAction(GalleryItem item)
        {
            SelectedItemName = item.Text;
        }
        
        #endregion

    }
}
