namespace interface_01
{
    internal class Program
    {
        abstract class Human
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public override string ToString()
            {
                return $"\nФамилия: {LastName} Имя: {FirstName} Дата рождения: {BirthDate.ToLongDateString()}";
            }
        }
        abstract class Employee : Human
        {
            public string Position { get; set; }
            public double Salary { get; set; }

            public override string ToString()
            {
                return base.ToString() + $"\nДожность: {Position} Заработная плата: {Salary} $";
            }
        }
        class Director : Employee, IManager
        {
            public List<IWorker> ListOfWorker { get; set; }

            public void Control()
            {
                Console.WriteLine("Контролирую работу!");
            }
            public void MakeBudget()
            {
                Console.WriteLine("Формирую бюджет!");
            }
            public void Organize()
            {
                Console.WriteLine("Организую работу!");
            }
        }
        class Seller : Employee, IWorker
        {
            bool isWorking = true;
            public bool IsWorking
            {
                get
                {
                    return isWorking;
                }
            }
            public string Work()
            {
                return "Продаю товар!";
            }
        }
        class Cashier : Employee, IWorker
        {
            bool isWorking = true;
            public bool IsWorking
            {
                get
                {
                    return isWorking;
                }
            }
            public string Work()
            {
                return "Принимаю оплату за товар!";
            }
        }
        class Storekeeper : Employee, IWorker
        {
            bool isWorking = true;
            public bool IsWorking
            {
                get
                {
                    return isWorking;
                }
            }
            public string Work()
            {
                return "Учитываю товар!";
            }
        }
        public interface IWorker
        {
            //event EventHandler WorkEnded;
            bool IsWorking { get; }
            string Work();
        }
        interface IManager 
        { 
            List<IWorker> ListOfWorker { get; set; }
            void Organize();
            void MakeBudget();
            void Control();
        }

        static void Main(string[] args)
        {
            Director director = new Director
            {
                LastName = "Doe",
                FirstName = "John",
                BirthDate = new DateTime(1996, 5, 26),
                Position = "Директор", Salary = 37080
            };
            IWorker seller = new Seller
            {
                LastName = "Beam",
                FirstName = "Jim",
                BirthDate = new DateTime(1956, 4, 6),
                Position = "Продавец",
                Salary = 380
            };

            if (seller is Employee)
            {
                Console.WriteLine($"Заработная плата продавца: {(seller as Employee).Salary}");
            }
            director.ListOfWorker = new List<IWorker>
            {
                seller, 
                new Cashier
                {
                    LastName = "Smith",
                    FirstName = "Nicole",
                    BirthDate = new DateTime(1956, 5, 23),
                    Position = "Кассир",
                    Salary = 3780
                },
                new Storekeeper
                {
                    LastName = "Ross",
                    FirstName = "Bob",
                    BirthDate = new DateTime(1956, 5, 13),
                    Position = "Кладовщик",
                    Salary = 4500
                }
            };
            Console.WriteLine(director);
            if (director is IManager) 
            {
                director.Control();
            }

            foreach (IWorker item in director.ListOfWorker)
            {
                Console.WriteLine(item);

                if (item.IsWorking) 
                { 
                    Console.WriteLine(item.Work());
                }
            }
        }
    }
}
