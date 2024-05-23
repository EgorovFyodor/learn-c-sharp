namespace inheritance_01
{
    internal class Program
    {
        /*public sealed class Tutor : Human
        {

        }
        public sealed class TutorSon : Tutor //Наследование невозможно sealed блокирует*/
        public class Human
        {
            string _firstName { get; set; }
            string _lastName { get; set; }
            DateTime _birthDate { get; set; }

            public Human() {}
            /* Пример 1
            public Human(string fName, string lName) { 
                _firstName = fName;
                _lastName = lName;
            }

            public Human(string fName, string lName, DateTime date)
            {
                _firstName = fName;
                _lastName = lName;
                _birthDate = date;
            }*/
            public virtual void Show()
            {
                Console.WriteLine($"\nФамилия : {_lastName}\nИмя: {_firstName}\nДата рождения: {_birthDate.ToShortDateString()}");
            }

            // setters
            public void SetFirstName(string value) { _firstName = value; }
            public void SetLastName(string value) { _lastName = value; }
            public void SetBirthDate(DateTime value) { _birthDate = value; }
        }

        public class Employee : Human
        {
            double _salary { get; set; }
            string _citizenship { get; set; } // new element
            public Employee() {}
            /* Пример 1
            public Employee(string fName, string lName) : base(fName, lName) { }
            public Employee(string fName, string lName, double salary) : base(fName, lName) { _salary = salary; }
            public Employee(string fName, string lName, DateTime date,double salary) : base(fName, lName, date) { _salary = salary; }
            */
            public void Show()
            {
                base.Show();
                Console.WriteLine($"Заработная плата {_salary} $\nГражданство {_citizenship}");
            }


            // setters
            public void SetSalary(double value) { _salary = value; }
            public void SetCitizenship(string value) { _citizenship = value; }

        }

        public class EmployeeBuilder
        {
            Employee employee = new Employee();

            public EmployeeBuilder SetFirstName(string name)
            {
                employee.SetFirstName(name);
                return this;
            }
            public EmployeeBuilder SetLastName(string lname)
            {
                employee.SetLastName(lname);
                return this;
            }
            public EmployeeBuilder SetBirthDate(DateTime date)
            {
                employee.SetBirthDate(date);
                return this;
            }
            public EmployeeBuilder SetSalary(double salary)
            {
                employee.SetSalary(salary);
                return this;
            }
            public EmployeeBuilder SetCitizenship(string citizenship)
            {
                employee.SetCitizenship(citizenship);
                return this;
            }
            public Employee build() { return employee; }
        }

        public class Scientist : Employee { 
            public void ShowScientist()
            {
                Console.WriteLine("I am a scientist");
            }
        }
        public class Manager : Employee {
            public void ShowManager()
            {
                Console.WriteLine("I am a manager");
            }
        }
        public class Specialist : Employee {
            public void ShowSpecialist()
            {
                Console.WriteLine("I am a specialist");
            }
        }

        static void Main(string[] args)
        {
            /* Пример 1
            Employee employee = new Employee("John", "Doe");
            employee.Show();
            employee = new Employee("Jim", "Beam", 1256);
            employee.Show();
            employee = new Employee("Tom", "ea", DateTime.Now, 186);
            employee.Show();*/

            Employee employee = new EmployeeBuilder().
                SetFirstName("Jack").
                SetLastName("Smith").
                SetBirthDate(DateTime.Now).
                SetSalary(235.5).
                SetCitizenship("Russia").
                build();

            //employee.Show();

            Employee snt = new Scientist();
            Employee m = new Manager();
            Employee sp = new Specialist();

            Employee[] employees = new Employee[3] { m, sp, snt };

            foreach (Employee empl in employees) {
                empl.Show();

                try
                {
                    ((Scientist)empl).ShowScientist();
                }
                catch
                {
                }

                Manager e = empl as Manager;
                if (e != null) { e.ShowManager(); }

                if (empl is Specialist)
                {
                    (empl as Specialist).ShowSpecialist();
                }
            }
        }
    }
}
