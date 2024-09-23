using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using gh3;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object FileTxt;
        private DispatcherTimer timer;

        List<string> mus = new List<string> { };
        List<Song> history = new List<Song>();




        public MainWindow()
        {
            InitializeComponent();
            Song newSong = new Song { Name = "навзвание песни" };
            history.Add(newSong);
            string a = "C:\\Путь в Вальхаллу\\aaa.mp3";
            mus.Add(a);
            string b = "C:\\Путь в Вальхаллу\\38315.mp3";
            mus.Add(b);
            string c = "C:\\Путь в Вальхаллу\\киш.mp3";
            mus.Add(c);
            string d = "C:\\Путь в Вальхаллу\\киш2.mp3";
            mus.Add(d);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }







        private void Timer_Tick(object sender, EventArgs e)
        {
            slider.Value = stuka.Position.TotalSeconds;

            /*if (stuka.Source != null && stuka.NaturalDuration.HasTimeSpan)
            {
                double totalSeconds = stuka.NaturalDuration.TimeSpan.TotalSeconds;
                double currentPosition = stuka.Position.TotalSeconds;

                slider.Value = currentPosition / totalSeconds * 100;
            }*/
        }

        private void stuka_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider.Maximum = stuka.NaturalDuration.TimeSpan.TotalSeconds;
        }


        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            {
                stuka.Position = TimeSpan.FromSeconds(slider.Value);
            }
            if (slider.Value == slider.Maximum)

            {
                if (stuka.Source == new Uri(mus[0]))
                {
                    slider.Value = 0; 
                    stuka.Source = new Uri(mus[1]);

                }
                else if (stuka.Source == new Uri(mus[1]))
                {
                    slider.Value = 0;
                    stuka.Source = new Uri(mus[2]);

                }
                else if (stuka.Source == new Uri(mus[2]))
                {
                    slider.Value = 0;
                    stuka.Source = new Uri(mus[3]);

                }
                else if (stuka.Source == new Uri(mus[3]))
                {
                    slider.Value = 0;
                    stuka.Source = new Uri(mus[0]);

                }
                /*stuka.Source = new Uri(mus[mus.Count - 1 ]); 
                if (stuka.Source == new Uri(mus[3])) 
                {
                    stuka.Source = new Uri(mus[0]);
                    l = 0; 
                    stuka.Play(); *\
                }
                
            }
            
            /*if (stuka.Source != null && stuka.NaturalDuration.HasTimeSpan)
            {
                double totalSeconds = stuka.NaturalDuration.TimeSpan.TotalSeconds;
                double newPosition = slider.Value / 100 * totalSeconds;

                stuka.Position = TimeSpan.FromSeconds(newPosition);
            }*/
            }
        }



        private void Mus_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog doalog = new CommonOpenFileDialog { IsFolderPicker = true };
            var result = doalog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(doalog.FileName);
                foreach (string file in files)
                {

                    Ttextblock.Text += file + "\n";
                    string[] fil = { file };
                    stuka.Source = new Uri(fil[0]);
                    stuka.Play();
                }




            }

        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            if (stuka.Source == null)
            {

                stuka.Source = new Uri(mus[0]);
            }

            stuka.Play();



        }

        private void SledP_Click(object sender, RoutedEventArgs e)
        {

            if (stuka.Source == new Uri(mus[0]))
            {
                stuka.Source = new Uri(mus[1]);
            }
            else if (stuka.Source == new Uri(mus[1]))
            {
                stuka.Source = new Uri(mus[2]);

            }
            else if (stuka.Source == new Uri(mus[2]))
            {
                stuka.Source = new Uri(mus[3]);
            }
            else if (stuka.Source == new Uri(mus[3]))
            {
                stuka.Source = new Uri(mus[0]);

            }











        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            if (stuka.Source == new Uri(mus[3]))
            {
                stuka.Source = new Uri(mus[2]);
            }
            else if (stuka.Source == new Uri(mus[2]))
            {
                stuka.Source = new Uri(mus[1]);

            }
            else if (stuka.Source == new Uri(mus[1]))
            {
                stuka.Source = new Uri(mus[0]);
            }
            else if (stuka.Source == new Uri(mus[0]))
            {
                stuka.Source = new Uri(mus[3]);

            }


        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            stuka.Pause();

        }

        private void prodol_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Zvuk_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            stuka.Volume = Zvuk.Value;
        }

        private void per_Click(object sender, RoutedEventArgs e)
        {
            slider.Value = 0;

        }

        private void peremeska_Click(object sender, RoutedEventArgs e)
        {


        }



        private void hostory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            hostory.ItemsSource = history;


        }
    }
}
    



