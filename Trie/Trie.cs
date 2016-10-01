using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Trie
{
    public class TrieNode : INode
    {
        public TrieNode(char label, bool isFake, List<TrieNode> children)
        {
            this.label = label;
            this.isFake = isFake;
            if (children == null)
            {
                this.children = new List<TrieNode>();
            }
            else
            {
                this.children = children;
            }
        }
        bool isFake;
        char label;
        List<TrieNode> children;
        public bool IsFake
        {
            get { return isFake; }
            set { isFake = value; }
        }
        public char Label
        {
            get { return label; }
        }
        public List<TrieNode> Children
        {
            get { return children; }
        }

        string INode.Label
        {
            get
            {
                return Label.ToString();
            }
        }

        List<INode> INode.Children
        {
            get
            {
                return Children.Cast<INode>().ToList();
            }
        }

        public TrieNode AddChild(TrieNode child)
        {
            children.Add(child);
            return child;
        }
        public TrieNode AddChild(char label)
        {
            TrieNode child = new TrieNode(label, true, null);
            return AddChild(child);
        }
    }
    public class Trie : ITree
    {
        TrieNode root;
        public Trie()
        {
            char label = (char)1;
            root = new TrieNode(label, true, new List<TrieNode>());
        }
        public bool IsEmpty
        {
            get { return root.Children.Count == 0; }
        }

        public string Label
        {
            get
            {
                return root.Label.ToString();
            }
        }

        public List<INode> Children
        {
            get
            {
                return root.Children.Cast<INode>().ToList();
            }
        }

        public TrieNode Add(string str)
        {
            return Add(str.ToList());
        }
        public TrieNode Add(List<char> str)
        {
            if (str == null) throw new ArgumentException("Adding string is null");
            if (str.Count == 0) throw new ArgumentException("Count is 0");
            TrieNode currentNode = root;
            foreach (var label in str)
            {
                TrieNode nextNode = currentNode.Children.Find(node => node.Label.Equals(label));
                if (nextNode != null)
                {
                    currentNode = nextNode;
                } else
                {
                    currentNode = currentNode.AddChild(label);
                }
            }
            currentNode.IsFake = false;
            return currentNode;
        }
        public bool Find(string str)
        {
            return Find(str.ToList());
        }
        public bool Find(List<char> str)
        {
            TrieNode t;
            return TryFind(str, out t);
        }
        private bool TryFind(List<char> str, out TrieNode findedNode)
        {
            if (str == null) throw new ArgumentException("Finding string is null");
            if (str.Count == 0) throw new ArgumentException("Count is 0");
            findedNode = null;
            TrieNode currentNode = root;
            foreach (var label in str)
            {
                TrieNode nextNode = currentNode.Children.Find(node => node.Label.Equals(label));
                if (nextNode != null)
                {
                    currentNode = nextNode;
                }
                else
                {
                    return false;
                }
            }
            findedNode = currentNode;
            return !findedNode.IsFake;
        }
        public void Remove(List<char> str)
        {
            TrieNode node;
            if (TryFind(str, out node))
            {
                node.IsFake = true;
            } else
            {
                throw new KeyNotFoundException(str.ToString() + " is not found.");
            }
        }
        public void Remove(string str)
        {
            Remove(str.ToList());
        }
    }
}
