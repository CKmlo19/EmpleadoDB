using EmpleadoDB.Models;
using System.Data.SqlClient;
using System.Data;

namespace EmpleadoDB.Data
{
    public class EmpleadoDatos
    {
        // este metodo lista en orden alfabetico 
        public List<EmpleadoModel> Listar() { 
            var oLista = new List<EmpleadoModel>();
            
            var cn = new Conexion();

            // abre la conexion
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                // el procedure de listar
                SqlCommand cmd = new SqlCommand("dbo.ListarEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    // hace una lectura del procedimiento almacenado
                    while (dr.Read())
                    {
                        oLista.Add(new EmpleadoModel()
                        {
                            // tecnicamente hace un select, es por eso que se lee cada registro uno a uno que ya esta ordenado
                            Id = (int)Convert.ToInt64(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Salario = Convert.ToInt64(dr["Salario"])
                        });
                    }
                }
            }
            return oLista;
        }

        public bool Guardar(EmpleadoModel oEmpleado) {
            bool resultado;

            try{ 


                var cn = new Conexion();

            // abre la conexion
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                // el procedure de listar
                SqlCommand cmd = new SqlCommand("dbo.InsertarEmpleado", conexion);
                cmd.Parameters.AddWithValue("inNombre",oEmpleado.Nombre);
                cmd.Parameters.AddWithValue("inSalario",oEmpleado.Salario);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery(); // sirve para que ejecute el store procedure como tal, que es la que inserta
   
            }
                resultado = true;
            
            }catch(Exception e) {
                string error = e.Message;
                resultado = false; 
                    
            }
            return resultado;
        }
    }
}
