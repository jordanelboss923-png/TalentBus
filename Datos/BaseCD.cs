using Datos.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    // TODO Interfaz
    public interface ICRUDBase
    {
        DataTable ObtenerTodos();
        DataTable ObtenerPorId(int id);
        bool Insertar();
        bool Actualizar(int id);
        bool Eliminar(int id);

        // Versiones asíncronas del contrato
        Task<DataTable> ObtenerTodosAsync();
        Task<DataTable> ObtenerPorIdAsync(int id);
        Task<bool> InsertarAsync();
        Task<bool> ActualizarAsync(int id);
        Task<bool> EliminarAsync(int id);
    }

    // TODO CLASE PADRE DE LAS OPERACIONES CRUD
    // TODO Clase abstracta
    public abstract class BaseCD : ICRUDBase
    {
        // TODO Metodo virtual
        public virtual bool Eliminar(int id)
        {
            string query = $"DELETE FROM {ObtenerNombreTabla()} WHERE Id = @Id";

            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // TODO llamada Asincrona de Eliminar
        public virtual async Task<bool> EliminarAsync(int id)
        {
            string query = $"DELETE FROM {ObtenerNombreTabla()} WHERE Id = @Id";

            using (SqlConnection con = ConexionDB.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();
                int filas = await cmd.ExecuteNonQueryAsync();
                return filas > 0;
            }
        }

        // TODO Metodo abstracto
        public abstract DataTable ObtenerTodos();
        public abstract DataTable ObtenerPorId(int id);
        public abstract bool Insertar();
        public abstract bool Actualizar(int id);

        
        public abstract Task<DataTable> ObtenerTodosAsync();
        public abstract Task<DataTable> ObtenerPorIdAsync(int id);
        public abstract Task<bool> InsertarAsync();
        public abstract Task<bool> ActualizarAsync(int id);

        // ─────────────────────────────────────────────────────
        // Método abstracto auxiliar: cada clase hija devuelve
        // el nombre de su tabla para que Eliminar() funcione genérico
        // ─────────────────────────────────────────────────────
        protected abstract string ObtenerNombreTabla();
    }
}
