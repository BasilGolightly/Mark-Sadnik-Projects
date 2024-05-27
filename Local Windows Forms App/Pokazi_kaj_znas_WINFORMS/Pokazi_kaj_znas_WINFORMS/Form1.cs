using Gym;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
namespace Pokazi_kaj_znas_WINFORMS
{
    public partial class Form1 : Form
    {
        //listi + display mode za skrivanje / kazanje panelov
        static int mode = 0;
        static List<Oprema> Oprema = new List<Oprema>();
        static List<Stranka> Stranke = new List<Stranka>();
        static List<Ucenec> Ucenci = new List<Ucenec>();
        static List<Usluzbenci> Usluzbenec = new List<Usluzbenci>();
        static List<Osebje> Zaposleni = new List<Osebje>();

        //primer opreme, stranke, zaposlenih
        //static Oprema new_oprema = new Oprema("4KG enoroèna utež", "4KG enoroèna utež nike", "", 4, 50.99, 2, 300, 200, 100);

        public Form1()
        {
            InitializeComponent();
        }

        /*tipki oz. labeli za nazaj*/
        public void Nazaj()
        {
            //homepage
            if (mode == 0)
            {
                Application.Exit();
            }
            //drugo
            else if (mode > 0 && mode < 4)
            {
                Prikaz(0);
                mode = 0;
            }
        }
        private void DirectionLabel_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        private void ArrowLabel_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        private void ArrowLabel1_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        private void DirectionLabel1_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        private void DirectionLabel2_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        private void ArrowLabel2_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        private void ArrowLabel3_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        private void DirectionLabel3_Click(object sender, EventArgs e)
        {
            Nazaj();
        }
        /*tipki oz. labeli za nazaj*/



        /*PRIKAZ PANELOV*/
        public void Prikaz(int mode)
        {
            //homepage
            if (mode == 0)
            {
                //prikazi home panel, skrij druge
                OpremaPanel.Visible = false;
                OsebjePanel.Visible = false;
                StrankePanel.Visible = false;
                HomePanel.Size = new Size(1005, 600);
                HomePanel.Location = new Point(0, 40);
                HomePanel.Visible = true;
            }
            //stranke
            else if (mode == 1)
            {
                //prikazi stranke panel, skrij druge
                HomePanel.Visible = false;
                OpremaPanel.Visible = false;
                OsebjePanel.Visible = false;
                StrankePanel.Size = new Size(1005, 600);
                StrankePanel.Location = new Point(0, 40);
                StrankeTable.Size = new Size(850, 260);
                StrankeTable.Location = new Point(75, 100);
                AddCustPanel.Visible = false;
                StrankePanel.Visible = true;
                SearchCustTextBox.Focus();
            }
            //osebje
            else if (mode == 2)
            {
                //prikazi osebje panel, skrij druge
                HomePanel.Visible = false;
                OpremaPanel.Visible = false;
                StrankePanel.Visible = false;
                OsebjePanel.Size = new Size(1005, 600);
                OsebjePanel.Location = new Point(0, 40);
                ZaposleniTable.Size = new Size(850, 260);
                AddOsebjePanel.Visible = false;
                ZaposleniTable.Location = new Point(75, 100);
                OsebjePanel.Visible = true;
                SearchOsebjeTextBox.Focus();
            }
            //oprema
            else if (mode == 3)
            {
                //prikazi oprema panel, skrij druge
                HomePanel.Visible = false;
                StrankePanel.Visible = false;
                OsebjePanel.Visible = false;
                AddCustPanel.Visible = false;
                OpremaPanel.Size = new Size(1005, 600);
                OpremaPanel.Location = new Point(0, 40);
                OpremaTable.Size = new Size(850, 260);
                OpremaTable.Location = new Point(75, 100);
                AddToolPanel.Visible = false;
                OpremaPanel.Visible = true;
                SearchOpremaTextBox.Focus();
            }
            //oprema add
            else if (mode == 4)
            {
                HomePanel.Visible = false;
                StrankePanel.Visible = false;
                OsebjePanel.Visible = false;
                AddCustPanel.Visible = false;
                AddOsebjePanel.Visible = false;
                OpremaPanel.Size = new Size(1005, 600);
                OpremaPanel.Location = new Point(0, 40);
                OpremaTable.Size = new Size(850, 260);
                AddToolPanel.Size = new Size(850, 210);
                OpremaTable.Location = new Point(75, 315);
                OpremaPanel.Visible = true;
                AddToolPanel.Visible = true;
                NazivOpreme.Focus();
            }
            //stranka add
            else if (mode == 5)
            {
                HomePanel.Visible = false;
                OpremaPanel.Visible = false;
                OsebjePanel.Visible = false;
                StrankePanel.Size = new Size(1005, 600);
                StrankePanel.Location = new Point(0, 40);
                StrankeTable.Size = new Size(850, 260);
                AddCustPanel.Size = new Size(850, 230);
                StrankeTable.Location = new Point(75, 335);
                StrankePanel.Visible = true;
                AddCustPanel.Visible = true;
            }
            //osebje add
            else if (mode == 6)
            {
                HomePanel.Visible = false;
                OpremaPanel.Visible = false;
                StrankePanel.Visible = false;
                OsebjePanel.Size = new Size(1005, 600);
                OsebjePanel.Location = new Point(0, 40);
                AddOsebjePanel.Size = new Size(850, 230);
                ZaposleniTable.Size = new Size(850, 260);
                ZaposleniTable.Location = new Point(75, 335);
                OsebjePanel.Visible = true;
                AddOsebjePanel.Visible = true;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Prikaz(1);
            mode = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Prikaz(2);
            mode = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Prikaz(3);
            mode = 3;
        }
        /*PRIKAZ PANELOV*/

        /*SEARCH*/
        public static bool IsNumeric(string text)
        {
            if (text.Trim().Length <= 0)
            {
                return false;
            }
            else
            {
                text = text.Trim();
                bool isNumeric = true;
                foreach (char c in text)
                {
                    if (c < '0' || c > '9')
                    {
                        isNumeric = false;
                    }
                }

                if (isNumeric)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool IsDecimal(string text)
        {
            if (text.Trim().Length <= 0)
            {
                return false;
            }
            else
            {
                text = text.Trim();
                bool isDecimal = true;
                foreach (char c in text)
                {
                    if ((c < '0' || c > '9') && (c != ',' || c != '.'))
                    {
                        isDecimal = false;
                    }
                }

                if (isDecimal)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void SearchOpremaTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchOpremaBtn.Enabled = IsNumeric(SearchOpremaTextBox.Text.Trim());
        }
        private void SearchCustTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchCustBtn.Enabled = IsNumeric(SearchCustTextBox.Text.Trim());
        }
        private void SearchOsebjeTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchOsebjeBtn.Enabled = IsNumeric(SearchOsebjeTextBox.Text.Trim());
        }
        /*SEARCH*/

        /*ADD PANELS*/

        //dodaj opremo
        private void AddToolBtn_Click(object sender, EventArgs e)
        {
            if (mode == 3)
            {
                mode = 4;
                Prikaz(mode);
            }
            else if (mode == 4)
            {
                mode = 3;
                Prikaz(mode);
            }
            else
            {
                mode = 3;
                Prikaz(mode);
            }
        }
        //dodaj zaposlenega
        private void AddOsebjeBtn_Click(object sender, EventArgs e)
        {
            if (mode == 2)
            {
                mode = 6;
                Prikaz(mode);
            }
            else if (mode == 6)
            {
                mode = 2;
                Prikaz(mode);
            }
            else
            {
                mode = 2;
                Prikaz(mode);
            }
        }
        //dodaj stranko
        private void AddCustBtn_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                mode = 5;
                Prikaz(mode);
            }
            else if (mode == 5)
            {
                mode = 1;
                Prikaz(mode);
            }
            else
            {
                mode = 1;
                Prikaz(mode);
            }
        }
        /*ADD PANELS*/

