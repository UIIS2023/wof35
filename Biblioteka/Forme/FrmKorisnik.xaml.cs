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
using System.Data.SqlClient;

namespace Biblioteka.Forme
{
    /// <summary>
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmKorisnik(bool azuriraj, DataRowView pomcniRed)
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomcniRed;
            konekcija = kon.KreirajKonekciju();
        }
        public FrmKorisnik()
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@imeKorisnika", SqlDbType.NVarChar).Value = txtImeKorisnika.Text;
                cmd.Parameters.Add("@prezimeKorisnika", SqlDbType.NVarChar).Value = txtPrezimeKorisnika.Text;
                cmd.Parameters.Add("@lozinka", SqlDbType.NVarChar).Value = txtLozinka.Text;
                cmd.Parameters.Add("@adresaKorisnika", SqlDbType.NVarChar).Value = txtAdresaKorisnika.Text;
                cmd.Parameters.Add("@kontaktKorisnika", SqlDbType.NVarChar).Value = txtKontaktKorisnika.Text;

                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @" update tblKorisnik
                                            set imeKorisnika=@imeKorisnika, prezimeKorisnika=@prezimeKorisnika,
                                             lozinka=@lozinka,adresaKorisnika=@adresaKorisnika,
                                             kontaktKorisnika=@kontaktKorisnika  where KorisnikID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKorisnik(imeKorisnika,prezimeKorisnika,lozinka,adresaKorisnika,kontaktKorisnika)
                                        values(@imeKorisnika,@prezimeKorisnika,@lozinka,@adresaKorisnika,@kontaktKorisnika)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
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

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
