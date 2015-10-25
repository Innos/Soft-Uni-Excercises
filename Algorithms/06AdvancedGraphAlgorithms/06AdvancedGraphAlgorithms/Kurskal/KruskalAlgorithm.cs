namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {          
            edges.Sort();
            int[] parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }
            var MST = new List<Edge>();
            foreach (var edge in edges)
            {
                int startNodeRoot = FindRoot(edge.StartNode, parent);
                int endNodeRoot = FindRoot(edge.EndNode, parent);
                if (startNodeRoot != endNodeRoot)
                {
                    parent[endNodeRoot] = startNodeRoot;
                    MST.Add(edge);
                }
            }
            return MST;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }
            while (node != root)
            {
                int currentRoot = parent[node];
                parent[node] = root;
                node = currentRoot;
            }
            return root;
        }
    }
}
