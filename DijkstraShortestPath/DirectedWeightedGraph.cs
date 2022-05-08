using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstraShortestPath
{
    class DirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int e;
        int n;
        int[,] adj;
        Vertex[] vertexList;

        private readonly int TEMPORARY = 1; // Trạng thái của các node chưa xét
        private readonly int PERMANENT = 2; // Trạng thái của các node đã xem xét
        private readonly int NIL = -1; // predecessor ban đầu
        private readonly int INFINITY = int.MaxValue; // pathLength ban đầu

        // Khai báo mảng 2 chiều
        public DirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        /// <summary>
        /// Thuật toán Dijkstra's Algorithm
        /// </summary>
        /// <param name="s"> Node nguồn (Vị trí bắt đầu) </param>
        private void Dijkstra(int s)
        {
            int v, c;

            for (v = 0; v < n; v++)
            {
                vertexList[v].status = TEMPORARY;
                vertexList[v].pathLength = INFINITY;
                vertexList[v].predecessor = NIL;
            }

            // Gán chiều này ban đầu (node nguồn đến node nguồn = 0)
            vertexList[s].pathLength = 0;

            while (true)
            {
                c = TempVertexMinPL();

                // Thoát vòng lặp nếu không tìm được node nào
                if (c == NIL)
                    return;

                // Cập nhật lại trạng thái node tìm được
                vertexList[c].status = PERMANENT;

                // Cập nhật lại predecessor và pathLength
                for (v = 0; v < n; v++)
                {
                    if (IsAdjacent(c, v) && vertexList[v].status == TEMPORARY)
                        if (vertexList[c].pathLength + adj[c, v] < vertexList[v].pathLength)
                        {
                            vertexList[v].predecessor = c;
                            vertexList[v].pathLength = vertexList[c].pathLength + adj[c, v];
                        }
                }
            }
        }

        /// <summary>
        /// Lấy node có trạng thái chưa xét (TEMPORARY) với pathLength nhỏ nhất
        /// </summary>
        /// <returns>
        /// x != NIL node có trạng thái chưa xét (TEMPORARY) có pathLength nhỏ nhất
        /// x == NIL Không còn node nào từ node nguồn đến được
        /// </returns>
        private int TempVertexMinPL()
        {
            int min = INFINITY;
            int x = NIL;
            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].status == TEMPORARY && vertexList[v].pathLength < min)
                {
                    min = vertexList[v].pathLength;
                    x = v;
                }
            }
            return x;
        }

        /// <summary>
        /// Kiểm tra đỉnh liền kề
        /// </summary>
        private bool IsAdjacent(int u, int v)
        {
            return (adj[u, v] != 0);
        }
        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertexList[i].name))
                    return i;
            throw new System.InvalidOperationException("Đỉnh không tồn tại");
        }

        /// <summary>
        /// path[]: đường đi ngắn nhất qua các node 
        /// </summary>
        /// <param name="s">Node nguồn (đỉnh bắt đầu) </param>
        /// <param name="v">Node đến (đỉnh kết thúc) </param>
        private void FindPath(int s, int v)
        {
            int i, u;
            int[] path = new int[n];
            int sd = 0;
            int count = 0;

            while (v != s)
            {
                count++;
                path[count] = v;
                u = vertexList[v].predecessor;
                sd += adj[u, v];
                v = u;
            }
            count++;
            path[count] = s;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Đường đi ngắn nhất: ");
            for (i = count; i >= 1; i--)
                Console.Write(path[i] + " ");
            Console.WriteLine("\n Khoảng cách ngắn nhất : " + sd + "\n");
        }
        public void FindPaths(String source, String Destination = null)
        {
            int s = GetIndex(source);
            int d = GetIndex(Destination);
            Dijkstra(s);
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Đỉnh nguồn : " + source + "\n");

            //for (int i = 0; i < adj.GetLength(0); i++)
            //{
            //    for (int j = 0; j < adj.GetLength(1); j++)
            //    {
            //        Console.Write(adj[i, j] + " ");
            //    }
            //}
            if (Destination != null)
            {
                Console.WriteLine("Đỉnh đến : " + vertexList[d].name);
                if (vertexList[d].pathLength == INFINITY)
                    Console.WriteLine("Không có đường đi từ " + source + " đến " + vertexList[d].name + "\n");
                else
                    FindPath(s, d);
            }
            else // Show all
            {
                for (int v = 0; v < n; v++)
                {
                    Console.WriteLine("Đỉnh đến : " + vertexList[v].name);
                    if (vertexList[v].pathLength == INFINITY)
                        Console.WriteLine("Không có đường đi từ " + source + " đến " + vertexList[v].name + "\n");
                    else
                        FindPath(s, v);
                }
            }
        }
        public void InsertVertex(String name)
        {
            vertexList[n++] = new Vertex(name);
        }
        public void InsertEdge(String s1, String s2, int wt)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);
            if (u == v)
                throw new System.InvalidOperationException("Cạnh không hợp lệ");

            if (adj[u, v] != 0)
                Console.Write("Cạnh này có rồi");
            else
            {
                adj[u, v] = wt;
                e++;
            }
        }
    }
}
