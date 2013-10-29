using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FP.Algorithm
{
    public class Node
    {
        string symbol;
        int fpCount;
        Node nextHeader;
        Node parent;

        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public Node NextHeader
        {
            get { return nextHeader; }
            set { nextHeader = value; }
        }
        List<Node> children;

        public List<Node> Children
        {
            get { return children; }
            set { children = value; }
        }
        public string Symbol
        {
            get { return symbol; }
        }
        public int FpCount
        {
            get { return fpCount; }
            set { fpCount = value; }
        }
        private Node()
        {
            fpCount = 0;
            nextHeader = null;
            children = new List<Node>();
            parent = null;
        }
        public Node(string _symbol)
            :this()
        {
            symbol = _symbol;
            if(symbol.Length != 0)
                fpCount = 1;
        }
        public bool IsNull()
        {
            return symbol.Length == 0;
        }
        public void AddChild(Node child)
        {
            child.parent = this;
            children.Add(child);
        }

    }
}