        private void Form1_Load(object sender, EventArgs e)
        {
            //nastavi UI 
            InitializeComponent();
            Size = new Size(1024, 768);
            Prikaz(0);
            DirectionLabel.ForeColor = Color.Red;
            ArrowLabel.ForeColor = Color.Red;
            DirectionLabel.Text = "Izhod";
            GymLabel.Text = "Gym management system";
            pictureBox1.Location = new Point(76, 200);
            pictureBox2.Location = new Point(405, 200);
            pictureBox3.Location = new Point(723, 200);
            OsebjeLabel.Location = new Point(448, 400);
            StrankeLabel.Location = new Point(130, 400);
            OpremaLabel.Location = new Point(775, 400);
            mode = 0;

            //nastavi ID text boxe
            int idOpreme = Gym.Oprema.stArtiklov;
            IDOpremeTextBox.Text = idOpreme.ToString();
            int idOsebja = Gym.Osebje.stZaposlenih;
            IDOsebjaTextBox.Text = idOsebja.ToString();
            int idStranke = Gym.Stranka.stStrank;
            IDCustTextBox.Text = idStranke.ToString();

            //nastavi DateTime polja
            DatumRojstvaOsebja.MaxDate = DateTime.Now;
            VeljavnostOsebja.MinDate = DateTime.Now;
            DatumRojstvaCust.MaxDate = DateTime.Now;
            VeljavnostCust.MinDate = DateTime.Now.AddDays(1);


        }



        /*----------------------------OPREMA----------------------------*/

        /*DODAJ OPREMO*/
        public int IdOpremeList(int idOpreme)
        {
            /*int index = Oprema.FindIndex(x => x.idOpreme == idOpreme);*/
            int index = -1;
            for (int i = 0; i < Oprema.Count; i++)
            {
                if (Oprema[i].idOpreme == idOpreme)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public int IdOpremeTable(int idOpreme)
        {
            //preveri, èe je oprema v tabeli
            int idTable = -1;

            if (OpremaTable.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in OpremaTable.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idOpreme.ToString())
                    {
                        idTable = row.Index;
                        return idTable;
                    }
                }
            }
            return idTable;
        }

