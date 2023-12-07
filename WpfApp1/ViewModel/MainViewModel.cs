using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ViewModel.ButtonViewModel> _items = new ObservableCollection<ViewModel.ButtonViewModel>();
        public ObservableCollection<ViewModel.ButtonViewModel> items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("items");
            }
        }
        private void AddingButtons(int[] rightNumbers, int count)
        {
            List<ViewModel.ButtonViewModel> buttons = Singleton.getInstance().buttons;
            for (int i = 0; i<count; i++)
            {
                bool numberCheck = false;
                for (int j = 0;j<rightNumbers.Length; j++)
                {
                    if (i+1 == rightNumbers[j])
                    {
                        buttons.Add(new ButtonViewModel(new NumberButton((buttons.Count + 1).ToString(), true)));
                        numberCheck = true;
                        break;
                    }
                }
                if (!numberCheck)
                {
                    buttons.Add(new ButtonViewModel(new NumberButton((buttons.Count + 1).ToString(), false)));
                }
                Console.WriteLine(numberCheck.ToString());
            }
            AddNumbersToCollection(buttons, items);
        }
        private void AddNumbersToCollection(List<ViewModel.ButtonViewModel> buttons, ObservableCollection<ViewModel.ButtonViewModel> items)
        {
            if (items != null) items.Clear();
            for (int i = 0; i < buttons.Count; i++)
            {
                items.Add(buttons[i]);
            }
        }



        public MainViewModel()
        {
            int[] a = {2,6,10 };
            int count = 14;
            AddingButtons(a, count);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
