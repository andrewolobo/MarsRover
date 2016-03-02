using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {

        static void Main(string[] args)
        {
            //Print out line below
            Console.WriteLine("Enter Rover Position;");
            //Read Position Input from user separated by spaces e.g. 1 3 N
            var position = Console.ReadLine();
            var split_return = position.Split(' ');
            Int32 x = Int32.Parse(split_return[0]);
            Int32 y = Int32.Parse(split_return[1]);
            string direction = split_return[2];
            //Instantiate Rover Class
            Rover r = new Rover(x, y, direction);
            //Allow Command input e.g. LMLMLMLMM
            Console.WriteLine("Enter Command Directive");
            var directive = Console.ReadLine();
            //Run Rover Command
            r.executeDirective(directive);
            //Print Out Final Results
            Console.WriteLine(r.posx + " " + r.posy + " " + r.direction);
            Console.ReadLine();
        }

    }
    class Rover
    {
        //Rover Position
        public Int32 posx = 0;
        public Int32 posy = 0;
        //Position Polarity(+,-)
        public Int32 polx = 1;
        public Int32 poly = 1;
        //Rover Previous Positions
        public Int32 prevx = 0;
        public Int32 prevy = 0;
        public String direction = "N";
        //This Creates a new Rover
        public Rover(int x, int y, String direction)
        {
            //Assign Rover Position and Direction Variables
            posx = x;
            posy = y;
            this.direction = direction;

        }
        public void executeDirective(String directive)
        {
            //Read Through the directive For the Following Keys. i.e. M for Move, R for Rotate right, L for Rotate Left
            foreach (char c in directive)
            {
                if (c == 'M')
                {
                    PlaceRover(direction);
                }
                if (c == 'L')
                {
                    Rotate("L");
                }
                if (c == 'R')
                {
                    Rotate("R");
                }
            }
        }
        //Given NESW, North South East and West, the PlaceRover function, takes the rover direction, and moves it one step in that direction
        //posx and poly variables store the negative or positive values attached to a direction.
        //i.e. When N, polx is going in a positive direction so its a signed integer(1)
        //and When S poly is going in a negative direction hence its an unsigned integer(-1)

        public void PlaceRover(String direction)
        {
            if (direction == "N")
            {
                poly = 1;
                posy = posy + ((poly) * 1);
            }
            else if (direction == "E")
            {
                polx = 1;
                posx = posx + ((polx) * 1);
            }
            else if (direction == "S")
            {

                poly = -1;
                posy = posy + ((poly) * 1);
            }
            else if (direction == "W")
            {
                polx = -1;
                posx = posx + ((polx) * 1);
            }
        }
        //This Rotates the rover, Its pretty basic, When L Move anti-clockwise, that is From the direction North, the sequence is NWSE
        //and for R move clockwise which is the sequence NESW
        public void Rotate(String rotation)
        {
            if (rotation == "L")
            {
                if (this.direction == "N")
                {
                    this.direction = "W";
                }
                else if (this.direction == "E")
                {
                    this.direction = "N";
                }
                else if (this.direction == "S")
                {
                    this.direction = "E";
                }
                else if (this.direction == "W")
                {
                    this.direction = "S";
                }

            }
            if (rotation == "R")
            {
                if (this.direction == "N")
                {
                    this.direction = "E";
                }
                else if (this.direction == "E")
                {
                    this.direction = "S";
                }
                else if (this.direction == "S")
                {
                    this.direction = "W";
                }
                else if (this.direction == "W")
                {
                    this.direction = "N";
                }

            }
        }
        //Failed experiments Just
        //Redacted
        public void DropRover(String direction)
        {
            if (direction == "N")
            {
                polx = 1;
                poly = 1;
                posx = posx * polx;
                posy = posy * poly;
            }
            else if (direction == "E")
            {
                polx = 1;
                poly = -1;
                posx = posx * polx;
                posy = posy * poly;
            }
            else if (direction == "S")
            {
                polx = -1;
                poly = -1;
                posx = posx * polx;
                posy = posy * poly;
            }
            else if (direction == "A")
            {
                polx = -1;
                poly = 1;
                posx = posx * polx;
                posy = posy * poly;
            }
        }
        //More Failed experiements
        //Redacted
        //If the solution is less elegant than it should be your not thinking well enough
        public void move()
        {
            //Heading North
            if (polx > 0 && poly > 0)
            {
                poly += 1;

            }//Heading West
            else if (polx < 0 && poly > 0)
            {
                polx -= 1;
            }//Heading South
            else if (polx < 0 && poly < 0)
            {
                poly -= 1;
            }//Heading East
            else if (polx > 0 && poly < 0)
            {
                polx += 1;
            }

        }
        //Another Failed Experiment
        public void direct(String directive)
        {
            if (posx > 0 && prevx > 0)
            {
                polx = -1;
                prevx = posx;
                posx = posx * polx;
            }
            else if (posx < 0 && prevx > 0)
            {
                prevx = posx;
            }
            if (posx < 0 && prevx < 0)
            {
                polx = -1;
                prevx = posx;
                posx = posx * polx;
            }
            else if (posx > 0 && prevx < 0)
            {
                prevx -= prevx;
            }
            if (posy > 0 && prevy < 0)
            {
                poly = -1;
                prevy = posy;
                posy = posy * poly;
            }
            else if (posy < 0 && prevy > 0)
            {
                prevy -= prevy;
            }
            else if (posy < 0 && prevy < 0)
            {
                poly = -1;
                prevy = posy;
                posy = posy * poly;
            }
        }
    }
}
