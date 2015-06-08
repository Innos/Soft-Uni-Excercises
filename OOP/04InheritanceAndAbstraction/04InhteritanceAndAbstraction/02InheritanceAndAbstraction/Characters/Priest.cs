using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceAndAbstraction.Intefaces;

namespace InheritanceAndAbstraction.Characters
{
    class Priest : Character, IHeal
    {
        private const int PriestHealth = 125;
        private const int PriestMana = 200;
        private const int PriestDamage = 100;

        public Priest() : base(PriestHealth,PriestMana,PriestDamage)
        {
        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -=  this.Damage;
            this.Health += this.Damage / 10;
        }

        public void Heal(Character target)
        {
            this.Mana -= 100;
            target.Health += 150;
        }
    }
}
