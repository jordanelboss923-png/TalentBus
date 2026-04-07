using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// usa using (SqlConnection con = ConexionDB.AbrirConexion()) para
// abrir la conexion con la base de datos

/* TODO ELIMINAR ESTO PARA QUITAR COMENTADO

{
    {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Porcentaje", this.Porcentaje);
                cmd.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }
    }
}

*/ // TODO ELIMINAR ESTO PARA QUITAR COMENTADO