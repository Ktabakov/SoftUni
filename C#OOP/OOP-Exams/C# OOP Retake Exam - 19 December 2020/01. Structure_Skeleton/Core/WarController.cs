using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characters;
		private Stack<Item> items;
		public WarController()
		{
			characters = new List<Character>();
			items = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

			if (characterType == "Priest")
            {
				character = new Priest(name);
            }
		    else if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
			else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			characters.Add(character);
			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;

			if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
			else if (itemName == "FirePotion")
            {
				item = new FirePotion();
            }
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			items.Push(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = characters.FirstOrDefault(f => f.Name == characterName);
			if (character == default)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
			if (items.Count == 0)
            {
				throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
			}

			Item item = items.Pop();
			character.Bag.AddItem(item);
			return $"{characterName} picked up {item.GetType().Name}!"; // maybe check if reflection works
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = characters.FirstOrDefault(c => c.Name == characterName);
			Item item = character.Bag.GetItem(itemName);

			if (character == default)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			if (!character.Bag.Items.Contains(item))
            {
				throw new ArgumentException($"Parameter Error: No item with name {itemName} in bag!");
            }

			character.UseItem(item);
			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			List<Character> sorterCharacters = characters.OrderByDescending(c => c.IsAlive)
				.ThenByDescending(c => c.Health).ToList();

            foreach (var item in sorterCharacters)
            {
				string deadOrAlive = string.Empty;
				if (item.IsAlive)
                {
					deadOrAlive = "Alive";
                }
                else
                {
					deadOrAlive = "Dead";
                }
				sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: {deadOrAlive}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			StringBuilder sb = new StringBuilder();

			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = characters.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = characters.FirstOrDefault(c => c.Name == receiverName);

			if (!characters.Contains(attacker))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attacker.Name));
			}
			if (!characters.Contains(receiver))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiver.Name));
			}

			if (attacker.GetType().Name != "Warrior")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
			}

			Warrior warr = (Warrior)attacker;
			warr.Attack(receiver);

			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");


			if (!receiver.IsAlive)
			{
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args) 
		{
			string healerName = args[0];
			string receiverName = args[1];

			Character healer = characters.FirstOrDefault(c => c.Name == healerName);
			Character receiver = characters.FirstOrDefault(c => c.Name == receiverName);

			if (!characters.Contains(healer))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healer.Name));
			}
			if (!characters.Contains(receiver))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiver.Name));
			}

			if (healer.GetType().Name != "Priest")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
			}

			Priest pop = (Priest)healer;
			pop.Heal(receiver);
			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
