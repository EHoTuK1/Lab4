using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class ButtonViewModel : INotifyPropertyChanged
    {
        private ICommand _buttonCommand;
        private Brush _buttonColor;
        

        public NumberButton NumberButton { get; set; }
        private bool ButtonValidity => NumberButton.Validity;

        public ICommand ButtonCommand
        {
            get
            {
                if (_buttonCommand == null)
                {
                    _buttonCommand = new RelayCommand(
                        param => this.ChangeColor(ButtonValidity),
                        param => true);
                }
                return _buttonCommand;
            }
        }

        public Brush ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                if (_buttonColor != value)
                {
                    _buttonColor = value;
                    OnPropertyChanged("ButtonColor");
                }
            }
        }

        public ButtonViewModel(NumberButton numberButton)
        {
            NumberButton = numberButton;
            ButtonColor = Brushes.LightGray;
        }

        private void ChangeColor(bool validity)
        {
            if (validity)
            {
                ButtonColor = Brushes.LightBlue;
            }
            else
            {
                ButtonColor = Brushes.Red;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
