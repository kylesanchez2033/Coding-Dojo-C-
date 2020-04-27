using System;

namespace Wizard_Ninja_Samurai
{
    public class Ninja : Human
    {
        public Ninja(string a) : base(a)
        {
            dexterity = 175;
        }

        public void Steal(object obj)
        {
            Human enemy = obj as Human;
            if (enemy != null)
            {
                attack(enemy);
                health += 10;
            }
        }
        public void get_away()
        {
            health -= 15;
        }
    }
}