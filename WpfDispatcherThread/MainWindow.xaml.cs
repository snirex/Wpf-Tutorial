using System;
using System.Threading;
using System.Windows;
//https://www.youtube.com/watch?v=945Hzyzzu2I&t=206s&ab_channel=Tutorialspoint
namespace WpfDispatcherThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Thread th1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            th1 = new Thread(new ThreadStart(SetText));
            th1.Start();
        }

        private void SetText()
        {
            //textbox1.Text = "snir is writing text"; // no working

            Dispatcher.BeginInvoke(new Action(() => { textbox1.Text = "snir is writing text"; }));
            Thread.Sleep(1000);
            Dispatcher.Invoke(() => { textbox1.Text = "SNIR IS WRITING TEXT"; });
        }
    }
}
