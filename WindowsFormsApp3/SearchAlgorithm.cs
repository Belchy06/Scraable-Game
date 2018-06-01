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
        public static List<Root> roots = new List<Root>();

        public static string word;

        public static StringBuilder sb = new StringBuilder();

        public static List<string> Search(List<Tile> editedTiles)
        {
            List<string> words = new List<string>();
            #region Find Root
            foreach (Tile tile in editedTiles)
            {
                bool updown = true;

                int x = tile.Position.X;
                int y = tile.Position.Y;

                int tmpX = tile.Position.X;
                int tmpY = tile.Position.Y;

                //search to the left
                while (frmGame.Tiles[tmpY, tmpX - 1].Value != null)
                {
                    tmpX -= 1;
                    updown = false;
                }

                rootX = tmpX;

                //search down
                while (frmGame.Tiles[tmpY - 1, tmpX].Value != null)
                {
                    tmpY -= 1;
                    updown = true;
                }

                rootY = tmpY;

                Point rootPoint = new Point(tmpX, tmpY);

                Root root = new Root(rootPoint, updown);

                int index = roots.FindIndex(rootPos => root.Position.X == tmpX && root.Position.Y == tmpY);
                if(!(index >= 0))
                {
                    roots.Add(root);
                }
            } 

            #endregion

            foreach(Root root in roots)
            {
                int x = root.Position.X;
                int y = root.Position.Y;
                bool updown = root.UpDown;
                
                while(frmGame.Tiles[y,x].Value != null)
                {
                    word += frmGame.Tiles[y, x].Value;

                    if(updown == true)
                    {
                        y += 1;
                    }
                    else
                    {
                        x += 1;
                    }
                }

                words.Add(word);

            }

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
