using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Dolgozo
    {
        public string nev;
        public string neme;
        public string reszleg;
        public int belepesev;
        public int ber;

        //generate constructor
        public Dolgozo(string nev, string neme, string reszleg, int belepesev, int ber)
        {
            this.nev = nev;
            this.neme = neme;
            this.reszleg = reszleg;
            this.belepesev = belepesev;
            this.ber = ber;
        }
    }
}
