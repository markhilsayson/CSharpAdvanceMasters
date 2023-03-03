using System.Reflection;

namespace Assignment_02
{
    public class AnimalType
    {
        public AnimalEnum _animalType { get; set; }
        private Assembly _petsAssembly;
        private object _animalInstance;
        Dictionary<int, string> _abilities;
        public Type _t { get; set; }

        public AnimalType(AnimalEnum animalType, Assembly assembly)
        {
            _petsAssembly = assembly;
            _animalType = animalType;
            _t = _petsAssembly.GetType("Pets." + animalType);

            /*Tuple and Pattern Matching*/
            var tuple = (GetName(animalType), GetAge(animalType));
            _animalInstance = Activator.CreateInstance(_t,tuple.Item1 ,tuple.Item2 );
            _abilities= new Dictionary<int, string>();
        }

        public void ShowAbilities()
        {
            Console.WriteLine("Abilities");
            MethodInfo[] allMethods = _t.GetMethods();
            int ctr = 1;
            foreach (MethodInfo method in allMethods.Where(m => !typeof(object)
                                     .GetMethods()
                                     .Select(me => me.Name)
                                     .Contains(m.Name) && !m.IsSpecialName))
            {
                Console.WriteLine(ctr + ") " + method.Name);
                _abilities.Add(ctr, method.Name);
                ctr++;
            }
        }
        public void ShowProperties() {

            PropertyInfo[] propInfo = _t.GetProperties();
            foreach (PropertyInfo prop in propInfo)
            {
                Console.WriteLine(prop.Name + ": " + prop.GetValue(_animalInstance));
            }
        }

        public void ShowClassName() {
            Console.WriteLine("Class: " + _animalInstance.GetType().Name);
        }

        public void PerformAbility(int selectedAbility) {
            if (_abilities.ContainsKey(selectedAbility))
            {
                MethodInfo talkMethodInfo = _t.GetMethod(_abilities.FirstOrDefault(p => p.Key == selectedAbility).Value);
                talkMethodInfo.Invoke(_animalInstance, null);
            }
            else
            {
                Console.WriteLine("Ability is not found.");
            }
            Console.WriteLine();
        }


        /* Pattern Matching */
        private string GetName(AnimalEnum animal) => (animal) switch
        {
            AnimalEnum.Bird => "Tweety Bird",
            AnimalEnum.Fish => "Grander Musashi",
            AnimalEnum.Dog => "Bogart",
            AnimalEnum.Cat => "Pussy cat"
        };
        private int GetAge(AnimalEnum animal) => (animal) switch
        {
            AnimalEnum.Bird => 4,
            AnimalEnum.Fish => 5,
            AnimalEnum.Dog => 3,
            AnimalEnum.Cat => 6
        };

        /*Attribute*/
        [Obsolete]
        private string GetName(int selectedAnimal) {
            string selection = string.Empty;
            switch (selectedAnimal) {
                case 0: selection = "Tweety Bird";
                    break;
                case 1:
                    selection = "Grander Musashi";
                    break;
                case 2:
                    selection = "Bogart";
                    break;
                case 3:
                    selection = "Pussy cat";
                    break;
            }
            return selection;
        }

        
    }
}
