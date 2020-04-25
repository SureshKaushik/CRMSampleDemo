using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CRMSamples
{
    public static class CRMConnection
    {
        public static void ConnectToCRM_Method1()
        {
            string crmServerName = "10.149.201.186:5555"; //--- You can also put IP address of your CRM server
            string crmOrganizationName = "CRM2016";
            string userName = "Administrator";
            string password = "Pit@ji05";
            IOrganizationService crmService;
            Guid userid = new Guid();

            ClientCredentials credentials = new ClientCredentials();
            credentials.UserName.UserName = userName;
            credentials.UserName.Password = password;

            Uri serviceUri = new Uri("http://" + crmServerName + "/" + crmOrganizationName + "/XRMServices/2011/Organization.svc");
            try
            {
                OrganizationServiceProxy proxy = new OrganizationServiceProxy(serviceUri, null, credentials, null);
                proxy.EnableProxyTypes();

                crmService = (IOrganizationService)proxy;

                //--Test the connection by following line of code. If it returns guid in variable "userid" then connected successfully
                userid = ((WhoAmIResponse)crmService.Execute(new WhoAmIRequest())).UserId;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error occured: ", ex.Message);
            }
            catch(FaultException<OrganizationServiceFault> ex)
            {
                Console.WriteLine(ex.Detail.Message);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
