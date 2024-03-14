using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DijkstraApp
{
    public class Cvor
    {

        public String ime { get; set; } //identifikator čvora - po imenu ih razlikujemo
        public int status { get; set; } // je li privremeni ili konačan
        public Cvor prijasnji { get; set; } // pamti se prijašnji čvor, postavlja se na null na početku 

        public int duljinaPuta { get; set; } // najmanja duljina puta od izvorišnog čvora do ovog

        public Point koordinate { get; set; } // koordinate za crtanje linija i točaka

        public Cvor(String ime)
        {
            this.ime = ime;
            /* popuni ostalo na pocetne vrijednosti na početku algoritma */
        }
    }
}
