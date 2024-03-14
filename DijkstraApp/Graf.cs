using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DijkstraApp
{
    public class Graf
    {
        List<String> listaS = new List<string>();
        public StringBuilder tekst;
        public readonly int PRIVREMENI = 1;
        public readonly int KONACNI = 2;
        public readonly Cvor NIL = null;
        public readonly int BESKONACNO = 99999;


        public List<Cvor> listaCvorova { get; set; }
        public Dictionary<(String prvi, String drugi), int> dict { get; set; }
        public Graf()
        {
            listaCvorova = new List<Cvor>();
            dict = new Dictionary<(String prvi, String drugi), int>();
            this.tekst = new StringBuilder(400);
        }


        public void refreshDijkstra(List<Cvor> cvorovi) //probavanje inicijalizacije dijkstre dok se pokrece 2. put
        {
            foreach(Cvor cvor in cvorovi)
            {
                cvor.status = PRIVREMENI;
                cvor.prijasnji = NIL;
                cvor.duljinaPuta = BESKONACNO;

            }
        }
        public void DodajUListu(String imeCvora, int x, int y)
        {
            Cvor cvor = new Cvor(imeCvora)
            {
                status = PRIVREMENI,
                prijasnji = NIL,
                duljinaPuta = BESKONACNO,
                koordinate = new Point(x, y)
            };

            listaCvorova.Add(cvor);
        }


        public void DodajUDict(String prvi, String drugi, int udaljenost)
        {
            dict.Add((prvi, drugi), udaljenost);
        }

        public Cvor PronadiPrivremeniMinimumPut()
        {
            int min = BESKONACNO;  //mora bit globalno? nez
            Cvor nadeni = null;

            foreach (Cvor cvor in listaCvorova)
            {
                if (cvor.status == PRIVREMENI && cvor.duljinaPuta < min)
                {
                    min = cvor.duljinaPuta;
                    nadeni = cvor;
                }
            }

            return nadeni;
        }


        public Cvor VratiCvor(String ime) /*funkciji dajemo ime i dobivamo natrag sve informacije o cvoru*/
        {
            Cvor trazeni = null;
            foreach (Cvor cvor in listaCvorova)
            {
                if (cvor.ime == ime)
                {
                    trazeni = cvor;
                }

            }
            return trazeni;
        }

        public int JesuLiSusjedi(Cvor prvi, Cvor drugi)
        {

            if (dict.TryGetValue((prvi.ime, drugi.ime), out int udaljenost)) //ili obrnuto !!!!
            {
                return udaljenost;
            }
            else if (dict.TryGetValue((drugi.ime, prvi.ime), out int udaljenost2))
            {
                return udaljenost2;
            }

            return -1;

            //ak jesu susjedi vrati udaljenost, ak nisu -1
        }
        private void Dijkstra(String ime)
        {
            //tekst = new StringBuilder(300);
            
            Cvor pocetak;
            Cvor trenutni;
            int temp = -1;
            int brojac = -1;
            

            pocetak = VratiCvor(ime); //pronasli smo pocetni cvor (source) i postavljamo njegovu duljinuputa na 0

            tekst.Append("Postavljamo duljinu početnog čvora: " + pocetak.ime + " na 0, a duljinu svih ostalih čvorova na beskonačnost\n");
            //listaS.Add(ime);
            //tekst.Append("Lista S(" + brojac + "): {" + string.Join(",", listaS)+ "} i = "+brojac+"\n");
            pocetak.duljinaPuta = 0;
            tekst.Append("Traži se čvor s najkraćom duljinom puta, taj čvor se postavlja kao KONAČAN, i to se ponavlja" +
                "dok se ne prođu svi čvorovi\n");
            tekst.Append("Kad postavimo čvor na konačan, znači da je određen put do njega\nAlgoritam se može zaustaviti " +
                "kad dođemo do čvora odredišta, ali ovdje je radi primjera uvijek proveden do kraja.\n\n");
            while (true)
            {
                
                trenutni = PronadiPrivremeniMinimumPut(); //trazi se cvor s najkracim putem

                if (trenutni == null)
                {
                    return;
                }

                //tekst.Append("Trenutni " + trenutni.ime+ "\n");
                trenutni.status = KONACNI;
                brojac++;
                listaS.Add(trenutni.ime);
                //tekst.Append("Udaljenost ostalih čvorova postavljena je na beskonačnost.\n");
                tekst.Append("\nČvor s najmanjom udaljenosti (postaje konačan): *" + trenutni.ime + "* \nLista S(" + brojac + "): {" + string.Join(",", listaS) + "} i = " + brojac + "\n");



                foreach (Cvor cvor in listaCvorova)
                {
                    temp = -1;


                    temp = JesuLiSusjedi(cvor, trenutni);

                    if (temp > 0 && cvor.status == PRIVREMENI) //provjeri je li susjed s trenutnim cvorom c i je li temporary
                    {
                        if (trenutni.duljinaPuta + temp < cvor.duljinaPuta)  // ako je, provjeri ak je duljinaPuta + trenutna udaljenost (iz dictionarija) < duljina puta - 
                        {
                            cvor.prijasnji = trenutni;
                            cvor.duljinaPuta = trenutni.duljinaPuta + temp; // ako je - promijeni prijasnji cvor i promijeni duljinu puta
                        }
                    }
                    
                    if (cvor.duljinaPuta != BESKONACNO && (!listaS.Contains(cvor.ime))) { 
                        tekst.Append("Najmanja duljina čvora " + cvor.ime + " je " + cvor.duljinaPuta + "\n"); }
                   

                }

                
                
                

            }


        }

        /*public void NadiPuteve(String ime)
        {
            Dijkstra(ime);

            Console.WriteLine("Čvor izvor je: " + ime + "\n");

            foreach (Cvor cvor in listaCvorova)
            {
                Console.WriteLine("Krajnji čvor je: " + cvor.ime + "\n");
                if (cvor.duljinaPuta == BESKONACNO)
                {
                    Console.WriteLine("Nema puta od početnog čvora izvora" + ime + " do krajnjeg čvora" + cvor.ime);

                }
                else NadiPut(ime, cvor.ime);

            }
         
        } */
        public void NadiPuteve1(String pocetak, String kraj, Graphics g, TextBox box)
        {
            Cvor krajnji = VratiCvor(kraj);
            Dijkstra(pocetak);

            
            Console.WriteLine("Krajnji čvor je: " + kraj + "\n");
            if (krajnji.duljinaPuta == BESKONACNO)
            {
                Console.WriteLine("Nema puta od početnog čvora " + pocetak + " do krajnjeg čvora " + kraj);
            }
            else NadiPut(pocetak, kraj, g, box);

        }

        public void NadiPut(string source, string destination, Graphics g, TextBox box)
        {
            Pen olovka = new Pen(Brushes.Red);
            olovka.Width = 4;
            Cvor s = VratiCvor(source);
            Cvor d = VratiCvor(destination);

            
            
            if (s == null || d == null)
            {
                System.Environment.Exit(1);
            }
            int udaljenost = d.duljinaPuta; // duljina najkraceg puta
            Console.WriteLine("Duljina puta = " + udaljenost);
            if (udaljenost == BESKONACNO) return; //ta kontrola vec postoji nez kak dode do tud, bug? 
            Cvor temp = null;
            List<Cvor> lista = new List<Cvor>();
            
            //int duljina = 0;

            while (d != s) // dodavanje cvorova u listu obrnuto po redu i zbrajanje duljine puta
            {
                lista.Add(d);
                if (d == null) return; //nez zakaj tu more opce d biti null, istraziti
                temp = d.prijasnji; //zamjena d i prijasnjeg cvora od d
                                    //Console.WriteLine("duljina puta od trenutnog cvora: "+d.duljinaPuta);
                                    //duljina += d.duljinaPuta; -- ovo je krivo
                                    //ak ocemo duljinu puta mozemo ju mjerit jos i po zbroju izmedu ta 2 cvora ak ocemo biti tocniji - nez ak radi uvijek to treba provjerit!!

                d = temp;

            }

            Console.WriteLine("Najkraći put je: ");
            tekst.Append("Rekonstrukcija najkraćeg puta je: (grafički prikaz na mapi) \n");
            lista.Reverse();
            Cvor prijasnji = s;
            tekst.Append(prijasnji.ime);
            foreach (Cvor cvor in lista)
            {
                Rectangle rectangle = new Rectangle(50, 100, 150, 150);
                /*g.DrawEllipse(Pens.Black, rectangle);
                g.DrawRectangle(Pens.Red, rectangle);*/
                g.DrawLine(olovka, prijasnji.koordinate, cvor.koordinate);
                g.FillEllipse(Brushes.Black, prijasnji.koordinate.X - 3, prijasnji.koordinate.Y - 3, 12, 12);
                g.FillEllipse(Brushes.Black, cvor.koordinate.X - 3, cvor.koordinate.Y - 3, 12, 12);
                Console.Write(" " + prijasnji.ime);
                Console.Write(" " + cvor.ime);
                tekst.Append("->"+(cvor.ime));
                if (prijasnji == null)
                {
                    prijasnji = cvor;
                    continue;
                }
                
                prijasnji = cvor;

            }
            Console.WriteLine("\nNajkraća udaljenost je: " + udaljenost);
            box.Text = "Najkraća udaljenost je:" + udaljenost;
        }

        public StringBuilder vratiTekst()
        {
            return tekst;
        }

        public void OcistiTekst()
        {
            tekst = tekst.Clear();
        }

        public void nacrtajGraf(Graphics g)
        {
            Pen olovka = new Pen(Brushes.Black);
            foreach (KeyValuePair<(String, String), int> stavka in dict)
            {
                Cvor prvi = VratiCvor(stavka.Key.Item1);
                Cvor drugi = VratiCvor(stavka.Key.Item2);
                //Console.WriteLine("Udaljenost izmedu {0} i {1} je: {2}", stavka.Key.Item1, stavka.Key.Item2, stavka.Value);
                g.DrawLine(olovka, prvi.koordinate, drugi.koordinate);
            }
        }

        public void NacrtajStablo(String pocetak, Graphics g) //crta dijkstrino stablo najkracih puteva
        {
            Pen olovka = new Pen(Brushes.Blue);
            olovka.Width = 4;
            Cvor s = VratiCvor(pocetak);
            List<Cvor> lista = new List<Cvor>();
            Cvor prijasnji = null;
            foreach(String ime in listaS)
            {
                if(ime == pocetak) { continue; }
                prijasnji = VratiCvor(ime).prijasnji;
                if(prijasnji == null) { continue; }
                //spajam cvor u listi s njegovim prijasnjim
                g.DrawLine(olovka, prijasnji.koordinate, VratiCvor(ime).koordinate);
                g.FillEllipse(Brushes.Black, prijasnji.koordinate.X - 3, prijasnji.koordinate.Y - 3, 12, 12);
                g.FillEllipse(Brushes.Black, VratiCvor(ime).koordinate.X - 3, VratiCvor(ime).koordinate.Y - 3, 12, 12);

            }
            







        }
    }
}
