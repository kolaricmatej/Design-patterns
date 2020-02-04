using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Interface;
using mkolaric1_zadaca_1.Osnovno;
using mkolaric1_zadaca_1.TvKuca;
using mkolaric1_zadaca_1.Ucitavanje;

namespace mkolaric1_zadaca_1
{
    class TvHouseManagement
    {
        static void Main(string[] args)
        {
            IParametri parametri;
            String putanjaTvKuca = "";
            List<TvKuca.TvKuca> listaTvkuca = new List<TvKuca.TvKuca>();
            List<Program> listaPrograma1= new List<Program>();
            List<Program> listaPrograma2 = new List<Program>();
            List<Program> listaDodatniProgrami = new List<Program>();
            List<Emisija> listaEmisija;
            List<Osoba> listaOsoba=new List<Osoba>();
            List<Uloga> listaUloga=new List<Uloga>();
            List<Program> listaTjedniRaspored=new List<Program>();
            


            Console.Write("Unesite opcije i navedene nazive datoteka:");
            string naredba = Console.ReadLine();
            string[] nared = naredba.Split(' ');
            Regex regex =
                new Regex(
                    @"((.{3,30})\.(exe|jar) -t (.{3,30})\.txt -e (.{3,30})\.txt -o (.{3,30})\.txt -u (.{3,30})\.txt)");
            Match match = regex.Match(naredba);
            if (match.Success)
            {
                TvKucaSingleton.Instace().PutanjaTvKuca = nared[2];
                putanjaTvKuca = TvKucaSingleton.Instace().PutanjaTvKuca;
            }
            else
            {
                Console.WriteLine("Niste unjeli sve argumente!");
            }

            if (naredba.Equals("") || !(File.Exists(nared[2])))
            {
                Console.WriteLine("There's no configuration file. Please select proper file");
                Console.ReadLine();
                System.Environment.Exit(1);
            }

            TvKucaSingleton.Instace().UcitajParametre(putanjaTvKuca);
            listaTvkuca = TvKucaSingleton.Instace().ListaTvKuca;
            ProgramiFactory pf = new ProgramiFactory();
            EmisijaFactory ef = new EmisijaFactory();
            OsobaFactory of = new OsobaFactory();
            UlogaFactoy uf = new UlogaFactoy();
            listaEmisija = ef.GetList(nared[4]);
            listaOsoba = of.GetList(nared[6]);
            listaUloga = uf.GetList(nared[8]);
            for (int i = 0; i < listaTvkuca.Count; i++)
            {
                List<string> putanja = listaTvkuca[i].GetListParameters("naziv datoteke");
                pf.UcitajZapise(putanja[i]);
                if (putanja[i].Equals("DZ_1_program_1.txt"))
                {
                    listaPrograma1 = pf.GetList(putanja[i]);
                    listaTjedniRaspored= listeSPocetkom(listaPrograma1);
                    listaTjedniRaspored.AddRange( listeBezPocetka(listaPrograma1));
                    listaTjedniRaspored.AddRange(listaBezVremena(listaPrograma1));
                    List<TvRaspored> proba = listaTjedniRasporedi(listaTjedniRaspored);
                    IspisPoDanu(proba, listaEmisija, listaOsoba, listaUloga);
                    //Ispis(proba,listaEmisija);
                    Console.WriteLine("1. prikaz programa po danima");
                    string izbor = Console.ReadLine();
                    if (izbor.Contains("1"))
                    {
                        Ispis(proba, listaEmisija);
                        Console.ReadLine();
                    }

                    

                }
                else if (putanja[i].Equals("DZ_1_program_2.txt"))
                {
                    listaPrograma2 = pf.GetList(putanja[i]);
                    listaTjedniRaspored = listeSPocetkom(listaPrograma2);
                    listaTjedniRaspored.AddRange(listeBezPocetka(listaPrograma2));
                    listaTjedniRaspored.AddRange(listaBezVremena(listaPrograma2));
                    List<TvRaspored> proba = listaTjedniRasporedi(listaTjedniRaspored);

                    IspisPoDanu(proba, listaEmisija, listaOsoba, listaUloga);
                }
                else
                {
                   listaDodatniProgrami = pf.GetList(putanja[i]);
                   listaTjedniRaspored = listeSPocetkom(listaDodatniProgrami);
                   listaTjedniRaspored.AddRange(listeBezPocetka(listaDodatniProgrami));
                   listaTjedniRaspored.AddRange(listaBezVremena(listaDodatniProgrami));
                   List<TvRaspored> proba = listaTjedniRasporedi(listaDodatniProgrami);

                }
            }

            

        }

