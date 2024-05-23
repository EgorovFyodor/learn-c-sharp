namespace inheritance_01
{
    internal class Program
    {
        public abstract class Human
        {
            string _firstName;
            string _lastName;
            DateTime _birthDate;

            public abstract void Think();

            //public Human(string firstName, string lastName)
            //{
            //    _firstName = firstName;
            //    _lastName = lastName;
            //}
            public Human(string firstName, string lastName, DateTime birthDate)
            {
                _firstName = firstName;
                _lastName = lastName;
                _birthDate = birthDate;
            }
            public virtual void Show()
            {
                Console.WriteLine($"\n\nLastName: {_lastName}\nName: {_firstName}\nBirthDate: {_birthDate}");
            }

            public void SetFirstName(string firstName) { _firstName = firstName; }
            public void SetLastName(string lastName) { _lastName = lastName; }
            public void SetBirthDate(DateTime dateTime) { _birthDate = dateTime; }
        }
        public abstract class Learner : Human
        {
            string _institution;

            protected Learner(string firstName, string lastName, DateTime birthDate, string institution) : base(firstName, lastName, birthDate)
            {
                _institution = institution;
            }
            public abstract void Study();
            public override void Show()
            {
                base.Show();
                Console.WriteLine($"Institution: {_institution}");
            }

        }
        class Student : Learner
        {
            string _groupname;
            public Student(string firstName, string lastName, DateTime birthDate, string institution, string groupname) : base(firstName, lastName, birthDate, institution)
            {
                _groupname = groupname;
            }
            public override void Show()
            {
                base.Show();
                Console.WriteLine($"I study at {_groupname} group");
            }
            public override void Study()
            {
                Console.WriteLine("*student sound*");
            }
            public override void Think()
            {
                Console.WriteLine("student thoughts");
            }
        }

        class Pupil : Learner
        {
            string _classname;
            public Pupil(string firstName, string lastName, DateTime birthDate, string institution, string classname) : base(firstName, lastName, birthDate, institution)
            {
                _classname = classname;
            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"I study at {_classname} class");
            }

            public override void Study()
            {
                Console.WriteLine("*pupil sound*");
            }
            public override void Think()
            {
                Console.WriteLine("pupil thoughts");
            }
        }



        static void Main(string[] args)
        {
            Learner[] learners = { new Student("Alex", "Star", DateTime.Now, "CHGU", "P21"), new Pupil("Max", "Old", DateTime.Now, "MAOU SOSH№22", "10B") };
            foreach (Learner learner in learners)
            {
                learner.Show();
                learner.Think();
                learner.Study();
            }
        }
    }
}
