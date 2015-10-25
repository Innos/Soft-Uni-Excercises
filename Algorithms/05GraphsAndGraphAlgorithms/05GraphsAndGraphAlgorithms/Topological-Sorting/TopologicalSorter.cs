using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    //private Dictionary<string, int> predecessorsCount;

    private HashSet<string> visited;

    private HashSet<string> cycleNodes; 

    private LinkedList<string> sortedNodes; 

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public IEnumerable<string> TopSort()
    {
        this.visited = new HashSet<string>();
        this.cycleNodes = new HashSet<string>();
        this.sortedNodes = new LinkedList<string>();

        foreach (var node in this.graph.Keys)
        {
            this.TopSortDFS(node);
        }

        return this.sortedNodes;

        //// find predecessors count
        //this.predecessorsCount = new Dictionary<string, int>();

        //foreach (var node in this.graph)
        //{
        //    if (!this.predecessorsCount.ContainsKey(node.Key))
        //    {
        //        this.predecessorsCount.Add(node.Key,0);
        //    }
        //    foreach (var childNode in node.Value)
        //    {
        //        if (!this.predecessorsCount.ContainsKey(childNode))
        //        {
        //            this.predecessorsCount.Add(childNode,0);
        //        }

        //        this.predecessorsCount[childNode]++;
        //    }
        //}

        //// remove nodes
        //List<string> removedNodes = new List<string>();
        //while (true)
        //{
        //    string nodeToRemove = this.graph.Keys.FirstOrDefault(k => this.predecessorsCount[k] == 0);

        //    if (nodeToRemove == null)
        //    {
        //        break;
        //    }

        //    // decrement predecessors
        //    foreach (var child in this.graph[nodeToRemove])
        //    {
        //        this.predecessorsCount[child]--;
        //    }

        //    this.graph.Remove(nodeToRemove);
        //    this.predecessorsCount.Remove(nodeToRemove);
        //    removedNodes.Add(nodeToRemove);
        //}

        //if (this.graph.Count > 0)
        //{
        //    throw new InvalidOperationException("A cycle detected in the graph!");
        //}
        //return removedNodes;
    }

    private void TopSortDFS(string node)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("A cycle detected in the graph!");
        }

        if (!this.visited.Contains(node))
        {
            this.visited.Add(node);
            this.cycleNodes.Add(node);
            foreach (var child in this.graph[node])
            {
                if (this.graph.ContainsKey(child))
                {
                    this.TopSortDFS(child);
                }            
            }

            this.cycleNodes.Remove(node);
            this.sortedNodes.AddFirst(node);
        }       
    }
}
