using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DijkstraApp
{
  
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Graf g = new Graf();
            g.DodajUListu("Varaždin", 733, 85);
            g.DodajUListu("Čakovec", 753, 65);
            g.DodajUListu("Krapina", 640, 109);
            g.DodajUListu("Zagreb", 672, 168);
            g.DodajUListu("Koprivnica", 833, 110);
            g.DodajUListu("Slavonski Brod", 1042, 278);
            g.DodajUListu("Osijek", 1178, 217);
            g.DodajUListu("Bjelovar", 818, 148);
            g.DodajUListu("Sisak", 749, 206);
            g.DodajUListu("Vukovar", 1211, 250);
            g.DodajUListu("Karlovac", 580, 232);
            g.DodajUListu("Rijeka", 391, 241);
            g.DodajUListu("Pazin", 315, 297);
            g.DodajUListu("Gospić", 535, 372);
            g.DodajUListu("Zadar", 542, 451);
            g.DodajUListu("Šibenik", 671, 534);
            g.DodajUListu("Virovitica", 949, 180);
            g.DodajUListu("Požega", 982, 247);
            g.DodajUListu("Split", 779, 561);
            g.DodajUListu("Dubrovnik", 1060, 707);
            g.DodajUListu("Vinkovci", 1181, 275);
            g.DodajUListu("Plitvička Jezera", 625, 326);
            g.DodajUListu("Kaprije", 622, 542);
            g.DodajUListu("Benkovac", 633, 482);
            g.DodajUListu("Makarska", 862, 591);
            g.DodajUListu("Mljet", 953, 689);
            g.DodajUListu("Rab", 458, 349);
            g.DodajUListu("Pula", 300, 334);
            g.DodajUListu("Umag", 245, 239);
            g.DodajUListu("Vis", 707, 636);
            g.DodajUListu("Imotski", 896, 574);
            g.DodajUListu("Ploče", 947, 650);
            g.DodajUListu("Donji Miholjac", 1056, 177);
            g.DodajUListu("Petrinja", 719, 235);
            g.DodajUListu("Senj", 491, 308);
            g.DodajUListu("Nova Gradiška", 900, 271);




            /*foreach (Cvor cvor in g.listaCvorova)
            {
                Console.WriteLine(cvor.ime);
            } */
            //upisivanje udaljenosti između gradova http://hr.toponavi.com
            g.DodajUDict("Varaždin", "Čakovec", 12);
            g.DodajUDict("Čakovec", "Koprivnica", 39);
            g.DodajUDict("Varaždin", "Zagreb", 61);
            g.DodajUDict("Zagreb", "Karlovac", 49);
            g.DodajUDict("Zagreb", "Sisak", 120);
            g.DodajUDict("Varaždin", "Koprivnica", 41);
            g.DodajUDict("Koprivnica", "Bjelovar", 29);
            g.DodajUDict("Virovitica", "Bjelovar", 43);
            g.DodajUDict("Koprivnica", "Virovitica", 56);
            g.DodajUDict("Virovitica", "Požega", 60);
            g.DodajUDict("Osijek", "Požega", 83);
            g.DodajUDict("Osijek", "Vukovar", 33);
            g.DodajUDict("Slavonski Brod", "Vukovar", 80);
            g.DodajUDict("Požega", "Slavonski Brod", 32);
            g.DodajUDict("Požega", "Bjelovar", 90);
            g.DodajUDict("Požega", "Sisak", 103);
            g.DodajUDict("Varaždin", "Krapina", 39);
            g.DodajUDict("Zagreb", "Krapina", 43);
            g.DodajUDict("Zagreb", "Bjelovar", 70);
            g.DodajUDict("Sisak", "Bjelovar", 59);
            g.DodajUDict("Virovitica", "Osijek", 106);
            g.DodajUDict("Karlovac", "Rijeka", 89);
            g.DodajUDict("Rijeka", "Pazin", 41);
            g.DodajUDict("Gospić", "Rijeka", 114);
            g.DodajUDict("Gospić", "Karlovac", 106);
            g.DodajUDict("Gospić", "Zadar", 49);
            g.DodajUDict("Zadar", "Šibenik", 68);
            g.DodajUDict("Šibenik", "Split", 51);
            g.DodajUDict("Makarska", "Split", 53);
            g.DodajUDict("Dubrovnik", "Slavonski Brod", 280);
            g.DodajUDict("Virovitica", "Donji Miholjac", 61);
            g.DodajUDict("Osijek", "Donji Miholjac", 47);
            g.DodajUDict("Osijek", "Vinkovci", 31);
            g.DodajUDict("Vukovar", "Vinkovci", 17);
            g.DodajUDict("Slavonski Brod", "Vinkovci", 64);
            g.DodajUDict("Slavonski Brod", "Nova Gradiška", 50);
            g.DodajUDict("Požega", "Nova Gradiška", 24);
            g.DodajUDict("Petrinja", "Karlovac", 57);
            g.DodajUDict("Sisak", "Petrinja", 9);
            g.DodajUDict("Petrinja", "Nova Gradiška", 89);
            g.DodajUDict("Plitvička Jezera", "Karlovac", 68);
            g.DodajUDict("Plitvička Jezera", "Gospić", 42);
            g.DodajUDict("Plitvička Jezera", "Senj", 57);
            g.DodajUDict("Plitvička Jezera", "Benkovac", 94);
            g.DodajUDict("Rijeka", "Senj", 63);
            g.DodajUDict("Rijeka", "Umag", 67);
            g.DodajUDict("Pazin", "Umag", 35);
            g.DodajUDict("Pula", "Umag", 67);
            g.DodajUDict("Pazin", "Pula", 42);
            g.DodajUDict("Gospić", "Benkovac", 60);
            g.DodajUDict("Gospić", "Rab", 59);
            g.DodajUDict("Senj", "Rab", 22);
            g.DodajUDict("Zadar", "Benkovac", 32);
            g.DodajUDict("Šibenik", "Benkovac", 40);
            g.DodajUDict("Šibenik", "Kaprije", 33);
            g.DodajUDict("Makarska", "Ploče", 42);
            g.DodajUDict("Ploče", "Dubrovnik", 70);
            g.DodajUDict("Ploče", "Mljet", 68);
            g.DodajUDict("Split", "Vis", 57);
            g.DodajUDict("Makarska", "Imotski", 23);
            g.DodajUDict("Split", "Imotski", 63);





            //g.NadiPuteve("Cakovec");




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(g));




           
        }
    }
}
