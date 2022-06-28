using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> tilesUsed = new Dictionary<string, int>()
            {
                ["Floor"] = 0,
                ["Sink"] = 0,
                ["Oven"] = 0,
                ["Countertop"] = 0,
                ["Wall"] = 0,
            };
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (greyTiles.Count > 0 && whiteTiles.Count > 0)
            {
                int greyTile = greyTiles.Dequeue();
                int whiteTile = whiteTiles.Pop();

                if (greyTile == whiteTile)
                {
                    int areaSum = greyTile + whiteTile;
                    string formedTile = FormingTile(areaSum);
                    tilesUsed[formedTile]++;
                }
                else
                {
                    int newWhiteTile = whiteTile / 2;
                    whiteTiles.Push(newWhiteTile);
                    greyTiles.Enqueue(greyTile);
                }
            }

            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var tile in tilesUsed.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }

        public static string FormingTile(int areaSum)
        {
            string tile = "";

            switch (areaSum)
            {
                case 40:
                    tile = "Sink";
                    break;
                case 50:
                    tile = "Oven";
                    break;
                case 60:
                    tile = "Countertop";
                    break;
                case 70:
                    tile = "Wall";
                    break;
                default:
                    tile = "Floor";
                    break;
            }

            return tile;
        }
    }
}
