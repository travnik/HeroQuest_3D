using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class GameMap
    {
        public static MapNodeGameObject[,] map;

        public const int MapWidth = 15;
        public const int MapHeight = 15;

        public void Initialize()
        {
            map = new MapNodeGameObject[MapWidth, MapHeight];

            AddNode(0, 0, NodeType.Wall);
            AddNode(0, 1, NodeType.Wall);
            AddNode(0, 2, NodeType.Wall);
            AddNode(0, 3, NodeType.Wall);
            AddNode(0, 4, NodeType.Wall);
            AddNode(0, 5, NodeType.Wall);
            AddNode(0, 6, NodeType.Wall);
            AddNode(0, 7, NodeType.Wall);
            AddNode(0, 8, NodeType.Wall);
            AddNode(0, 9, NodeType.Wall);
            AddNode(0, 10, NodeType.Wall);
            AddNode(0, 11, NodeType.Wall);
            AddNode(1, 0, NodeType.Wall);
            AddNode(2, 0, NodeType.Wall);
            AddNode(3, 0, NodeType.Wall);
            AddNode(4, 0, NodeType.Wall);

            AddNode(1, 1, NodeType.Floor);
            AddNode(1, 2, NodeType.Floor);
            AddNode(1, 3, NodeType.Floor);
            AddNode(1, 4, NodeType.Floor);
            AddNode(1, 5, NodeType.Floor);
            AddNode(1, 6, NodeType.Floor);
            AddNode(1, 7, NodeType.Floor);
            AddNode(1, 8, NodeType.Floor);
            AddNode(1, 9, NodeType.Floor);
            AddNode(1, 10, NodeType.Floor);

            AddNode(2, 1, NodeType.Floor);
            AddNode(2, 2, NodeType.Floor);
            AddNode(2, 3, NodeType.Floor);
            AddNode(2, 4, NodeType.Floor);
            AddNode(2, 5, NodeType.Floor);

            AddNode(3, 1, NodeType.Floor);
            AddNode(3, 2, NodeType.Floor);
            AddNode(3, 3, NodeType.Floor);
            AddNode(3, 4, NodeType.Floor);
            AddNode(3, 5, NodeType.Floor);

            AddNode(4, 1, NodeType.Floor);
            AddNode(4, 2, NodeType.Floor);
            AddNode(4, 3, NodeType.Floor);
            AddNode(4, 4, NodeType.Floor);
            AddNode(4, 5, NodeType.Floor);
        }

        public MapNode AddNode(int x, int y, NodeType type)
        {
            Vector2Int gridPoint = Geometry.GridPoint(x, y);
            var node = new MapNodeGameObject()
            {
                X = x,
                Y = y,
                Type = type,
                WorldPosition = Geometry.PointFromGrid(gridPoint),
                ArrayPosition = gridPoint
            };
            GameMap.map[x, y] = node;
            return node;
        }
    }
}
