using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Letter
    {
        private string _letters;
        public string Letters
        {
            get { return _letters; }
            set { _letters = value; }
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Letter(string letter)
        {
            switch (letter)
            {
                case " ":
                    _value = 0;
                    break;
                case "a":
                case "e":
                case "i":
                case "o":
                case "u":
                case "l":
                case "n":
                case "s":
                case "t":
                case "r":
                    _value = 1;
                    break;
                case "d":
                case "g":
                    _value = 2;
                    break;
                case "b":
                case "c":
                case "m":
                case "p":
                    _value = 3;
                    break;
                case "f":
                case "h":
                case "v":
                case "w":
                case "y":
                    _value = 4;
                    break;
                case "k":
                    _value = 5;
                    break;
                case "j":
                case "x":
                    _value = 8;
                    break;
                case "q":
                case "z":
                    _value = 10;
                    break;
                default:
                    //console.out.writeline("invalid tile created!");
                    break;
            }
        }
    }
}
