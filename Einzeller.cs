using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Zellen
{
    abstract class Einzeller
    {
        //int x, y;
        //public int X { get { return x; } }
        //public int Y { get { return y; } }

        public int x {  get; private set; }
        public int y {  get; private set; }

        static protected Random rnd = new Random();

        public Einzeller()
        {
            x = rnd.Next(50,751);
            y = rnd.Next(50,401);
        }

        public Einzeller(Einzeller ez)
        {
            x = ez.x;
            y = ez.y;
        }

        public abstract void Draw(Canvas petrischale);

        public void Move()
        {
            x += rnd.Next(-1,2);
            y += rnd.Next(-1,2);
        }

        public abstract List<Einzeller> Teilen();

        public abstract List<Einzeller> Die();
    }

    class Amöbe : Einzeller
    {
        public Amöbe() { }
        public Amöbe(Amöbe a) : base(a)
        {

        }
        public override void Draw(Canvas petrischale)
        {
            Ellipse e = new Ellipse();
            e.Width = 8;
            e.Height = 8;
            e.Fill = Brushes.Red;
            petrischale.Children.Add(e);
            Canvas.SetLeft(e,x-4);
            Canvas.SetTop(e,y-4);
        }

        public override List<Einzeller> Teilen()
        {
            List<Einzeller> töchter = new List<Einzeller>();
            if (rnd.NextDouble() < 0.02)
            {
                töchter.Add( new Amöbe(this)); 
            }
            return töchter;            
        }

        public override List<Einzeller> Die()
        {
            List<Einzeller> kranke = new List<Einzeller>();
            if (rnd.NextDouble() < 0.01)
            {
                kranke.Add(this);
            }
            return kranke;
        }
    }

    class Bakterie : Einzeller
    {
        public Bakterie() { }
        public Bakterie(Bakterie b) : base(b) 
        {
        }
        public override void Draw(Canvas petrischale)
        {
            Ellipse e = new Ellipse();
            e.Width = 4;
            e.Height = 4;
            e.Fill = Brushes.Green;
            petrischale.Children.Add(e);
            Canvas.SetLeft(e, x - 2);
            Canvas.SetTop(e, y - 2);
        }

        public override List<Einzeller> Teilen()
        {
            List<Einzeller> töchter = new List<Einzeller>();
            if (rnd.NextDouble() < 0.02)
            {
                töchter.Add(new Bakterie(this));
            }
            return töchter;
        }

        public override List<Einzeller> Die()
        {
            List<Einzeller> kranke = new List<Einzeller>();
            if (rnd.NextDouble() < 0.01)
            {
                kranke.Add(this);
            }
            return kranke;
        }
    }
}
