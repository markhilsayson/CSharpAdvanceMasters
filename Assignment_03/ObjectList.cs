using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03
{
    public class ObjectList
    {
        private List<int> listInt;
        private List<string> listString;
        private List<double> listDouble;
        private List<bool> listBool;
        private ArrayList arrayList;

        public ObjectList()
        {
            listInt = new List<int>();
            listString = new List<string>();
            listDouble=new List<double>();
            listBool=new List<bool>();
            arrayList = new ArrayList();
        }
        public void Add(string input) {
            if (int.TryParse(input, out int intValue))
                listInt.Add(intValue);
            else if (double.TryParse(input, out double doubleValue))
                listDouble.Add(doubleValue);
            else if (bool.TryParse(input, out bool boolValue))
                listBool.Add(boolValue);
            else listString.Add(input);

            arrayList.Add(input);
        }

        private List<int> GetListInts() => listInt;
        private List<double> GetListDoubles() => listDouble;
        private List<bool> GetListBools() => listBool;
        private List<string> GetListStrings() => listString;
        public ArrayList GetListArrays() => arrayList;

        public void Display(EnumType selection) {
            switch (selection) {
                case EnumType.IntList:
                    PrintGeneric(GetListInts()); break;
                case EnumType.DoubleList:
                    PrintGeneric(GetListDoubles()); break;
                case EnumType.BoolList:
                    PrintGeneric(GetListBools()); break;
                case EnumType.StringList:
                    PrintGeneric(GetListStrings()); break;
                default:
                    PrintNonGeneric(GetListArrays());
                    break;
            }
        }

        public void PrintGeneric<T>(List<T> lists) {
            if (lists.Count == 0) Console.WriteLine("No data found.");
            else Console.WriteLine(lists[0].GetType().Name+" Generic Lists");
            foreach (var item in lists) { 
                if(item!=null)Console.WriteLine(item);
            }
        }

        public void PrintNonGeneric(ArrayList arrayList) {
            Console.WriteLine("Non Generic List");
            foreach (var item in arrayList) {
                if (item != null) Console.WriteLine(item);
            }
        }

    }
}
