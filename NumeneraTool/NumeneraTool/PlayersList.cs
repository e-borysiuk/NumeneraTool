using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace NumeneraTool
{
    public class PlayersList
    {
        public static Collection<object> Players = new ObservableCollection<object>();
        public static ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(Players);
            }
        }
    }
}