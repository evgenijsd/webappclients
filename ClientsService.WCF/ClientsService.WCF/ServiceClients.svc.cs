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

        public string GetClientsJson(string city)
        {
            return GetClients(city);
        }

        private string GetClients(string city)
        {
            List<Client> Clients = new List<Client>();
            int i = 0;

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
                            i = ds.Tables[0].Rows.Count;
                        }
                    }
                    catch
                    {
                        return "-1";
                    }
                    finally
                    {
                        sqlCon.Close();
                    }
                }                

                using (DataTable dt = ds.Tables[0])
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Clients.Add(new Client()
                        {
                            Id = Guid.Parse(dr["id"].ToString()),
                            Name = dr["name"].ToString(),
                            Gender = dr["gender"].ToString(),
                            Email = dr["email"].ToString(),
                            Phone = dr["phone"].ToString(),
                            City = dr["city"].ToString(),
                            Birthday = DateTime.Parse(dr["birthday"].ToString()),
                            Created = DateTime.Parse(dr["created"].ToString()),
                            Comment = dr["comment"].ToString()
                        });
                    }
                }
            }

          List<Timetable> Schedule = new List<Timetable>
          {
            new Timetable
            {
                id=1, arrivaltime=DateTime.Parse("12:05:00"), busnumber=5, busstation = Clients.Count.ToString()
            },
            new Timetable
            {
                id=2, arrivaltime =DateTime.Parse("12:10:00"), busnumber=5, busstation ="Детский мир"
            }
          };
            return i.ToString();
        }
    }
}
