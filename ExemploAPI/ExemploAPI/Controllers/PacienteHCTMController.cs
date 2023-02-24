using ExemploAPI.Models;
using HttpActionResultStatus;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace ExemploAPI.Controllers
{
    public class PacienteHCTMController : ApiController
    {
        [HttpGet]
        [Route("api/paciente/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                HttpResult result = new HttpResult();
                var paciente = new PacienteHCTM();
                string retorno = paciente.Get(id);

                if(String.IsNullOrEmpty(retorno))
                {
                    retorno = @"{'Message' : Paciente não encontrado.}";
                    return result.ResultStatus(JObject.Parse(retorno).ToString(), Request, HttpStatusCode.InternalServerError);
                }

                return result.ResultStatus(retorno, Request, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}