        public static List<Program> listeSPocetkom(List<Program> lista)
        {
            List<Program> a=new List<Program>();
            foreach (var VARIABLE in lista)
            {
                if (VARIABLE.Pocetak!=null && VARIABLE.DaniUTjednu.Length >= 1)
                {
                    a.Add(VARIABLE);
                }
            }
            
            return a;
        }

        public static List<Program> listeBezPocetka(List<Program> lista)
        {
            List<Program> l=new List<Program>();
            foreach (var v in lista)
            {
                if (v.Pocetak == null && v.DaniUTjednu.Length >2)
                {
                    l.Add((v));
                }
            }
            return l;
        }

        public static List<Program> listaBezVremena(List<Program> lista)
        {
            List<Program> l = new List<Program>();
            foreach (var v in lista)
            {
                if (v.Pocetak == null && v.DaniUTjednu=="")
                {
                    l.Add((v));
                }
            }
            return l;
        }

        public static List<TvRaspored> listaTjedniRasporedi(List<Program> lista)
        {
            List<TvRaspored> listaPoDanima = new List<TvRaspored>();
            TvRaspored r = new TvRaspored();
            int id;
            string dani = "";
            List<int> listaDana;
            TimeSpan pocetak;

            foreach (var dan in lista)
            {
                if (dan.DaniUTjednu.Contains("1") && dan.DaniUTjednu.Length >= 1)
                {
                    id = dan.Id;
                    dani = dan.DaniUTjednu;
                    pocetak =dan.Pocetak;
                    listaDana = r.VratiDane(dani);
                    r = new TvRaspored(id, listaDana, pocetak);
                    listaPoDanima.Add(r);
                }
                else if (dan.DaniUTjednu.Contains("2") && dan.DaniUTjednu.Length >= 1)
                {
                    id = dan.Id;

                    dani = dan.DaniUTjednu;
                    pocetak = dan.Pocetak;
                    listaDana = r.VratiDane(dani);
                    r = new TvRaspored(id, listaDana, pocetak);
                    listaPoDanima.Add(r);
                }
                else if (dan.DaniUTjednu.Contains("3") && dan.DaniUTjednu.Length >= 1)
                {
                    id = dan.Id;
                    dani = dan.DaniUTjednu;
                    pocetak = dan.Pocetak;
                    listaDana = r.VratiDane(dani);
                    r = new TvRaspored(id, listaDana, pocetak);
                    listaPoDanima.Add(r);
                }
                else if (dan.DaniUTjednu.Contains("4") && dan.DaniUTjednu.Length >= 1)
                {
                    id = dan.Id;
                    dani = dan.DaniUTjednu;
                    pocetak = dan.Pocetak;
                    listaDana = r.VratiDane(dani);
                    r = new TvRaspored(id, listaDana, pocetak);
                    listaPoDanima.Add(r);
                }
                else if (dan.DaniUTjednu.Contains("5") && dan.DaniUTjednu.Length >= 1)
                {
                    id = dan.Id;
                    dani = dan.DaniUTjednu;
                    pocetak = dan.Pocetak;
                    listaDana = r.VratiDane(dani);
                    r = new TvRaspored(id, listaDana, pocetak);
                    listaPoDanima.Add(r);
                }
                else if (dan.DaniUTjednu.Contains("6") && dan.DaniUTjednu.Length >= 1)
                {
                    id = dan.Id;
                    dani = dan.DaniUTjednu;


                    pocetak = dan.Pocetak;

                    listaDana = r.VratiDane(dani);
                    r = new TvRaspored(id, listaDana, pocetak);
                    listaPoDanima.Add(r);
                }
                else if (dan.DaniUTjednu.Contains("7") && dan.DaniUTjednu.Length >= 1)
                {
                    id = dan.Id;
                    dani = dan.DaniUTjednu;

                    pocetak = dan.Pocetak;

                    listaDana = r.VratiDane(dani);
                    r = new TvRaspored(id, listaDana, pocetak);
                    listaPoDanima.Add(r);

                }
            }

            return listaPoDanima;

        }

        public static void Ispis(List<TvRaspored>lista, List<Emisija> emisije)
        {
           
            foreach (var v in lista)
            {
                var proba = from l in lista
                    where l.Id == v.Id
                    from emisija in emisije
                    where emisija.Id == v.Id
                    select new
                    {
                        emisija.naziv, l.Pocetak
                    };
                foreach (var p in proba)
                {
                    Console.WriteLine("Naziv: "+p.naziv+"\n"+"Pocetak: "+p.Pocetak);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Dani prikazivanja:");
                    foreach (var l in v.Dani)
                    {
                        {
                            switch (l)
                            {
                                case 1:
                                    Console.WriteLine("Ponedjeljak");
                                    break;

                                case 2:
                                    Console.WriteLine("Utorak");
                                    break;
                                case 3:
                                    Console.WriteLine("Srijeda");
                                    break;
                                case 4:
                                    Console.WriteLine("Četvrtak");
                                    break;
                                case 5:
                                    Console.WriteLine("Petak");
                                    break;
                                case 6:
                                    Console.WriteLine("Subota");
                                    break;
                                case 7:
                                    Console.WriteLine("Nedjelja");
                                    break;
                                default:
                                    Console.WriteLine("Neispravan format");
                                    break;
                            }

                        }
                    }

                    Console.WriteLine("------------------------------");
                }
               
               
            }
            
        }

