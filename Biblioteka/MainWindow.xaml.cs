using System.Text;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Common;
using Biblioteka.Forme;
using System.Runtime.Intrinsics.X86;


namespace Biblioteka
{




    public partial class MainWindow : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        string ucitanaTabela;
        bool azuriraj;
       // string ucitanaTabela;


        
        #region Select upiti
        static string zanrSelect = @"select žanrID as ID, imeŽanra as Zanr from tblžanr";
        static string autorSelect = @"select autorID as ID, imeAutora as 'Ime autora', prezimeAutora as 'Prezime autora' from tblAutor";
        static string izdavacSelect = @"select izdavacID as ID, imeIzdavaca as Izdavac from tblIzdavac";
        static string korisnikSelect = @"select KorisnikID as ID, imeKorisnika as 'Ime korisnika', prezimeKorisnika as 'Prezime korisnika',
                                        lozinka as lozinka, adresaKorisnika as 'Adresa korisnika' , kontaktKorisnika as 'Kontakt korisnika' from tblKorisnik";
        static string radnikSelect = @"select radnikID as ID, ime as 'Ime', prezime as 'Prezime ',
                                        adresa as 'Adresa ', grad as 'Grad ', kontakt as 'Kontakt ' from tblRadnik";

        static string clanskaKartaSelect = @"select clanskaKartaID as ID, cena as 'cena', datum as 'datum' 
                                        from tblClanskaKarta join tblKorisnik on tblClanskaKarta.KorisnikID = tblKorisnik.KorisnikID
                                                      join tblKnjiga on tblClanskaKarta.knjigaID = tblKnjiga.knjigaID";


        static string nabavkaSelect = @"select nabavkaID as ID, datumNabavke as 'Datum nabavke', cenaNabavke as 'Cena nabavke', imeKorisnika as 'Ime korisnika'
                                        from tblNabavka join tblKorisnik on tblNabavka.KorisnikID = tblKorisnik.KorisnikID";


        static string knjigaSelect = @"select KnjigaID as ID, ISBN, naslovKnjige as 'naslov', imeAutora as 'Ime Autora', imeZanra as 'Zanr', imeIzdavaca as Ime Izdavaca,
                                      cena as 'cena', CenaNabavke as 'Cena nabavke'
                                        from tblKnjiga join tblAutor on tblKnjiga.autorID = tblAutor.autorID
                                                       join tblžanr on tblKnjiga.žanrID = tblZanr2.žanrID
                                                       join tblIzdavac on tblKnjiga.izdavacID = tblIzdavac.izdavacID
                                                       join tblClanskaKarta on tblKnjiga.clanskaKartaID = tblClanskaKarta.clanskaKartaID
                                                       join tblNabavka on tblKnjiga.nabavkaID = tblNabavka.nabavkaID";
        #endregion


        #region Select sa uslovom
        string selectUslovZanr = @"select * from tblžanr where žanrID=";
        string selectUslovIzdavac = @"select * from tblIzdavac where izdavacID=";
        string selectUslovAutor = @"select * from tblAutor where autorID=";
        string selectUslovKorisnik = @"select * from tblKorisnik where KorisnikID=";
        string selectUslovClanskaKarta = @"select * from tblClanskaKarta where clanskaKartaID=";
        string selectUslovNabavka = @"select * from tblNabavka where nabavkaID=";
        string selectUslovRadnik = @"select * from tblRadnik where radnikID=";
        string selectUslovKnjiga = @"select * from tblKnjiga where knjigaID=";
        #endregion


