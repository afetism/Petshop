using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHouses.Moduls
{
    internal class PetShop
    {
        public PetShop()
        {
            CatHouses=new();

        }

        public List<CatHouse> CatHouses { get; init; }

        public void AddCatHouse(CatHouse house)
        {
            if (house is null)
            {
                throw new ArgumentNullException(nameof(house));
            }


            CatHouses.Add(house);

        }

        public void ShowCatHouses()
        {
            foreach (var house in CatHouses)
            {
                Console.WriteLine(house.ToString());
            }
        }
        public string[] GetStringArray()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var house in CatHouses)
            {
                sb.Append(house.ToString());
                sb.Append("\n");
            }
            sb.Append("Add CatHouse\n");
            sb.Append("Exit");
            return sb.ToString().Split("\n");

        }


    }
   
}
