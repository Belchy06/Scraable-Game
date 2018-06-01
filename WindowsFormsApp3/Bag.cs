using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public static class Bag
    {
        public static List<Letter> letters = new List<Letter>();

        /// <summary>
        /// Populate the list tiles with scrabble tiles.
        /// </summary>
        public static void PopulateTiles()
        {
            AddTile(9, "A", 1);
            AddTile(2, "B", 42);
            AddTile(2, "C", 42);
            AddTile(4, "D", 42);
            // ...
        }

        public static void AddTile(int count, string letter, int score)
        {
            for (int i = 0; i < count; i++)
            {
                Letter letterToUse = new Letter(letter); // Pass the score along to the tile as well
                letters.Add(letterToUse);
            }
        }
    }
    //https://codereview.stackexchange.com/questions/94202/populating-a-bag-of-scrabble-tiles
}
