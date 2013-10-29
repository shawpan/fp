using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FP.DAL.DAO
{
    public class ItemSet
    {
        private List<Item> items; //list of items in item set

        
        private int supportCount; // support count of this item set

        public int SupportCount
        {
            get { return supportCount; }
            set { supportCount = value; }
        }

        //constructor
        public ItemSet()
        {
            items = new List<Item>();
            supportCount = -1;
        }
        //add item into item set
        public void AddItem(Item item)
        {
            items.Add(item);
            supportCount = -1;
        }
        //remove item
        public Item GetItem(int position)
        {
            if (position < items.Count)
                return items[position];
            else
                return null;
        }
        //add item into item set
        public bool IsEmpty()
        {
            return items.Count == 0;
        }
        //add item into item set
        public int GetLength()
        {
            return items.Count;
        }
        public ItemSet Clone()
        {
            ItemSet itemSet = new ItemSet();
            itemSet.SupportCount = SupportCount;
            foreach(Item anItem in items)
            {
                itemSet.AddItem(anItem.Clone());
            }
            return itemSet;
        }
        public string GetInfoString()
        {
            string info="";
            
            foreach(Item anItem in items)
            {
                info += (" " + anItem.Symbol.ToString());
            }

            return info;
        }
        public void Print()
        {
            Console.WriteLine(SupportCount);
            foreach(Item item in items)
            {
                Console.Write(item.Symbol.ToString() + " ");
            }
            Console.WriteLine();
        }

        public Item GetLastItem()
        {
            return items.Last();
        }
    }
}
