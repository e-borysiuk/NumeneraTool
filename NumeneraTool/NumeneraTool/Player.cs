using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NumeneraTool
{
    public class Player : INotifyPropertyChanged
    {
        private DataClass _might;
        private DataClass _speed;
        private DataClass _intellect;
        private string _name;

        public DataClass Might
        {
            get { return _might; }
            set
            {
                _might = value;
                OnPropertyChanged();
            }
        }

        public DataClass Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged();
            }
        }

        public DataClass Intellect
        {
            get { return _intellect; }
            set
            {
                _intellect = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public Player()
        {
            Might = new DataClass();
            Speed = new DataClass();
            Intellect = new DataClass();
        }
        public Player(string name)
        {
            Might = new DataClass();
            Speed = new DataClass();
            Intellect = new DataClass();
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}