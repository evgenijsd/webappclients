using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClientsService.WCF
{   
    public class ServiceClients : IServiceClients
    {
        public string ConnectionString = "Data Source=localhost;Initial Catalog=ClientsBase;Persist Security Info=True;User ID=sa;Password=01234567;";

        public int GetClientsJson(string city)
        {
            return GetClients(city);
        }

        private int GetClients(string city)
        {
            int count = 0;

            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        string sqlStr = $"select * from Clients where City='{city}'";
                        using (SqlDataAdapter sqlDa = new SqlDataAdapter(sqlStr, sqlCon))
                        {
                            sqlDa.Fill(ds);
                            count = ds.Tables[0].Rows.Count;
                        }
                    }
                    catch
                    {
                        return -1;
                    }
                    finally
                    {
                        sqlCon.Close();
                    }
                }                

            }

            return count;
        }
    }
}
