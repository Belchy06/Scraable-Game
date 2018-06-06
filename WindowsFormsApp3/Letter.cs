using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Letter
    {
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private int _points;
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public static List<Letter> letters = new List<Letter>();


        public Letter(string letterValue, int letterPoints)
        {
            Value = letterValue;
            Points = letterPoints;
        }

        public Letter(string letterValue)
        {
            Value = letterValue;

            switch(Value)
            {
                case "A":
                    Points = 1;
                    break;
                case "B":
                    Points = 3;
                    break;
                case "C":
                    Points = 3;
                    break;
                case "D":
                    Points = 2;
                    break;
                case "E":
                    Points = 1;
                    break;
                case "F":
                    Points = 4;
                    break;
                case "G":
                    Points = 2;
                    break;
                case "H":
                    Points = 4;
                    break;
                case "I":
                    Points = 1;
                    break;
                case "J":
                    Points = 8;
                    break;
                case "K":
                    Points = 5;
                    break;
                case "L":
                    Points = 1;
                    break;
                case "M":
                    Points = 3;
                    break;
                case "N":
                    Points = 1;
                    break;
                case "O":
                    Points = 1;
                    break;
                case "P":
                    Points = 3;
                    break;
                case "Q":
                    Points = 10;
                    break;
                case "R":
                    Points = 1;
                    break;
                case "S":
                    Points = 1;
                    break;
                case "T":
                    Points = 1;
                    break;
                case "U":
                    Points = 1;
                    break;
                case "V":
                    Points = 4;
                    break;
                case "W":
                    Points = 4;
                    break;
                case "X":
                    Points = 8;
                    break;
                case "Y":
                    Points = 4;
                    break;
                case "Z":
                    Points = 10;
                    break;
            }
        }

        public static void PopulateList()
        {
            addLetter(9, "A", 1);
            addLetter(2, "B", 3);
            addLetter(2, "C", 3);
            addLetter(4, "D", 2);
            addLetter(12, "E", 1);
            addLetter(2, "F", 4);
            addLetter(3, "G", 2);
            addLetter(2, "H", 4);
            addLetter(9, "I", 1);
            addLetter(1, "J", 8);
            addLetter(1, "K", 5);
            addLetter(4, "L", 1);
            addLetter(2, "M", 3);
            addLetter(6, "N", 1);
            addLetter(8, "O", 1);
            addLetter(2, "P", 3);
            addLetter(1, "Q", 10);
            addLetter(6, "R", 1);
            addLetter(4, "S", 1);
            addLetter(6, "T", 1);
            addLetter(4, "U", 1);
            addLetter(2, "V", 4);
            addLetter(4, "W", 2);
            addLetter(1, "X", 8);
            addLetter(2, "Y", 4);
            addLetter(1, "Z", 10);
        }

        public static void addLetter(int quantity, string letter, int points)
        {
            for(int i = 0; i < quantity; i++)
            {
                Letter letterToAdd = new Letter(letter, points);
                letters.Add(letterToAdd);
            }
        }
    }
    //https://codereview.stackexchange.com/questions/94202/populating-a-bag-of-scrabble-tiles
}
