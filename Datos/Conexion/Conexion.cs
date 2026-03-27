using System.Data;
using System.Data.SqlClient;
using System;


namespace CapaDatos
{//Hola
    public class ConexionDB
    {
        private SqlConnection Conexion = new SqlConnection("Server=localhost;DataBase=TalentBusDB;Integrated Security=true");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}

