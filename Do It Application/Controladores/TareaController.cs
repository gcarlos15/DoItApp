using DoIt.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Controladores
{
    class TareaController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private Dictionary<string, string> statements;
 
        public TareaController()
        {
            statements = new Dictionary<string, string>
            {
                { "AddStatement", "INSERT INTO Tarea(Titulo, Descripcion, Fecha, CreatedAt, Usuario, Hecho) " +
                "VALUES (@Titulo, @Descripcion, @Fecha, @CreatedAt, @Usuario, @Hecho)" },

                { "UpdateStatement", "UPDATE Tarea SET Titulo = @Titulo, " +
                    "Descripcion = @Descripcion, Fecha = @Fecha, " +
                    "Hecho = @Hecho WHERE Id = @Id" },

                { "DashboardStatement",

                "SELECT t.Id, t.Titulo, t.Descripcion, t.Hecho, " +
                "t.Fecha, t.CreatedAt, p.Usuario " +
                "FROM Tarea t INNER JOIN Persona p ON t.Usuario = p.Usuario"},

                { "DeleteStatement", "DELETE FROM Tarea WHERE Id = @Id"},

                { "GetStatement", "SELECT * FROM Tarea WHERE Usuario = @Usuario" }
            };
        }

        private void ErrorMessage(Exception ex)
        {
            Console.Write("HA OCURRIDO UN PROBLEMA: {0}", ex.Message);
        }

        public DataTable Dashboard()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["DashboardStatement"], connection))
                    {
                        DataTable feedTable = new DataTable();

                        connection.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            feedTable.Load(dataReader);
                            return feedTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            return null;
        }

        public void Add(Tarea tarea, Cuenta cuenta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["AddStatement"], connection))
                    {
                        command.Parameters.AddWithValue("@Titulo", tarea.Titulo);
                        command.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                        command.Parameters.AddWithValue("@Fecha", tarea.Fecha.ToString("yyyy/MM/dd"));                      
                        command.Parameters.AddWithValue("@Hecho", tarea.Hecho);
                        command.Parameters.AddWithValue("@Usuario", cuenta.Usuario);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy/MM/dd"));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void Update(Tarea tarea)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["UpdateStatement"], connection)) {                       
                        command.Parameters.AddWithValue("@Id", tarea.Id);
                        command.Parameters.AddWithValue("@Titulo", tarea.Titulo);
                        command.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                        command.Parameters.AddWithValue("@Fecha", tarea.Fecha.ToString("yyyy/MM/dd"));
                        command.Parameters.AddWithValue("@Hecho", tarea.Hecho);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
            }

            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["DeleteStatement"], connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

        }
    }
}
