using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Trie
{
    public partial class Form1 : Form
    {
        Trie trie;
        public Form1()
        {
            InitializeComponent();
            trie = new Trie();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string str = textBoxInput.Text;
            trie.Add(str.ToList());
            Paint(trie);
        }

        private void Paint(ITree tree)
        {
            treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(tree.Label);
            root.Tag = tree;
            treeView1.Nodes.Add(root);
            PaintRecursive(root, tree.Children);
            treeView1.ExpandAll();
        }

        private void PaintRecursive(TreeNode parentViewNode, List<INode> nodes)
        {
            if (nodes.Count == 0) return;
            foreach (var node in nodes)
            {
                TreeNode viewNode = new TreeNode(node.Label);
                viewNode.Tag = node;
                parentViewNode.Nodes.Add(viewNode);
                PaintRecursive(viewNode, node.Children);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBoxInput.Text;
                trie.Remove(str.ToList());
                Paint(trie);
            }
            catch (KeyNotFoundException ke)
            {
                MessageBox.Show("Key is not found: " + ke.Message);
            }
        }
    }
}
