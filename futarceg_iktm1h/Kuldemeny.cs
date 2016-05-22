using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    abstract class Kuldemeny : IKuldemeny
    {
        int prioritas;

        public int Prioritas
        {
            get { return prioritas; }
            set { prioritas= value; }

        }
        int prioritas_masolat;

        public int Prioritas_masolat
        {
            get { return prioritas_masolat; }
            set { prioritas_masolat = value; }
        }
        public int azonosito;
        int tomeg;

        public int Tomeg
        {
            get { return tomeg; }
            set { tomeg = value; }
        }

        public Kuldemeny(int prioritas, int tomeg, int azonosito)
        {
            this.prioritas = prioritas;
            this.tomeg = tomeg;
            this.azonosito = azonosito;
        }
        public override string ToString()
        {
            return string.Format("Csomag tömege:{0} prioritasa: {1}", tomeg, prioritas);
        }
        public void PrioritasNovel()
        {
            if (prioritas < 10)
            {
                prioritas++;
            }
        }
        public bool Egyenlo_e(object obj, int mod)//elso  mod, a rendezett betétel osszehasonlításáért felel, a második a listából való törlésért
        {
            if (obj is Kuldemeny)
            {
                Kuldemeny adat = obj as Kuldemeny;
                if (mod == 1)//akk ad vissza true-t ha sorban lévő nagyobb nála
                {

                    return (this.Prioritas <= adat.Prioritas); // a később jövő hátrébb kerül a 0/1 hátizsákprobléma kifejtésénél előrébb kerül 

                }
                else if (mod == 2)
                {
                    return (this.azonosito == adat.azonosito);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }//equals vége
       
    }



}

