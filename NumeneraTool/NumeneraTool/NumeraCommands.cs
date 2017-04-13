using System.Windows.Input;

namespace NumeneraTool
{
    public class NumeraCommands
    {
        private static RoutedUICommand _addValue;
        private static RoutedUICommand _subtractValue;


        static NumeraCommands()
        {
            _addValue = new RoutedUICommand(
                "Add", "Adds value", typeof(NumeraCommands));
            _subtractValue = new RoutedUICommand(
                "Subtract", "Subtracts value", typeof(NumeraCommands));
        }

        public static RoutedUICommand AddValue
        {
            get { return _addValue; }
        }

        public static RoutedUICommand SubtractValue
        {
            get { return _subtractValue; }
        }
    }
}