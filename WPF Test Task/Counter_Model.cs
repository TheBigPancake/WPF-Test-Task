using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace WPF_Test_Task
{
    internal class Counter_Model : INotifyPropertyChanged
    {
        private byte number = 0;
        public Counter_Model() { }
        public byte Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public void Increment() { if (Number < 99) Number++; }
        public void Clear() => Number = 0;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
