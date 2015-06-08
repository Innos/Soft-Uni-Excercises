using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndAbstraction.Characters
{
    class Mage : Character
    {
        private const int MageHealth = 100;
        private const int MageMana = 300;
        private const int MageDamage = 75;

        public Mage() : base(MageHealth,MageMana,MageDamage)
        {
        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= 2 * this.Damage;
        }
    }
}
