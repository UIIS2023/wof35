using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for FrmClanskaKarta.xaml
    /// </summary>
    public partial class FrmClanskaKarta : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmClanskaKarta(bool azuriraj, DataRowView pomcniRed)
        {
            InitializeComponent();
            dpDatumUclanjenja.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomcniRed;
            konekcija = kon.KreirajKonekciju();
        }
        public FrmClanskaKarta()
        {
            InitializeComponent();
            dpDatumUclanjenja.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DateTime date = (DateTime)dpDatumUclanjenja.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@cena", System.Data.SqlDbType.Money).Value = txtCenaKarte.Text;
                cmd.Parameters.Add("@datum", System.Data.SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@korisnikID", System.Data.SqlDbType.NVarChar).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@knjigaID", System.Data.SqlDbType.NVarChar).Value = cbKnjiga.SelectedValue;

                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblClanskaKarta  set cena=@cena,datum=@datum,
                                        KorisnikID=@korisnikID, knjigaID=@knjigaID, where clanskaKartaID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblClanskaKarta(cena, datum, KorisnikID, KnjigaID) 
                                    values(@cenaUclanjenja, @datumUclanjenja, @KorisnikID, @KnjigaID )";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close(); //this se odnosi na tog izdavaca i zatvara prozor
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos podataka nije validan", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greška prilikom konverzije podataka", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally// sluzi za zatvaranje konekcije
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

        private void cbKnjiga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    }
