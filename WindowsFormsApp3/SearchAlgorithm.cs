using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    public class SearchAlgorithm
    {
        public static int rootX;
        public static int rootY;

        public static List<Point> rootPositions = new List<Point>();

        public static List<string> words = new List<string>();

        public static string word;

        public static StringBuilder sb = new StringBuilder();

        public static List<string> Search(List<Tile> editedTiles)
        {

            #region Find Root
            findHorizontalRoot(editedTiles);
            findVerticalRoot(editedTiles);
            #endregion


            //rootPositions.Clear();
            //foreach (Point position in rootPositions)
            //{
            //    int x = position.X; // initial root x position

            //    int y = position.Y; // initial root y position

            //    // if tile to the right has letter
            //    if (frmGame.Tiles[y, x + 1].Value != null)
            //    {
            //        searchRight(x, y);
            //    }

            //    // if the tile down has a letter
            //    if (frmGame.Tiles[y + 1, x].Value != null)
            //    {
            //        searchDown(x, y);
            //    }
            //}

            return words;
            
        }

        public static void searchRight(int x, int y)
        {
            //While the tile is not empty
            while (frmGame.Tiles[y, x].Value != null)
            {
                // add the value of the current tile to word
                word += frmGame.Tiles[y, x].Value;

                //move right 1 tile
                if(x < 14)
                {
                    x += 1;
                }     
            }

            // add word to list of words
            words.Add(word);

            // reset value of word
            word = null;
        }

        public static void searchDown(int x, int y)
        {
            //While the tile is not empty
            while (frmGame.Tiles[y, x].Value != null)
            {
                // add the value of the current tile to word
                word += frmGame.Tiles[y, x].Value;

                //move down 1 tile
                if(y < 14)
                {
                    y += 1;
                }    
            }

            // add word to list of words
            words.Add(word);

            // reset value of word
            word = null;
        }

        public static void findHorizontalRoot(List<Tile> editedTiles)
        {
            bool across = false;
            int searchX = 0;
            int searchY = 0;

            foreach (Tile tile in editedTiles)
            {
                across = false;
                // initalize variable
                int x = tile.Position.X; // inital x
                int y = tile.Position.Y; // inital y

                int tmpX = tile.Position.X; // editable x
                int tmpY = tile.Position.Y; // editable y

                // if tile to the left has a letter
                if (frmGame.Tiles[y, x - 1].Value != null)
                {
                    // move to the left tile until ladning on root letter
                    while (frmGame.Tiles[tmpY, tmpX - 1].Value != null)
                    {
                        tmpX -= 1;
                        across = true;
                    }
                }

                searchX = tmpX;
                searchY = tmpY;

                Point rootPoint = new Point(tmpX, tmpY);

                if (across)
                {
                    if (!(rootPositions.Contains(rootPoint)))
                    {
                        rootPositions.Add(rootPoint);
                        searchRight(searchX, searchY);
                    } 
                }

                
            }

            rootPositions.Clear();
            //if (across)
            //{
            //    searchRight(searchX, searchY);
            //}
        }

        public static void findVerticalRoot(List<Tile> editedTiles)
        {
            bool up = false;
            int searchX = 0;
            int searchY = 0;

            foreach (Tile tile in editedTiles)
            {
                up = false;
                int x = tile.Position.X; // inital x
                int y = tile.Position.Y; // inital y

                int tmpX = tile.Position.X; // editable x
                int tmpY = tile.Position.Y; // editable y

                // if upper tile has a letter
                if (frmGame.Tiles[y - 1, x].Value != null)
                {
                    // move to the upper tile
                    while (frmGame.Tiles[tmpY - 1, tmpX].Value != null)
                    {
                        tmpY -= 1;
                        up = true;
                    }
                }

                searchX = tmpX;
                searchY = tmpY;

                Point rootPoint = new Point(tmpX, tmpY);

                if (up)
                {
                    if (!(rootPositions.Contains(rootPoint)))
                    {
                        rootPositions.Add(rootPoint);
                        searchDown(searchX, searchY);
                    } 
                }
            }

            rootPositions.Clear();
        }
    }
}
