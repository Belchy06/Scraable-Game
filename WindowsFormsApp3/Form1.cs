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
        public static Bitmap rackBitmap;

        public static Graphics rackGraphics;
        public static Graphics boardGraphics;

        private int _rows;
        private int _cols;
        private int _width;
        private int _height;

        private int _rackrows;
        private int _rackcols;
        private int _rackwidth;
        private int _rackheight;

        public int tileW;
        public int tileH;

        public int rackW;
        public int rackH;

        public string[,] values;
        public int[,] cellID;

        public string[,] toprackvalues;
        public int[,] toprackcellID;

        public string[,] botrackvalues;
        public int[,] botrackcellID;

        public bool playerOneTurn;
        public bool firstTurn;

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
            _width = width;
            _height = height;
            _rows = rows;
            _cols = cols;
	        tileW = _width / _cols;
            tileH = _height / _rows;
	        boardBitmap = new Bitmap(_width, _height);
            boardGraphics = Graphics.FromImage(boardBitmap);
            boardGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

	        //Initialize arrays
            values = new string[_rows, _cols];
            cellID = new int[_rows, _cols];
            int counter = 0;

	        //Create cells on the board
            for (int i = 0; i < _rows; i++)
            {
                for(int j = 0; j < _cols; j++)
                {
                    cellID[i, j] = counter;
                    counter++;
                    values[i, j] = null;
                }
            }

            displayCells();

	        //Draw grid lines
            for (int i = 0; i <= _rows; i++)
            {
                for (int j = 0; j <= _cols; j++)
                {
                    boardGraphics.DrawLine(Pens.Black, 0, i * (_width / _cols), _cols * (_width / _cols), i * (_width / _cols));
                    boardGraphics.DrawLine(Pens.Black, j * (_height / _rows), 0, j * (_height / _rows), _rows * (_width / _rows));
                }
            }

            //Adjust form size
            this.Width = _width + 40;
            this.Height = _height + 300;

            //Change some form settings
            pbBoard = new PictureBox();
            pbBoard.Name = "Main Board";
            pbBoard.MouseClick += new MouseEventHandler(cellClicked);
            pbBoard.Image = boardBitmap;
            pbBoard.SetBounds(5, 29, _width + 4, _height);
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
                rackBitmap = null;
                pbTopRack = null;
                pbBottomRack = null;
            }
            
            //Move variables to private and initialize graphics etc
            _rackwidth = width;
            _rackheight = height;
            _rackrows = Rows;
            _rackcols = Cols;
            rackW = _rackwidth / _rackcols;
            rackH = _rackheight / _rackrows;
            rackBitmap = new Bitmap(_rackwidth, _rackheight);
            rackGraphics = Graphics.FromImage(rackBitmap);
            rackGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            #region Top Rack
            //Initialize arrays
            toprackvalues = new string[_rackrows, _rackcols];
            toprackcellID = new int[_rackrows, _rackcols];
            int counter = 0;

            //Create cells in each rack
            for (int i = 0; i < _rackrows; i++)
            {
                for (int j = 0; j < _rackcols; j++)
                {
                    toprackcellID[i, j] = counter;
                    counter++;
                    int num = rand.Next(0, 26); // Zero to 25
                    char let = (char)('a' + num);
                    toprackvalues[i, j] = let.ToString().ToUpper();
                }
            }

            displayRack("Top");

            //Draw grid lines
            for (int i = 0; i <= _rackrows; i++)
            {
                for (int j = 0; j <= _rackcols; j++)
                {
                    rackGraphics.DrawLine(Pens.Black, 0, i * (_rackwidth / _rackcols), _rackcols * (_rackwidth / _rackcols), i * (_rackwidth / _rackcols));
                    rackGraphics.DrawLine(Pens.Black, j * (_rackheight / _rackrows), 0, j * (_rackheight / _rackrows), _rackrows * (_rackwidth / _rackrows));
                }
            }

            //Change some form settings
            pbTopRack = new PictureBox();
            pbTopRack.Name = "Top Rack";
            pbTopRack.MouseClick += new MouseEventHandler(cellClicked);
            pbTopRack.Image = rackBitmap;
            pbTopRack.SetBounds(5, 29, _rackwidth + 4, _rackheight);
            pbTopRack.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pbTopRack);
            pbTopRack.Location = new Point(0, 0);
            #endregion

            #region Bottom Rack
            //Reinitialize bitmap and graphics for new rack
            rackBitmap = new Bitmap(_rackwidth, _rackheight);
            rackGraphics = Graphics.FromImage(rackBitmap);
            rackGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            
            //Initialize arrays
            botrackvalues = new string[_rackrows, _rackcols];
            botrackcellID = new int[_rackrows, _rackcols];
            counter = 0;

            //Create the cells in each rack
            for (int i = 0; i < _rackrows; i++)
            {
                for (int j = 0; j < _rackcols; j++)
                {
                    botrackcellID[i, j] = counter;
                    counter++;
                    int num = rand.Next(0, 26); // Zero to 25
                    char let = (char)('a' + num);
                    botrackvalues[i, j] = let.ToString().ToUpper();
                }
            }

            displayRack("Bottom");

            //Draw gridlines
            for (int i = 0; i <= _rackrows; i++)
            {
                for (int j = 0; j <= _rackcols; j++)
                {
                    rackGraphics.DrawLine(Pens.Black, 0, i * (_rackwidth / _rackcols), _rackcols * (_rackwidth / _rackcols), i * (_rackwidth / _rackcols));
                    rackGraphics.DrawLine(Pens.Black, j * (_rackheight / _rackrows), 0, j * (_rackheight / _rackrows), _rackrows * (_rackwidth / _rackrows));
                }
            }

            //Change some form settings
            pbBottomRack = new PictureBox();
            pbBottomRack.Name = "Bottom Rack";
            pbBottomRack.MouseClick += new MouseEventHandler(cellClicked);
            pbBottomRack.Image = rackBitmap;
            pbBottomRack.SetBounds(5, 29, _rackwidth + 4, _rackheight);
            pbBottomRack.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pbBottomRack);
            pbBottomRack.Location = new Point(0, 675);
            #endregion
        }


        private void displayCells()
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
                    int ID = cellID[i, j];

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
                            rackGraphics.DrawString(toprackvalues[i, j], myFont, Brushes.Black, drawX, drawY);
                            break;

                        case "Bottom":
                            rackGraphics.DrawString(botrackvalues[i, j], myFont, Brushes.Black, drawX, drawY);
                            break;
                    }
                }
            }

            //Forces execution of all pending graphics operations and returns immediately without waiting for the operations to finish
            rackGraphics.Flush();
            this.Refresh();
        }


        private void placeLetter(int letterRow, int letterCol)
        {
            //Retrieve the letter that needs to be rendered
            letterToPlace = values[letterRow,letterCol];
            
            //Maths to solve x and y position of the letter
            int _letterx = letterCol * tileW;
            int _lettery = letterRow * tileH;
            int drawX = _letterx + tileW / 3;
            int drawY = _lettery + tileH / 3;
            
            //Fill rectangle behind the letter and then render the letter onto this rectangle
            boardGraphics.FillRectangle(customBrush, _letterx, _lettery, tileW, tileH);
            boardGraphics.DrawString(letterToPlace, myFont, Brushes.Black, drawX, drawY);
            pbBoard.Image = boardBitmap;

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
            col = e.X * _cols / _width;
            oldVal = values[row, col];

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
                            txtDebug.Text = "X: " + col + ", Y: " + row + ", Old Value: " + oldVal + ", New Value: " + values[row, col] + ", ID: " + cellID[row, col];
                            break;

                        case MouseButtons.Left:
                            //If letterToPlace has a letter, then update the value stored in the cell and then render this letter to the cell
                            if (letterToPlace != null)
                            {
                                values[row, col] = letterToPlace;
                                placeLetter(row, col);
                            }
                            txtDebug.Text = "X: " + col + ", Y: " + row + ", Old Value: " + oldVal + ", New Value: " + values[row, col] + ", ID: " + cellID[row, col];
                            break;
                    }
                    break;
                #endregion
                #region Bottom Rack
                case "Bottom Rack":
                    //If bottomrack then retrieve value from bottomrack array
                    row = e.Y * _rackrows / _rackheight;
                    col = e.X * _rackcols / _rackwidth;
                    oldVal = botrackvalues[row, col];

                    //TODO retrieve tile value
                    letterToPlace = botrackvalues[row, col];
                    break;
                #endregion
                #region Top Rack
                case "Top Rack":
                    //If toprack then retrieve value from toprack array
                    row = e.Y * _rackrows / _rackheight;
                    col = e.X * _rackcols / _rackwidth;
                    oldVal = toprackvalues[row, col];

                    //TODO retrieve tile value
                    letterToPlace = toprackvalues[row, col];
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
            int ID = cellID[cellRow, cellCol];
            values[cellRow, cellCol] = null;

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
                    boardGraphics.DrawLine(Pens.Black, 0, i * (_width / _cols), _cols * (_width / _cols), i * (_width / _cols));
                    boardGraphics.DrawLine(Pens.Black, j * (_height / _rows), 0, j * (_height / _rows), _rows * (_width / _rows));
                }
            }

            //Forces execution of all pending graphics operations and returns immediately without waiting for the operations to finish
            boardGraphics.Flush();
            this.Refresh();
        }


        private void endTurn()
        {

        }


        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            endTurn();
        }
    }
}
