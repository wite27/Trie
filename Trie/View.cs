using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Trie
{
    public interface ITree : INode
    {

    }
    public interface INode
    {
        string Label { get; }
        List<INode> Children { get; }
    }
}