        private void SubmitOprema(object sender, EventArgs e)
        {
            bool accept = true;

            //1. del forme
            if (NazivOpreme.Text.Trim() == "") accept = false;
            if (OpisOpreme.Text.Trim() == "") accept = false;

            if (accept)
            {
                //2. del forme
                string naziv = NazivOpreme.Text.Trim().ToUpper(), opis = OpisOpreme.Text.Trim().ToUpper(), komentar = KomentarOpreme.Text.Trim().ToUpper();
                accept = IsDecimal(TezaOpreme.Text.Trim());
                accept = IsDecimal(VrednostOpreme.Text.Trim());
                accept = IsNumeric(KvantitetaOpreme.Text.Trim());

                if (accept)
                {
                    //3. del forme
                    string temp_teza = TezaOpreme.Text.Trim().Replace('.', ','), temp_vrednost = VrednostOpreme.Text.Trim().Replace('.', ',');
                    double teza = Math.Round(Convert.ToDouble(temp_teza), 2);
                    double vrednost = Math.Round(Convert.ToDouble(temp_vrednost), 2);
                    int kvantiteta = Convert.ToInt32(KvantitetaOpreme.Text.Trim());
                    accept = IsNumeric(X_Opreme.Text.Trim());
                    accept = IsNumeric(Y_Opreme.Text.Trim());
                    accept = IsNumeric(Z_Opreme.Text.Trim());

                    //dodaj oz. uredi vrstico
                    if (accept)
                    {
                        int x = Convert.ToInt32(X_Opreme.Text.Trim()), y = Convert.ToInt32(Y_Opreme.Text.Trim()), z = Convert.ToInt32(Z_Opreme.Text.Trim()), volumen = x * y * z;
                        int id = Convert.ToInt32(IDOpremeTextBox.Text.Trim()), id_v_listu = IdOpremeList(id);

                        //preveri, èe je oprema v tabeli
                        string table_Row_Id = id.ToString();
                        int id_table = -1;
                        id_table = IdOpremeTable(id);

                        //ID obstaja že v listu in tabeli - UPDATE
                        if (id_v_listu > -1 && id_table > -1)
                        {
                            //posodobi list in nato tabelo
                            Oprema[id_v_listu].naziv = naziv;
                            Oprema[id_v_listu].opis = opis;
                            Oprema[id_v_listu].komentar = komentar;
                            Oprema[id_v_listu].teza = teza;
                            Oprema[id_v_listu].cena = vrednost;
                            Oprema[id_v_listu].kvantiteta = kvantiteta;
                            Oprema[id_v_listu].x = x;
                            Oprema[id_v_listu].y = y;
                            Oprema[id_v_listu].z = z;

                            //posodobi tabelo
                            DataGridViewRow row = OpremaTable.Rows[id_table];
                            row.Cells[1].Value = naziv;
                            row.Cells[2].Value = opis;
                            row.Cells[3].Value = teza;
                            row.Cells[4].Value = vrednost;
                            row.Cells[5].Value = kvantiteta;
                            row.Cells[6].Value = volumen;
                            row.Cells[7].Value = komentar;
                        }
                        //OBJEKTA ŠE NI V LISTU - CREATE
                        else
                        {
                            Oprema new_oprema = new Oprema(naziv, opis, komentar, teza, vrednost, kvantiteta, x, y, z);
                            id = new_oprema.idOpreme;
                            Oprema.Add(new_oprema);
                            OpremaTable.Rows.Add(id, naziv, opis, teza, vrednost, kvantiteta, volumen, komentar);

                            //UPDATE OPREMA ID 
                            IDOpremeTextBox.Text = Gym.Oprema.stArtiklov.ToString();

                            //sproži clearOpremaSearch - sprazni polja, nastavi ID opreme text box na nasleden ID
                            ClearOpremaSearch(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vsa polja poleg komentarja morajo biti (pravilno) izpolnjena");
                    }
                }
                else
                {
                    MessageBox.Show("Vsa polja poleg komentarja morajo biti (pravilno) izpolnjena");
                }
            }
            else
            {
                MessageBox.Show("Vsa polja poleg komentarja morajo biti (pravilno) izpolnjena");
            }
        }
        /*DODAJ OPREMO*/

        /*SEARCH OPREMA*/
        private void IDOpremeTextChanged_TextChanged(object sender, EventArgs e)
        {
            //1.    text se spremeni v ID text boxu
            //2.    preveri, èe obstaja objekt s tem ID v listu
            //3.1.  èe ja, zapolni formo z atributi objekta
            //3.2.  èe ne, sprazni search bar in nastavi ID text box na stArtiklov lastnost objekta new_oprema in sproži MessageBox z opozorilom
            string string_id = IDOpremeTextBox.Text.Trim();
            int id = Convert.ToInt32(string_id);
            //MessageBox.Show(id.ToString());

            //2.
            int id_v_listu = IdOpremeList(id);
            //MessageBox.Show(id_v_listu.ToString());
            //3.1.
            if (id_v_listu > -1)
            {
                NazivOpreme.Text = Oprema[id_v_listu].naziv;
                OpisOpreme.Text = Oprema[id_v_listu].opis;
                KomentarOpreme.Text = Oprema[id_v_listu].komentar;
                TezaOpreme.Text = Oprema[id_v_listu].teza.ToString().Replace('.', ',');
                VrednostOpreme.Text = Oprema[id_v_listu].cena.ToString().Replace('.', ',');
                KvantitetaOpreme.Text = Oprema[id_v_listu].kvantiteta.ToString();
                X_Opreme.Text = Oprema[id_v_listu].x.ToString();
                Y_Opreme.Text = Oprema[id_v_listu].y.ToString();
                Z_Opreme.Text = Oprema[id_v_listu].z.ToString();

                //preveri, èe je oprema v tabeli
                int id_table = -1;
                id_table = IdOpremeTable(id);

                //èe obstaja v tabeli, posodobi in izberi vrstico
                if (id_table > -1)
                {
                    //posodobi vrstico že obstojeèe opreme
                    DataGridViewRow row = OpremaTable.Rows[id_table];
                    row.Cells[1].Value = Oprema[id_v_listu].naziv;
                    row.Cells[2].Value = Oprema[id_v_listu].opis;
                    row.Cells[3].Value = Oprema[id_v_listu].teza;
                    row.Cells[4].Value = Oprema[id_v_listu].cena;
                    row.Cells[5].Value = Oprema[id_v_listu].kvantiteta;
                    row.Cells[6].Value = Oprema[id_v_listu].volumen;
                    row.Cells[7].Value = Oprema[id_v_listu].komentar;

                    //izberi to vrstico 
                    OpremaTable.Rows[id_table].Selected = true;
                }
                //èe ne, ustvari novo
                else
                {
                    OpremaTable.Rows.Add(id, Oprema[id_v_listu].naziv, Oprema[id_v_listu].opis, Oprema[id_v_listu].teza, Oprema[id_v_listu].cena, Oprema[id_v_listu].kvantiteta, Oprema[id_v_listu].volumen, Oprema[id_v_listu].komentar);
                }

                //prikaži delete button
                DeleteOpremaBtn.Visible = true;
                OutputOpremaBtn.Visible = true;
            }

            //3.2.
            else
            {
                //èe je vpisan v textbox naslednji ID v new_oprema, sproži clearOpremaSearch
                if (id == Gym.Oprema.stArtiklov)
                {
                    ClearOpremaSearch(sender, e);
                }
                //objekt z ID ne obstaja in ni naslednji ID v new_oprema
                else
                {
                    //MessageBox.Show($"Oprema z ID {IDOpremeTextBox.Text.Trim()} ne obstaja");
                    IDOpremeTextBox.Text = Gym.Oprema.stArtiklov.ToString();
                }

                //skrij delete in clear search button
                DeleteOpremaBtn.Visible = false;
                OutputOpremaBtn.Visible = false;
            }
        }

        private void SearchOprema(object sender, EventArgs e)
        {
            IDOpremeTextBox.Text = SearchOpremaTextBox.Text;
            ClearSearchOpremaBtb.Visible = true;
        }

        private void ClearOpremaSearch(object sender, EventArgs e)
        {
            //poèisti searchbar
            ClearSearchOpremaBtb.Visible = false;
            OutputOpremaBtn.Visible = false;
            SearchOpremaTextBox.Text = "";

            //poèisti polja
            NazivOpreme.Text = "";
            OpisOpreme.Text = "";
            KomentarOpreme.Text = "";
            TezaOpreme.Text = "";
            VrednostOpreme.Text = "";
            KvantitetaOpreme.Text = "";
            X_Opreme.Text = "";
            Y_Opreme.Text = "";
            Z_Opreme.Text = "";

            //nastavi ID na stArtiklov
            int id_opreme = Gym.Oprema.stArtiklov;
            IDOpremeTextBox.Text = id_opreme.ToString();
        }
        /*SEARCH OPREMA*/

        /*DELETE OPREMA*/
        private void DeleteOpremaClick(object sender, EventArgs e)
        {
            //izbriši objekt iz lista
            int id_v_listu = -1, id = Convert.ToInt32(IDOpremeTextBox.Text.Trim());
            id_v_listu = IdOpremeList(id);

            //Objekt s takšnim id obstaja, odstrani iz lista in tabele
            if (id_v_listu > -1)
            {
                Oprema.RemoveAt(id_v_listu);

                //odstrani iz tabele
                int id_v_tabeli = IdOpremeTable(id);

                //obstaja v tabeli - odstrani
                if (id_v_tabeli > -1)
                {
                    OpremaTable.Rows.RemoveAt(id_v_tabeli);
                }
            }

            ClearOpremaSearch(sender, e);
        }
        /*DELETE OPREMA*/

        /*OUTPUT OPREMA*/
        private void OutputOpremaBtn_Click(object sender, EventArgs e)
        {
            int idOprema, idList = -1;
            if (IsNumeric(IDOpremeTextBox.Text))
            {
                idOprema = Convert.ToInt32(IDOpremeTextBox.Text);
                idList = IdOpremeList(idOprema);

                if (idList > -1)
                {
                    Oprema oprema = Oprema[idList];
                    string output = oprema.ToString();
                    MessageBox.Show(output);
                }
                else
                {
                    MessageBox.Show($"Oprema z ID {idOprema} ne obstaja.");
                }

            }
            else
            {
                MessageBox.Show("ID opreme ni pravilno vpisan.");
            }
        }
        /*OUTPUT OPREMA*/

        /*----------------------------OPREMA----------------------------*/



        /*----------------------------DELAVEC----------------------------*/
        public int IdOsebjaTable(int idOsebja)
        {
            //preveri, èe je zaposleni v tabeli
            int idTable = -1;

            if (ZaposleniTable.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in ZaposleniTable.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idOsebja.ToString())
                    {
                        idTable = row.Index;
                        break;
                    }
                }
            }
            return idTable;
        }

