namespace Assignment_03
{
    public class CollectData
    {
        private Dictionary<int, EnumType> _dict;
        public CollectData()
        {
            _dict = new Dictionary<int, EnumType>();
            _dict.Add(0, EnumType.IntList);
            _dict.Add(1, EnumType.DoubleList);
            _dict.Add(2, EnumType.BoolList);
            _dict.Add(3, EnumType.StringList);
            _dict.Add(4, EnumType.NonGenericList);
        }
        public void Run() {
            ObjectList objectList = new ObjectList();
            string input = "";
            do {
                EnumType selection;

                Console.Write("Type anything here: ");
                input= Console.ReadLine();
                objectList.Add(input);

                Console.Write("Do you want to continue adding more items to the lists? Y/y or N/n: ");
                input=Console.ReadLine();
                if (input.ToLower() == "y") continue;

                Console.Write("Do you want to view the lists? Y/y or N/n: ");
                input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    ViewInstruction();
                    do
                    {
                        Console.Write("Please input code here: ");
                        int outputToDisplay = int.Parse(Console.ReadLine());

                        if (_dict.ContainsKey(outputToDisplay))
                        {
                            _dict.TryGetValue(outputToDisplay, out selection);
                            objectList.Display(selection);

                            Console.WriteLine("Do you want to continue viewing to the lists? Y/y or N/n: ");
                            input = Console.ReadLine();
                            if (input.ToLower() == "y") continue;
                            else break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Code.");
                            continue;
                        }

                    } while (true);
                }
                else break;
                
            } while (true);
        }

        public void ViewInstruction() {
            Console.WriteLine("/***********************************************/");
            Console.WriteLine("To view different types of lists available, please select the code that corresponds to the type of list below.");
            Console.WriteLine("0 - Int List");
            Console.WriteLine("1 - Double List");
            Console.WriteLine("2 - Bool List");
            Console.WriteLine("3 - String List");
            Console.WriteLine("4 - Non Generic List");
            Console.WriteLine("/***********************************************/");

        }
    }

    public enum EnumType { 
        IntList,
        DoubleList,
        BoolList,
        StringList,
        NonGenericList
    }
}
