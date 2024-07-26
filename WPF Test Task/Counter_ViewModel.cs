using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPF_Test_Task
{
    internal class Counter_ViewModel : INotifyPropertyChanged
    {
        private Counter_Model counter;
        private ICommand incrementCommand;
        public ICommand IncrementCommand
        {
            get
            {
                return incrementCommand ??
                  (incrementCommand = new RelayCommand(obj =>
                  {
                      if (ClearButtonEnable == false) ClearButtonEnable = true;
                      counter.Increment();
                      if (counter.Number == 99) IncrementButtonEnable = false;
                  }));
            }
        }
        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ??
                  (clearCommand = new RelayCommand(obj =>
                  {
                      ClearButtonEnable = false;
                      IncrementButtonEnable = true;
                      counter.Clear();
                  }));
            }
        }
        private bool incrementButtonEnable = true;
        public bool IncrementButtonEnable
        {
            get { return incrementButtonEnable; }
            set
            {
                incrementButtonEnable = value;
                OnPropertyChanged("IncrementButtonEnable");
            }
        }
        private bool clearButtonEnable = false;
        public bool ClearButtonEnable
        {
            get { return clearButtonEnable; }
            set
            {
                clearButtonEnable = value;
                OnPropertyChanged("ClearButtonEnable");
            }
        }
        public Counter_ViewModel() { counter = new(); }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
