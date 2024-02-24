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
    /// Interaction logic for FrmZanr.xaml
    /// </summary>
    public partial class FrmZanr : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmZanr(bool azuriraj, DataRowView pomcniRed)
        {
            InitializeComponent();
            txtNazivZanra.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomcniRed;
            konekcija = kon.KreirajKonekciju();
        }
        public FrmZanr()
        {
            InitializeComponent();
            txtNazivZanra.Focus();
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
                cmd.Parameters.Add("@imeŽanra", System.Data.SqlDbType.NVarChar).Value = txtNazivZanra.Text;
                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblžanr set imeŽanra=@imeŽanra where žanrID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblŽanr(imeŽanra) values(@imeŽanra)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close(); //this se odnosi na tog izdavaca i zavara prozor
            }
            catch (SqlException)
            {
                MessageBox.Show("unos odredjenih vrednosti nije validan", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }

}
