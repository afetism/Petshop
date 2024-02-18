using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHouses.Moduls
{
    internal class Cat
    {
        public Cat(string nickName, int age, bool gender, int price)
        {
            NickName=nickName;
            Age=age;
            Gender=gender;
            Price=price;
        }

        public  string NickName { get; set; }
        public int Age { get; set; }
        bool Gender { get; set; }
        public int Price {  get; set; }
        public int MealQuality { get; set; } = 0;
        public int Energy { get; set; } = 100;

        public void Eat()
        {
            if (Energy==100) Console.WriteLine("Cat is Full");
            else
            {
                Energy++;
                Console.WriteLine("Cat Eating...");
            } 
                    
        }
        public void Sleep()
        {
            if (Energy==100) Console.WriteLine("Cat is not sleeply");
            else
            {
                while (Energy<=100 && !Console.KeyAvailable)
                {
                    Console.Clear();
                    Console.WriteLine($" Energy: {Energy}  Cat sleeping...");
                    Thread.Sleep(1000);
                    Energy+=5;
                    Console.WriteLine("Press any key to wake up the cat...");


                }
                

            }

        }

        public void Play()
        {
            if (Energy==0) Console.WriteLine("Cat is sleeply");
            else
            {
                Energy-=10;
                Console.WriteLine("Cat playing...");

            }

        }
        public override string ToString()
        {
           
            return $"Nickname: {NickName} Age: {Age} Gender: {Gender} Price: {Price} MealQuality: {MealQuality} Energy: {Energy} ";
        }

        public  string getName()
        {
            return NickName;
        }




    }
}
