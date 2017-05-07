using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NumeneraTool
{
    public class DataClass : INotifyPropertyChanged
    {
        private short _current;
        private short _pool;
        private short _edge;

        public DataClass()
        {
            Current = 0;
            Pool = 0;
            Edge = 0;
        }

        public short Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged();
            }
        }

        public short Pool
        {
            get { return _pool; }
            set
            {
                _pool = value;
                OnPropertyChanged();
            }
        }

        public short Edge
        {
            get { return _edge; }
            set
            {
                _edge = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}