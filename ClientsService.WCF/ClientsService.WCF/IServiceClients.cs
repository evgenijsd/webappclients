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
        int GetClientsJson(string city);
    }
}
