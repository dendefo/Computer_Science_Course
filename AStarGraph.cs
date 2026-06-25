using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class AStarNode
    {
        public Vector2 Position;
        public AStarNode(Vector2 position)
        {
            Position = position;
        }
        public List<AStarNode> GetNeighbors(int[][] grid)
        {
            int x = ((int)Position.X);
            int y = ((int)Position.Y);

            var result = new List<AStarNode>();
            for (int i = y - 1; i <= y + 1; i++)
            {
                if (i < 0) continue;
                if (i >= grid.Length) continue;
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (j < 0) continue;
                    if (j >= grid[i].Length) continue;
                    if (i == y && j == x) continue;
                    int gridValue = grid[i][j];
                    if (gridValue == 1) continue;
                    result.Add(new AStarNode(new Vector2(j, i)));
                }
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            if (obj==null) return false;
            if (obj is not AStarNode node)
            {
                return false;
            }
            return Position.Equals(node.Position);
        }
        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
    }
}
