using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class Datos
    {
        public string insertar(EntidadMaestro obj)
        {
            string Respuesta = " ";
            SqlConnection conexiones = new SqlConnection();
             
            try
            {
                conexiones = Conexiones.crearInstancia().crearConexion();
                SqlCommand comandos = new SqlCommand("sp_insertar", conexiones);
                comandos.CommandType = CommandType.StoredProcedure;
                comandos.Parameters.Add("@NombreM", SqlDbType.VarChar).Value = obj.NombreM;
                comandos.Parameters.Add("@EdadM", SqlDbType.Int).Value = obj.EdadM;
                conexiones.Open();
                Respuesta = comandos.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Ingresar el registro del maestro Correctamente. ";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;

            }
            finally
            {
                if (conexiones.State == ConnectionState.Open)
                {

                    conexiones.Close();
                }
            }
            return Respuesta;
        }

        public string AgregarNotaAlumno(EntidadAlumno obj)
        {
            string Respuesta = " ";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion = Conexiones.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("up_AgregarNotaAlumnos", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@NombreEs", SqlDbType.VarChar).Value = obj.NombreE;
                comando.Parameters.Add("@EdadEs", SqlDbType.Int).Value = obj.EdadE;
                comando.Parameters.Add("@NotaFinal", SqlDbType.Decimal).Value = obj.NotaF;
                comando.Parameters.Add("@Materia", SqlDbType.VarChar).Value = obj.Materia;
                conexion.Open();
                Respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Ingresar el registro Correctamente. ";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {

                    conexion.Close();
                }
            }
            return Respuesta;
        }

        public DataTable Mostrars()
        {
            SqlDataReader resultados;

            DataTable tablas = new DataTable();
            SqlConnection conexiones = new SqlConnection();

            try
            {
                conexiones = Conexiones.crearInstancia().crearConexion();
                SqlCommand comandos = new SqlCommand("sp_mostrars", conexiones);
                comandos.CommandType = CommandType.StoredProcedure;
                conexiones.Open();
                resultados = comandos.ExecuteReader();
                tablas.Load(resultados);
                return tablas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexiones.State == ConnectionState.Open)
                {
                    conexiones.Close();
                }
            }
        }
        public DataTable Mostrar() 
        {
            SqlDataReader resultado;

            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();

            try 
            {
                conexion = Conexiones.crearInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("sp_mostrar", conexion);               
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
