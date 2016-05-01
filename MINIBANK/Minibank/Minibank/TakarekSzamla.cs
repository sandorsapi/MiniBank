using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minibank
{
    class TakarekSzamla : NormalSzamla
    {
        private double kamatlab;

        public  TakarekSzamla() {}

        public TakarekSzamla(int fIndex, string szSzam, string felhasznalo, int betet) 
            : base (fIndex, szSzam, felhasznalo, betet) {}
        
        public double KamatLabAdat
        {
            get { return kamatlab; }
            set { kamatlab = value; }
        }
    }
}
