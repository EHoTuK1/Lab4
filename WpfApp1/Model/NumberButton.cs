using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp1.Model
{
    public class NumberButton : INotifyPropertyChanged
    {
        private string _buttonText;
        private static bool _validity;

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }

        public bool Validity
        {
            get { return _validity; }
            set
            {
                _validity = value;
                OnPropertyChanged("Value");
            }
        }

        public NumberButton(string buttonText, bool validity)
        {
            ButtonText = buttonText;
            Validity = validity;
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
