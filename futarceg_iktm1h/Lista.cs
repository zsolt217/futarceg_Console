using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class Lista : IEnumerable<Kuldemeny>
    {
        ListaElem <Kuldemeny> Elso;
        public Lista()
        {
            Elso = null;
        }
        public bool Ures_e()
        {
            return Elso == null;
        }
        public void Beszur(Kuldemeny ujadat)
        {
            ListaElem<Kuldemeny> ujelem = new ListaElem<Kuldemeny>(ujadat);
            if (Elso == null)
            {
                Elso = ujelem;
            }
            else if (ujadat is Kuldemeny)
            {
                Kuldemeny adat = ujadat as Kuldemeny;
                ListaElem<Kuldemeny> akt;
                ListaElem<Kuldemeny> elozo = null;
                akt = this.Elso;
                Kuldemeny akt_adat;
                akt_adat = akt.Adat as Kuldemeny;

                while (akt != null && adat.Egyenlo_e(akt_adat,1)) //azért állthat le mert adat végén vagy mert kisebb a sorban az Elem mint az enyém
                {
                    elozo = akt;
                    akt = akt.Kov;
                    if (akt != null)
                    {
                        akt_adat = akt.Adat as Kuldemeny;
                    }
                }
                if (elozo == null)//ha előre akarom betenni
                {
                    ujelem.Kov = this.Elso;
                    this.Elso = ujelem;
                }
                else if (akt != null)//megtaláltam a határolót
                {
                    elozo.Kov = ujelem;
                    ujelem.Kov = akt;
                }
                else//végére berakás
                {
                    elozo.Kov = ujelem;
                }

            }
            else
            {
                ListaElem<Kuldemeny> p = Elso;
                while (p.Kov != null)
                {
                    p = p.Kov;
                }
                p.Kov = ujelem;
            }
        }
        public void Torol(object sender, TorolEventArgs adat)
        //p aktuálisra mutat
        //e p előttire mutat
        {
            ListaElem<Kuldemeny> p = Elso;
            ListaElem<Kuldemeny> e = null;
            while (p != null && !p.Adat.Egyenlo_e(adat.lenyeg,2))//p.Adat==adat, nem jó mert ref szerint hasonlítaná össze
            {
                e = p;
                p = p.Kov;
            }
            if (p != null)
            {
                if (e == null)
                {
                    Elso = Elso.Kov;
                }
                else//megtalálom amit törölni akarok és az nem az első elem
                {
                    e.Kov = p.Kov;
                }
            }
            //GC.Collect();//GC-t meghívom h törölje a törlendő adatot
            //memory leak-- olyan memoriaterület amit már nem használok és nem szabadítottam fel
        }
        public void Torol2(object sender, TorolEventArgs adat)
        //p aktuálisra mutat
        //e p előttire mutat
        {
            ListaElem<Kuldemeny> p = Elso;
            ListaElem<Kuldemeny> e = null;
            while (p != null && !p.Adat.Egyenlo_e(adat.lenyeg, 2))//p.Adat==adat, nem jó mert ref szerint hasonlítaná össze
            {
                e = p;
                p = p.Kov;
            }
            if (p != null)
            {
                if (e == null)
                {
                    Elso = Elso.Kov;
                }
                else//megtalálom amit törölni akarok és az nem az első elem
                {
                    p.Adat.Prioritas = p.Adat.Prioritas_masolat;
                    e.Kov = p.Kov;
                }
            }
            //GC.Collect();//GC-t meghívom h törölje a törlendő adatot
            //memory leak-- olyan memoriaterület amit már nem használok és nem szabadítottam fel
        }
        //public void Torol(Kuldemeny elem)
        //{
        //    if (T is Kuldemeny)
        //    {
                
        //    }
        //    ListaElem<T> p = Elso;
        //    ListaElem<T> e = null;
        //    //int cnt = 0;
        //    while (p != null && p != elem)//p.Adat==adat, nem jó mert ref szerint hasonlítaná össze
        //    {
        //        e = p;
        //        p = p.Kov;
        //    }
        //    if (p != null)
        //    {
        //        if (e == null)
        //        {
        //            Elso = Elso.Kov;
        //        }
        //        else//megtalálom amit törölni akarok és az nem az első elem
        //        {
        //            e.Kov = p.Kov;
        //        }
        //    }
        //}
        public void Torol(int idx)
        {
            ListaElem<Kuldemeny> p = Elso;
            ListaElem<Kuldemeny> e = null;
            int cnt = 0;
            while (p != null && cnt < idx)//p.Adat==adat, nem jó mert ref szerint hasonlítaná össze
            {
                e = p;
                p = p.Kov;
                cnt++;
            }
            if (p != null)
            {
                if (e == null)
                {
                    Elso = Elso.Kov;
                }
                else//megtalálom amit törölni akarok és az nem az első elem
                {
                    e.Kov = p.Kov;
                }
            }
        }
        public Kuldemeny Keres(Kuldemeny mitkeres, out bool van)
        {
            ListaElem<Kuldemeny> p = Elso;
            while (p != null && !p.Adat.Equals(mitkeres))
            {
                p = p.Kov;
            }
            if (p == null)
            {
                van = false;
                return default(Kuldemeny);
            }
            else
            {
                van = true;
                return p.Adat;
            }
        }
        public IEnumerator<Kuldemeny> GetEnumerator()
        {
            return new ListaEnumerator<Kuldemeny>(Elso);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
