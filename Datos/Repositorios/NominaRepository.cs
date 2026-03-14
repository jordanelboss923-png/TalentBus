using Datos.Conexion;
using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Repositorios
{
    public class NominaRepository
    {
        public DataTable ListarEmpleados()
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT e.Id, e.Cedula, e.Nombre, e.Apellido, 
                             c.NombreCargo, e.SalarioBase
                      FROM Empleado e
                      INNER JOIN Cargo c ON e.IdCargo = c.Id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void GenerarNomina(DataTable empleados,
                                   decimal pctAFP,
                                   decimal pctARS)
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                
                // TRANSACCIÓN: si algo falla, se revierte todo
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    // 1. Insertar cabecera Nomina
                    SqlCommand cmdNomina = new SqlCommand(
                        @"INSERT INTO Nomina (Fecha, TotalBruto, TotalDeducciones, TotalNeto)
                          VALUES (GETDATE(), @Bruto, @Deducciones, @Neto);
                          SELECT SCOPE_IDENTITY();", con, trans);

                    decimal totalBruto = 0, totalDeducciones = 0, totalNeto = 0;

                    foreach (DataRow row in empleados.Rows)
                    {
                        decimal salario = Convert.ToDecimal(row["SalarioBase"]);
                        int horasExtra = Convert.ToInt32(row["HorasExtra"]);
                        decimal afp = salario * (pctAFP / 100);
                        decimal ars = salario * (pctARS / 100);
                        decimal isr = CalcularISR(salario);
                        decimal extras = (salario / 240) * 1.35m * horasExtra;
                        decimal bruto = salario + extras;
                        decimal deducciones = afp + ars + isr;
                        decimal neto = bruto - deducciones;

                        totalBruto += bruto;
                        totalDeducciones += deducciones;
                        totalNeto += neto;
                    }

                    cmdNomina.Parameters.AddWithValue("@Bruto", totalBruto);
                    cmdNomina.Parameters.AddWithValue("@Deducciones", totalDeducciones);
                    cmdNomina.Parameters.AddWithValue("@Neto", totalNeto);

                    int idNomina = Convert.ToInt32(cmdNomina.ExecuteScalar());

                    // 2. Insertar detalle por empleado
                    foreach (DataRow row in empleados.Rows)
                    {
                        decimal salario = Convert.ToDecimal(row["SalarioBase"]);
                        int horasExtra = Convert.ToInt32(row["HorasExtra"]);
                        decimal afp = salario * (pctAFP / 100);
                        decimal ars = salario * (pctARS / 100);
                        decimal isr = CalcularISR(salario);
                        decimal extras = (salario / 240) * 1.35m * horasExtra;
                        decimal bruto = salario + extras;
                        decimal deducciones = afp + ars + isr;
                        decimal neto = bruto - deducciones;

                        SqlCommand cmdDetalle = new SqlCommand(
                            @"INSERT INTO NominaDetalle 
                              (IdNomina, IdEmpleado, SalarioBruto, TotalDeducciones, SalarioNeto)
                              VALUES (@IdNomina, @IdEmpleado, @Bruto, @Deducciones, @Neto)",
                              con, trans);

                        cmdDetalle.Parameters.AddWithValue("@IdNomina", idNomina);
                        cmdDetalle.Parameters.AddWithValue("@IdEmpleado", Convert.ToInt32(row["Id"]));
                        cmdDetalle.Parameters.AddWithValue("@Bruto", bruto);
                        cmdDetalle.Parameters.AddWithValue("@Deducciones", deducciones);
                        cmdDetalle.Parameters.AddWithValue("@Neto", neto);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    trans.Commit(); //  Todo salió bien
                }
                catch
                {
                    trans.Rollback(); //  Algo falló, se revierte todo
                    throw;
                }
            }
        }

        public DataTable ResumenPorDepartamento()
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                c.Departamento,
                COUNT(e.Id)               AS TotalEmpleados,
                SUM(nd.SalarioBruto)      AS TotalBruto,
                SUM(nd.TotalDeducciones)  AS TotalDeducciones,
                SUM(nd.SalarioNeto)       AS TotalNeto
              FROM NominaDetalle nd
              INNER JOIN Empleado e ON nd.IdEmpleado = e.Id
              INNER JOIN Cargo    c ON e.IdCargo     = c.Id
              WHERE nd.IdNomina = (SELECT MAX(Id) FROM Nomina) --  Solo la última
              GROUP BY c.Departamento", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public decimal CalcularISR(decimal salarioMensual)
        {
            decimal anual = salarioMensual * 12;

            if (anual <= 416220m) return 0;
            else if (anual <= 624329m) return (anual - 416220m) * 0.15m / 12;
            else if (anual <= 867123m) return (31216m + (anual - 624329m) * 0.20m) / 12;
            else return (79776m + (anual - 867123m) * 0.25m) / 12;
        }
        public DataTable ListarNominaCompleta()
        {
            using (SqlConnection con = new ConexionDB().AbrirConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                n.Fecha,
                e.Nombre,
                e.Apellido,
                c.NombreCargo      AS Cargo,
                nd.SalarioBruto,
                nd.TotalDeducciones,
                nd.SalarioNeto
              FROM NominaDetalle nd
              INNER JOIN Nomina   n ON nd.IdNomina   = n.Id
              INNER JOIN Empleado e ON nd.IdEmpleado = e.Id
              INNER JOIN Cargo    c ON e.IdCargo     = c.Id
              ORDER BY n.Fecha DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}