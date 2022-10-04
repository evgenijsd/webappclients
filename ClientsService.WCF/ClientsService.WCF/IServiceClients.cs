using System.ServiceModel;
using System.ServiceModel.Web;

namespace ClientsService.WCF
{
    [ServiceContract]
    public interface IServiceClients
    {

        [OperationContract]
        [WebGet(UriTemplate = "/GetClientsCity/{city}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        int GetClientsCity(string city);
    }
}
