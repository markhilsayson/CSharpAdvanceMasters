using System.Reflection;

namespace Assignment_02
{
    public class AnimalZoo
    {
        private Assembly assembly;
        private Type[] _allClasses;

        public AnimalZoo()
        {
            assembly = Assembly.LoadFrom("Pets.dll");
            _allClasses= assembly.GetExportedTypes();
        }

        public void Run()
        {
            do
            {
                Console.WriteLine("Select a pet");
                AllClasses classes = new(_allClasses);
                classes.Print();

                Console.Write("Select Type: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                AnimalType animalType = new AnimalType(ReadInput(input), assembly);
                animalType.ShowClassName();
                animalType.ShowProperties();
                animalType.ShowAbilities();

                Console.Write("Ability: ");
                int selectedInputAbility = int.Parse(Console.ReadLine());
                animalType.PerformAbility(selectedInputAbility);
                
                Console.Write("Do you want to continue? Y/y or N/n: ");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Console.WriteLine();
                    continue;
                }
                else
                    break;

            } while (true);

            Console.WriteLine("Thank You!");
            Console.ReadKey();
        }

        /*Pattern matching*/
        private AnimalEnum ReadInput(int input) => (input) switch
        {
            1 => AnimalEnum.Bird,
            2 => AnimalEnum.Cat,
            3 => AnimalEnum.Dog,
            4 => AnimalEnum.Fish
        };
    }

    /* record */
    public record AllClasses(Type[] classess)
    {
        public Type[] allClasses { get => classess; }

        public void Print()
        {
            int number = 1;
            foreach (var t in allClasses)
            {
                Console.WriteLine(number + ") " + t.Name);
                number++;
            }
        }
    }
}
