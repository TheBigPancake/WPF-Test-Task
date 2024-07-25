using System.Windows;

namespace WPF_Test_Task
{
    /// <summary>
    /// Логика взаимодействия для Counter_View.xaml
    /// </summary>
    public partial class Counter_View : Window
    {
        public Counter_View()
        {
            InitializeComponent();
            DataContext = new Counter_ViewModel();
        }
    }
}
