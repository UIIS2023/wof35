
using System.Windows.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {
           SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder()

            {
                DataSource= @"DESKTOP-3C0C2GQ\SQLEXPRESS",
                InitialCatalog = "Biblioteka",
                IntegratedSecurity = true
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;

        }
    }
}