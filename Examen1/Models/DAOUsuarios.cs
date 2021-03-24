using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace Examen1.Models
{
    public class DAOUsuarios
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAOUsuarios()
        {
           
        }

        public string login(string usu, string contra)
        {
            string nivel = "";
            this.cmd.CommandText = "select nivel_usuario from usuarios where nombre_usuario='" + usu + "' and contra='" + contra + "'";
            this.cmd.Connection = con;
            this.cmd.Connection.Open();
            SqlDataReader lector = this.cmd.ExecuteReader();
            while(lector.Read())
            {
                nivel = lector[0].ToString();
            }

            this.cmd.Connection.Close();
            return nivel;
        }
    }
}