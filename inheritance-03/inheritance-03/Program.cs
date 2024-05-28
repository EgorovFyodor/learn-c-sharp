using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace inheritance_03
{
    internal class Program
    {
        public abstract class Animal
        {
            protected string _name;
            protected string _characteristic;
            //public abstract void Think();

            public Animal(string name, string characteristic) 
            { 
                _name = name;
                _characteristic = characteristic;
            }

            public abstract void Show();
        }
        class Tiger : Animal
        {
            public Tiger(string name, string characteristic) : base(name, characteristic) {}
            public override void Show() {
                Console.WriteLine($"Tiger:\nName - {_name}\nCharacteristic - {_characteristic}\n");
            }
        }
        class Kangaroo : Animal
        {
            public Kangaroo(string name, string characteristic) : base(name, characteristic) { }
            public override void Show()
            {
                Console.WriteLine($"Kangaroo:\nName - {_name}\nCharacteristic - {_characteristic}\n");
            }
        }
        class Crocodile : Animal
        {
            public Crocodile(string name, string characteristic) : base(name, characteristic) { }
            public override void Show()
            {
                Console.WriteLine($"Crocodile:\nName - {_name}\nCharacteristic - {_characteristic}\n");
            }
        }
        static void Main(string[] args)
        {
            Animal animal_1 = new Tiger("Tigra", "А tiger can break a tree with a diameter of 20 cm, and with its fangs it can bite through a sheet of iron 5 mm thick.");
            Animal animal_2 = new Kangaroo("Kenga", "Kangaroo is a special bag for carrying small children.");
            Animal animal_3 = new Crocodile("Crocushka", "They have excellent senses of smell, vision and hearing, and they also have pressure receptors that allow them to feel vibrations in the water.");

            animal_1.Show();
            animal_2.Show();
            animal_3.Show();
        }
    }
}
