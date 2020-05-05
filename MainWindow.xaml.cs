using System;
using System.Collections.Generic;
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

namespace Zellen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Einzeller> Zoo = new List<Einzeller>();
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Start();
            timer.Tick += animate;

            for (int i = 0; i < 5; i++)
            {
                Zoo.Add(new Amöbe());
            }

            for (int i = 0; i < 10; i++)
            {
                Zoo.Add(new Bakterie());
            }

           

         
        }

        private void animate(object sender, EventArgs e)
        {
            Petrischale.Children.Clear();
            List<Einzeller> Kindergarten = new List<Einzeller>();
            List<Einzeller> Friedhof = new List<Einzeller>();
            foreach (Einzeller item in Zoo)
            {                                
                item.Move();
                Kindergarten.AddRange(item.Teilen());
                item.Draw(Petrischale);
                Friedhof.AddRange(item.Die());
            }
            Zoo.AddRange(Kindergarten);
            //Elemente entfernen?
            
        }
    }
}
