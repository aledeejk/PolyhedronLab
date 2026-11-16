using System.Collections.Generic;

namespace PolyhedronLab
{
    public class Face
    {
        public List<int> Indices { get; } = new List<int>();
        public Face() { }
        public Face(IEnumerable<int> idx) { Indices.AddRange(idx); }
    }
}