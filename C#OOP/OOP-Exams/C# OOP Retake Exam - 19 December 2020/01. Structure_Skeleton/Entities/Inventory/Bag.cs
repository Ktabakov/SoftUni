using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly ICollection<Item> items = new List<Item>();

        public Bag(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load => this.Items.Sum(w => w.Weight);

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)this.items;


        public void AddItem(Item item)
        {
            if (this.Load +item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            // check if this one actually works

            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item itemToTake = items.FirstOrDefault(i => name == i.GetType().Name);

            if (itemToTake == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(itemToTake);
            return itemToTake;
        }
    }
}
