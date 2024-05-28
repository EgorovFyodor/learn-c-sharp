namespace inheritance_04
{
    internal class Program
    {
        public abstract class Figure
        {
            public abstract void Area();
            public abstract void Set(List<double> l);
        }
        class Rectangle : Figure
        {
            double _x;
            double _y;

            public Rectangle() { }
            public Rectangle(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public override void Set(List<double> l)
            {
                _x = l[0];
                _y = l[1];
            }
            public override void Area()
            {
                Console.WriteLine($"Rectangle area = {_x * _y}");
            }
        }
        class Circle : Figure
        {
            double _r;

            public Circle() { }
            public Circle(double r)
            {
                _r = r;
            }

            public override void Set(List<double> l)
            {
                _r = l[0];
            }
            public override void Area()
            {
                Console.WriteLine($"Circle area = {_r * _r * 3.14}");
            }
        }

        class Rectangular_triangle : Figure
        {
            double _x;
            double _y;

            public Rectangular_triangle() { }
            public Rectangular_triangle(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public override void Set(List<double> l)
            {
                _x = l[0];
                _y = l[1];
            }
            public override void Area()
            {
                Console.WriteLine($"Rectangular_triangle area = {_x * _y / 2}");
            }
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            Figure[] arr = new Figure[10];
            Figure[] choice = [new Rectangle(), new Circle(), new Rectangular_triangle()];
            for (int i = 0; i < 10; i++)
            {
                List<double> l = [];
                l.Add(r.Next(1, 10));
                l.Add(r.Next(1, 10));
                Figure obj = choice[r.Next(0, 3)];
                obj.Set(l);
                arr[i] = obj;
            }
            for (int i = 0;i < 10; i++) {
                arr[i].Area();
            }
        }
    }
}
