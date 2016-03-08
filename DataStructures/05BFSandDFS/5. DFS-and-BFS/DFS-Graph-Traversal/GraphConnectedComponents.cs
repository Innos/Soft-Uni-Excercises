using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    public static void Main()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        int nodes = int.Parse(Console.ReadLine());
        for (int i = 0; i < nodes; i++)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                graph.Add(i, new List<int>());
            }
            else
            {
                List<int> nums = line.Split().Select(int.Parse).ToList();
                graph.Add(i, nums);
            }        
        }

        bool[] visited = new bool[nodes];
        for (int i = 0; i < nodes; i++)
        {
            HashSet<int> component = new HashSet<int>();
            DFS(graph, visited, component, i);
            if (component.Count != 0)
            {
                Console.WriteLine("Connected component: {0}", string.Join(" ", component));
            }
        }
    }

    private static void DFS(Dictionary<int, List<int>> graph, bool[] visited, HashSet<int> component, int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(graph, visited, component, child);
            }

            component.Add(node);
        }
    }
}
