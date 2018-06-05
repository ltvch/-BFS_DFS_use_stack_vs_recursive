using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS_use_stack_vs_recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph();

            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);

            g.AddEdge(2, 5);
            g.AddEdge(2, 6);
            g.AddEdge(4, 7);
            g.AddEdge(4, 8);

            g.AddEdge(5, 9);
            g.AddEdge(5, 10);
            g.AddEdge(7, 11);
            g.AddEdge(7, 12);

            //Console.WriteLine("Following is Breadth First Traversal (starting from vertex 1)");
            //g.BFSWalkWithStartNode(1);

            Console.WriteLine("Following is Depth First Traversal (starting from vertex 1)");
            g.DFSWalkWithStartNode(1);

            //Console.WriteLine("Following is Depth First Traversal USING RECURSION (starting from vertex 1)");
            //g.DFSWithRecursion(1);

            Console.Read();
        }
    }
}
