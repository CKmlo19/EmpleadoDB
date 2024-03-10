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
                cmd.Parameters.AddWithValue("OutResultCode", 0); // se le coloca un 0 en el outresultcode
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
                            Salario = Convert.ToDecimal(dr["Salario"])
                        });
                    }
                }
            }
            return oLista;
        }

        public bool Insertar(EmpleadoModel oEmpleado) {
            bool resultado;

            try{ 


                var cn = new Conexion();

            // abre la conexion
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                // el procedure de listar
                SqlCommand cmd = new SqlCommand("dbo.InsertarEmpleado", conexion);
                cmd.Parameters.AddWithValue("inNombre",oEmpleado.Nombre.Trim()); // se le hace un trim a la hora de insertar
                cmd.Parameters.AddWithValue("inSalario",oEmpleado.Salario);
                cmd.Parameters.AddWithValue("OutResultCode", 0); // en un inicio se coloca en 0
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
