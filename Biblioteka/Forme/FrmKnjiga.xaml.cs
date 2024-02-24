using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Biblioteka.Konekcija;

namespace Biblioteka.Forme
{
    /// <summary>
    /// Interaction logic for FrmKnjiga.xaml
    /// </summary>
    public partial class FrmKnjiga : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKnjiga(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtISBN.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }
        public FrmKnjiga()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtISBN.Focus();
            PopuniPadajuceListe();
        }


        private void PopuniPadajuceListe() 
        {
            try 
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                string vratiAutora = @"select autorID, imeAutora + ' ' + prezimeAutora as Autor from tblAutor";
                SqlDataAdapter daAutor = new SqlDataAdapter(vratiAutora, konekcija);
                DataTable dtAutor = new DataTable();
                daAutor.Fill(dtAutor);
                cbAutor.ItemsSource = dtAutor.DefaultView;
                daAutor.Dispose();
                dtAutor.Dispose();

                string vratiZanr = @"select žanrID, imeŽanra  from tblžanr";
                SqlDataAdapter daZanr = new SqlDataAdapter(vratiZanr, konekcija);
                DataTable dtZanr = new DataTable();
                daZanr.Fill(dtZanr);
                cbZanr.ItemsSource = dtZanr.DefaultView;
                daZanr.Dispose();
                dtZanr.Dispose();

                string vratiIzdavace = @"select izdavacID, imeIzdavaca from tblIzdavac";
                SqlDataAdapter daIzdavac = new SqlDataAdapter(vratiIzdavace, konekcija);
                DataTable dtIzdavac = new DataTable();
                daIzdavac.Fill(dtIzdavac);
                cbIzdavac.ItemsSource = dtIzdavac.DefaultView;
                daIzdavac.Dispose();
                dtIzdavac.Dispose();

                string vratiNabavke = @"select nabavkaID, CenaNabavke from tblNabavka";
                SqlDataAdapter daNabavka = new SqlDataAdapter(vratiNabavke, konekcija);
                DataTable dtNabavka = new DataTable();
                daNabavka.Fill(dtNabavka);
                cbNabavka.ItemsSource = dtNabavka.DefaultView;
                daNabavka.Dispose();
                dtNabavka.Dispose();

                string vratiClanskuKartu = @"select clanskaKartaID, cena from tblClanskaKarta";
                SqlDataAdapter daClanskaKarta = new SqlDataAdapter(vratiAutora, konekcija);
                DataTable dtClanskaKarta = new DataTable();
                daClanskaKarta.Fill(dtClanskaKarta);
                cbClanskaKarta.ItemsSource = dtClanskaKarta.DefaultView;
                daClanskaKarta.Dispose();
                dtClanskaKarta.Dispose();
            }
            catch(SqlException)
            {
                MessageBox.Show("unos odredjenih vrednosti nije validan", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@ISBN", SqlDbType.NVarChar).Value = txtISBN.Text;
                cmd.Parameters.Add("@naslovKnjige", SqlDbType.NVarChar).Value = txtNaslov.Text;
                cmd.Parameters.Add("@autorID", SqlDbType.Int).Value = cbAutor.SelectedValue;
                cmd.Parameters.Add("@zanrID", SqlDbType.Int).Value = cbZanr.SelectedValue;
                cmd.Parameters.Add("@izdavacID", SqlDbType.Int).Value = cbIzdavac.SelectedValue;
                cmd.Parameters.Add("@clanskaKartaID", SqlDbType.Int).Value = cbClanskaKarta.SelectedValue;
                cmd.Parameters.Add("@nabavkaID", SqlDbType.Int).Value = cbNabavka.SelectedValue;

                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKnjiga
                                        set ISBN=@ISBN, naslovKnjige=@naslovKnjige, autor=@autorID, zanr=@zanrID, izdavac=@izdavacID, clanskaKarta=@clanskaKarta, nabavka=@nabavkaID
                                        where knjigaID=@id";
                    pomocniRed = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblKnjiga(ISBN,naslovKnjige,autorID,zanrID,izdavacID,clanskaKartaID,nabavkaID)
                                        values(@ISBN,@naslovKnjige,@autor,@zanrID,@izdavacID,@clanskaKartaID,@nabavkaID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch (SqlException)
            {

                MessageBox.Show("unos odredjenih vrednosti nije validan", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally 
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
