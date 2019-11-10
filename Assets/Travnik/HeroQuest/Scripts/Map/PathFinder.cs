using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travnik.HeroQuest
{
    public enum MapPath : int
    {
        NotPath = -255,
        Start = 0,
        Path = 255,
    }

    public static class PathFinder
    {
        public static bool IsMove(MapNode node)
        {
            return node.Cost > (int)MapPath.Start && node.Cost < (int)MapPath.Path;
        }

        public static void Search(GameMap gameMap, int startX, int startY, int moveStep)
        {
            ClearMap(gameMap);
            gameMap.Map[startX, startY].Cost = (int)MapPath.Start;

            var index = 0;
            while (index < moveStep || index >= gameMap.MapWidth + gameMap.MapHeight)
            {
                for (int i = 0; i < gameMap.MapHeight; i++)
                {
                    for (int j = 0; j < gameMap.MapWidth; j++)
                    {
                        int step = index + (int)MapPath.Start;
                        if (gameMap.Map[i, j] != null && gameMap.Map[i, j].Cost == step)
                        {
                            Set(gameMap, i - 1, j, step);
                            Set(gameMap, i + 1, j, step);
                            Set(gameMap, i, j - 1, step);
                            Set(gameMap, i, j + 1, step);
                        }
                    }
                }

                index++;
            }
        }

        private static void Set(GameMap gameMap, int x, int y, int cost)
        {
            if (gameMap.Map[x, y] != null && gameMap.Map[x, y].Cost == (int)MapPath.Path)
            {
                gameMap.Map[x, y].Cost = cost + 1;
            }
        }

        private static void ClearMap(GameMap gameMap)
        {
            foreach(var node in gameMap.Map)
            {
                if(node != null )
                {
                    node.Cost = node.Type == NodeType.Wall
                        ? (int)MapPath.NotPath
                        : (int)MapPath.Path;
                }
            }
        }
    }
}
