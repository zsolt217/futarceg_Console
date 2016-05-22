using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class Program
    {
        static void Main(string[] args)
        {
            Rendszerkezeles rendszerkezeles = new Rendszerkezeles();
            int i = 0;
            rendszerkezeles.Ujdolgozofelvetele(new Szemely("sanyi", false, new Motor()));
            rendszerkezeles.Ujdolgozofelvetele(new Szemely("józsi", true, new auto()));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(2, 2, i++));

            rendszerkezeles.beszur_kuldemenyt(new Egyeb(4, 4, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(3, 3, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(5, 5, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(5, 4, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(1, 1, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 5, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(2, 4, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(9, 15, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 2, i++));

            rendszerkezeles.beszur_kuldemenyt(new Egyeb(11, 4, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 3, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 5, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 4, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(11, 1, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 5, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 4, i++));
            rendszerkezeles.beszur_kuldemenyt(new Egyeb(10, 15, i++));
            rendszerkezeles.kiir();
           
            bool lefutott_aznapi = false;
            int opcio = 0;
            do
            {
                Console.WriteLine("Lehetőségek: \n \t 1. Küldemény felvétele \n \t 2.Aktuális napi beosztás elkészítese \n \t 3. Előre beosztás (először a napi beosztást kell lefuttatni) \n \t 4.Új dolgozó felvétele \n \t 5. Új nap \n \t 6. Szabadságmódosítás \n \t 7. Kilépés");

                
                int.TryParse(Console.ReadLine(), out opcio);
                if (opcio > 0 && opcio < 7)
                {
                    switch (opcio)
                    {
                        case 1:
                            //Console.WriteLine("3 típusú küldemény van: Targyak, Elelmiszer és Egyed. Az elemiszereknek csak 5 felett lehet az prioritásuk, ugyanakkor egyiké se haladhatja meg a 10-et és 1nél alacsonyabb sem lehet.");
                            //Console.WriteLine("Típusa");
                            //string tipus = Console.ReadLine();
                            //int prioritas = 0;
                            //int.TryParse(Console.ReadLine(), out prioritas);
                            //Console.WriteLine("A csomeg tömege (kg-ben):");
                            //int tomeg = 0;
                            //int.TryParse(Console.ReadLine(), out tomeg);
                            //rendszerkezeles.beszur_kuldemenyt(tipus(10, 15, i++));
                            Console.WriteLine("3 típusú küldemény van: Targyak, Elelmiszer és Egyed. Az elemiszereknek csak 5 felett lehet az prioritásuk, ugyanakkor egyiké se haladhatja meg a 10-et és 1nél alacsonyabb sem lehet.");
                            Console.WriteLine("Csomag prioritása?");
                            int prioritas = 0;
                            int.TryParse(Console.ReadLine(), out prioritas);
                            Console.WriteLine("Csomag tomege?");
                            int tomeg = 0;
                            do{
                            int.TryParse(Console.ReadLine(), out tomeg);
                            }while(!(tomeg>0));
                            Console.WriteLine("Milyen típusu a csomag? 1. Élelmiszer, 2. Tárgy, 3. Egyéb");
                            int csomagtipus;
                            do
                            {
                                int.TryParse(Console.ReadLine(), out csomagtipus);
                            }
                            while (!(csomagtipus >= 1 && csomagtipus < 4));
                            switch (csomagtipus)
                            {
                                case 1:
                                    rendszerkezeles.beszur_kuldemenyt(new Elelmiszer(prioritas, tomeg, i++));
                                    break;
                                case 2:
                                    rendszerkezeles.beszur_kuldemenyt(new Targyak(prioritas, tomeg, i++));
                                    break;
                                case 3:
                                    rendszerkezeles.beszur_kuldemenyt(new Egyeb(prioritas, tomeg, i++));
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            rendszerkezeles.Aznapi_kiosztas();
                            lefutott_aznapi = true;
                            break;
                        case 3:
                            if (lefutott_aznapi)
                            { rendszerkezeles.Elorejelzes(); }
                            break;
                        case 4:
                            Console.WriteLine("Dolgozó neve?");
                            string nev = Console.ReadLine();
                            Console.WriteLine("Mivel jár a dolgozó? 1. Motor, 2. Auto, 3. Furgon");
                            int jarmu;
                            do
                            {
                                int.TryParse(Console.ReadLine(), out jarmu);
                            }
                            while (!(jarmu > 1 && jarmu < 4));
                            switch (jarmu)
                            {
                                case 1:
                                    rendszerkezeles.Ujdolgozofelvetele(new Szemely(nev, false, new Motor()));
                                    break;
                                case 2:
                                    rendszerkezeles.Ujdolgozofelvetele(new Szemely(nev, false, new auto()));
                                    break;
                                case 3:
                                    rendszerkezeles.Ujdolgozofelvetele(new Szemely(nev, false, new Furgon()));
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 5:
                            rendszerkezeles.PrioritasNovel();
                            Console.WriteLine("Prioritások megnövelve.");
                            break;
                        case 6:
                            Console.WriteLine("Dolgozó neve:");
                            string xxx = Console.ReadLine();
                            Console.WriteLine("Szabadságon van-e: \n \t 1. igen \n \t 2. nem");
                             int yyy=0;
                            do
                            {
                                int.TryParse(Console.ReadLine(), out yyy);
                            }
                            while (!(yyy >= 1 && yyy < 3));
                            switch (yyy)
                            {
                                case 1:
                                    rendszerkezeles.Szabadsagmodositas(xxx as object,true);
                                    break;
                                case 2:
                                    rendszerkezeles.Szabadsagmodositas(xxx as object, true);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            while (opcio != 7);
           //Console.ReadKey();
        }
    }
}
