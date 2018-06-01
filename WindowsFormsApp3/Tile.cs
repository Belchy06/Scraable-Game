using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace WindowsFormsApp3
{
    public class Tile
    {
        public Tile()
        {
            Occupied = false;
            Editable = true;
            
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private bool _isEditable;
        public bool Editable
        {
            get { return _isEditable; }
            set { _isEditable = value; }
        }

        private bool _isOccupied;
        public bool Occupied
        {
            get { return _isOccupied; }
            set { _isOccupied = value; }
        }

        private Point _position;
        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
