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

namespace Biblioteka.Forme
{
    /// <summary>
    /// Interaction logic for FrmNabavka.xaml
    /// </summary>
    public partial class FrmNabavka : Window
    {
        Konekcija kon= new Konekcija(); 
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmNabavka(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtCenaNabavke.Focus();
            this.azuriraj=azuriraj;
            this.pomocniRed=pomocniRed;
            PopuniPadajuceListe();
        }
        
        public FrmNabavka()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtCenaNabavke.Focus();
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe() 
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                string vratiKorisnike = @"select KorisnikID,imeKorisnika from tblKorisnik ";
                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnike, konekcija);
                
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                daKorisnik.Dispose();
            }
            catch(SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                DateTime date = (DateTime)dpDatumNabavke.SelectedDate;
                string datum = date.ToString("YYYY-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@datumNabavke", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@cenaNabavke", SqlDbType.Money).Value = txtCenaNabavke.Text;
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;

                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblNabavka
                                        set datumNabavke=@datumeNabavke, cenaNabavke=@cenaNabavke , KorisnikID=@korisnikID
                                        where NabavkaID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblNabavka(datumNabavke,cenaNabavke,KorisnikID)
                                        values(@datumNabavke,@cenaNabavke,@korisnikID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("unos odredjenih vrednosti nije validan", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("odaberite datum!", "greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("greska prilikom konverzije podataka!", "greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                konekcija.Close();
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
