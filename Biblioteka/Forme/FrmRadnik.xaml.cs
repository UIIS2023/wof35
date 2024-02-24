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
    /// Interaction logic for FrmRadnik.xaml
    /// </summary>
    public partial class FrmRadnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        public FrmRadnik(bool azuriraj, DataRowView pomcniRed)
        {
            InitializeComponent();
            txtImeRadnika.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomcniRed;
            konekcija = kon.KreirajKonekciju();
        }
        public FrmRadnik()
        {
            InitializeComponent();
            txtImeRadnika.Focus();
            konekcija = kon.KreirajKonekciju();
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
                cmd.Parameters.Add("@imeRadnika", SqlDbType.NVarChar).Value = txtImeRadnika.Text;
                cmd.Parameters.Add("@prezimeRadnika", SqlDbType.NVarChar).Value = txtPrezimeRadnika.Text;
                cmd.Parameters.Add("@adresaRadnika", SqlDbType.NVarChar).Value = txtAdresaRadnika.Text;
                cmd.Parameters.Add("@kontaktRadnika", SqlDbType.NVarChar).Value = txtKontaktRadnika.Text;
                cmd.Parameters.Add("@gradRadnika", SqlDbType.NVarChar).Value = txtGradRadnika.Text;
                cmd.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = txtJMBG.Text;


                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @" update tblRadnik
                                            set ime=@imeRadnika, prezime=@prezimeRadnika,
                                            adresa=@adresaRadnika, kontakt=@kontaktRadnika
                                            grad=@gradRadnika, JMBG=@JMBG  where radnikID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblRadnik(ime,prezime,adresa,kontakt,grad,JMBG)
                                        values(@imeRadnika,@prezimeRadnika,@adresaRadnika,@kontaktRadnika,@gradRadnika,@JMBG)";

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
