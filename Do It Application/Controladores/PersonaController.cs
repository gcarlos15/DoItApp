using DoIt.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data.Common;

namespace DoIt.Controladores
{
    class PersonaController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private Dictionary<string, string> statements;

        public PersonaController () {
            statements = new Dictionary<string, string>
            {
                { "AddStatement", "INSERT INTO Persona VALUES (@Usuario, @Nombre, @Apellido, " +
                            "@Genero, @Edad)" },
                { "UpdateStatement", "UPDATE Persona SET Nombre = @Nombre, " +
                    "Apellido = @Apellido, Genero = @Genero, Edad = @Edad WHERE Usuario = @Usuario" },
                { "GetStatement", "SELECT Nombre, Apellido, Genero, Edad FROM Persona WHERE Usuario = @Usuario" }
            };
        }

        private void ErrorMessage(Exception ex)
        {
            Console.Write("HA OCURRIDO UN PROBLEMA: {0}", ex.Message);
        }

        public Persona Get(string usuario)
        {

            try {
                Persona persona = new Persona();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand(statements["GetStatement"], connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        connection.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            if (dataReader.Read())
                            {
                                persona.Nombre = dataReader.GetString(0);
                                persona.Apellido = dataReader.GetString(1);
                                persona.Genero = dataReader.GetBoolean(2) ? 1 : 0;
                                persona.Edad = dataReader.GetInt32(3);
                            }

                            return persona;

                        }
                    }

                }
            } catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            return null;
        }
        public void Add(Persona persona, string usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(statements["AddStatement"], connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                        command.Parameters.AddWithValue("@Genero", persona.Genero);
                        command.Parameters.AddWithValue("@Edad", persona.Edad);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void Update(Persona persona, string usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statements["UpdateStatement"], connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                        command.Parameters.AddWithValue("@Genero", persona.Genero);
                        command.Parameters.AddWithValue("@Edad", persona.Edad);
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



   