        #region Select delete
        string zanrDelete = @"delete from tblžanr where žanrID=";
        string izdavacDelete = @"delete from tblIzdavac where izdavacID=";
        string autorDelete = @"delete from tblAutor where autorID=";
        string korisnikDelete = @"delete from tblKorisnik where KorisnikID=";
        string clanskaKartaDelete = @"delete from tblClanskaKarta where clanskaKartaID=";
        string nabavkaDelete = @"delete from tblNabavka where nabavkaID=";
        string radnikDelete = @"delete from tblRadnik where radnikID=";
        string knjigaDelete = @"delete from tblKnjiga where knjigaID=";
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            //UcitajPodatke(dataGridCentralni, korisnikSelect);
            konekcija = kon.KreirajKonekciju(); //pristupanje bazi
        }

        private void UcitajPodatke(DataGrid grid, string selectUpiti)
        {
            try
            {
                konekcija.Open(); //konekcija sa bazom
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpiti, konekcija); //pomocu njega dobijamo podatke iz baze
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                if (grid != null)// ako grid postoji
                {
                    grid.ItemsSource = dt.DefaultView;// prikazuje tabelu po redovima i kolonama
                }
                ucitanaTabela = selectUpiti;
                dt.Dispose();
                dataAdapter.Dispose();// oslobadja zauzete resurse
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno ucitani podatci", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally// sluzi za zatvaranje konekcije
            {
                if (konekcija != null)
                {
                    konekcija.Close();// konwkcija se zatvara ako se ne zatvori nece moci da joj se pristupi
                }
            }
        }

        private void btnKnjiga_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, knjigaSelect);
        }

        private void btnZanr_Clik(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, zanrSelect);
        }

        private void btnAutor_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, autorSelect);
        }

        private void btnIzdavac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, izdavacSelect);
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, korisnikSelect);
        }

        private void btnClanskaKarta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, clanskaKartaSelect);
        }

        private void btnNabavka_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, nabavkaSelect);
        }

        private void btnRadnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, radnikSelect);
        }

        private void PopuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0]; //kastovanje
                SqlCommand komanda = new SqlCommand
                {
                    Connection = konekcija
                };
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                komanda.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                komanda.CommandText = selectUslov + "@id";
                SqlDataReader citac = komanda.ExecuteReader();
                komanda.Dispose();

                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(korisnikSelect))
                    {
                        FrmKorisnik prozorKorisnik = new FrmKorisnik(azuriraj, red);
                        prozorKorisnik.txtImeKorisnika.Text = citac["imeKorisnika"].ToString();
                        prozorKorisnik.txtPrezimeKorisnika.Text = citac["prezimeKorisnika"].ToString();
                        prozorKorisnik.txtAdresaKorisnika.Text = citac["adresaKorisnika"].ToString();
                        prozorKorisnik.txtLozinka.Text = citac["lozinka"].ToString();
                        prozorKorisnik.txtKontaktKorisnika.Text = citac["KontaktKorisnika"].ToString();
                        prozorKorisnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(radnikSelect))
                    {
                        FrmRadnik prozorRadnik = new FrmRadnik(azuriraj, red);
                        prozorRadnik.txtImeRadnika.Text = citac["ime"].ToString();
                        prozorRadnik.txtPrezimeRadnika.Text = citac["prezime"].ToString();
                        prozorRadnik.txtJMBG.Text = citac["JMBG"].ToString();
                        prozorRadnik.txtAdresaRadnika.Text = citac["adresa"].ToString();
                        prozorRadnik.txtGradRadnika.Text = citac["grad"].ToString();
                        prozorRadnik.txtKontaktRadnika.Text = citac["kontakt"].ToString();
                        prozorRadnik.ShowDialog();



                        //novi
                        // prozorKupac.cbxClanskaKarta.IsChecked = !Convert.IsDBNull(citac["ClanskaKarta"]) && (bool)citac["ClanskaKarta"];
                        //proverava da li je vrednost DBNull. Ako nije, onda se izvršava drugi deo izraza (bool)citac["ClanskaKarta"]

                    }
                    else if (ucitanaTabela.Equals(zanrSelect))
                    {
                        FrmZanr prozorZanr = new FrmZanr(azuriraj, red);
                        prozorZanr.txtNazivZanra.Text = citac["imeŽanra"].ToString();
                        prozorZanr.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(izdavacSelect))
                    {
                        FrmIzdavac prozorIzdavac = new FrmIzdavac(azuriraj, red);
                        prozorIzdavac.txtNazivIzdavaca.Text = citac["imeIzdavaca"].ToString();
                        prozorIzdavac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(autorSelect))
                    {
                        FrmAutor prozorAutor = new FrmAutor(azuriraj, red);
                        prozorAutor.txtImeAutora.Text = citac["imeAutora"].ToString();
                        prozorAutor.txtPrezimeAutora.Text = citac["prezimeAutora"].ToString();
                        prozorAutor.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(nabavkaSelect))
                    {
                        FrmNabavka prozorNabavka = new FrmNabavka(azuriraj, red);
                        prozorNabavka.dpDatumNabavke.SelectedDate = (DateTime)citac["DatumNabavke"];
                        prozorNabavka.txtCenaNabavke.Text = citac["CenaNabavke"].ToString();
                        prozorNabavka.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorNabavka.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(clanskaKartaSelect))
                    {
                        FrmClanskaKarta prozorClanskaKarta = new FrmClanskaKarta(azuriraj, red);
                        prozorClanskaKarta.dpDatumUclanjenja.SelectedDate = (DateTime)citac["datum"];
                        prozorClanskaKarta.txtCenaKarte.Text = citac["cena"].ToString();
                        prozorClanskaKarta.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorClanskaKarta.cbKnjiga.SelectedValue = citac["knjigaID"].ToString();
                        prozorClanskaKarta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(knjigaSelect))
                    {
                        FrmKnjiga prozorKnjiga = new FrmKnjiga(azuriraj, red);
                        prozorKnjiga.txtISBN.Text = citac["ISBN"].ToString();
                        prozorKnjiga.txtNaslov.Text = citac["Naslov"].ToString();
                        prozorKnjiga.cbAutor.SelectedValue = citac["autorID"];
                        prozorKnjiga.cbZanr.SelectedValue = citac["ZanrID"];
                        prozorKnjiga.cbIzdavac.SelectedValue = citac["izdavacID"];
                        prozorKnjiga.cbNabavka.SelectedValue = citac["nabavkaID"];
                        prozorKnjiga.cbClanskaKarta.SelectedValue = citac["clanskaKartaID"];
                        prozorKnjiga.ShowDialog();
                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }
        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Obaveštenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }


        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(knjigaSelect))
            {
                prozor = new FrmKnjiga();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, knjigaSelect);
            }
            else if (ucitanaTabela.Equals(zanrSelect))
            {
                prozor = new FrmZanr();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, zanrSelect);
            }
            else if (ucitanaTabela.Equals(izdavacSelect))
            {
                prozor = new FrmIzdavac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, izdavacSelect);
            }
            else if (ucitanaTabela.Equals(autorSelect))
            {
                prozor = new FrmAutor();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, autorSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                prozor = new FrmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(clanskaKartaSelect))
            {
                prozor = new FrmClanskaKarta();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, clanskaKartaSelect);
            }
            else if (ucitanaTabela.Equals(radnikSelect))
            {
                prozor = new FrmRadnik();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, radnikSelect);
            }
            else if (ucitanaTabela.Equals(knjigaSelect))
            {
                prozor = new FrmKnjiga();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, knjigaSelect);
            }

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(zanrSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovZanr);
                UcitajPodatke(dataGridCentralni, zanrSelect);
            }
            else if (ucitanaTabela.Equals(izdavacSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovIzdavac);
                UcitajPodatke(dataGridCentralni, izdavacSelect);
            }

            else if (ucitanaTabela.Equals(autorSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovAutor);
                UcitajPodatke(dataGridCentralni, autorSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKorisnik);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }

            else if (ucitanaTabela.Equals(clanskaKartaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovClanskaKarta);
                UcitajPodatke(dataGridCentralni, clanskaKartaSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovNabavka);
                UcitajPodatke(dataGridCentralni, nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(radnikSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovRadnik);
                UcitajPodatke(dataGridCentralni, radnikSelect);
            }
            else if (ucitanaTabela.Equals(knjigaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKnjiga);
                UcitajPodatke(dataGridCentralni, knjigaSelect);
            }
        }


        private void btnIzm_Click(object sender, RoutedEventArgs e)
        {



            if (ucitanaTabela.Equals(zanrSelect))
            {
                ObrisiZapis(zanrDelete);
                UcitajPodatke(dataGridCentralni, zanrSelect);
            }
            else if (ucitanaTabela.Equals(izdavacSelect))
            {
                ObrisiZapis( izdavacDelete);
                UcitajPodatke(dataGridCentralni, izdavacSelect);
            }

            else if (ucitanaTabela.Equals(autorSelect))
            {
                ObrisiZapis(autorDelete);
                UcitajPodatke(dataGridCentralni, autorSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                ObrisiZapis(korisnikDelete);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }

            else if (ucitanaTabela.Equals(clanskaKartaSelect))
            {
                ObrisiZapis(clanskaKartaDelete);
                UcitajPodatke(dataGridCentralni, clanskaKartaSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                ObrisiZapis(nabavkaDelete);
                UcitajPodatke(dataGridCentralni, nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(radnikSelect))
            {
                ObrisiZapis(radnikDelete);
                UcitajPodatke(dataGridCentralni, radnikSelect);
            }
            else if (ucitanaTabela.Equals(knjigaSelect))
            {
                ObrisiZapis( knjigaDelete);
                UcitajPodatke(dataGridCentralni, knjigaSelect);
            }



        }
    }
        
    }
