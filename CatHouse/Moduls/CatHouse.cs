using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CatHouses.Moduls
{
    internal class CatHouse
    {
        
        
        public CatHouse(string name)
        {
            Cats=new();
            Name=name;
        }

       public List<Cat> Cats { get; init; }
       private string Name { get ; set; }

       public void AddCat(Cat newCat)
        {
            if (newCat == null) throw new ArgumentNullException();
            Cats.Add(newCat);   
        }

       public void RemoveCat(string nickName) { 

            if(string.IsNullOrEmpty(nickName)) throw new ArgumentNullException("Value can not be emppty");
            List<Cat> removeCat=new();
            foreach(var cat in Cats) { 
               if(cat == null) continue;
               if(cat.NickName == nickName)
                {
                    removeCat.Add(cat);

                }

            }
            foreach(var cat in removeCat) {
                Cats.Remove(cat);
                
            }


       }

        public void ShowCat()
        {
            if(!Cats.Any())  Console.WriteLine("There is no cat "); 
            foreach(var cat in Cats)
            {
               
                Console.WriteLine(cat.ToString());
            }
        }
        public string[] getStringCats()
        {
            StringBuilder sb = new();
            foreach (var cat in Cats)
            {
                sb.Append(cat.getName());
                sb.Append("\n");
            }
            sb.Append("Add Cat   \n");
            sb.Append("Delete Cat\n");
            sb.Append("Show Cats \n");
            sb.Append("Exit      ");
            return sb.ToString().Split('\n');

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
