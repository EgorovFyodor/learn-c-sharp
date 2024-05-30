namespace interface_03
{
    internal class Program
    {
        interface IPlant
        {
            int timeOfGrow {  get; set; }

            public void Grow();
        }

        class Potato : IPlant
        {
            public int timeOfGrow {  get; set; }
            public void Grow()
            {
                Console.WriteLine("growing");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
