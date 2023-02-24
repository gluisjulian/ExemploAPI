using DAO;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Text;
using HCTaNaMao.Domain;

namespace ExemploAPI.Models
{
    public class PacienteHCTM
    {
        public string Get(int id)
        {
            string sqlString = "select " +
                                "id_paciente, " +
                                "id_legado, " +
                                "id_unidade_basica_saude, " +
                                "to_char(data_nascimento, 'DD/MM/YYYY') data_nascimento," +
                                "foto, " +
                                "nome, " +
                                "cns, " +
                                "cpf, " +
                                "prontuario, " +
                                "token_notificacao, " +
                                "email, " +
                                "rg, " +
                                "to_char(data_hora_alterou_senha, 'DD/MM/YYYY') data_hora_alterou_senha," +
                                "flg_forca_alteracao_senha, to_char(data_hora_aceitacao_termo, 'DD/MM/YYYY') data_hora_aceitacao_termo, " +
                                "senha" +
                                $" from hctm_paciente where id_paciente = {id.ToString()}";

            var dt = BDOracle.getDataTable(sqlString);

            HCTMPacienteDTO paciente = new HCTMPacienteDTO();

            try
            {
                DataRow reg = dt.Rows[0];

                paciente.id_paciente = reg["id_paciente"].ToString();
                paciente.id_legado = reg["id_legado"].ToString();
                paciente.id_unidade_basica_saude = reg["id_unidade_basica_saude"].ToString();
                paciente.data_nascimento = reg["data_nascimento"].ToString();
                paciente.foto = Encoding.UTF8.GetBytes(reg["foto"].ToString());
                paciente.nome = reg["nome"].ToString();
                paciente.cns = reg["cns"].ToString();
                paciente.cpf = reg["cpf"].ToString();
                paciente.prontuario = reg["prontuario"].ToString();
                paciente.email = reg["email"].ToString();
                paciente.rg = reg["rg"].ToString();
                paciente.data_hora_alterou_senha_string = reg["data_hora_alterou_senha"].ToString() == "" ? null : reg["data_hora_aceitacao_termo"].ToString();
                paciente.data_hora_aceitacao_termo_string = reg["data_hora_aceitacao_termo"].ToString() == "" ? null : reg["data_hora_aceitacao_termo"].ToString();
                paciente.flg_forca_alteracao_senha = reg["flg_forca_alteracao_senha"].ToString();
                paciente.senha = reg["id_paciente"].ToString();
                return JObject.FromObject(paciente).ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}