using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDataTemplate1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MyClass> myCollection = new ObservableCollection<MyClass>();
        public MainWindow()
        {
            InitializeComponent();
            myCollection.Add(new MyClass
            {
                Name = "snir ha-totach", IsLecturer = false,
            });
            myCollection.Add(new MyClass
            {
                Name = "michal the queen", IsLecturer = true,
            });

            DataContext = myCollection;
        }

        private int counter = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ++counter;
            myCollection.Add(
                new MyClass()
                {
                    Name = "item " + counter,
                    IsLecturer = counter % 3 == 0
                });
        }

    }

    class MyClass
    {
        public string Name { get; set; }
        public bool IsLecturer { get; set; }
    }
}
