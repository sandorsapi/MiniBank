using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minibank
{
    class NormalSzamla
    {
        private int felhasznIndex;
        private string szamlaszam;
        private int mennyiseg;
        private string felhasznaloNev;

        public NormalSzamla() { }

        public NormalSzamla(int fIndex, string szSzam, string felhasznalo, int betet)
        {
                felhasznIndex = fIndex;
                szamlaszam = szSzam;
                mennyiseg = betet;
                felhasznaloNev = felhasznalo;
              
        }

        public int IndexTarolo
        {
            get { return felhasznIndex; }
            set { felhasznIndex = value; }
        }
        public string SzamlaSzamTarolo
        {
            get { return szamlaszam; }
            set { szamlaszam = value; }
        }

        public int MennyisegTarolo
        {
            get { return mennyiseg; }
            set { mennyiseg = value; }
        }

        public string FelhasznaloTarolo
        {
            get { return felhasznaloNev; }
            set { felhasznaloNev = value; }
        }

    }
}
