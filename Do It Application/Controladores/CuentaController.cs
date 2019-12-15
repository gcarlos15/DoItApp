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
   
    class CuentaController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private Dictionary<string, string> statements;
      

        public CuentaController()
        {

            statements = new Dictionary<string, string>
            {
                { "AddStatement", "INSERT INTO Cuenta VALUES (@Usuario, @Contrasena)" },

                { "UpdateStatement", "UPDATE Cuenta SET Usuario = @Usuario, Contrasena = @Contrasena WHERE Usuario = @Usuario)" },
                { "GetStatement", "SELECT * FROM Cuenta WHERE Usuario = @Usuario" },
                { "DeleteStatement", "DELETE FROM Cuenta WHERE Usuario = @Usuario" },
                { "UserExistsStatement", "SELECT COUNT(*) FROM Cuenta WHERE Usuario = @Usuario OR Contrasena = @Contrasena" }
            };
        }

        private void ErrorMessage(Exception ex)
        {
            Console.Write("HA OCURRIDO UN PROBLEMA: {0}", ex.Message);
        }

        public Cuenta Get(string usuario)
        {
            Cuenta cuenta = new Cuenta();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["GetStatement"], connection))
                    {
                        
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        connection.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if(dataReader.Read())
                            {
                                cuenta.Usuario = dataReader["Usuario"].ToString();
                                cuenta.Contrasena = dataReader["Contrasena"].ToString();
                            }

                            return cuenta;
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

        public void Add(Cuenta cuenta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["AddStatement"], connection))
                    {
                        
                        command.Parameters.AddWithValue("@Usuario", cuenta.Usuario);
                        command.Parameters.AddWithValue("@Contrasena", cuenta.Contrasena);
                        connection.Open();
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void Update(Cuenta cuenta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["UpdateStatement"], connection))
                    {

                        command.Parameters.AddWithValue("@Usuario", cuenta.Usuario);
                        command.Parameters.AddWithValue("@Contrasena", cuenta.Contrasena);
                        connection.Open();
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    connection.Close();

                }
            }

            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void Delete(string usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["DeleteStatement"], connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        connection.Open();
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

        }

        public bool UserExists(Cuenta cuenta)
        {
            bool feedback = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["UserExistsStatement"], connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", cuenta.Usuario);
                        command.Parameters.AddWithValue("@Contrasena", cuenta.Contrasena);
                        connection.Open();
                        feedback = (int)command.ExecuteScalar() > 0 ? true : false;
                        command.Dispose();
                        
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            return feedback;
        }
    }
}
