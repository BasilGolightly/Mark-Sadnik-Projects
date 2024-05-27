using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gym
{
    //OPREMA
    public class Oprema
    {
        string Naziv, Opis, Komentar;
        double Teza, Cena;
        int Kvantiteta;
        int[] dimenzije_mm = new int[4];
        static int StArtiklov = 0;
        readonly int IdOpreme;
        
        static public int stArtiklov
        {
            get { return StArtiklov; }
        }
        public int idOpreme
        {
            get { return IdOpreme; }
        }
        public string naziv
        {
            get { return Naziv; }
            set
            {
                if(value == null || value.Trim() == "") 
                {
                    value = "Neznana oprema";
                }
                Naziv = value.Trim();
            }
        }
        public int kvantiteta
        {
            get { return Kvantiteta; }
            set
            {
                if(value < 1)
                {
                    value = 1;
                }
                Kvantiteta = value;
            }
        }
        public string opis
        {
            get
            {
                return Opis;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    value = "Brez opisa";
                }
                Opis = value.Trim();
            }
        }
        public string komentar
        {
            get
            {
                return Komentar;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    value = "Ni komentarja";
                }
                Komentar = value.Trim();
            }
        }
        public double teza
        {
            get
            {
                return Teza;
            }
            set
            {
                if(value <= 0)
                {
                    value = 0.1;
                }
                Teza = value;
            }
        }
        public double cena
        {
            get
            {
                return Cena;
            }
            set
            {
                if(value <= 0)
                {
                    value = 1;
                }
                Cena = value;   
            }
        }
        public int x
        {
            get
            {
                return dimenzije_mm[0];
            }
            set
            {
                if(value < 1)
                {
                    value = 1;
                }
                dimenzije_mm[0] = value;

                if (dimenzije_mm[0] == 0 || dimenzije_mm[1] == 0 || dimenzije_mm[2] == 0)
                {
                    dimenzije_mm[3] = 0;
                }
                else
                {
                    dimenzije_mm[3] = (dimenzije_mm[0] * dimenzije_mm[1] * dimenzije_mm[2]);
                }
            }
        }
        public int y
        {
            get
            {
                return dimenzije_mm[1];
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                dimenzije_mm[1] = value;

                if (dimenzije_mm[0] == 0 || dimenzije_mm[1] == 0 || dimenzije_mm[2] == 0)
                {
                    dimenzije_mm[3] = 0;
                }
                else
                {
                    dimenzije_mm[3] = (dimenzije_mm[0] * dimenzije_mm[1] * dimenzije_mm[2]);
                }
            }
        }
        public int z
        {
            get
            {
                return dimenzije_mm[2];
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                dimenzije_mm[2] = value;

                if (dimenzije_mm[0] == 0 || dimenzije_mm[1] == 0 || dimenzije_mm[2] == 0)
                {
                    dimenzije_mm[3] = 0;
                }
                else
                {
                    dimenzije_mm[3] = (dimenzije_mm[0] * dimenzije_mm[1] * dimenzije_mm[2]);
                }
            }
        }

        public int volumen
        {
            get
            {
                return dimenzije_mm[3];
            }
        }

        //override, konstr., destruk.
        public override string ToString()
        {
            string output = $"Oprema {idOpreme} {Environment.NewLine}--------------------------------------------------------------{Environment.NewLine}Naziv: {naziv.ToUpper()}{Environment.NewLine}Opis: {opis.ToUpper()}{Environment.NewLine}Vrednost: {cena} €{Environment.NewLine}Teža: {teza} KG{Environment.NewLine}Pripomba: {komentar}{Environment.NewLine}Dimenzije: {Environment.NewLine}    X: {x} mm{Environment.NewLine}    Y: {y} mm    =    {volumen} mm{Environment.NewLine}    Z: {z} mm{Environment.NewLine}";
            return output;
        }


        public Oprema()
        {
            x = 100; y = 100; z = 100;
            cena = 1;
            teza = 1;
            Naziv = "Testna oprema";
            Opis = "";
            Komentar = "";
            IdOpreme = stArtiklov;
            StArtiklov++;
        }

        public Oprema(string naziv, string opis, string komentar, double teza, double cena, int kvantiteta, int x, int y, int z)
        {
            this.naziv = naziv;
            this.opis = opis;
            this.komentar = komentar;
            this.teza = teza;
            this.cena = cena;
            this.kvantiteta = kvantiteta;
            this.x = x;
            this.y = y;
            this.z = z;
            IdOpreme = stArtiklov;
            StArtiklov++;
        }

        public Oprema(Oprema oprema)
        {
            naziv = oprema.naziv;
            opis = oprema.opis;
            komentar = oprema.komentar;
            teza = oprema.teza;
            cena = oprema.cena;
            kvantiteta = oprema.kvantiteta;
            dimenzije_mm = oprema.dimenzije_mm;
            x = oprema.x;
            y = oprema.y;
            z = oprema.z;
            IdOpreme = stArtiklov;
            StArtiklov++;
        }

        ~Oprema()
        {
            MessageBox.Show($"Oprema ({naziv}) z ID {idOpreme} je bila odstranjena.");
        }
    }

    //OSEBA
    public class Oseba
    {
        DateTime DatumPrijave;
        protected DateTime DatumRojstva;
        protected string Ime, Priimek, Komentar, Naslov, Email, Telefon;
        int PostnaSt, IdOsebe;
        static int StOseb;
        public enum Spol
        {
            m,
            z,
            n
        };
        protected Spol spol;

        
        public DateTime datumRojstva
        {
            get { return DatumRojstva; }
            set { DatumRojstva = NajdiDatum(value.Day, value.Month, value.Year); }
        }
        public void NastaviSpol(string spol)
        {
            spol = spol.Trim().ToLower();
            if(spol == "moski" || spol == "moški" || spol == "m" || spol == "male" || spol == "male")
            {
                this.spol = Spol.m;
            }
            else if(spol == "ženski" || spol == "zenski" || spol == "female" || spol == "woman" || spol == "f" || spol == "z" || spol == "ž")
            {
                this.spol = Spol.z;
            }
            else
            {
                this.spol = Spol.n;
            }
        }
        public void NastaviSpol(Spol spol)
        {
            this.spol = spol;
        }
        public static Spol VrniSpol(string spol)
        {
            spol = spol.Trim().ToLower();
            if (spol == "moski" || spol == "moški" || spol == "m" || spol == "male" || spol == "male" || spol == "Moški")
            {
                return Spol.m;
            }
            else if (spol == "ženski" || spol == "zenski" || spol == "female" || spol == "woman" || spol == "f" || spol == "z" || spol == "ž" || spol == "Ženski")
            {
                return Spol.z;
            }
            else
            {
                return Spol.n;
            }
        }
        public string IzpisiSpol()
        {
            if (spol == Spol.m)
            {
                return "Moški";
            }
            else if (spol == Spol.z)
            {
                return "Ženski";
            }
            else
            {
                return "Nedoločen";
            }
        }
        public static string IzpisiSpol(string spol)
        {
            spol = spol.Trim().ToLower();
            if (spol == "moski" || spol == "moški" || spol == "m" || spol == "male" || spol == "male")
            {
                return "Moški";
            }
            else if (spol == "ženski" || spol == "zenski" || spol == "female" || spol == "woman" || spol == "f" || spol == "z" || spol == "ž")
            {
                return "Ženski";
            }
            else
            {
                return "Nedoločen";
            }
        }
        public static string IzpisiSpol(Oseba oseba)
        {
            if (oseba.spol == Spol.m)
            {
                return "Moški";
            }
            else if (oseba.spol == Spol.z)
            {
                return "Ženski";
            }
            else
            {
                return "Nedoločen";
            }
        }
        public int stOseb
        {
            get { return StOseb; }
            set
            {
                if(value == StOseb + 1)
                {
                    StOseb = value;
                }
            }
        }
        public int idOsebe
        {
            get { return IdOsebe; }
            set
            {
                if(value == stOseb)
                {
                    IdOsebe = value;
                }
            }
        }
        public DateTime datumPrijave
        {
            get { return DatumPrijave; }
            set
            {
                if(value == DateTime.Now)
                {
                    DatumPrijave = value;
                }
            }
        }
        
        public static bool PreveriDatum(int d, int m, int y)
        {
            int[] leapMonths = { 1, 3, 5, 7, 8, 10, 12 };
            int feb = 28;
            int leapMonth = 30;

            //check if the values are negative
            if (y < 0 || m < 0 || d < 0)
            {
                return false;
            }

            //check for leap years
            if ((y % 4 == 0 && y % 100 != 0) || (y % 400 == 0 && y % 100 == 0))
            {
                feb = 29;
            }

            //check for correct month input
            if (m > 12)
            {
                return false;
            }

            //check for leap months
            for (int i = 0; i < leapMonths.Length; i++)
            {
                if (leapMonths[i] == m)
                {
                    leapMonth = 31;
                }
            }

            //Check proper leap month input
            if (d > leapMonth)
            {
                return false;
            }

            //check if there is a wrong number of days in leap february
            if (m == 2 && d > feb)
            {
                return false;
            }

            return true;
        }
        public static DateTime NajdiDatum(int d, int m, int y)
        {
            bool veljavenDatum = false;

            //preverjaj datume in, pristej ce datum ni ustrezen
            do
            {
                //datum ustrezen
                if (PreveriDatum(d, m, y))
                {
                    veljavenDatum = true;
                }
                //datum ni ustrezen, prilagajaj datum
                else
                {
                    //zadnji dan v mesecu
                    if (d >= 31)
                    {       
                        //vec kot 31. dan - nastavljanje karte
                        if(d > 31)
                        {
                            m += d / 31;
                            d %= 31;
                        }
                        //31. december - nastavi datum na 1.1.[naslednje leto]
                        if (m >= 12)
                        {
                            //vec kot december - nastavljanje nove karte
                            if(m > 12)
                            {
                                y += m / 12;
                                m %= 12;
                            }
                            //mesec je december
                            else
                            {
                                m = 1;
                                y++;
                            }
                        }
                        //mesec ni 12. ali vec
                        else
                        {
                            m++;
                            d = 1;
                        }
                    }
                    //ni zadnji dan v mesecu - pristej dan
                    else
                    {
                        d++;
                    }
                    
                    //preveri, ce so mesci med 1 in 12
                    if (m > 12)
                    {
                        m = 12;
                        d = 31;
                    }
                    //vpisan mesec manjsi od 1 
                    else if(m < 1)
                    {
                        m = 1;
                        d = 1;
                    }

                    //preveri leta
                    if(y < 1900)
                    {
                        y = 1900;
                    }
                }
            }
            while (veljavenDatum != true);
            return new DateTime(y, m, d);
        }

        public string ime
        {
            get
            {
                return Ime;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    MessageBox.Show("Ime ne sme biti prazno.");
                }
                else
                {
                    Ime = value.Trim();
                }
            }
        }
        public string priimek
        {
            get
            {
                return Priimek;
            }
            set
            {   
                if(value == null || value.Trim() == "")
                {
                    MessageBox.Show("Priimek ne sme biti prazen.");
                }
                else
                {
                    Priimek = value.Trim();
                }
            }
        }
        public string komentar
        {
            get
            {
                return Komentar;
            }
            set
            {
                if(value == null || value.Trim() == "")
                {
                    value = "Brez komentarja";
                }
                Komentar = value.Trim();
            }
        }
        public string naslov
        {
            get
            {
                return Naslov;
            }
            set
            {
                if(value == null || value.Trim() == "")
                {
                    MessageBox.Show("Naslov ne sme biti prazen");
                }
                else
                {
                    Naslov = value.Trim();
                }
            }
        }
        public string email
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value.Trim();
            }
        }
        public string telefon
        {
            get
            {
                return Telefon;
            }
            set
            {
                Telefon = value.Trim();
            }
        }
        public int postnaSt
        {
            get
            {
                return PostnaSt;
            }
            set
            {
                if (value < 1000 || value > 9999)
                {
                    MessageBox.Show("Poštna številka ustanove mora biti med 1000 in 9999");
                    value = 1000;
                }
                PostnaSt = value;
            }
        }

        public override string ToString()
        {
            string output = $"Oseba {idOsebe}: {Environment.NewLine}Ime, priimek in spol: {ime + ", " + priimek} ({IzpisiSpol()}) {Environment.NewLine}Naslov: {naslov + ", " + postnaSt}{Environment.NewLine}Kontakt: Tel. [{telefon}] , E-pošta [{email}]{Environment.NewLine}Datum rojstva: {datumRojstva} {Environment.NewLine}Datum prijave: {datumPrijave}{Environment.NewLine}Pripomba: \"{komentar}\"";
            return output;
        }

        public Oseba()
        {
            DatumPrijave = DateTime.Now; DatumRojstva = NajdiDatum(datumPrijave.Day, datumPrijave.Month, datumPrijave.Year - 18);
            ime = "Testna"; priimek = "Oseba"; spol = Spol.n;
            komentar = ""; naslov = "[Nedoločen]";
            email = ""; telefon = ""; postnaSt = 1000;
            IdOsebe = stOseb;
            StOseb++;
        }
        public Oseba(string Ime, string Priimek, string Komentar, string Naslov, string Email, string Telefon, Spol spol, int PostnaSt, DateTime DatumRojstva)
        {
            ime = Ime.Trim().ToLower();
            priimek = Priimek.Trim().ToLower();
            komentar = Komentar.Trim();
            naslov = Naslov.Trim();
            email = Email.Trim();
            telefon = Telefon.Trim();
            this.spol = spol;
            postnaSt = PostnaSt;
            DatumPrijave = DateTime.Now;
            datumRojstva = NajdiDatum(DatumRojstva.Day, DatumRojstva.Month, DatumRojstva.Year);
            IdOsebe = stOseb;
            StOseb++;
        }
        public Oseba(Oseba oseba)
        {
            ime = oseba.ime;
            priimek = oseba.priimek;
            komentar = oseba.komentar;
            naslov = oseba.naslov; 
            email = oseba.email;
            telefon = oseba.telefon;
            spol = oseba.spol;
            postnaSt = oseba.postnaSt;
            DatumPrijave = DateTime.Now;
            datumRojstva = NajdiDatum(oseba.datumRojstva.Day, oseba.datumRojstva.Month, oseba.datumRojstva.Year);
            IdOsebe = stOseb;
            StOseb++;
        }

        ~Oseba()
        {
            MessageBox.Show($"Oseba ({ime + " " + priimek}) z ID {idOsebe} je bila izbrisana");
        }
    }

    //STRANKA, OSEBJE - 2. NIVO
    public class Osebje : Oseba
    {
        string Poklic, TRR, Davcna_st;
        DateTime Pogodba_do;
        double Placa;
        static int StZaposlenih = 0; 
        readonly int IdZaposlenega;

        public DateTime pogodbaDo
        {
            get { return Pogodba_do; }
            set
            {
                Pogodba_do = NajdiDatum(value.Day, value.Month, value.Year);
            }
        }
        static public int stZaposlenih
        {
            get { return StZaposlenih; }
        }
        public int idZaposlenega
        {
            get { return IdZaposlenega; }
        }
        public double placa
        {
            get
            {
                return Placa;
            }
            set
            {   
                if(value < 5)
                {
                    value = 5;
                }
                Placa = value;
            }
        }
        public string poklic
        {
            get { return Poklic; }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    value = "Nedoločeno";
                }
                Poklic = value.Trim();
            }
        }
        public string trr
        {
            get { return TRR; }
            set
            {
                if(value == "" || value.Trim() == "")
                {
                    MessageBox.Show("TRR mora biti vpisan.");
                }
                else
                {
                    TRR = value.Trim();
                }
            }
        }
        public string davcna_st
        {
            get { return Davcna_st; }
            set
            {
                if(value == "" || value.Trim() == "")
                {
                    MessageBox.Show("Davčna številka mora biti vpisana.");
                }
                else
                {
                    Davcna_st = value.Trim();
                }
            }
        }

        public override string ToString()
        {
            string output = $"Zaposleni {idZaposlenega} {Environment.NewLine}---------------------------------------------------------------------------{Environment.NewLine}Ime, priimek in spol: {ime + ", " + priimek} ({IzpisiSpol()}) {Environment.NewLine}Naslov: {naslov + ", " + postnaSt}{Environment.NewLine}Kontakt: Tel. [{telefon}] , E-pošta [{email}]{Environment.NewLine}Datum rojstva: {datumRojstva} {Environment.NewLine}Datum zaposlitve: {datumPrijave} {Environment.NewLine}Zaposlen do: {pogodbaDo} {Environment.NewLine}Poklic: \"{poklic}\" {Environment.NewLine}TRR: {trr} {Environment.NewLine}Davčna številka: {davcna_st} {Environment.NewLine}Pripomba: \"{komentar}\"";
            return output;
        }

        public Osebje() : base()
        {   
            placa = 5;
            ime = "Testni";
            priimek = "Delavec";
            Pogodba_do = NajdiDatum(datumPrijave.Day, datumPrijave.Month + 1, datumPrijave.Year);
            trr = "SI56 1234 5678 9012 345";
            davcna_st = "12345678";
            poklic = "";
            IdZaposlenega = stZaposlenih;
            StZaposlenih++;
        }
        public Osebje(string Ime, string Priimek, string Komentar, string Naslov, string Email, string Telefon, Spol spol, int PostnaSt, DateTime DatumRojstva, double Placa, DateTime Pogodba_do, string TRR, string DavcnaSt, string Poklic)
        {
            ime = Ime.Trim().ToLower();
            priimek = Priimek.Trim().ToLower();
            komentar = Komentar.Trim();
            naslov = Naslov.Trim();
            email = Email.Trim();
            telefon = Telefon.Trim();
            this.spol = spol;
            postnaSt = PostnaSt;
            datumPrijave = DateTime.Now;
            datumRojstva = NajdiDatum(DatumRojstva.Day, DatumRojstva.Month, DatumRojstva.Year);
            placa = Placa;
            this.Pogodba_do = NajdiDatum(Pogodba_do.Day, Pogodba_do.Month, Pogodba_do.Year);
            trr = TRR;
            davcna_st = DavcnaSt;
            poklic = Poklic;
            IdZaposlenega = stZaposlenih;
            idOsebe = stOseb;
            stOseb++;
            StZaposlenih++;
        }
        public Osebje(Osebje osebje)
        {
            ime = osebje.ime;
            priimek = osebje.priimek;
            komentar = osebje.komentar;
            naslov = osebje.naslov;
            email = osebje.email;
            telefon = osebje.telefon;
            spol = osebje.spol;
            postnaSt = osebje.postnaSt;
            datumPrijave = osebje.datumPrijave;
            datumRojstva = NajdiDatum(osebje.datumRojstva.Day, osebje.datumRojstva.Month, osebje.datumRojstva.Year);
            placa = osebje.placa;
            Pogodba_do = NajdiDatum(osebje.Pogodba_do.Day, osebje.Pogodba_do.Month, osebje.Pogodba_do.Year);
            trr = osebje.trr;
            davcna_st = osebje.davcna_st;
            poklic = osebje.poklic;
            IdZaposlenega = stZaposlenih;
            idOsebe = stOseb;
            stOseb++;
            StZaposlenih++;
        }

        ~Osebje()
        {
            MessageBox.Show($"Delavec oz. delavka ({ime + " " + priimek}) z ID {idZaposlenega} je bil(a) izbrisana");
        }
    }
    public class Stranka : Oseba
    {
        DateTime DatumKarte;
        protected List<DateTime> Obiski = new List<DateTime>();

        double CenaKarte;
        static int StStrank = 0;
        int IdStranke;

        public DateTime datumKarte
        {
            get { return DatumKarte; }
            set
            {
                DatumKarte = NajdiDatum(value.Day, value.Month, value.Year);
            }
        }

        public static int stStrank
        {
            get { return StStrank; }
            protected set
            {
                if(value == stStrank + 1)
                {
                    StStrank = value;
                }
            }
        }

        public int idStranke
        {
            get { return IdStranke; }
            protected set
            {
                if(value == stStrank)
                {
                    IdStranke = value;
                }
            }
        }

        public double cenaKarte
        {
            get
            {
                return CenaKarte;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                CenaKarte = value;
            }
        }
        
        public List<DateTime> obiski
        {
            get { return Obiski; }
        }

        public virtual void NovObisk()
        {
            Obiski.Add(DateTime.Now);
            MessageBox.Show($"{obiski.Count}. obisk za stranko {idStranke} dodan");
        }

        public void NovaKarta()
        {
            DatumKarte = NajdiDatum(DatumKarte.Day, DatumKarte.Month + 1, DatumKarte.Year);
        }

        public void NovaKarta(int stDni)
        {
            double stMesecev, stLet, stPreostalihDni;
            //nepravilen vpis
            if (stDni < 1)
            {
                NovaKarta();
            }
            //pravilen vpis
            else
            {   
                //vec kot en mesec
                if(stDni > 30)
                {
                    stMesecev = stDni / 30;
                    stPreostalihDni = stDni % 30;
                    stLet = 0;
                    stMesecev = Math.Floor(stMesecev);
                    //vec kot leto
                    if (stMesecev >= 12)
                    {
                        stLet = stMesecev / 12;
                        stMesecev = (stMesecev % 12);
                        stLet = Math.Floor(stLet);
                    }
                    DatumKarte = NajdiDatum(datumKarte.Day + (int)stPreostalihDni, datumKarte.Month + (int)stMesecev, datumKarte.Year + (int)stLet);
                }
                else
                {
                    DatumKarte = NajdiDatum(datumKarte.Day + stDni, datumKarte.Month, datumKarte.Year);
                }
            }
        }

        //Konstr. destruk., polimorfizmi, override
        public virtual void IzpisiObiske()
        {
            string output = ToString() + $"{Environment.NewLine} {Environment.NewLine}----------------------------------------------------------------------------------{Environment.NewLine} {Environment.NewLine}";
            output += $"Obiski stranke {idStranke}: {ime.ToUpper()}, {priimek.ToUpper()} ({IzpisiSpol()}) {Environment.NewLine}";
            for (int i = 0; i < obiski.Count; i++)
            {
                output += $"     {i+1}. Obisk: {obiski[i].Day}. {obiski[i].Month}. {obiski[i].Year} {Environment.NewLine}";
            }
            MessageBox.Show(output);    
        }

        public override string ToString()
        {
            string output = $"Stranka {idStranke}{Environment.NewLine}----------------------------------------------------------------------------------{Environment.NewLine} {Environment.NewLine}Ime, priimek in spol: {ime.ToUpper() + ", " + priimek.ToUpper()} ({IzpisiSpol()}) {Environment.NewLine}Naslov: {naslov + ", " + postnaSt}{Environment.NewLine}Kontakt: Tel. [{telefon}] , E-pošta [{email}]{Environment.NewLine}Datum rojstva: {datumRojstva} {Environment.NewLine}Datum prijave: {datumPrijave} {Environment.NewLine}Karta do: {datumKarte} {Environment.NewLine}Cena karte: {cenaKarte} € {Environment.NewLine}Pripomba: \"{komentar}\"";
            return output;
        }

        public Stranka() : base()
        {
            DatumKarte = NajdiDatum(datumPrijave.Day, datumPrijave.Month + 1, datumPrijave.Year);
            ime = "Testna"; priimek = "Stranka";
            NovObisk();
            cenaKarte = 30;
            idStranke = stStrank;
            stStrank++;
        }

        public Stranka(string Ime, string Priimek, string Komentar, string Naslov, string Email, string Telefon, Spol spol, int PostnaSt, DateTime DatumRojstva, DateTime DatumKarte, double CenaKarte)
        {
            ime = Ime.Trim().ToLower();
            priimek = Priimek.Trim().ToLower();
            komentar = Komentar.Trim();
            naslov = Naslov.Trim();
            email = Email.Trim();
            telefon = Telefon.Trim();
            this.spol = spol;
            postnaSt = PostnaSt;
            datumPrijave = DateTime.Now;
            datumRojstva = NajdiDatum(DatumRojstva.Day, DatumRojstva.Month, DatumRojstva.Year);
            datumKarte = NajdiDatum(DatumKarte.Day, DatumKarte.Month, DatumKarte.Year);
            NovObisk();
            cenaKarte = CenaKarte;
            idStranke = stStrank;
            idOsebe = stOseb;
            //stOseb++;
            stStrank++;
        }

        ~Stranka()
        {
            MessageBox.Show($"Stranka ({ime + " " + priimek}) z ID {idStranke} je bila izbrisana.");
        }
    }

    //POSEBNE STRANKE - 3. NIVO
    public class Ucenec : Stranka
    {
        string Sola, Program, NaslovSole;
        int PostaSole, Letnik;
        double Akcija = 0.15;

        public double akcija
        {
            get { return Akcija; }
            set
            {
                if (value <= 1 || value < 0)
                {
                    value = 0.15;
                }
                Akcija = value;
            }
        }
        public int postaSole
        {
            get { return PostaSole; }
            set
            {
                if(value < 1000 || value > 9999)
                {
                    MessageBox.Show("Poštna številka šole mora biti med 1000 in 9999.");
                    value = 1000;
                }
                PostaSole = value;
            }
        }
        public int letnik
        {
            get { return Letnik; }
            set
            {
                if(value < 1 || value > 10)
                {
                    value = 1;
                }
                Letnik = value;
            }
        }
        public string sola
        {
            get
            {
                return Sola;
            }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                Sola = value.Trim();
            }
        }
        public string program
        {
            get { return Program; }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    value = "Nedoločen";
                }
                Program = value.Trim();
            }
        }
        public string naslovSole
        {
            get { return NaslovSole; }
            set
            {
                if(value == null || value.Trim() == "")
                {
                    value = "Neznano";
                }
                NaslovSole = value.Trim();
            }
        }

        //Konstr. destruk., polimorfizmi, override
        public override void IzpisiObiske()
        {
            string output = ToString() + $"{Environment.NewLine} {Environment.NewLine}----------------------------------------------------------------------------------{Environment.NewLine} {Environment.NewLine}";
            output += $"Obiski učenca (stranka {idStranke}): {ime.ToUpper()}, {priimek.ToUpper()} ({IzpisiSpol()}) {Environment.NewLine}";
            for (int i = 0; i < obiski.Count; i++)
            {
                output += $"    {i + 1}. Obisk: {obiski[i].Day}. {obiski[i].Month}. {obiski[i].Year} {Environment.NewLine}";
            }
            MessageBox.Show(output);
        }

        public override string ToString()
        {
            string output = $"Učenec (stranka {idStranke}){Environment.NewLine}----------------------------------------------------------------------------------{Environment.NewLine} {Environment.NewLine}Ime, priimek in spol: {ime.ToUpper() + ", " + priimek.ToUpper()} ({IzpisiSpol()}) {Environment.NewLine}Učni program: {program} - {letnik}. letnik {Environment.NewLine}Naslov: {naslov + ", " + postnaSt}{Environment.NewLine}Kontakt: Tel. [{telefon}] , E-pošta [{email}]{Environment.NewLine}Datum rojstva: {datumRojstva} {Environment.NewLine}Datum prijave: {datumPrijave} {Environment.NewLine}Karta do: {datumKarte} {Environment.NewLine}Akcija na karto (%): {Convert.ToInt32(akcija * 100)} {Environment.NewLine}Naslov šole oz. fakultete: {naslovSole}, {postaSole} {Environment.NewLine}Cena karte: {cenaKarte} € {Environment.NewLine}Pripomba: \"{komentar}\"";
            return output;
        }

        public Ucenec() : base()
        {
            ime = "Testni"; priimek = "Učenec";
            cenaKarte = cenaKarte - Math.Round(cenaKarte * akcija, 2);
            sola = "Testna šola";
            program = "";
            naslovSole = "Ljubljanska ulica 8";
            letnik = 1;
            postaSole = 1000;
        }

        public Ucenec(string Ime, string Priimek, string Komentar, string Naslov, string Email, string Telefon, Spol spol, int PostnaSt, DateTime DatumKarte, DateTime DatumRojstva, double Akcija, string Sola, string Program, string NaslovSole, int Letnik, int PostaSole, double CenaKarte)
        {
            ime = Ime.Trim().ToLower();
            priimek = Priimek.Trim().ToLower();
            komentar = Komentar.Trim();
            naslov = Naslov.Trim();
            email = Email.Trim();
            telefon = Telefon.Trim();
            this.spol = spol;
            postnaSt = PostnaSt;
            datumPrijave = DateTime.Now;
            datumRojstva = NajdiDatum(DatumRojstva.Day, DatumRojstva.Month, DatumRojstva.Year);
            cenaKarte = CenaKarte - Math.Round(cenaKarte * Akcija, 2);
            datumKarte = NajdiDatum(DatumKarte.Day, DatumKarte.Month, DatumKarte.Year);
            //NovObisk();
            sola = Sola.Trim();
            program = Program.Trim();
            naslovSole = NaslovSole.Trim();
            letnik = Letnik;
            postaSole = PostaSole;
            idStranke = stStrank;
            idOsebe = stOseb;
            //stOseb++;
            //stStrank++;
        }

        public Ucenec(Ucenec ucenec)
        {
            ime = ucenec.ime;
            priimek = ucenec.priimek;
            komentar = ucenec.komentar;
            naslov = ucenec.naslov;
            email = ucenec.email;
            telefon = ucenec.telefon;
            spol = ucenec.spol;
            postnaSt = ucenec.postnaSt;
            datumPrijave = DateTime.Now;
            datumRojstva = NajdiDatum(ucenec.datumRojstva.Day, ucenec.datumRojstva.Month, ucenec.datumRojstva.Year);
            datumKarte = NajdiDatum(ucenec.datumKarte.Day, ucenec.datumKarte.Month, ucenec.datumKarte.Year);
            cenaKarte = ucenec.cenaKarte - Math.Round(ucenec.cenaKarte * ucenec.akcija, 2);
            sola = ucenec.sola;
            program = ucenec.program;
            naslovSole = ucenec.naslovSole;
            letnik = ucenec.letnik;
            postaSole = ucenec.postaSole;
            Obiski = ucenec.Obiski;
            idStranke = stStrank;
            idOsebe = stOseb;
            //stOseb++;
            //stStrank++;
        }

        ~Ucenec()
        {
            MessageBox.Show($"Učenec oz. učenka ({ime + " " + priimek}) z ID stranke {idStranke} je bil(a) izbrisan(a).");
        }
    }
    public class Usluzbenci : Stranka
    {
        string Poklic, Ustanova, NaslovUstanove;
        int PostaUstanove;
        double Akcija = 0.25;
        public double akcija
        {
            get { return Akcija; }
            set
            {
                if (value <= 1 || value < 0)
                {
                    value = 0.25;
                }
                Akcija = value;
            }
        }
        public int postaUstanove
        {
            get { return PostaUstanove; }
            set
            {
                if(value < 1000 || value > 9999)
                {
                    MessageBox.Show("Poštna številka ustanove mora biti med 1000 in 9999");
                    value = 1000;
                }
                PostaUstanove = value;
            }
        }
        public string poklic
        {
            get { return Poklic; }
            set
            {
                if(value == null || value.Trim() == "")
                {
                    MessageBox.Show("Javni uslužbenec mora imeti določen poklic, da lahko ima akcijo.");
                }
                else
                {
                    Poklic = value.Trim();
                }
            }
        }
        public string ustanova
        {
            get { return Ustanova; }
            set
            {
                
                if (value == null || value.Trim() == "")
                {
                    value = "";
                }
                Ustanova = value;
            }
        }
        public string naslovUstanove
        {
            get { return NaslovUstanove; }
            set
            {
                if(value == null || value.Trim() == "")
                {
                    value = "Neznano";
                }
                NaslovUstanove = value.Trim();
            }
        }

        //Konstr. destruk., polimorfizmi, override
        public override void IzpisiObiske()
        {
            string output = ToString() + $"{Environment.NewLine} {Environment.NewLine}----------------------------------------------------------------------------------{Environment.NewLine} {Environment.NewLine}";
            output = $"Obiski javnega uslužbenca (stranka {idStranke}): {ime.ToUpper()}, {priimek.ToUpper()} ({IzpisiSpol()}) {Environment.NewLine}";
            for (int i = 0; i < obiski.Count; i++)
            {
                output += $"    {i + 1}. Obisk: {obiski[i].Day}. {obiski[i].Month}. {obiski[i].Year} {Environment.NewLine}";
            }
            MessageBox.Show(output);
        }

        public override string ToString()
        {
            string output = $"Javni uslužbenec (stranka {idStranke}){Environment.NewLine}----------------------------------------------------------------------------------{Environment.NewLine} {Environment.NewLine}Ime, priimek in spol: {ime.ToUpper() + ", " + priimek.ToUpper()} ({IzpisiSpol()}) {Environment.NewLine}Poklic: {poklic} {Environment.NewLine}Naslov: {naslov + ", " + postnaSt} {Environment.NewLine}Kontakt: Tel. [{telefon}] , E-pošta [{email}] {Environment.NewLine}Datum rojstva: {datumRojstva} {Environment.NewLine}Datum prijave: {datumPrijave} {Environment.NewLine}Karta do: {datumKarte} {Environment.NewLine}Akcija na karto (%): {Convert.ToInt32(akcija * 100)} {Environment.NewLine}Naslov ustanove: {naslovUstanove}, {postaUstanove} {Environment.NewLine}Cena karte: {cenaKarte} € {Environment.NewLine}Pripomba: \"{komentar}\"";
            return output;
        }

        public Usluzbenci() : base()
        {
            ime = "Testni"; priimek = "Uslužbenec";
            poklic = "Smetar"; ustanova = "Simbio d.o.o."; naslovUstanove = "Ljubljanska cesta 9";
            postaUstanove = 1000;
            cenaKarte = cenaKarte - Math.Round(cenaKarte * akcija, 2);
        }

        public Usluzbenci(string Ime, string Priimek, string Komentar, string Naslov, string Email, string Telefon, Spol spol, int PostnaSt, DateTime DatumKarte, DateTime DatumRojstva, double Akcija, string Poklic, string Ustanova, string NaslovUstanove, int PostaUstanove, double CenaKarte)
        {
            ime = Ime.Trim().ToLower();
            priimek = Priimek.Trim().ToLower();
            komentar = Komentar.Trim();
            naslov = Naslov.Trim();
            email = Email.Trim();
            telefon = Telefon.Trim();
            this.spol = spol;
            postnaSt = PostnaSt;
            datumPrijave = DateTime.Now;
            datumRojstva = NajdiDatum(DatumRojstva.Day, DatumRojstva.Month, DatumRojstva.Year);
            cenaKarte = CenaKarte - Math.Round(cenaKarte * Akcija, 2);
            datumKarte = NajdiDatum(DatumKarte.Day, DatumKarte.Month, DatumKarte.Year);
            //NovObisk();
            poklic = Poklic;
            ustanova = Ustanova;
            naslovUstanove = NaslovUstanove;
            postaUstanove = PostaUstanove;
            idStranke = stStrank;
            idOsebe = stOseb;
            //stOseb++;
            //stStrank++;
        }

        public Usluzbenci(Usluzbenci usluzbenec)
        {
            ime = usluzbenec.ime;
            priimek = usluzbenec.priimek;
            komentar = usluzbenec.komentar;
            naslov = usluzbenec.naslov;
            email = usluzbenec.email;
            telefon = usluzbenec.telefon;
            spol = usluzbenec.spol;
            postnaSt = usluzbenec.postnaSt;
            datumPrijave = usluzbenec.datumPrijave;
            datumRojstva = NajdiDatum(usluzbenec.datumRojstva.Day, usluzbenec.datumRojstva.Month, usluzbenec.datumRojstva.Year);
            datumKarte = NajdiDatum(usluzbenec.datumKarte.Day, usluzbenec.datumKarte.Month, usluzbenec.datumKarte.Year);
            Obiski = usluzbenec.Obiski;
            cenaKarte = usluzbenec.cenaKarte - Math.Round(usluzbenec.cenaKarte * usluzbenec.akcija, 2);
            poklic = usluzbenec.poklic;
            ustanova = usluzbenec.ustanova;
            naslovUstanove = usluzbenec.naslovUstanove;
            postaUstanove = usluzbenec.postaUstanove;
            idStranke = stStrank;
            idOsebe = stOseb;
            //stOseb++;
            //stStrank++;
        }

        ~Usluzbenci()
        {
            MessageBox.Show($"Javni uslužbenec oz. uslužbenka ({ime + " " + priimek}) z ID stranke {idStranke} je bil(a) izbrisana.");
        }
    }
}
