using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FP.DAL.DAO
{
    public class Item
    {
        private string symbol;
        private int supportCount;

        public int SupportCount
        {
            get { return supportCount; }
            set { supportCount = value; }
        }
        public string Symbol
        {
            get { return symbol; }
        }

        //constructors
        public Item()
        {
            symbol = null;
            supportCount = -1;
        }
        public Item(string _symbol) 
            : this()
        {
            symbol = _symbol;
        }
        public Item(string _symbol,int _supportCount)
            : this()
        {
            symbol = _symbol;
            supportCount = _supportCount;
        }
        public Item Clone()
        {
            Item item = new Item(symbol,supportCount);
            return item;
        }
    }
}
