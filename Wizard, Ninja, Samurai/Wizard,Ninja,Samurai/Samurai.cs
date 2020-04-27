using System;

namespace Wizard_Ninja_Samurai
{
    public class Samurai : Human
    {
        public Samurai(string a) : base(a)
        {
            health = 200;
        }
        public void death_blow(object obj)
        {
            Human enemy = obj as Human;
            if (enemy == null || enemy.health > 50)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health = 0;
            }
        }
        public void Meditate()
        {
            health = 200;
        }
    }
}