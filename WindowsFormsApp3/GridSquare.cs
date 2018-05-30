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
    public class GridSquare
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private static string _value;
        public static string value { get { return _value; } set { _value = value; } }
        private float scale = 4f;

        public Font myFont = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Pixel);

        public Graphics graphic;


        public GridSquare(int X, int Y, int Width, int Height, string Value)
        {
            _x = X;
            _y = Y;
            _width = Width;
            _height = Height;
            _value = Value;
        }

        public string getValue()
        {
            return _value;
        }

        public void updateGridSquare(string Value)
        {
            _value = Value;
        }

        public void display()
        {
            
            switch (_value)
            {
                
                case " ":
                    Form1.drawGraphics.FillRectangle(Brushes.Gray, _x, _y, _width, _height);
                    break;
                case "X":
                case "O":
                case "T":   
                    Form1.drawGraphics.FillEllipse(Brushes.LightBlue, _x, _y, _width, _height);
                    Form1.drawGraphics.DrawString(_value.ToString(), myFont, Brushes.Black, _x + _width / scale, _y + _height / scale);    
                    break;
                case "TW":
                    Form1.drawGraphics.FillRectangle(Brushes.Red, _x, _y, _width, _height);
                    Form1.drawGraphics.DrawString(_value.ToString(), myFont, Brushes.Black, _x + _width / scale, _y + _height / scale);
                    break;
            }

            
        }
    }
}
