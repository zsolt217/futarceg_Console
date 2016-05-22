using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    
    class Szemely
    {
        public delegate void DolgoznikellEvent(object sender, TorolEventArgs e);
        public event DolgoznikellEvent dolgozz;
        public event DolgoznikellEvent lesz_munka;
        Gepjarmu jarmu;
        public bool szabadsagonvan_e;
        int szallithatolegnagyobbtomeg;
        string nev;

        public int Szallithatolegnagyobbtomeg
        {
            get { return szallithatolegnagyobbtomeg; }
        }
        Queue<Kuldemeny> kiszallitandokuldenyek=new Queue<Kuldemeny>();
        public Szemely(string nev,bool szabadsag, Gepjarmu jarmu)
        {
            this.jarmu = jarmu;
            szabadsagonvan_e = szabadsag;
            szallithatolegnagyobbtomeg = jarmu.Szallithatosuly;
            this.nev = nev;
        }
        public void KuldemenyListaFeltoltese(Kuldemeny obj)
        {
            kiszallitandokuldenyek.Enqueue(obj);
        }
        public void Napiteendokilistazasa()
        {
            Console.WriteLine(this);
            foreach (Kuldemeny item in kiszallitandokuldenyek)
            {
                Console.WriteLine(item);
            }
            Kihordas();
        }
        public void Kihordas()
        {
            while (kiszallitandokuldenyek.Count!=0)
            {
                if (dolgozz != null)
                {
                    Kuldemeny csomag = kiszallitandokuldenyek.Dequeue();
                    Console.WriteLine(nev + "kiszállította a:" + csomag.ToString() + "csomagot.");
                    dolgozz(this, new TorolEventArgs(ref csomag));
                }
                else
                {
                    Kuldemeny csomag = kiszallitandokuldenyek.Dequeue();
                    lesz_munka(this,new TorolEventArgs(ref csomag));
                 }
            }
        }
        public override bool Equals(object nev)
        {
            string ujnev = nev as string;
            if (this.nev.CompareTo(ujnev)==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return string.Format(nev);
        }
    }
}
