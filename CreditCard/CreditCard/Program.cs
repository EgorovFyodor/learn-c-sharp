
/*Ранее в одном из практических заданий вы создавали класс "Дебетовая карточка". 
 * Добавьте к уже созданному кдассу информацию о сумме денег на карте. 
 * Выполните перегрузку о сумме денег на карте. выполните перегрузку +, -. == (проверка на равенство cvc кода),
 * > и <, != и Equals, используйте механизм свойств для полей класса.*/

using System.Collections.Specialized;

namespace CreditCard
{

    internal class Program
    {
        class DebitCard(int c, int n, double a)
        {
            int cvv = c;
            int number = n;
            double amount = a;

            public double GetAmount() { return amount; }
            public int GetCVV() { return cvv; }

            public void SetAmount(double num) {  amount += num; }

            public static DebitCard operator +(DebitCard dc, double number)
            {
                dc.SetAmount(number);
                return dc;
            }
            public static DebitCard operator -(DebitCard dc, double number)
            {
                dc.SetAmount(-number);
                return dc;
            }

            public static bool operator ==(DebitCard dc1, DebitCard dc2)
            {
                return dc1.GetCVV() == dc2.GetCVV();
            }

            public static bool operator !=(DebitCard dc1, DebitCard dc2)
            {
                return dc1.GetCVV() != dc2.GetCVV();
            }

            public static bool operator <(DebitCard dc1, DebitCard dc2)
            {
                return dc1.GetAmount() < dc2.GetAmount();
            }
            public static bool operator >(DebitCard dc1, DebitCard dc2)
            {
                return dc1.GetAmount() > dc2.GetAmount();
            }
            /*public override bool Equals(DebitCard dc1, DebitCard dc2)
            {
                return dc1.Equals(dc2);
            }*/
        }



        static void Main(string[] args)
        {
            DebitCard debit1 = new DebitCard(123, 54235432, 45.7), debit2 = new DebitCard(123, 5676432, 100), debit3 = new DebitCard(323, 5676432, 150);

            debit1 = debit1 + 132;
            Console.WriteLine(debit1.GetAmount());
            debit2 = debit1 - 200;
            Console.WriteLine(debit2.GetAmount());

            if (debit1 == debit2)
            {
                Console.WriteLine("==");
            }
            else
            {
                Console.WriteLine("!=");
            }

            if (debit1 != debit2) { }
        }
    }
    
}
