using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class DinamikusKiosztas
    {
        Lista kuldemenyek = new Lista();
        public DinamikusKiosztas(Lista kuldemenyek)
        {
            this.kuldemenyek = kuldemenyek;
        }
        Kuldemeny[] betehetokuldemenyek;

        public void Kuldemenyszetosztas(Szemely szemely)
        {
            List<Kuldemeny> eredmeny = new List<Kuldemeny>();
            Queue<int> prioritasszintek = new Queue<int>(); // a tömbbeli elem indexe ahol már épp kisebb a prioritas mint az elozo
            segedszamitasok(szemely, ref prioritasszintek); //megvan a tömb és a priaritashatarolok
            int sulyhatar = szemely.Szallithatolegnagyobbtomeg + 1;//+1 trollface :D
            int i = prioritasszintek.Count + 1;
            int maxelemszam = 0;
            int elozo = 0;
            int kovetkezo = 0;
            do
            {
                if (prioritasszintek.Count == 0)
                {
                    maxelemszam = betehetokuldemenyek.Length - elozo;
                }
                else
                {
                    kovetkezo = prioritasszintek.Dequeue();
                    maxelemszam = kovetkezo - elozo;
                }
                sulyhatar -= Hatizsak((maxelemszam + 1), elozo, sulyhatar, eredmeny);//kiveszek egy +1-et
                i--;
                elozo = kovetkezo;
            } while (sulyhatar > 0 && i > 0);
            if (eredmeny.Count > 0)
            {
                foreach (Kuldemeny ered in eredmeny)
                {
                    szemely.KuldemenyListaFeltoltese(ered);
                }
            }
            //szemely.Napiteendokilistazasa();
            eredmeny = null;
            betehetokuldemenyek = null;
        }

        private void segedszamitasok(Szemely szemely, ref Queue<int> prioritasszintek)
        {
            Queue<int> seged = prioritasszintek;
            int sulykorlat = szemely.Szallithatolegnagyobbtomeg;
            int db = 0; //tömb mérete, hogy van-e olyan elem ami kisebb minta sulykorlat
            foreach (Kuldemeny kuldemeny in kuldemenyek)
            {
                if (kuldemeny.Tomeg <= sulykorlat)
                {
                    db++;
                }
            }
            if (db > 0)
            {
                int i = 0;
                int elozo_prioritas = 0;
                betehetokuldemenyek = new Kuldemeny[db];
                foreach (Kuldemeny kuldemeny in kuldemenyek)
                {
                    if (kuldemeny.Tomeg <= sulykorlat)
                    {
                        betehetokuldemenyek[i] = kuldemeny;
                        if (elozo_prioritas > kuldemeny.Prioritas)
                        {
                            seged.Enqueue(i);
                        }
                        elozo_prioritas = kuldemeny.Prioritas;
                        i++;
                    }
                }

            }
        }


        //honnan lépkedek, az a szám ahonnan az adot szinthez tartozó értékek vannak a tömbben
        private int Hatizsak(int maxelemszam, int honnan_lepkedek, int sulykorlat, List<Kuldemeny> eredmeny)//maxelemszam, adott prioritas szinten hány olyan elem van ami kisebb mint a sulykorlat
        {
            int berakottsuly = 0;
            int[,] muveleti_tomb = new int[maxelemszam, sulykorlat + 1];
            for (int i = 0; i < sulykorlat + 1; i++)
            {
                muveleti_tomb[0, i] = 0;
            }
            for (int i = 0; i < maxelemszam; i++)
            {
                muveleti_tomb[i, 0] = 0;
            }
            for (int i = 1; i < maxelemszam; i++)
            {
                for (int j = 1; j < sulykorlat; j++)
                {
                    if (betehetokuldemenyek[honnan_lepkedek + i - 1].Tomeg <= j)
                    {
                        muveleti_tomb[i, j] = Maximumkivalasztas(muveleti_tomb[i - 1, j], (muveleti_tomb[i - 1, j - betehetokuldemenyek[honnan_lepkedek + i - 1].Tomeg] + 1));//3. i-1 mert az tömben nullától van itt viszont a sorszázomás eggyel magasabbról indul
                    }
                    else
                    {
                        muveleti_tomb[i, j] = muveleti_tomb[i - 1, j];
                    }
                }
            }
           

            int y = maxelemszam - 1;//csökkentem a nullás indexelés miatt a értékét
            int x = sulykorlat - 1;//csökkentem a nullás indexelés miatt a értékét
            while (x > 0 && y > 0)
            {
                if (muveleti_tomb[y, x] != muveleti_tomb[y - 1, x])
                {
                    eredmeny.Add(betehetokuldemenyek[honnan_lepkedek + y - 1]);
                    x = x - betehetokuldemenyek[honnan_lepkedek + y - 1].Tomeg;
                    berakottsuly += betehetokuldemenyek[honnan_lepkedek + y - 1].Tomeg;
                }
                y--;
            }
            return berakottsuly;
        }
        private int Maximumkivalasztas(int elso, int masodik)
        {
            if (elso >= masodik) return elso;
            else return masodik;

        }
    }
}