        public int IdOsebjaList(int idOsebja)
        {
            int index = -1;
            for (int i = 0; i < Zaposleni.Count; i++)
            {
                if (Zaposleni[i].idZaposlenega == idOsebja)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /*DODAJ DELAVCA*/
        private void SubmitOsebje(object sender, EventArgs e)
        {
            bool accept = true;

            //1. del forme
            if (ImeOsebja.Text.Trim() == "") accept = false;
            if (PriimekOsebja.Text.Trim() == "") accept = false;

            if (accept)
            {
                //2. del forme
                string ime = ImeOsebja.Text.Trim().ToUpper(), priimek = PriimekOsebja.Text.Trim().ToUpper(), komentar = KomentarOsebja.Text.Trim();
                if (NaslovOsebja.Text.Trim() == "") accept = false;
                accept = IsNumeric(PostaOsebja.Text.Trim());
                if (PoklicOsebja.Text.Trim() == "") accept = false;
                if (DavcnaOsebja.Text.Trim() == "") accept = false;
                if (TrrOsebja.Text.Trim() == "") accept = false;
                accept = IsDecimal(PlacaOsebja.Text.Trim());
                //MessageBox.Show(PlacaOsebja.Text.Trim());

                if (accept)
                {
                    string issue = "";
                    //3. del forme
                    string naslov = NaslovOsebja.Text.Trim().ToUpper(), poklic = PoklicOsebja.Text.Trim();
                    string davcna = DavcnaOsebja.Text.Trim(), TRR = TrrOsebja.Text.ToUpper().Trim();
                    int posta = Convert.ToInt32(PostaOsebja.Text.Trim());
                    double placa = Math.Round(Convert.ToDouble(PlacaOsebja.Text.Trim().Replace('.', ',')), 2);

                    if (DatumRojstvaOsebja.Value <= DatumRojstvaOsebja.MinDate || DatumRojstvaOsebja.Value >= DatumRojstvaOsebja.MaxDate) accept = false; issue = "1";
                    if (SpolOsebja.Text.Trim() == "") accept = false; issue = "2";
                    if (VeljavnostOsebja.Value < VeljavnostOsebja.MinDate) accept = false; issue = "3";

                    if (accept)
                    {
                        DateTime datumRojstva = DatumRojstvaOsebja.Value, pogodbaDo = VeljavnostOsebja.Value;
                        string email = EmailOsebja.Text.Trim(), telefon = TelefonOsebja.Text.Trim();
                        Oseba.Spol spol = Gym.Oseba.VrniSpol(SpolOsebja.Text.Trim());

                        //preveri, èe delavec že obstaja
                        int idOsebja = Convert.ToInt32(IDOsebjaTextBox.Text.Trim());
                        int id_list = IdOsebjaList(idOsebja);
                        int id_table = IdOsebjaTable(idOsebja);

                        //delavec že obstaja - UPDATE
                        if (id_list > -1 && id_table > -1)
                        {
                            //posdobi objekt v listu in vrstico v tabeli
                            Osebje osebje = Zaposleni[id_list];
                            osebje.ime = ime;
                            osebje.priimek = priimek;
                            osebje.komentar = komentar;
                            osebje.naslov = naslov;
                            osebje.email = email;
                            osebje.telefon = telefon;
                            osebje.NastaviSpol(spol);
                            osebje.postnaSt = posta;
                            osebje.datumRojstva = datumRojstva;
                            osebje.placa = placa;
                            osebje.pogodbaDo = pogodbaDo;
                            osebje.trr = TRR;
                            osebje.davcna_st = davcna;
                            osebje.poklic = poklic;

                            DataGridViewRow row = ZaposleniTable.Rows[id_table];
                            row.Cells[1].Value = ime;
                            row.Cells[2].Value = priimek;
                            row.Cells[3].Value = datumRojstva;
                            //row.Cells[4].Value = datumPrijave;
                            row.Cells[5].Value = pogodbaDo;
                            row.Cells[6].Value = poklic;
                            row.Cells[7].Value = TRR;
                            row.Cells[8].Value = davcna;
                            row.Cells[9].Value = placa;
                            row.Cells[10].Value = naslov;
                            row.Cells[11].Value = telefon;
                            row.Cells[12].Value = email;
                            row.Cells[13].Value = spol;
                        }

                        //delavec še ne obstaja - CREATE
                        else
                        {
                            //dodaj novega delavca v tabelo in v list
                            Zaposleni.Add(new Osebje(ime, priimek, komentar, naslov, email, telefon, spol, posta, datumRojstva, placa, pogodbaDo, TRR, davcna, poklic));
                            ZaposleniTable.Rows.Add(idOsebja, ime, priimek, datumRojstva, DateTime.Now, pogodbaDo, poklic, TRR, davcna, placa, naslov + ", " + posta, telefon, email, spol);

                            //sproži clearOsebjeSearch - nastavi nov ID, sprazni polja
                            ClearOsebjeSearch(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Vsa polja poleg komentarja, telefona in e-pošte morajo biti (pravilno) izpolnjena 3 {issue}");
                    }
                }
                else
                {
                    MessageBox.Show("Vsa polja poleg komentarja, telefona in e-pošte morajo biti (pravilno) izpolnjena 2");
                }
            }
            else
            {
                MessageBox.Show("Vsa polja poleg komentarja, telefona in e-pošte morajo biti (pravilno) izpolnjena 1");
            }
        }
        /*DODAJ DELAVCA*/

        /*SEARCH DELAVEC*/
        private void SearchOsebjeBtn_Click(object sender, EventArgs e)
        {
            IDOsebjaTextBox.Text = SearchOsebjeTextBox.Text.Trim();
            ClearSearchOsebjeBtn.Visible = true;
        }

        private void IDOsebjaTextBox_TextChanged(object sender, EventArgs e)
        {
            //1.    text se spremeni v ID text boxu
            //2.    preveri, èe obstaja objekt s tem ID v listu
            //3.1.  èe ja, zapolni formo z atributi objekta
            //3.2.  èe ne, sprazni search bar in nastavi ID text box na id lastnost in sproži MessageBox z opozorilom
            string string_id = IDOsebjaTextBox.Text.Trim();
            int id = Convert.ToInt32(string_id);

            //2.
            int id_v_listu = IdOsebjaList(id);

            //3.1.
            if (id_v_listu > -1)
            {
                //UPDATE MODE - zapolni polja s podatki iz osebje objekta   
                Osebje osebje = Zaposleni[id_v_listu];
                ImeOsebja.Text = osebje.ime;
                PriimekOsebja.Text = osebje.priimek;
                KomentarOsebja.Text = osebje.komentar;
                NaslovOsebja.Text = osebje.naslov;
                PostaOsebja.Text = osebje.postnaSt.ToString();
                PoklicOsebja.Text = osebje.poklic;
                DavcnaOsebja.Text = osebje.davcna_st;
                TrrOsebja.Text = osebje.trr;
                PlacaOsebja.Text = osebje.placa.ToString().Replace('.', ',');
                KomentarOsebja.Text = osebje.komentar;
                DatumRojstvaOsebja.Value = osebje.datumRojstva;
                VeljavnostOsebja.Value = osebje.pogodbaDo;

                //preveri, èe je zaposleni v tabeli
                int id_table = -1;
                id_table = IdOsebjaTable(id);

                //èe obstaja v tabeli, posodobi in izberi vrstico
                if (id_table > -1)
                {
                    //posodobi vrstico že obstojeèe opreme
                    DataGridViewRow row = ZaposleniTable.Rows[id_table];
                    row.Cells[1].Value = osebje.ime;
                    row.Cells[2].Value = osebje.priimek;
                    row.Cells[3].Value = osebje.datumRojstva;
                    row.Cells[4].Value = osebje.datumPrijave;
                    row.Cells[5].Value = osebje.pogodbaDo;
                    row.Cells[6].Value = osebje.poklic;
                    row.Cells[7].Value = osebje.trr;
                    row.Cells[8].Value = osebje.davcna_st;
                    row.Cells[9].Value = osebje.placa;
                    row.Cells[10].Value = osebje.naslov;
                    row.Cells[11].Value = osebje.telefon;
                    row.Cells[12].Value = osebje.email;
                    row.Cells[13].Value = osebje.IzpisiSpol();

                    //izberi to vrstico 
                    ZaposleniTable.Rows[id_table].Selected = true;
                }
                //èe ne, ustvari novo
                else
                {
                    ZaposleniTable.Rows.Add(id, osebje.ime, osebje.priimek, osebje.datumRojstva, osebje.datumPrijave, osebje.pogodbaDo, osebje.poklic, osebje.trr, osebje.davcna_st, osebje.placa, osebje.naslov, osebje.telefon, osebje.email, osebje.IzpisiSpol());
                }

                //prikaži delete button
                DeleteOsebjeBtn.Visible = true;
                OutputOsebjeBtn.Visible = true;
            }

            //3.2.
            else
            {
                //èe je vpisan v textbox naslednji ID osebja, sproži clearOsebjeSearch
                if (id == Gym.Osebje.stZaposlenih)
                {
                    ClearOsebjeSearch(sender, e);
                }
                //zaposleni z ID ne obstaja in ni naslednji ID v osebju
                else
                {
                    MessageBox.Show($"Zaposleni z ID {IDOsebjaTextBox.Text.Trim()} ne obstaja");
                    IDOsebjaTextBox.Text = Gym.Osebje.stZaposlenih.ToString();
                }

                //skrij delete button
                DeleteOsebjeBtn.Visible = false;
                OutputOsebjeBtn.Visible = false;
            }
        }

        private void ClearOsebjeSearch(object sender, EventArgs e)
        {
            //poèisti searchbar za osebje in skrij tipke za izbris in clear 
            ClearSearchOsebjeBtn.Visible = false;
            DeleteOsebjeBtn.Visible = false;
            OutputOsebjeBtn.Visible = false;
            SearchOsebjeTextBox.Text = "";

            //poèisti polja
            ImeOsebja.Text = "";
            PriimekOsebja.Text = "";
            KomentarOsebja.Text = "";
            NaslovOsebja.Text = "";
            PostaOsebja.Text = "";
            PoklicOsebja.Text = "";
            DavcnaOsebja.Text = "";
            TrrOsebja.Text = "";
            PlacaOsebja.Text = "";
            KomentarOsebja.Text = "";
            DatumRojstvaOsebja.Value = DateTime.Now.AddYears(-18);
            VeljavnostOsebja.Value = DateTime.Now.AddDays(1);

            //nastavi text box za ID osebja na nasleden ID
            IDOsebjaTextBox.Text = Gym.Osebje.stZaposlenih.ToString();
        }
        /*SEARCH DELAVEC*/

        /*DELETE DELAVEC*/
        private void DeleteOsebjeClick(object sender, EventArgs e)
        {
            //izbriši objekt iz lista
            int id_v_listu = -1, id = Convert.ToInt32(IDOsebjaTextBox.Text.Trim());
            id_v_listu = IdOsebjaList(id);

            //Objekt s takšnim id obstaja, odstrani iz lista in tabele
            if (id_v_listu > -1)
            {
                Zaposleni.RemoveAt(id_v_listu);

                //odstrani iz tabele
                int id_v_tabeli = IdOsebjaTable(id);

                //obstaja v tabeli - odstrani
                if (id_v_tabeli > -1)
                {
                    ZaposleniTable.Rows.RemoveAt(id_v_tabeli);
                }
            }

            ClearOsebjeSearch(sender, e);
        }
        /*DELETE DELAVEC*/

        /*OUTPUT DELAVEC*/
        private void OutputOsebjeBtn_Click(object sender, EventArgs e)
        {
            int idOsebje, idList = -1;
            if (IsNumeric(IDOsebjaTextBox.Text))
            {
                idOsebje = Convert.ToInt32(IDOsebjaTextBox.Text);
                idList = IdOsebjaList(idOsebje);

                if (idList > -1)
                {
                    Osebje osebje = Zaposleni[idList];
                    string output = osebje.ToString();
                    MessageBox.Show(output);
                }
                else
                {
                    MessageBox.Show($"Oprema z ID {idOsebje} ne obstaja.");
                }

            }
            else
            {
                MessageBox.Show("ID osebja ni pravilno vpisan.");
            }
        }
        /*OUTPUT DELAVEC*/

        /*----------------------------DELAVEC----------------------------*/



        /*----------------------------STRANKA----------------------------*/
        public int IdStrankaList(int idStranka)
        {
            int idList = -1;
            for (int i = 0; i < Stranke.Count; i++)
            {
                if (Stranke[i].idStranke == idStranka)
                {
                    idList = i;
                    break;
                }
            }
            return idList;
        }

        public int IdStrankaTable(int idStranka)
        {
            int idTable = -1;
            if (StrankeTable.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in StrankeTable.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idStranka.ToString())
                    {
                        idTable = row.Index;
                        break;
                    }
                }
            }
            return idTable;
        }

        public int IdUcenecList(int idStranka)
        {
            int idList = -1;
            for (int i = 0; i < Ucenci.Count; i++)
            {
                if (Ucenci[i].idStranke == idStranka)
                {
                    idList = i;
                    break;
                }
            }
            return idList;
        }

        public int IdUsluzbenciList(int idStranka)
        {
            int idList = -1;
            for (int i = 0; i < Usluzbenec.Count; i++)
            {
                if (Usluzbenec[i].idStranke == idStranka)
                {
                    idList = i;
                    break;
                }
            }
            return idList;
        }

        /*DODAJ STRANKA*/
        private void StatusCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            //izbrano
            if (StatusCust.SelectedIndex > 0)
            {
                AkcijaCust.Enabled = true;
                NaslovStavbe.Enabled = true;
                PostaStavbe.Enabled = true;
                PozicijaCust.Enabled = true;

                //javni uslužbenec
                if (StatusCust.SelectedIndex == 1)
                {
                    NaslovLabel.Text = "Naslov ustanove";
                    PostaLabel.Text = "Poš. ustanove";
                    PozicijaLabel.Text = "Poklic";
                    LetnikLabel.Visible = false;
                    LetnikCust.Visible = false;
                }

                //student
                else
                {
                    NaslovLabel.Text = "Naslov šole";
                    PostaLabel.Text = "Pošta šole";
                    PozicijaLabel.Text = "Program";
                    LetnikLabel.Visible = true;
                    LetnikCust.Visible = true;
                }
            }
            //status ni izbran 
            else
            {
                AkcijaCust.Enabled = false;
                NaslovStavbe.Enabled = false;
                PostaStavbe.Enabled = false;
                LetnikLabel.Visible = false;
                LetnikCust.Visible = false;
                PozicijaCust.Enabled = false;
            }
        }
        private void SubmitStranka(object sender, EventArgs e)
        {
            bool accept = true;
            int idStranka = Convert.ToInt32(IDCustTextBox.Text.Trim());
            int idList = -1, idTable = -1;
            idTable = IdStrankaTable(idStranka);

            //1. del forme
            if (ImeCust.Text.Trim() == "") accept = false;
            if (PriimekCust.Text.Trim() == "") accept = false;
            accept = IsDecimal(CenaCust.Text.Trim());

            if (accept)
            {
                string ime = ImeCust.Text.Trim().ToUpper(), priimek = PriimekCust.Text.Trim().ToUpper(), komentar = KomentarCust.Text.Trim();

                //2. del forme
                if (NaslovCust.Text.Trim() == "") accept = false;
                accept = IsNumeric(PostaCust.Text.Trim());

                if (accept)
                {
                    string naslov = NaslovCust.Text.Trim().ToUpper();
                    int posta = Convert.ToInt32(PostaCust.Text.Trim());
                    double cenaKarte = Convert.ToDouble(CenaCust.Text.Trim().Replace('.', ','));

                    //3. del forme - datumi, spol, email, telefon
                    if (DatumRojstvaCust.Value >= DatumRojstvaCust.MaxDate || DatumRojstvaCust.Value < DatumRojstvaCust.MinDate) accept = false;
                    if (VeljavnostCust.Value <= VeljavnostCust.MinDate) accept = false;
                    if (SpolCust.SelectedIndex == -1) accept = false;

                    if (accept)
                    {
                        DateTime datumRojstva = DatumRojstvaCust.Value, kartaDo = VeljavnostCust.Value;
                        Gym.Oseba.Spol spol = Gym.Oseba.VrniSpol(SpolCust.Text);
                        string email = EmailCust.Text.Trim(), telefon = TelefonCust.Text.Trim();

                        //izbran status - ustvari ucenec ali usluzbenec objekt
                        if (StatusCust.SelectedIndex > 0)
                        {
                            //4. del forme - posebni statusi
                            if (NaslovStavbe.Text.Trim() == "") accept = false;
                            accept = IsNumeric(PostaStavbe.Text);
                            if (PozicijaCust.Text.Trim() == "") accept = false;
                            accept = IsNumeric(AkcijaCust.Text);

                            //dijak, student
                            if (StatusCust.SelectedIndex > 1)
                            {
                                accept = IsNumeric(LetnikCust.Text);
                            }

                            //podatki za status pravilni - ustvari objekt
                            if (accept)
                            {
                                string naslovUstanove = NaslovStavbe.Text.Trim().ToUpper(), pozicija = PozicijaCust.Text.Trim().ToUpper();
                                int postaUstanove = Convert.ToInt32(PostaStavbe.Text.Trim()), letnik = 0;
                                double akcija_raw = Convert.ToDouble(AkcijaCust.Text.Trim());

                                double akcija = Math.Round(akcija_raw / 100, 2);

                                //ucenec
                                if (StatusCust.SelectedIndex > 1)
                                {
                                    letnik = Convert.ToInt32(LetnikCust.Text.Trim());
                                    idList = IdUcenecList(idStranka);
                                    pozicija += $" - {letnik}. Letnik";
                                }
                                //usluzbenec
                                else
                                {
                                    idList = IdUsluzbenciList(idStranka);
                                }

                                //UPDATE - POSEBNI STATUS objekt
                                if (idList > -1 && idTable > -1)
                                {
                                    string status = "";

                                    //ucenec
                                    if (StatusCust.SelectedIndex > 1)
                                    {
                                        Ucenec ucenec = Ucenci[idList];
                                        ucenec.ime = ime;
                                        ucenec.priimek = priimek;
                                        ucenec.komentar = komentar;
                                        ucenec.naslov = naslov;
                                        ucenec.postnaSt = posta;
                                        ucenec.cenaKarte = cenaKarte;
                                        ucenec.naslovSole = naslovUstanove;
                                        ucenec.postaSole = postaUstanove;
                                        ucenec.program = pozicija;
                                        ucenec.akcija = akcija;
                                        ucenec.letnik = letnik;
                                        ucenec.datumRojstva = datumRojstva;
                                        ucenec.datumKarte = kartaDo;
                                        ucenec.NastaviSpol(spol);
                                        ucenec.email = email;
                                        ucenec.telefon = telefon;

                                        status = "UÈENEC";
                                    }
                                    //usluzbenec
                                    else
                                    {
                                        Usluzbenci usluzbenci = Usluzbenec[idList];
                                        usluzbenci.ime = ime;
                                        usluzbenci.priimek = priimek;
                                        usluzbenci.komentar = komentar;
                                        usluzbenci.naslov = naslov;
                                        usluzbenci.postnaSt = posta;
                                        usluzbenci.cenaKarte = cenaKarte;
                                        usluzbenci.naslovUstanove = naslovUstanove;
                                        usluzbenci.postaUstanove = postaUstanove;
                                        usluzbenci.poklic = pozicija;
                                        usluzbenci.akcija = akcija;
                                        usluzbenci.datumRojstva = datumRojstva;
                                        usluzbenci.datumKarte = kartaDo;
                                        usluzbenci.NastaviSpol(spol);
                                        usluzbenci.email = email;
                                        usluzbenci.telefon = telefon;

                                        status = "USLUŽBENEC";
                                    }

                                    DataGridViewRow row = StrankeTable.Rows[idTable];
                                    row.Cells[1].Value = ime;
                                    row.Cells[2].Value = priimek;
                                    row.Cells[3].Value = datumRojstva;
                                    //row.Cells[4].Value = ;
                                    row.Cells[5].Value = kartaDo;
                                    row.Cells[6].Value = cenaKarte;
                                    row.Cells[7].Value = akcija * 100;
                                    row.Cells[8].Value = naslov + ", " + postaUstanove;
                                    row.Cells[9].Value = spol;
                                    row.Cells[10].Value = telefon;
                                    row.Cells[11].Value = email;
                                    row.Cells[12].Value = status;
                                    row.Cells[12].Value = naslovUstanove + ", " + postaUstanove;
                                    row.Cells[13].Value = pozicija;
                                }
                                //CREATE - POSEBNI STATUS objekt
                                else
                                {
                                    string status = "";

                                    //ucenec
                                    if (StatusCust.SelectedIndex > 1)
                                    {
                                        status = "UÈENEC";
                                        Ucenec ucenec = new Ucenec(ime, priimek, komentar, naslov, email, telefon, spol, posta, kartaDo, datumRojstva, akcija, "", pozicija, naslovUstanove, letnik, postaUstanove, cenaKarte);
                                        Ucenci.Add(ucenec);
                                        StrankeTable.Rows.Add(idStranka, ime, priimek, datumRojstva, ucenec.datumPrijave, kartaDo, ucenec.cenaKarte, akcija * 100, naslov + ", " + posta, spol, telefon, email, status, naslovUstanove + ", " + postaUstanove, pozicija);
                                    }
                                    //usluzbenec
                                    else
                                    {
                                        status = "USLUŽBENEC";
                                        Usluzbenci usluzbenci = new Usluzbenci(ime, priimek, komentar, naslov, email, telefon, spol, posta, kartaDo, datumRojstva, akcija, pozicija, "", naslovUstanove, postaUstanove, cenaKarte);
                                        Usluzbenec.Add(usluzbenci);
                                        StrankeTable.Rows.Add(idStranka, ime, priimek, datumRojstva, usluzbenci.datumPrijave, kartaDo, usluzbenci.cenaKarte, akcija * 100, naslov + ", " + posta, spol, telefon, email, status, naslovUstanove + ", " + postaUstanove, pozicija);
                                    }

                                    //poèisti formo
                                    ClearStrankaSearch(sender, e);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vsa polja, poleg e-pošte in telefona morajo biti (pravilno) izpolnjena, vkljuèno s polji, ki so povezana s statusom stranke.");
                            }
                        }
                        //status ni izbran - stranka objekt
                        else
                        {
                            idList = IdStrankaList(idStranka);
                            //UPDATE STRANKA
                            if (idList > -1 && idTable > -1)
                            {
                                //posodobi list
                                Stranka stranka = Stranke[idList];
                                stranka.ime = ime;
                                stranka.priimek = priimek;
                                stranka.komentar = komentar;
                                stranka.naslov = naslov;
                                stranka.email = email;
                                stranka.telefon = telefon;
                                stranka.NastaviSpol(spol);
                                stranka.postnaSt = posta;
                                stranka.datumRojstva = datumRojstva;
                                stranka.datumKarte = kartaDo;
                                stranka.cenaKarte = cenaKarte;

                                //posodobi tabelo
                                DataGridViewRow row = StrankeTable.Rows[idTable];
                                row.Cells[1].Value = ime;
                                row.Cells[2].Value = priimek;
                                row.Cells[3].Value = datumRojstva;
                                row.Cells[5].Value = kartaDo;
                                row.Cells[6].Value = cenaKarte;
                                row.Cells[7].Value = 0;
                                row.Cells[8].Value = naslov + ", " + posta;
                                row.Cells[9].Value = spol;
                                row.Cells[10].Value = telefon;
                                row.Cells[11].Value = email;
                                row.Cells[12].Value = "Brez";
                                row.Cells[13].Value = "";
                            }
                            //CREATE STRANKA - nov objekt, nova vrstica v tabeli
                            else
                            {
                                //Stranka newStranka = new Stranka(ime, priimek, komentar, naslov, email, telefon, spol, posta, datumRojstva, kartaDo, cenaKarte);
                                Stranke.Add(new Stranka(ime, priimek, komentar, naslov, email, telefon, spol, posta, datumRojstva, kartaDo, cenaKarte));
                                StrankeTable.Rows.Add(idStranka, ime, priimek, datumRojstva, DateTime.Now, kartaDo, cenaKarte, 0, naslov + ", " + posta, spol, telefon, email, "BREZ", "");
                                ClearStrankaSearch(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    if (StatusCust.SelectedIndex > 0)
                    {
                        MessageBox.Show("Vsa polja, poleg e-pošte in telefona morajo biti (pravilno) izpolnjena, vkljuèno s polji, ki so povezana s statusom stranke.");
                    }
                    else
                    {
                        MessageBox.Show("Vsa polja, poleg e-pošte, telefona in posebnega stanja morajo biti (pravilno) izpolnjena.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Vsa polja, poleg e-pošte, telefona in posebnega stanja morajo biti (pravilno) izpolnjena.");
            }
        }
        /*DODAJ STRANKA*/

        /*SEARCH STRANKA*/
        private void SearchStrankaClick(object sender, EventArgs e)
        {
            IDCustTextBox.Text = SearchCustTextBox.Text;
            ClearSearchStrankeBtn.Visible = true;
        }

        private void ClearStrankaSearch(object sender, EventArgs e)
        {
            //sprazni search bar, skrij delete, clear in obiski tipki
            SearchCustTextBox.Text = "";
            ClearSearchStrankeBtn.Visible = false;
            DeleteStrankeBtn.Visible = false;
            OutputObiskiBtn.Visible = false;
            AddObiskButton.Visible = false;

            //sprazni polja
            ImeCust.Text = "";
            PriimekCust.Text = "";
            KomentarCust.Text = "";
            NaslovCust.Text = "";
            PostaCust.Text = "";
            StatusCust.Text = "";
            AkcijaCust.Text = "";
            NaslovStavbe.Text = "";
            PostaStavbe.Text = "";
            CenaCust.Text = "";
            VeljavnostCust.Value = DateTime.Now.AddDays(30);
            DatumRojstvaCust.Value = DateTime.Now.AddYears(-18);
            SpolCust.SelectedIndex = -1;
            StatusCust.SelectedIndex = -1;
            LetnikCust.Text = "";
            EmailCust.Text = "";
            TelefonCust.Text = "";
            StatusCust.Enabled = true;

            //nastavi ID stranke text box na naslednji ID po vrsti
            IDCustTextBox.Text = Gym.Stranka.stStrank.ToString();
        }

        private void IDCustTextBox_TextChanged(object sender, EventArgs e)
        {
            //1.    text se spremeni v ID text boxu
            //2.    preveri, èe obstaja objekt s tem ID v listu
            //3.1.  èe ja, zapolni formo z atributi objekta
            //3.2.  èe ne, sprazni search bar in nastavi ID text box na id lastnost in sproži MessageBox z opozorilom
            int idStranka = Convert.ToInt32(IDCustTextBox.Text.Trim()), idTable = -1, idList = -1;
            idTable = IdStrankaTable(idStranka);


            //id obstaja v tabeli
            if (idTable > -1)
            {
                idList = IdStrankaList(idStranka);
                DeleteStrankeBtn.Visible = true;
                OutputObiskiBtn.Visible = true;
                AddObiskButton.Visible = true;

                //Stranka class
                if (idList > -1)
                {
                    //napolni polja, brez statusa
                    Stranka stranka = Stranke[idList];
                    ImeCust.Text = stranka.ime;
                    PriimekCust.Text = stranka.priimek;
                    KomentarCust.Text = stranka.komentar;
                    NaslovCust.Text = stranka.naslov;
                    PostaCust.Text = stranka.postnaSt.ToString();
                    CenaCust.Text = stranka.cenaKarte.ToString().Replace('.', ',');
                    SpolCust.Text = stranka.IzpisiSpol();
                    VeljavnostCust.Value = stranka.datumKarte;
                    DatumRojstvaCust.Value = stranka.datumRojstva;
                    EmailCust.Text = stranka.email;
                    TelefonCust.Text = stranka.telefon;

                    //onemogoèi izbiro statusa
                    StatusCust.Enabled = false;
                    StatusCust.SelectedIndex = 0;
                    AkcijaCust.Text = "";
                    NaslovStavbe.Text = "";
                    PostaStavbe.Text = "";
                    LetnikCust.Text = "";

                    //izberi vrstico objekta v tabeli
                    StrankeTable.Rows[idTable].Selected = true;
                }
                else
                {
                    for (int i = 0; i < Ucenci.Count; i++)
                    {
                        if (Ucenci[i].idStranke == idStranka)
                        {
                            idList = i;
                            break;
                        }
                    }

                    //Ucenec class
                    if (idList > -1)
                    {
                        //napolni polja, brez statusa
                        Ucenec stranka = Ucenci[idList];
                        ImeCust.Text = stranka.ime.ToUpper();
                        PriimekCust.Text = stranka.priimek.ToUpper();
                        KomentarCust.Text = stranka.komentar;
                        NaslovCust.Text = stranka.naslov.ToUpper();
                        PostaCust.Text = stranka.postnaSt.ToString();
                        CenaCust.Text = stranka.cenaKarte.ToString().Replace('.', ',');
                        SpolCust.Text = stranka.IzpisiSpol();
                        VeljavnostCust.Value = stranka.datumKarte;
                        DatumRojstvaCust.Value = stranka.datumRojstva;
                        EmailCust.Text = stranka.email;
                        TelefonCust.Text = stranka.telefon;

                        //onemogoèi izbiro statusa in izberi status ucenca
                        StatusCust.Enabled = false;
                        StatusCust.SelectedIndex = 2;
                        AkcijaCust.Text = Convert.ToInt32(stranka.akcija * 100).ToString();
                        NaslovStavbe.Text = stranka.naslovSole.ToUpper();
                        PostaStavbe.Text = stranka.postaSole.ToString();
                        LetnikCust.Text = stranka.letnik.ToString();
                        PozicijaCust.Text = stranka.program.ToUpper();

                        //izberi vrstico objekta v tabeli
                        StrankeTable.Rows[idTable].Selected = true;
                    }
                    else
                    {
                        for (int i = 0; i < Usluzbenec.Count; i++)
                        {
                            if (Usluzbenec[i].idStranke == idStranka)
                            {
                                idList = i;
                                break;
                            }
                        }

                        //Usluzbenci class
                        if (idList > -1)
                        {
                            //napolni polja, brez statusa
                            Usluzbenci stranka = Usluzbenec[idList];
                            ImeCust.Text = stranka.ime.ToUpper();
                            PriimekCust.Text = stranka.priimek.ToUpper();
                            KomentarCust.Text = stranka.komentar;
                            NaslovCust.Text = stranka.naslov.ToUpper();
                            PostaCust.Text = stranka.postnaSt.ToString();
                            CenaCust.Text = stranka.cenaKarte.ToString().Replace('.', ',');
                            SpolCust.Text = stranka.IzpisiSpol();
                            VeljavnostCust.Value = stranka.datumKarte;
                            DatumRojstvaCust.Value = stranka.datumRojstva;
                            EmailCust.Text = stranka.email;
                            TelefonCust.Text = stranka.telefon;

                            //onemogoèi izbiro statusa in izberi status usluzbenca
                            StatusCust.Enabled = false;
                            StatusCust.SelectedIndex = 1;
                            AkcijaCust.Text = Convert.ToInt32(stranka.akcija * 100).ToString();
                            NaslovStavbe.Text = stranka.naslovUstanove.ToUpper();
                            PostaStavbe.Text = stranka.postaUstanove.ToString();
                            PozicijaCust.Text = stranka.poklic.ToUpper();

                            //izberi vrstico objekta v tabeli
                            StrankeTable.Rows[idTable].Selected = true;
                        }
                        //Stranke ni v nobenem listu - error messageBox
                        else
                        {
                            MessageBox.Show($"Stranka z ID {idStranka} ne obstaja.");
                            DeleteStrankeBtn.Visible = false;
                            OutputObiskiBtn.Visible = false;
                            AddObiskButton.Visible = false;
                        }
                    }
                }
            }
            //id ni v tabeli
            else
            {
                //id = naslednji id - pocisti formo
                if (idStranka == Gym.Stranka.stStrank)
                {
                    ClearStrankaSearch(sender, e);
                }
                //id ni naslednji id in niti ne obstaja v tabeli
                else
                {
                    MessageBox.Show($"Stranka z ID {idStranka} ne obstaja.");
                    DeleteStrankeBtn.Visible = false;
                    OutputObiskiBtn.Visible = false;
                    AddObiskButton.Visible = false;
                }
            }
        }
        /*SEARCH STRANKA*/

        /*OUTPUT OBISKI*/
        private void OutputObiskiBtn_Click(object sender, EventArgs e)
        {
            int idStranka = Convert.ToInt32(IDCustTextBox.Text), idList = -1;
            idList = IdStrankaList(idStranka);

            //stranka
            if (idList > -1)
            {
                Stranke[idList].IzpisiObiske();
            }
            else
            {
                idList = IdUcenecList(idStranka);

                //ucenec
                if (idList > -1)
                {
                    Ucenci[idList].IzpisiObiske();
                }

                else
                {
                    idList = IdUsluzbenciList(idStranka);

                    //usluzbenec
                    if (idList > -1)
                    {
                        Usluzbenec[idList].IzpisiObiske();
                    }
                }
            }
        }
        /*OUTPUT OBISKI*/

        /*DELETE STRANKA*/
        private void DeleteStrankaClick(object sender, EventArgs e)
        {
            int idStranka = Convert.ToInt32(IDCustTextBox.Text), idList = -1, idTable = -1;
            idTable = IdStrankaTable(idStranka);
            bool success = true;

            if (idTable > -1)
            {
                idList = IdStrankaList(idStranka);

                //stranka
                if (idList > -1)
                {
                    Stranke.RemoveAt(idList);
                }
                else
                {
                    idList = IdUcenecList(idStranka);

                    //ucenec
                    if (idList > -1)
                    {
                        Ucenci.RemoveAt(idList);
                    }

                    else
                    {
                        idList = IdUsluzbenciList(idStranka);

                        //usluzbenec
                        if (idList > -1)
                        {
                            Usluzbenec.RemoveAt(idList);
                        }
                        //ne obstaja v listu
                        else
                        {
                            success = false;
                        }
                    }
                }

                StrankeTable.Rows.RemoveAt(idTable);
            }
            else
            {
                success = false;
            }

            ClearStrankaSearch(sender, e);

            if (!success)
            {
                MessageBox.Show($"Stranka z ID {idStranka} ne obstaja.");
            }

        }

        private void AddObiskButton_Click(object sender, EventArgs e)
        {
            int idStranka = Convert.ToInt32(IDCustTextBox.Text), idList = -1;
            idList = IdStrankaList(idStranka);

            //stranka
            if (idList > -1)
            {
                Stranke[idList].NovObisk();
            }
            else
            {
                idList = IdUcenecList(idStranka);

                //ucenec
                if (idList > -1)
                {
                    Ucenci[idList].NovObisk();
                }

                else
                {
                    idList = IdUsluzbenciList(idStranka);

                    //usluzbenec
                    if (idList > -1)
                    {
                        Usluzbenec[idList].NovObisk();
                    }
                }
            }
        }

        /*DELETE STRANKA*/

        /*----------------------------STRANKA----------------------------*/
    }
}
