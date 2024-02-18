using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHouses.Helpers
{
    internal static class ConvertData
    {
      public static int getInt(string input)
        {
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            else
                throw new InvalidDataException("Data is Invalid");

        }

      public static bool getBool(string input)
       {
            if (bool.TryParse(input, out bool value))
            {
                return value;
            }
            else
                throw new InvalidDataException("Data is Invalid");
       }
    }
}
