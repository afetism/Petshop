using CatHouses.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHouses.Helpers
{
    internal static class CatMethods
    {

        public static void addCat(CatHouse catHouse)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Nickname of Cat: ");
                    string? nickName = Console.ReadLine();
                    Console.Write("Enter Age of Cat: ");
                    string? inputAge = Console.ReadLine();
                    Console.Write("Enter Gender of Cat: ");
                    string? inputGender = Console.ReadLine();
                    Console.Write("Enter Price of Cat: ");
                    string? inputPrice = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nickName)) throw new InvalidDataException("Data is invalid");
                    Cat newCat = new(nickName!, ConvertData.getInt(inputAge!), ConvertData.getBool(inputGender!), ConvertData.getInt(inputPrice!));
                    catHouse.AddCat(newCat);
                    break;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public static void AddPetShop(PetShop _)
        {
            try
            {
                AddPetShop:
                Console.Write("Enter New Cat House Name: ");
                string? NewCatHouse = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(NewCatHouse))
                {
                    CatHouse catHouseNo = new(NewCatHouse);
                    _.AddCatHouse(catHouseNo); 
                }
                else goto AddPetShop; 


            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

       public static void deleteCat(CatHouse catHouse)
        {
            DeleteCat:
            Console.WriteLine("Enter Nickname of Cat");
            string? nickName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nickName))
            {
                Console.WriteLine("No exists Cat");
                goto DeleteCat;
            }
            catHouse.RemoveCat(nickName);
        }




    }
}
