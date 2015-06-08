using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndAbstraction.Characters
{
    class Warrior : Character
    {
        private const int WarriorHealth = 300;
        private const int WarriorMana = 0;
        private const int WarriorDamage = 120;

        public Warrior() : base(WarriorHealth,WarriorMana,WarriorDamage)
        {
        }

        public override void Attack(Character target)
        {
            target.Health -=  this.Damage;
        }
    }
}
