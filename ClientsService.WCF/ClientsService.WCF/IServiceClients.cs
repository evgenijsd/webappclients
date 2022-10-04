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
        [WebGet(UriTemplate = "/GetClientsJson/{city}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        string GetClientsJson(string city);
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

    [DataContract]
    public class Client
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public string Comment { get; set; }
    }

}
