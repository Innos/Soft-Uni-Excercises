using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Interface;

namespace Battleships.Ships
{
    public abstract class BattleShip : Ship,IAttack
    {
        public BattleShip(string name, double lengthInMeters, double volume) : base(name,lengthInMeters,volume)
        {
        }

        public abstract string Attack(Ship targetShip);

        public void DestroyShip(Ship target)
        {
            target.IsDestroyed = true;
        }
    }
}
