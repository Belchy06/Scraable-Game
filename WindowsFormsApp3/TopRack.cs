﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class TopRackTile
    {
        public TopRackTile() { }

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
    }
}
