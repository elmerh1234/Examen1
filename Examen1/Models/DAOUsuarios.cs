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
            this.con.ConnectionString = @"Data Source=192.00.00.00; Initial Catalog=examen1ds39; User ID=sa;Password=Passw0rd;";



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

            return nivel;
        }
    }
}