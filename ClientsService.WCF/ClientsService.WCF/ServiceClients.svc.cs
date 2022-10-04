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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class ServiceClients : IServiceClients
    {
        public string ConnectionString = "Server=tcp:timetableserverok.database.windows.net,1433;Initial Catalog=timetabledb;Persist Security Info=False;User ID=alexej;Password=ЗДЕСЬ_ПАРОЛЬ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //public string ConnectionString = "Data Source=localhost;Initial Catalog=ClientsBase;Persist Security Info=True;User ID=sa;Password=01234567;";
        public List<Timetable> GetScheduleJson()
        {
            return GetSchedule();
        }


        private List<Timetable> GetSchedule()
        {
            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        string sqlStr = "select * from Timetable";
                        using (SqlDataAdapter sqlDa = new SqlDataAdapter(sqlStr, sqlCon))
                        {
                            sqlDa.Fill(ds);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                    finally
                    {
                        sqlCon.Close();
                    }
                }

                List<Timetable> Schedule = new List<Timetable>();

                using (DataTable dt = ds.Tables[0])
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Schedule.Add(new Timetable()
                        {
                            id = Convert.ToInt16((dr["ID"])),
                            arrivaltime = DateTime.Parse(dr["arrivaltime"].ToString()),
                            busnumber = Convert.ToInt16((dr["busnumber"] ?? 0)),
                            busstation = dr["busstation"].ToString()
                        });
                    }
                }
                return Schedule;
            }
        }
    }
}
