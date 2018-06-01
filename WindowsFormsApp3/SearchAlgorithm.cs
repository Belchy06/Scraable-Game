using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    public static class SearchAlgorithm
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
            foreach (Tile tile in editedTiles)
            {

                int x = tile.Position.X;
                int y = tile.Position.Y;

                int tmpX = tile.Position.X;
                int tmpY = tile.Position.Y;

                if (frmGame.Tiles[y, x - 1].Value != null)
                {
                    while (frmGame.Tiles[tmpY, tmpX].Value != null)
                    {
                        tmpX -= 1;
                    }
                }

                //Point rootPoint = new Point(tmpX, tmpY);
                
                //if(!(rootPositions.Contains(rootPoint)))
                //{
                //    rootPositions.Add(rootPoint);
                //}

                //tmpX = x;
                //tmpY = y;

                if (frmGame.Tiles[y - 1, x].Value != null)
                {
                    while (frmGame.Tiles[tmpY - 1, tmpX].Value != null)
                    {
                        //updown = true;
                        tmpY -= 1;
                    }
                }

                Point rootPoint = new Point(tmpX, tmpY);

                if (!(rootPositions.Contains(rootPoint)))
                {
                    rootPositions.Add(rootPoint);
                }
            } 

            #endregion

            foreach(Point position in rootPositions)
            {
                int x = position.X;
                int tmpX = x;
                int y = position.Y;
                int tmpY = y;
                
                if(frmGame.Tiles[tmpY, tmpX + 1].Value != null)
                {
                    while (frmGame.Tiles[tmpY, tmpX].Value != null)
                    {
                        word += frmGame.Tiles[tmpY, tmpX].Value;
                        tmpX += 1;
                    }
                }

                if(word != null)
                {
                    words.Add(word);
                    word = null;
                }

                if (frmGame.Tiles[tmpY + 1, tmpX].Value != null)
                {
                    while (frmGame.Tiles[tmpY, tmpX].Value != null)
                    {
                        word += frmGame.Tiles[tmpY, tmpX].Value;
                        tmpY += 1;
                    }
                }

                if (word != null)
                {
                    words.Add(word);
                    word = null;
                }

            }

            rootPositions.Clear();
            return words;
        }
    }

    public class Root
    {
        public Root(Point rootPosition, Boolean rootUpDown)
        {
            Position = rootPosition;
            UpDown = rootUpDown;
        }

        private bool _updown;
        public bool UpDown
        {
            get { return _updown; }
            set { _updown = value; }
        }

        private Point _position;
        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
