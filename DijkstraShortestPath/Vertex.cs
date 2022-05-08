using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstraShortestPath
{
    class Vertex
    {
        /// <summary>
        /// name: Tên node
        /// status: trạng thái đã xét/ chưa xét
        /// predecessor: Giá trị đỉnh trước đó
        /// pathLength: chiều dài
        /// </summary>
        public String name;
        public int status;
        public int predecessor;
        public int pathLength;

        public Vertex(String name)
        {
            this.name = name;
        }
    }
}
