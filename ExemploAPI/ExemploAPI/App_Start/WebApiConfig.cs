using DAO;
using ExemploAPI.Service;
using System.Web.Http;

namespace ExemploAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Setar a conexao com banco
            //HCTMService.Conexao = "TESTE";
             HCTMService.Conexao = "PROD";


            BDOracle.strConexao = HCTMService.Conexao;

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
