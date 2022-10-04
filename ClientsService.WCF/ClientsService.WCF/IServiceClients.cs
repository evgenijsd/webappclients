using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClientsService.WCF
{
    [ServiceContract]
    public interface IServiceClients
    {

        [OperationContract]
        [WebGet(UriTemplate = "/GetScheduleJson",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        List<Timetable> GetScheduleJson();
    }

    [DataContract]
    public class Timetable
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public DateTime arrivaltime { get; set; }

        [DataMember]
        public Int16 busnumber { get; set; }

        [DataMember]
        public string busstation { get; set; }
    }

}
