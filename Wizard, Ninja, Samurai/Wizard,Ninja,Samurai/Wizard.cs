using System;

namespace Wizard_Ninja_Samurai
{
    public class Wizard : Human
    {
        public Wizard(string a) : base(a)
        {
            health = 50;
            intelligence = 25;
        }
        public void heal()
        {
            health += 10 * intelligence;
        }
        public void Fireball(object obj)
        {
            Random rand = new Random();
            Human enemy = obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= rand.Next(25, 501);
            }
        }
    }
}