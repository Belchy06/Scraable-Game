using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        #region variables
        public static Bitmap boardBitmap;
        public static Bitmap topRack;
        public static Bitmap bottomRack;

        public static Graphics rackGraphics;
        public static Graphics boardGraphics;

        private int _rows;
        private int _cols;    
        private int _height;

        private int _formwidth;

        private int _rackrows;
        private int _rackcols;
        private int _rackheight;

        private int tileW;
        private int tileH;

        private int rackW;
        private int rackH;

        private Tile[,] Tiles;
        private TopRackTile[,] TopRack;
        private BottomRackTile[,] BottomRack;

        private bool playerOneTurn;
        private bool firstTurn;

        Random rand = new Random();

        private string letterToPlace;

        static Color customColour = Color.FromArgb(240, 240, 240);
        SolidBrush customBrush = new SolidBrush(customColour);

        Font myFont = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Pixel);
        #endregion

        public Form1()
        {
            InitializeComponent();

            playerOneTurn = true;
            firstTurn = true;
            this.Text = "Player One's Turn!";

            setupRack(600, 75, 1, 8);
            setupBoard(600, 600, 15, 15);
            
        }


        private void setupBoard(int width, int height, int rows, int cols)
        {
            //If picturebox1 has image then remove it
            if (pbBoard != null)
            {
                this.Controls.Remove(pbBoard);
                this.Refresh();
                boardBitmap = null;
                pbBoard = null;
            }

            //Move variables to private and initialize graphics etc.
            _formwidth = width;
            _height = height;
            _rows = rows;
            _cols = cols;
	        tileW = _formwidth / _cols;
            tileH = _height / _rows;
	        boardBitmap = new Bitmap(_formwidth, _height);
            boardGraphics = Graphics.FromImage(boardBitmap);
            boardGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //Initialize arrays
            Tiles = new Tile[_rows, _cols];
            int counter = 0;

	        //Create cells on the board
            for (int i = 0; i < _rows; i++)
            {
                for(int j = 0; j < _cols; j++)
                {
                    Tiles[i, j] = new Tile();
                    Tiles[i, j].ID = counter;
                    Tiles[i, j].Value = null;
                    counter++;
                }
            }

            renderTiles();

            //Adjust form size
            this.Width = _formwidth + 40;
            this.Height = _height + 300;

            //Change some form settings
            pbBoard = new PictureBox();
            pbBoard.Name = "Main Board";
            pbBoard.MouseClick += new MouseEventHandler(cellClicked);
            pbBoard.Image = boardBitmap;
            pbBoard.SetBounds(5, 29, _formwidth + 4, _height);
            pbBoard.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pbBoard);
            pbBoard.Location = new Point(0, 75);
        }


        private void setupRack(int width, int height, int Rows, int Cols)
        {
            //If top and bottom rack pb's are occupied then clear them
            if (pbTopRack != null || pbBottomRack != null)
            {
                this.Controls.Remove(pbTopRack);
                this.Controls.Remove(pbBottomRack);
                this.Refresh();
                topRack = null;
                bottomRack = null;
                pbTopRack = null;
                pbBottomRack = null;
            }

            //Move variables to private and initialize graphics etc
            _formwidth = width;
            _rackheight = height;
            _rackrows = Rows;
            _rackcols = Cols;
            rackW = _formwidth / _rackcols;
            rackH = _rackheight / _rackrows;

            #region Top Rack
            //Initialize Bitmap and Graphics
            topRack = new Bitmap(_formwidth, _rackheight);
            rackGraphics = Graphics.FromImage(topRack);
            rackGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //Initialize arrays
            TopRack = new TopRackTile[_rackrows, _rackcols];
            int counter = 0;

            //Create cells in each rack
            for (int i = 0; i < _rackrows; i++)
            {
                for (int j = 0; j < _rackcols; j++)
                {
                    TopRack[i, j] = new TopRackTile();
                    TopRack[i, j].ID = counter;
                    counter++;

                    int num = rand.Next(0, 26); // Zero to 25
                    char let = (char)('a' + num);
                    TopRack[i,j].Value = let.ToString().ToUpper();
                }
            }

            displayRack("Top");

            //Change some form settings
            pbTopRack = new PictureBox();
            pbTopRack.Name = "Top Rack";
            pbTopRack.MouseClick += new MouseEventHandler(cellClicked);
            pbTopRack.Image = topRack;
            pbTopRack.SetBounds(5, 29, _formwidth + 4, _rackheight);
            pbTopRack.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pbTopRack);
            pbTopRack.Location = new Point(0, 0);
            #endregion

            #region Bottom Rack
            //Initialize bitmap and graphics for rack
            bottomRack = new Bitmap(_formwidth, _rackheight);
            rackGraphics = Graphics.FromImage(bottomRack);
            rackGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            //Initialize arrays
            BottomRack = new BottomRackTile[_rackrows, _rackcols];
            counter = 0;

            //Create the cells in each rack
            for (int i = 0; i < _rackrows; i++)
            {
                for (int j = 0; j < _rackcols; j++)
                {
                    BottomRack[i, j] = new BottomRackTile();
                    BottomRack[i, j].ID = counter;
                    counter++;

                    int num = rand.Next(0, 26); // Zero to 25
                    char let = (char)('a' + num);
                    BottomRack[i, j].Value = let.ToString().ToUpper();
                }
            }

            displayRack("Bottom");

            //Change some form settings
            pbBottomRack = new PictureBox();
            pbBottomRack.Name = "Bottom Rack";
            pbBottomRack.MouseClick += new MouseEventHandler(cellClicked);
            pbBottomRack.Image = bottomRack;
            pbBottomRack.SetBounds(5, 29, _formwidth + 4, _rackheight);
            pbBottomRack.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pbBottomRack);
            pbBottomRack.Location = new Point(0, 675);
            #endregion
        }


        private void renderTiles()
        {
            //Clear background colour
            boardGraphics.Clear(this.BackColor);

            //For loop to go through each cell that way created
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    //Maths to figure out x and y position of each cell
                    int _x = j * tileW;
                    int _y = i * tileH;
                    int drawX = _x - 10 + tileW / 3;
                    int drawY = _y + tileH / 3;

                    //Get ID from cellID array
                    int ID = Tiles[i, j].ID;

                    switch (ID)
                    {
                        #region Triple Words
                        case 0:
                        case 7:
                        case 14:
                        case 105:
                        case 119:
                        case 210:
                        case 217:
                        case 224:
                            boardGraphics.FillRectangle(Brushes.Orange, _x, _y, tileW, tileH);
                            boardGraphics.DrawString("TW", myFont, Brushes.Black, drawX, drawY);
                            break;
                        #endregion
                        #region Double Words
                        case 16:
                        case 28:
                        case 32:
                        case 42:
                        case 48:
                        case 56:
                        case 64:
                        case 70:
                        case 154:
                        case 160:
                        case 168:
                        case 176:
                        case 182:
                        case 192:
                        case 196:
                        case 208:
                            boardGraphics.FillRectangle(Brushes.Red, _x, _y, tileW, tileH);
                            boardGraphics.DrawString("DW", myFont, Brushes.Black, drawX, drawY);
                            break;
                        #endregion
                        #region Double Letter
                        case 3:
                        case 11:
                        case 36:
                        case 38:
                        case 52:
                        case 59:
                        case 45:
                        case 92:
                        case 96:
                        case 98:
                        case 102:
                        case 108:
                        case 116:
                        case 122:
                        case 126:
                        case 128:
                        case 132:
                        case 165:
                        case 172:
                        case 179:
                        case 186:
                        case 188:
                        case 213:
                        case 221:
                            boardGraphics.FillRectangle(Brushes.LightBlue, _x, _y, tileW, tileH);
                            boardGraphics.DrawString("DL", myFont, Brushes.Black, drawX, drawY);
                            break;
                        #endregion
                        #region Triple Letter
                        case 20:
                        case 24:
                        case 76:
                        case 80:
                        case 84:
                        case 88:
                        case 136:
                        case 140:
                        case 144:
                        case 148:
                        case 200:
                        case 204:
                            boardGraphics.FillRectangle(Brushes.Green, _x, _y, tileW, tileH);
                            boardGraphics.DrawString("TL", myFont, Brushes.Black, drawX, drawY);
                            break;
                        #endregion
                        #region Centre Star
                        case 112:
                            //Fill cell with pink background
                            boardGraphics.FillRectangle(Brushes.Pink, _x, _y, tileW, tileH);

                            //Create array for the 10 points of the star
                            Point[] starPoints = new Point[10];

                            //Maths to solve the x and y position of each point in the star. Starting at the top and working counter-clockwise
                            starPoints[0] = new Point(_x + tileW / 2, _y);
                            starPoints[1] = new Point(_x + tileW / 3, _y + tileH / 3);
                            starPoints[2] = new Point(_x, _y + tileH / 3);
                            starPoints[3] = new Point(_x + tileW / 3, _y + 4 * (tileH / 6));
                            starPoints[4] = new Point(_x + tileW / 6, _y + tileH);
                            starPoints[5] = new Point(_x + tileW / 2, _y + 5 * (tileH / 6));
                            starPoints[6] = new Point(_x + tileW - (tileW / 6), _y + tileH);
                            starPoints[7] = new Point(_x + tileW - tileW / 3, _y + 4 * (tileH / 6));
                            starPoints[8] = new Point(_x + tileW, _y + tileH / 3);
                            starPoints[9] = new Point(_x + 2 * (tileW / 3), _y + tileH / 3);

                            //Draw and fill star
                            boardGraphics.FillPolygon(Brushes.Black, starPoints);
                            break;
                        #endregion
                    }
                }
            }

            //Draw grid lines
            for (int i = 0; i <= _rows; i++)
            {
                for (int j = 0; j <= _cols; j++)
                {
                    boardGraphics.DrawLine(Pens.Black, 0, i * (_formwidth / _cols), _cols * (_formwidth / _cols), i * (_formwidth / _cols));
                    boardGraphics.DrawLine(Pens.Black, j * (_height / _rows), 0, j * (_height / _rows), _rows * (_formwidth / _rows));
                }
            }

            //Forces execution of all pending graphics operations and returns immediately without waiting for the operations to finish
            boardGraphics.Flush();
            this.Refresh();
        }


        private void displayRack(string rackPosition)
        {
            //Clear background color
            rackGraphics.Clear(this.BackColor);

            //For loop for each cell in the rack
            for (int i = 0; i < _rackrows; i++)
            {
                for (int j = 0; j < _rackcols; j++)
                {
                    //Maths to solve x and y position of each letter in the rack
                    int _rackx = j * rackW;
                    int _racky = i * rackH;
                    int drawX = _rackx - 10 + rackW / 3;
                    int drawY = _racky + rackH / 3;

                    //Switch statement to figure out from which array to retrieve letter from depending on the rack
                    switch(rackPosition)
                    {
                        case "Top":
                            rackGraphics.DrawString(TopRack[i,j].Value, myFont, Brushes.Black, drawX, drawY);
                            break;

                        case "Bottom":
                            rackGraphics.DrawString(BottomRack[i, j].Value, myFont, Brushes.Black, drawX, drawY);
                            break;
                    }
                }
            }

            //Draw grid lines
            for (int i = 0; i <= _rackrows; i++)
            {
                for (int j = 0; j <= _rackcols; j++)
                {
                    rackGraphics.DrawLine(Pens.Black, 0, i * (_formwidth / _rackcols), _rackcols * (_formwidth / _rackcols), i * (_formwidth / _rackcols));
                    rackGraphics.DrawLine(Pens.Black, j * (_rackheight / _rackrows), 0, j * (_rackheight / _rackrows), _rackrows * (_formwidth / _rackrows));
                }
            }

            //Forces execution of all pending graphics operations and returns immediately without waiting for the operations to finish
            rackGraphics.Flush();
            this.Refresh();
        }


        private void placeLetter(int letterRow, int letterCol)
        {
            //Retrieve the letter that needs to be rendered
            letterToPlace = Tiles[letterRow,letterCol].Value;
            Tiles[letterRow, letterCol].Occupied = true;
            
            //Maths to solve x and y position of the letter
            int _letterx = letterCol * tileW;
            int _lettery = letterRow * tileH;
            int drawX = _letterx + tileW / 3;
            int drawY = _lettery + tileH / 3;

            if (Tiles[letterRow, letterCol].Editable == true)
            {
                //Fill rectangle behind the letter and then render the letter onto this rectangle
                boardGraphics.FillRectangle(customBrush, _letterx, _lettery, tileW, tileH);
                boardGraphics.DrawString(letterToPlace, myFont, Brushes.Black, drawX, drawY);
                pbBoard.Image = boardBitmap; 
            } 
            else
            {
                MessageBox.Show("There is already a letter on that tile!");
            }

            //Forces execution of all pending graphics operations and returns immediately without waiting for the operations to finish
            rackGraphics.Flush();
            this.Refresh();
        }


        private void cellClicked(object sender, MouseEventArgs e)
        {
            //Store the information of the picturebox clicked in the myPicture variable
            PictureBox myPicture = (PictureBox)sender;

            //Initialize variables
            int row;
            int col;
            string oldVal;

            //Maths to figure out which cell was clicked base on the x and y position of the mouse
            row = e.Y * _rows / _height;
            col = e.X * _cols / _formwidth;
            oldVal = Tiles[row, col].Value;

            //Switch statement based on the names of the picture box clicked. Names were given in the setupBoard and setupRack functions
            switch (myPicture.Name)
            {
                #region Main Board
                case "Main Board":
                    //If main board, execute another switch to see which mouse button was clicked and execute code
                    switch(e.Button)
                    {
                        case MouseButtons.Right:
                            //Render the default look of the cell, whether this is a default, or special tiles does not matter
                            renderDefaultCell(row, col);
                            txtDebug.Text = "X: " + col + ", Y: " + row + ", Old Value: " + oldVal + ", New Value: " + Tiles[row, col].Value + ", ID: " + Tiles[row, col].ID;
                            break;

                        case MouseButtons.Left:
                            //If letterToPlace has a letter, then update the value stored in the cell and then render this letter to the cell
                            if (letterToPlace != null)
                            {
                                Tiles[row, col].Value = letterToPlace;
                                placeLetter(row, col);
                            }
                            txtDebug.Text = "X: " + col + ", Y: " + row + ", Old Value: " + oldVal + ", New Value: " + Tiles[row, col].Value + ", ID: " + Tiles[row, col].ID;
                            break;
                    }
                    break;
                #endregion
                #region Bottom Rack
                case "Bottom Rack":
                    //If bottomrack then retrieve value from bottomrack array
                    row = e.Y * _rackrows / _rackheight;
                    col = e.X * _rackcols / _formwidth;
                    oldVal = BottomRack[row, col].Value;

                    //TODO retrieve tile value
                    letterToPlace = BottomRack[row, col].Value;
                    break;
                #endregion
                #region Top Rack
                case "Top Rack":
                    //If toprack then retrieve value from toprack array
                    row = e.Y * _rackrows / _rackheight;
                    col = e.X * _rackcols / _formwidth;
                    oldVal = TopRack[row, col].Value;

                    //TODO retrieve tile value
                    letterToPlace = TopRack[row, col].Value;
                    break;
                #endregion
            }
        }


        private void renderDefaultCell(int cellRow, int cellCol)
        {
            //Update graphics smoothing mode to give an antialiased line, more useful for the center star
            boardGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;



            //Maths to figure x and y positions of the letter
            int _x = cellCol * tileW;
            int _y = cellRow * tileH;
            int drawX = _x - 10 + tileW / 3;
            int drawY = _y + tileH / 3;

            //Get ID of cell and then update value stored
            int ID = Tiles[cellRow, cellCol].ID;
            Tiles[cellRow, cellCol].Value = null;
            Tiles[cellRow, cellCol].Occupied = false;

            switch (ID)
            {
                #region Triple Word
                case 0:
                case 7:
                case 14:
                case 105:
                case 119:
                case 210:
                case 217:
                case 224:
                    boardGraphics.FillRectangle(Brushes.Orange, _x, _y, tileW, tileH);
                    boardGraphics.DrawString("TW", myFont, Brushes.Black, drawX, drawY);
                    break;
                #endregion
                #region Double Word
                case 16:
                case 28:
                case 32:
                case 42:
                case 48:
                case 56:
                case 64:
                case 70:
                case 154:
                case 160:
                case 168:
                case 176:
                case 182:
                case 192:
                case 196:
                case 208:
                    boardGraphics.FillRectangle(Brushes.Red, _x, _y, tileW, tileH);
                    boardGraphics.DrawString("DW", myFont, Brushes.Black, drawX, drawY);
                    break;
                #endregion
                #region Double Letter
                case 3:
                case 11:
                case 36:
                case 38:
                case 52:
                case 59:
                case 45:
                case 92:
                case 96:
                case 98:
                case 102:
                case 108:
                case 116:
                case 122:
                case 126:
                case 128:
                case 132:
                case 165:
                case 172:
                case 179:
                case 186:
                case 188:
                case 213:
                case 221:
                    boardGraphics.FillRectangle(Brushes.LightBlue, _x, _y, tileW, tileH);
                    boardGraphics.DrawString("DL", myFont, Brushes.Black, drawX, drawY);
                    break;
                #endregion
                #region Triple Letter
                case 20:
                case 24:
                case 76:
                case 80:
                case 84:
                case 88:
                case 136:
                case 140:
                case 144:
                case 148:
                case 200:
                case 204:
                    boardGraphics.FillRectangle(Brushes.Green, _x, _y, tileW, tileH);
                    boardGraphics.DrawString("TL", myFont, Brushes.Black, drawX, drawY);
                    break;
                #endregion
                #region Center Star
                case 112:
                    boardGraphics.FillRectangle(Brushes.Pink, _x, _y, tileW, tileH);
                    Point[] starPoints = new Point[10];
                    starPoints[0] = new Point(_x + tileW / 2, _y);
                    starPoints[1] = new Point(_x + tileW / 3, _y + tileH / 3);
                    starPoints[2] = new Point(_x, _y + tileH / 3);
                    starPoints[3] = new Point(_x + tileW / 3, _y + 4 * (tileH / 6));
                    starPoints[4] = new Point(_x + tileW / 6, _y + tileH);
                    starPoints[5] = new Point(_x + tileW / 2, _y + 5 * (tileH / 6));
                    starPoints[6] = new Point(_x + tileW - (tileW / 6), _y + tileH);
                    starPoints[7] = new Point(_x + tileW - tileW / 3, _y + 4 * (tileH / 6));
                    starPoints[8] = new Point(_x + tileW, _y + tileH / 3);
                    starPoints[9] = new Point(_x + 2 * (tileW / 3), _y + tileH / 3);
                    boardGraphics.FillPolygon(Brushes.Black, starPoints);
                    break;
                #endregion
                #region Default Cell
                default:
                    boardGraphics.FillRectangle(customBrush, _x, _y, tileW, tileH);
                    break;
                #endregion
            }

            //Draw Gridlines
            for (int i = 0; i <= _rows; i++)
            {
                for (int j = 0; j <= _cols; j++)
                {
                    boardGraphics.DrawLine(Pens.Black, 0, i * (_formwidth / _cols), _cols * (_formwidth / _cols), i * (_formwidth / _cols));
                    boardGraphics.DrawLine(Pens.Black, j * (_height / _rows), 0, j * (_height / _rows), _rows * (_formwidth / _rows));
                }
            }

            //Forces execution of all pending graphics operations and returns immediately without waiting for the operations to finish
            boardGraphics.Flush();
            this.Refresh();
        }


        private void endTurn()
        {
            if(firstTurn == true)
            {
                if(Tiles[7,7].Occupied ==false)
                {
                    MessageBox.Show("Make sure the center tile is occupied on the first turn", "Center Tile not occupied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            findOccupiedTiles();

            playerOneTurn = !playerOneTurn;
            if(playerOneTurn == true)
            {
                this.Text = "Player One's Turn!";
            }
            else
            {
                this.Text = "Player Two's Turn!";
            }
        }


        private void findOccupiedTiles()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if(Tiles[i,j].Occupied == true)
                    {
                        Tiles[i, j].Editable = false;
                    }
                }
            }
        }


        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            endTurn();
        }
    }
}
