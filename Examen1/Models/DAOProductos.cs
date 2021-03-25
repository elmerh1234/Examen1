using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace Examen1.Models
{
    public class DAOProductos
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAOProductos()
        {
            this.con.ConnectionString = @"Data Source=ELMER\ELMERH; Initial Catalog=examen1ds39; integrated security = true";
        }

        public List<Productos> getTabla(string valor)
        {
            List<Productos> data = new List<Productos>();
            cmd.Connection = this.con;
            cmd.CommandText = "select * from productos";
            if (valor != null) { 
            cmd.CommandText = "select * from productos where (" +
                     "(cod_prod like '%"+valor+ "%')) or " +
                     "((nombre like '%" + valor + "%')) or " +
                     "((descripcion like '%" + valor + "%')) or" +
                     "((precio_unit like '%" + valor + "%')) or " +
                     "((existencia like '%" + valor + "%')) or" +
                     "((garantia like '%" + valor + "%'));";

            }
       
            cmd.Connection.Open();
           SqlDataReader lector= cmd.ExecuteReader();
            while (lector.Read())
            {
                data.Add(new Productos(int.Parse(lector[0].ToString()), lector[1].ToString(), lector[2].ToString(), 
                    double.Parse(lector[3].ToString()), int.Parse(lector[4].ToString()), int.Parse(lector[5].ToString())));
            }

            cmd.Connection.Close();
            lector.Close();
            return data;

        }

        public bool insertar(Productos pro)
        {
            cmd.Connection = this.con;
            cmd.CommandText = "insert into productos values('" + pro.nombre + "','" + pro.descripcion + "'," + pro.precioUnit + ", " + pro.existencia + ", " + pro.garantia + ")";
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool eliminar(Productos pro)
        {
            cmd.Connection = this.con;
            cmd.CommandText = "delete from productos where cod_prod="+pro.codProd;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool modificar(Productos pro)
        {
            cmd.Connection = this.con;
            cmd.CommandText = "update productos set nombre='" + pro.nombre + "', descripcion='" + pro.descripcion + "', precio_unit=" + pro.precioUnit + ", existencia=" + pro.existencia + ", garantia="
                + pro.garantia + " where cod_prod=" + pro.codProd;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}