using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS_use_stack_vs_recursive
{
    public class Graph
    {
        public Dictionary<int, HashSet<int>> Adjacent { get; set; }
        public Graph()
        {
            Adjacent = new Dictionary<int, HashSet<int>>();
        }

        public void AddEdge(int source, int target)
        {
            if (Adjacent.ContainsKey(source))
            {
                try
                {
                    Adjacent[source].Add(target);
                }
                catch
                {
                    Console.WriteLine("This edge already exist: " + source + " to " + target);
                }
            }
            else
            {
                var hashset = new HashSet<int>();
                hashset.Add(target);
                Adjacent.Add(source, hashset);
            }
        }

        public void BFSWalkWithStartNode(int vertex)
        {
            var visited = new HashSet<int>();
            // Mark this node as visited
            visited.Add(vertex);
            // Queue for BFS
            var queue = new Queue<int>();
            // Add this node to the queue
            queue.Enqueue(vertex);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);
                // Only if the node has a any adj notes
                if (Adjacent.ContainsKey(current))
                {
                    // Iterate through UNVISITED nodes
                    foreach (int neighbour in Adjacent[current].Where(a => !visited.Contains(a)))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        public int BFSFindNodeWithStartNode(int vertex, int lookingFor)
        {
            if (vertex == lookingFor)
            {
                Console.WriteLine("Found it!");
                Console.WriteLine("Steps Took: 0");
                return 0;
            }
            var visited = new HashSet<int>();
            // Mark this node as visited
            visited.Add(vertex);
            // Queue for BFS
            var q = new Queue<int>();
            // Add this node to the queue
            q.Enqueue(vertex);

            int count = 0;

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                Console.WriteLine(current);
                if (current == lookingFor)
                {
                    Console.WriteLine("Found it!");
                    Console.WriteLine("Steps Took: " + count);
                    return visited.Count();
                }

                // Only if the node has a any adj notes
                if (Adjacent.ContainsKey(current))
                {
                    // Iterate through UNVISITED nodes
                    foreach (int neighbour in Adjacent[current].Where(a => !visited.Contains(a)))
                    {
                        visited.Add(neighbour);
                        q.Enqueue(neighbour);
                    }
                }
                count++;
            }
            Console.WriteLine("Could not find node!");
            return count;
        }

        public void DFSWalkWithStartNode(int vertex)
        {
            var visited = new HashSet<int>();
            visited.Add(vertex);//mark this node as visited
            var stack = new Stack<int>();//stack for DFS
            stack.Push(vertex);//add this node to the stack

            while(stack.Count > 0)
            {
                var current = stack.Pop();
                Console.WriteLine(current);
                if (!visited.Contains(current))//add visited
                    visited.Add(current);
                if(Adjacent.ContainsKey(current))//if node as a any adjacent nodes
                    foreach(int neighbour in Adjacent[current].Where(a => !visited.Contains(a)))
                    {
                        visited.Add(neighbour);
                        stack.Push(neighbour);
                    }
            }
        }

        public void DFSWithRecursion(int vertex)
        {
            var visited = new HashSet<int>();
            Traverse(vertex, visited);
        }

        private void Traverse(int v, HashSet<int> visited)
        {
            visited.Add(v);// Mark this node as visited
            Console.WriteLine(v);//if the node has a any adj notes
            if (Adjacent.ContainsKey(v))
            {
                // Iterate through UNVISITED nodes
                foreach (int neighbour in Adjacent[v].Where(a => !visited.Contains(a)))
                    Traverse(neighbour, visited);
            }
        }
    }
}
