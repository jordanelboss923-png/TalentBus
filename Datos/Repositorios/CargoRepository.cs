<<<<<<< Updated upstream:Datos/Repositorios/CargoRepository.cs
﻿using Entidades;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace Datos.Repositorios
{
    public class CargoRepository
    {
        ConexionDB conexion = new ConexionDB();
        public void Insertar(Cargo cargo)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Cargo (NombreCargo, Departamento) VALUES (@Nombre, @Depto)", con);
                cmd.Parameters.AddWithValue("@Nombre", cargo.NombreCargo);
                cmd.Parameters.AddWithValue("@Depto", cargo.Departamento);
                cmd.ExecuteNonQuery();

            }




        }


        public DataTable Listar()
        {
=======
﻿using CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class PosicionesCD : BaseCD
    {
        
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
        public int IdDepartamento { get; set; }


        // TODO MÉTODO PROTEGIDO: Nombre de tabla para Eliminar

        protected override string ObtenerNombreTabla()
        {
            return "Posiciones";
        }


        // TODO OBTENER TODAS LAS POSICIONES síncrono


        public override DataTable ObtenerTodos()
        {
            string query = @"SELECT p.Id, 
                                    p.Nombre, 
                                    p.Salario, 
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento";

            DataTable tabla = new DataTable();

>>>>>>> Stashed changes:Datos/Repositorios/Configuraciones/PosicionesCD.cs
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UNA POSICIÓN POR SU ID síncrono

        public override DataTable ObtenerPorId(int id)
        {
<<<<<<< Updated upstream:Datos/Repositorios/CargoRepository.cs
=======
            string query = @"SELECT p.Id, 
                                    p.Nombre, 
                                    p.Salario, 
                                    p.IdDepartamento,
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento
                             WHERE p.Id = @Id";

            DataTable tabla = new DataTable();

>>>>>>> Stashed changes:Datos/Repositorios/Configuraciones/PosicionesCD.cs
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO INSERTAR UNA NUEVA POSICIÓN síncrono


        public override bool Insertar()
        {
            string query = @"INSERT INTO Posiciones (Nombre, Salario, IdDepartamento) 
                             VALUES (@Nombre, @Salario, @IdDepartamento)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Salario", this.Salario);
                cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

<<<<<<< Updated upstream:Datos/Repositorios/CargoRepository.cs
        public void Actualizar(Cargo cargo)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Cargo SET 
                      NombreCargo  = @Nombre, 
                      Departamento = @Depto 
                      WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Nombre", cargo.NombreCargo);
                cmd.Parameters.AddWithValue("@Depto", cargo.Departamento);
                cmd.Parameters.AddWithValue("@Id", cargo.Id);
                cmd.ExecuteNonQuery();
=======

        // TODO ACTUALIZAR UNA POSICIÓN EXISTENTE síncrono

        public override bool Actualizar(int id)
        {
            string query = @"UPDATE Posiciones 
                             SET Nombre         = @Nombre, 
                                 Salario        = @Salario, 
                                 IdDepartamento = @IdDepartamento 
                             WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Salario", this.Salario);
                cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        // TODO OBTENER TODAS LAS POSICIONES asíncrono

        public override async Task<DataTable> ObtenerTodosAsync()
        {
            string query = @"SELECT p.Id, 
                                    p.Nombre, 
                                    p.Salario, 
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento";

            DataTable tabla = new DataTable();

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                await con.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO OBTENER UNA POSICIÓN POR ID asíncrono

        public override async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT p.Id, 
                                    p.Nombre, 
                                    p.Salario, 
                                    p.IdDepartamento,
                                    d.Nombre AS NombreDepartamento
                             FROM Posiciones p
                             INNER JOIN Departamentos d ON d.Id = p.IdDepartamento
                             WHERE p.Id = @Id";

            DataTable tabla = new DataTable();

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }

            return tabla;
        }


        // TODO INSERTAR UNA POSICIÓN asíncrono

        public override async Task<bool> InsertarAsync()
        {
            string query = @"INSERT INTO Posiciones (Nombre, Salario, IdDepartamento) 
                             VALUES (@Nombre, @Salario, @IdDepartamento)";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Salario", this.Salario);
                cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
            }
        }


        // TODO ACTUALIZAR UNA POSICIÓN asíncrono

        public override async Task<bool> ActualizarAsync(int id)
        {
            string query = @"UPDATE Posiciones 
                             SET Nombre         = @Nombre, 
                                 Salario        = @Salario, 
                                 IdDepartamento = @IdDepartamento 
                             WHERE Id = @Id";

            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@Salario", this.Salario);
                cmd.Parameters.AddWithValue("@IdDepartamento", this.IdDepartamento);
                cmd.Parameters.AddWithValue("@Id", id);
                await con.OpenAsync();

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                return filasAfectadas > 0;
>>>>>>> Stashed changes:Datos/Repositorios/Configuraciones/PosicionesCD.cs
            }
        }
    }
}