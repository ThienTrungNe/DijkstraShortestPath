using System;

namespace DijkstraShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedWeightedGraph g = new DirectedWeightedGraph();

            g.InsertVertex("0");
            g.InsertVertex("1");
            g.InsertVertex("2");
            g.InsertVertex("3");
            g.InsertVertex("4");
            g.InsertVertex("5");
            g.InsertVertex("6");
            g.InsertVertex("7");
            g.InsertVertex("8");

            g.InsertEdge("0", "3", 2);
            g.InsertEdge("0", "1", 5);
            g.InsertEdge("0", "4", 8);
            g.InsertEdge("1", "4", 2);
            g.InsertEdge("2", "1", 3);
            g.InsertEdge("2", "5", 4);
            g.InsertEdge("3", "4", 7);
            g.InsertEdge("3", "6", 8);
            g.InsertEdge("4", "5", 9);
            g.InsertEdge("4", "7", 4);
            g.InsertEdge("5", "1", 6);
            g.InsertEdge("6", "7", 9);
            g.InsertEdge("7", "3", 5);
            g.InsertEdge("7", "5", 3);
            g.InsertEdge("7", "8", 5);
            g.InsertEdge("8", "5", 3);

            g.FindPaths("0","5");

        }
    }
}
