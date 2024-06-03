using System;


class Rogue
{
    public string name;
    public string bow;
    public string knife;
    public int arrows;
    public float exp;
  
    public Rogue(string _name,string _bow,string _knife)
    {
        name = _name;
        bow = _bow;
        knife = _knife;
        arrows = 3;
        exp = 0f;
    }

    public void shoot_bow()
    {
        if (arrows > 0)
        {
            arrows --;
            exp += 0.3f;
            Console.WriteLine(name + " shoots an arrow from " + bow +"\n" +arrows + " Arrows are left");
        } else
        {
            Console.WriteLine(name + " is out of arrows");
        }
        
    }
    public void find_arrows()
    {
        arrows ++;
        Console.WriteLine(name + " gathers an arrow " +name + " now has " +arrows+ " arrows");
    }
    public void much_exp()
    {
        Console.WriteLine("\n" +name+ " now has " +exp+ "exp");
    }
}


class Goblin
{
    public string name;
    public int health;

    public Goblin(string _name,int _health)
    {
        name = _name;
        health = _health;
    }
    public void take_damage()
    {
        health --;
        Console.WriteLine(name + " now has " + health + " Health left");
    }
    public void defeated()
    {Console.WriteLine(name+ " is defeated");}
}

class Program
{
    static void Main(string[] args)
    {
        Rogue rogue01 = new Rogue("Dusk", "LongShot", "Cracked knife");
        Goblin goblin01 = new Goblin("Lesser Goblin", 3);
        bool game_active = true;
        Console.WriteLine("You ecounter " +goblin01);
        while (game_active == true)
        {
            Console.WriteLine("What is your next action?");
            Console.WriteLine("Actions: \n1. shoot bow\n2. find arrows");
            int player_input = Convert.ToInt32(Console.ReadLine());
            if (player_input == 1)
            {
                if (goblin01.health > 1)
                {
                    rogue01.shoot_bow();
                    goblin01.take_damage();
                    
                }else 
                {
                    goblin01.defeated();
                }
            } else if (player_input == 2)
            {
                rogue01.find_arrows();
            } else
            {
                rogue01.much_exp();
            }


        }     
    }    

    
}
