// See https://aka.ms/new-console-template for more information
using CatHouses.Moduls;
using CatHouses.Helpers;
string[] catMethods(string CatNickName)
{
    Console.WriteLine(CatNickName);
    string[] _ = {"Eat  ", "Sleep", "Play ", "Exit " };
    return _;
}

CatHouse catHouseNo1 = new("Cat House1");
CatHouse catHouseNo2 = new("Cat House2");

catHouseNo1.AddCat(new("Mestan", 3, false, 102));
catHouseNo1.AddCat(new("Limon", 1, true, 130));
catHouseNo2.AddCat(new("Şükufe", 12, true, 50));
catHouseNo2.AddCat(new("Tarzan", 4, true, 95));

PetShop petShop = new();

petShop.AddCatHouse(catHouseNo1);
petShop.AddCatHouse(catHouseNo2);

string[] getMenu(int choose)
{
    foreach (var i in petShop.CatHouses)
    {

        if (i==petShop.CatHouses[choose])
            return i.getStringCats();

    }
    throw new Exception("Proqram cokdu");
}


void CatHouseMenu(int choose, string[] CatHouseItem)
{
    
    for (int i = 0; i < CatHouseItem.Length; i++)
    {
        if (choose ==i)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(CatHouseItem[i]);
            Console.BackgroundColor= ConsoleColor.Black;

        }
        else Console.WriteLine(CatHouseItem[i]);
    }
}

void PetshopMenu(int choose)
{
    string[] _ = petShop.GetStringArray();
   for(int i = 0;i<petShop.GetStringArray().Length;i++)
   {
        if(choose == i)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(_[i]);
            Console.BackgroundColor= ConsoleColor.Black;

        }
        else Console.WriteLine(_[i]);
   }


}
bool moveInMenu(ref int choose, out int size, ConsoleKeyInfo key, string[] _)
{

    size=_.Length;
    if (key.Key==ConsoleKey.DownArrow)
    {
        if (choose < size-1)
            choose++;
        else choose =0;
    }
    else if (key.Key==ConsoleKey.UpArrow)
    {
        if (choose>0)
            choose--;
        else choose =size-1;
    }
    else if (key.Key == ConsoleKey.Enter)
    {
        return false;
    }
    return true;
}

void manageCatMethod(Cat cat)
{
    int choose = 0;
    CatHouseMenu(choose, catMethods(cat.NickName));
    while(true)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.Clear();
        bool _ = moveInMenu(ref choose, out int size, key, catMethods(cat.NickName));
        if (_)
            CatHouseMenu(choose, catMethods(cat.NickName));
        else
        {
            if (choose==0)
                cat.Eat();
            else if (choose==1)
                cat.Sleep();
            else if (choose==2)
                cat.Play();
            else
                return;
        }
    }

}


void manageCatHouse(CatHouse catHouse,int count)
{
    CatHouse:
    int choose =0;
    string[] CatHouseItem = getMenu(count);
    CatHouseMenu(choose, CatHouseItem);
    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.Clear();
        bool _ = moveInMenu(ref choose,out int size, key, CatHouseItem);
        if (_)
            CatHouseMenu(choose,CatHouseItem);
        else
        {
            if (choose == catHouse.Cats.Count)
            {
                CatMethods.addCat(catHouse);

            }
            else if (choose ==catHouse.Cats.Count+2)
            {
                catHouse.ShowCat();
            }
            else if (choose == catHouse.Cats.Count+1)
                CatMethods.deleteCat(catHouse);
            else if (choose ==catHouse.Cats.Count + 3)
                return;
            else
            {
                for(int i = 0; i <catHouse.Cats.Count;i++)
                {
                    if(i==choose)
                    {
                        manageCatMethod(catHouse.Cats[i]);
                        goto CatHouse;
                    }
                }
            }
        }
    }

}

void managePetshop()
{
    PetShop:
    int choose =0;
    
    Console.WriteLine(@$"
      <---------- Welcome to Petshop------------>");
    PetshopMenu(choose);
   

    while (true)
    {

        ConsoleKeyInfo key = Console.ReadKey();
        Console.Clear();
        bool _ = moveInMenu(ref choose, out int size, key, petShop.GetStringArray());
        if (_)
        {
            Console.WriteLine(@$"
      <---------- Welcome to Petshop------------>");
            PetshopMenu(choose);

        }
        else
        {



            if (choose == petShop.GetStringArray().Length-2)
                CatMethods.AddPetShop(petShop);
            else if (choose == petShop.GetStringArray().Length-1) Environment.Exit(0);
            else
            {

                foreach (var i in petShop.CatHouses)
                {

                    if (i==petShop.CatHouses[choose])
                    {
                        manageCatHouse(petShop.CatHouses[choose], choose);

                    }
                }

            }

            goto PetShop;
            


        }
    }
}
managePetshop();


