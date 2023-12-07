using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Singleton
    {
        private static Singleton instance;
        public List<ViewModel.ButtonViewModel> buttons = new List<ViewModel.ButtonViewModel>();

        private Singleton() { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }

        
    }
}