        public static void IspisPoDanu(List<TvRaspored> lista, List<Emisija> emisije,List<Osoba> osobe, List<Uloga>uloge)
        {
            foreach (var v in lista)
            {
                var proba = from l in lista
                    where l.Id == v.Id
                    from emisija in emisije
                    where emisija.Id == l.Id
                    from osoba in osobe
                    where osoba.Id == emisija.OsobaUloga1[0]
                    from uloga in uloge
                    where uloga.Id == emisija.OsobaUloga1[1]
                    from osoba1 in osobe
                    where osoba1.Id == emisija.OsobaUloga2[0]
                    from uloga1 in uloge
                    where uloga1.Id == emisija.OsobaUloga2[1]
                    select new
                    {
                        emisija.naziv,
                        l.Pocetak,
                        Zavrsetak = l.Pocetak.Add(TimeSpan.FromMinutes(emisija.trajanje)),
                        emisija.trajanje,
                        osoba.Naziv,
                        uloga.Opis,
                        Osoba = osoba1.Naziv,
                        Uloga = uloga1.Opis
                    };
                foreach (var p in proba)
                {
                    Console.WriteLine();
                    Console.WriteLine("Naziv emisije" + p.naziv);
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Pocetak:" + p.Pocetak);
                    Console.WriteLine("Zavrsetak:" + p.Zavrsetak);
                    Console.WriteLine("Trajanje u minutama:" + p.trajanje);
                    Console.WriteLine("Osoba:" + p.Naziv + "|| Uloga:" + p.Opis);
                    Console.WriteLine("Osoba" + p.Osoba + "||" + "Uloga" + p.Uloga);
                    Console.WriteLine("----------------------------");
                }

                
            }

        }

        public static void RasporedPoDanima(List<TvRaspored> lista, List<Emisija> emisije, List<Osoba> osobe, List<Uloga> uloge)
        {
            TvPregled tv= new TvPregled();
            List<TvPregled> ponedjeljak=new List<TvPregled>();
            List<TvPregled> utorak = new List<TvPregled>();
            List<TvPregled> srijeda = new List<TvPregled>();
            List<TvPregled> cetvrtak = new List<TvPregled>();
            List<TvPregled> petak = new List<TvPregled>();
            List<TvPregled> subota = new List<TvPregled>();
            List<TvPregled> nedjelja = new List<TvPregled>();
            string naziv = "";
            TimeSpan pocetak;
            TimeSpan zavrsetak;
            int trajanje;
            string ime = "";
            string ulog = "";
            foreach (var v in lista)
            {
                foreach (var e in emisije)
                {
                    var proba = from l in lista
                        where l.Id == v.Id
                        from emisija in emisije
                        where emisija.Id == v.Id
                        from osoba in osobe
                        where osoba.Id == e.OsobaUloga1[0]
                        from uloga in uloge
                        where uloga.Id == e.OsobaUloga1[1]



                                select new
                        {
                            emisija.naziv,
                            l.Pocetak,
                            Zavrsetak = l.Pocetak.Add(TimeSpan.FromMinutes(emisija.trajanje)),
                            emisija.trajanje,
                            osoba.Naziv,
                            uloga.Opis
                        };
                    foreach (var p in proba)
                    {
                        naziv = p.naziv;
                            pocetak = p.Pocetak;
                            zavrsetak = p.Zavrsetak;
                            trajanje = p.trajanje;
                            ime = p.Naziv;
                            ulog = p.Opis;
                            tv = new TvPregled(naziv, pocetak, zavrsetak, trajanje, ime, ulog);
                            nedjelja.Add(tv);
                        

                    }

                }

            }

        }

        public static void ispisi(string naziv, TimeSpan pocetak, TimeSpan kraj, int trajanje, string osoba, string uloga)
        {
            Console.WriteLine("Naziv emisije" + naziv);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Pocetak:" + pocetak);
            Console.WriteLine("Zavrsetak:" +kraj);
            Console.WriteLine("Trajanje u minutama:" + trajanje);
            Console.WriteLine("Osoba:" + osoba + "|| Uloga:" + uloga);
            Console.WriteLine("----------------------------");
        }
    }
}
