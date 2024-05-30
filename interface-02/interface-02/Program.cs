namespace interface_02
{
    internal class Program
    {
        interface IIndexer
        {
            string this[int index] { get; set; }

            string this[string index] { get; }

        }
        enum Numbers { one, two, three, four, five }

        class IndexerClass : IIndexer
        {
            string[] _names = new string[5];

            public string this[int index] { 
                get { return _names[index]; } 
                set { _names[index] = value;}
            }

            public string this[string index]
            {
                get
                {
                    if (Enum.IsDefined(typeof(Numbers), index))
                        return _names[(int)Enum.Parse(typeof(Numbers), index)];
                    else
                        return "";
                }
            }
            public IndexerClass()
            {
                this[0] = "Bob";
                this[1] = "Candice";
                this[2] = "Jimmy";
                this[3] = "Joey";
                this[4] = "Nicole";
            }
        }
        static void Main(string[] args)
        {
            IndexerClass indexerClass = new IndexerClass();

            Console.WriteLine("\t\tВывод значений\n");
            Console.WriteLine("Использование индексатора с целочисленным параметром:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(indexerClass[i]);
            }

            Console.WriteLine("\nИспользование индексатора со строковым папаметром:");

            foreach (string item in Enum.GetNames(typeof(Numbers)))
            {
                Console.WriteLine(indexerClass[item]);
            }
        }
    }
}
