using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double health;
		private double armor;

		public Character(string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag)
        {
			Name = name;
			BaseHealth = baseHealth;
			BaseArmor = baseArmor;
            Health = BaseHealth;
            Armor = BaseArmor;
			AbilityPoints = abilityPoints;
			Bag = bag;
        }
		public bool IsAlive { get; set; } = true;

        public string Name
        {
			get => this.name;
			private set
            {
				if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}
				name = value;
            }
        }
        public double BaseHealth { get; }

        public double BaseArmor { get; }

        public double Health
        {
			get
            {
				return health;
            }
			set
            {
				if(value > BaseHealth)
                {
					health = BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            private set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; } = 40;

		public Bag Bag  { get;}

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
		public void TakeDamage(double hitPoints)
        {
			if (this.IsAlive)
            {
                if (hitPoints > Armor)
                {
                    Health -= hitPoints - Armor;
                }
                Armor -= hitPoints;

                if (this.Health <= 0)
                {
					this.IsAlive = false;
                }
            }
        }
		public void UseItem(Item item)
        {
			if (this.IsAlive)
            {
				item.AffectCharacter(this);
            }
			//check if works or need reflection for Which Item?
        }
	}
}