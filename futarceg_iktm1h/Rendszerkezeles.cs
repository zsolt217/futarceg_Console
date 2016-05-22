using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class Rendszerkezeles
    {
        Lista kuldemenyek = new Lista();
        List<Szemely> dolgozok = new List<Szemely>();
        public Rendszerkezeles()
        {

        }
        public void Ujdolgozofelvetele(Szemely szemely)
        {
            dolgozok.Add(szemely);

        }
        public void beszur_kuldemenyt(Kuldemeny kuldemeny)
        {
            int maxtomeg = 0;
            foreach (Szemely dolgoz in dolgozok)
            {
                if (!dolgoz.szabadsagonvan_e&&maxtomeg<dolgoz.Szallithatolegnagyobbtomeg)
                {
                    maxtomeg = dolgoz.Szallithatolegnagyobbtomeg;
                }
            }
            try
            {
                if ((kuldemeny is Elelmiszer && kuldemeny.Prioritas < 5) || (kuldemeny.Prioritas > 10))
                {
                    throw new TulMagasPrioritasException(kuldemeny.Prioritas);
                }
                else if (kuldemeny.Tomeg>maxtomeg)
                {
                    throw new TulMagasTomegException(maxtomeg);
                }
                else
                {
                    kuldemenyek.Beszur(kuldemeny);
                }
            }
            catch (TulMagasPrioritasException e)
            {
                Console.WriteLine("A beadott prioritas ({0}) tulmagas", e.Prioritas);
            }
            catch(TulMagasTomegException e)
            {
                Console.WriteLine("A beadott tömeg túl magas, a legnagyobb kiviheto csomag tömege : {0} lehet.",maxtomeg);
            }
            
        }

        public void Aznapi_kiosztas()
        {

            foreach (Szemely szemely in dolgozok)
            {
                if (kuldemenyek.Ures_e())
                {
                    Console.WriteLine("Elfogyott a kihordandó küldemény");
                    break;
                }
                    else if(szemely.szabadsagonvan_e)
                {
                    Console.WriteLine(szemely.ToString()+" szabadságon van.");
                    }
                else
                {
                    DinamikusKiosztas kiosztas = new DinamikusKiosztas(kuldemenyek);
                    kiosztas.Kuldemenyszetosztas(szemely);
                    szemely.dolgozz += kuldemenyek.Torol;
                    szemely.Napiteendokilistazasa();
                    szemely.dolgozz -= kuldemenyek.Torol;
                }
            }
        }
        public void Elorejelzes()
        {
            if (!kuldemenyek.Ures_e())
            {
                Lista elore_kuldemeny = new Lista();
                foreach (Kuldemeny kuldemeny in kuldemenyek)
                {
                    kuldemeny.Prioritas_masolat = kuldemeny.Prioritas;
                    elore_kuldemeny.Beszur(kuldemeny);
                }
                int i = 1;
                while (!elore_kuldemeny.Ures_e())
                {
                    Console.WriteLine("Előrejelzés {0}. nap", i++);
                    DinamikusKiosztas kiosztas = new DinamikusKiosztas(elore_kuldemeny);
                    foreach (Kuldemeny csomag in elore_kuldemeny)
                    {
                        csomag.PrioritasNovel();
                    }
                    Prioritasnovel();
                    foreach (Szemely szemely in dolgozok)
                    {
                        if (elore_kuldemeny.Ures_e())
                        {
                            Console.WriteLine("Elfogyott a kihordandó küldemény");
                            break;
                        }
                        else if (!szemely.szabadsagonvan_e)
                        {
                            kiosztas.Kuldemenyszetosztas(szemely);
                            szemely.lesz_munka += elore_kuldemeny.Torol2;
                            szemely.Napiteendokilistazasa();
                            szemely.lesz_munka -= elore_kuldemeny.Torol2;

                        }

                    }
                }
                Console.WriteLine("elfogytak a küldemények");
            }
            else
            {
                Console.WriteLine("Nincs kiosztható csomag a jövőre nézve.");
            }
        }
        public void PrioritasNovel()
        {
            foreach (Kuldemeny csomag in kuldemenyek)
            {
                csomag.PrioritasNovel();
            }
        }
        public void Szabadsagmodositas(object nev, bool szabagsag)
        {
            foreach (Szemely dolgozo in dolgozok)
            {
                if (dolgozo.Equals(nev))
                {
                    dolgozo.szabadsagonvan_e = szabagsag;
                }
            }
        }
        //public void Elemtorles(object kuldo, TorolEventArgs e)
        //{
        //    Kuldemeny csomag = e.lenyeg as Kuldemeny;
        //    kuldemenyek.Torol(csomag);
        //}
        //public void kereses(Kuldemeny keresendo)
        //{
        //    bool van;
        //    kuldemenyek.Keres(keresendo, out van);

        //}
        public void Prioritasnovel()
        {
            foreach (Kuldemeny kuldemeny in kuldemenyek)
            {
                kuldemeny.PrioritasNovel();
            }
        }


        public void kiir()
        {
            foreach (Kuldemeny item in kuldemenyek)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
