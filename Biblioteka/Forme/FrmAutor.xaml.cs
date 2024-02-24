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
    /// Interaction logic for FrmAutor.xaml
    /// </summary>
    public partial class FrmAutor : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmAutor(bool azuriraj, DataRowView pomcniRed)
        {
            InitializeComponent();
            txtImeAutora.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomcniRed;
            konekcija = kon.KreirajKonekciju();
        }
        public FrmAutor()
        {
            InitializeComponent();
            txtImeAutora.Focus();
            konekcija = kon.KreirajKonekciju();
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
                cmd.Parameters.Add("@imeAutora", System.Data.SqlDbType.NVarChar).Value = txtImeAutora.Text;
                cmd.Parameters.Add("@prezimeAutora", System.Data.SqlDbType.NVarChar).Value = txtPrezimeAutora.Text;
                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblAutor set imeAutora=@imeAutora,prezimeAutora=@prezimeAutora where autorID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblAutor(imeAutora,prezimeAutora) values(@imeAutora,@prezimeAutora)";

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
    }
}
