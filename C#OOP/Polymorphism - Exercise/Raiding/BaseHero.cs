using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public int Power { get; set; }

        public virtual string CastAbility()
        {
            if (this.GetType().Name is nameof(Druid) || this.GetType().Name is nameof(Paladin))
            {
                return $"{this.GetType().Name} - {Name} healed for {Power}";
            }

            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
