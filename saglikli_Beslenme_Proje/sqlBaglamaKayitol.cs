using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace saglikli_Beslenme_Proje
{
    class sqlBaglamaKayitol
    {
        public SqlConnection verileriGoster()
        {
            SqlConnection baglan = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=saglikliBeslenme;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            baglan.Open();
            return baglan;
        }
    }
}
