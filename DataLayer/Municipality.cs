﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity = EntityLayer;

namespace DataLayer
{
    public class Municipality
    {
        /// <summary>
        /// Crea un Municipio en la tabla Municipios.
        /// </summary>
        /// <param name="municipality">Municipio a crear</param>
        /// <param name="message">Mensaje de error</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa.
        /// </returns>
        public bool Create(Entity.Municipality municipality, out string message)
        {
            bool result;

            try
            {
                // Crear Conexión
                using (var connection = new SqlConnection(Connection.value))
                {
                    // Configurar consulta
                    var cmd = new SqlCommand()
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_municipality",
                        Connection = connection
                    };

                    // Establecer Parametros
                    cmd.Parameters.AddWithValue("Operation", "C");

                    cmd.Parameters.AddWithValue("Id", municipality.Id);
                    cmd.Parameters.AddWithValue("DepartmentId", municipality.Department.Id);
                    cmd.Parameters.AddWithValue("Name", municipality.Name);
                    cmd.Parameters.AddWithValue("Active", municipality.Active);

                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;


                    // Abrir Conexion
                    connection.Open();

                    // Ejecutar consulta
                    cmd.ExecuteNonQuery();

                    // Guardar el resultado y el mensaje
                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    message = Convert.ToString(cmd.Parameters["Message"].Value);
                }
            }
            catch (Exception e)
            {
                result = false;
                message = e.Message;
            }
            return result;
        }

        /// <summary>
        /// Lista todos los Municipios de la tabla Municipality. 
        /// </summary>
        /// <returns>
        /// Una lista de Municipios.
        /// </returns>
        public List<Entity.Municipality> Read()
        {
            var municipalityList = new List<Entity.Municipality>();

            try
            {
                // Crear Conección
                using (var connection = new SqlConnection(Connection.value))
                {
                    // Configurar Consulta
                    var cmd = new SqlCommand()
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_municipality",
                        Connection = connection
                    };

                    // Establecer Parametros
                    cmd.Parameters.AddWithValue("Operation", "R");

                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;

                    // Abrir Conexión
                    connection.Open();

                    // Ejecutar la Consulta
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Leer cada fila de la tabla
                        while (reader.Read())
                        {
                            // Añadir Cada Elemento a La Lista
                            municipalityList.Add(new Entity.Municipality()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Department = new Entity.Department()
                                {
                                    Id = Convert.ToInt32(reader["DepartmentId"]),
                                    Name = ""
                                },
                                Name = Convert.ToString(reader["Name"]),
                                Active = Convert.ToBoolean(reader["Active"])
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return municipalityList;
        }

        /// <summary>
        /// Actualiza el Municipio brindado por parametros
        /// </summary>
        /// <param name="municipality">Municipio a actualizar</param>
        /// <param name="message">Mensaje de error</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa.
        /// </returns>
        public bool Update(Entity.Municipality municipality, out string message)
        {
            bool result;

            try
            {
                // Crear Conección
                using (var connection = new SqlConnection(Connection.value))
                {
                    // Configurar Consulta
                    var cmd = new SqlCommand()
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_municipality",
                        Connection = connection
                    };

                    // Establecer Parametros
                    cmd.Parameters.AddWithValue("Operation", "U");

                    cmd.Parameters.AddWithValue("Id", municipality.Id);
                    cmd.Parameters.AddWithValue("DepartmentId", municipality.Department.Id);
                    cmd.Parameters.AddWithValue("Name", municipality.Name);
                    cmd.Parameters.AddWithValue("Active", municipality.Active);

                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;

                    // Abrir Conexión
                    connection.Open();

                    // Ejecutar Consulta
                    cmd.ExecuteNonQuery();

                    // Guardar Resultados
                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    message = Convert.ToString(cmd.Parameters["Message"].Value);
                }
            }
            catch (Exception e)
            {
                result = false;
                message = e.Message;
            }

            return result;
        }

        /// <summary>
        /// Elimina el Municipio brindado por parametros
        /// </summary>
        /// <param name="municipality">Municipio a eliminar</param>
        /// <param name="message">Mensaje de error</param>
        /// <returns>
        /// Verdadero si la operación fue exitosa.
        /// </returns>
        public bool Delete(Entity.Municipality municipality, out string message)
        {
            bool result;

            try
            {
                // Crear Conección
                using (var connection = new SqlConnection(Connection.value))
                {
                    // Configurar Consulta
                    var cmd = new SqlCommand()
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "sp_municipality",
                        Connection = connection
                    };

                    // Establecer Parametros
                    cmd.Parameters.AddWithValue("Operation", "D");

                    cmd.Parameters.AddWithValue("Id", municipality.Id);
                    cmd.Parameters.AddWithValue("DepartmentId", municipality.Department.Id);
                    cmd.Parameters.AddWithValue("Name", municipality.Name);
                    cmd.Parameters.AddWithValue("Active", municipality.Active);

                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;

                    // Abrir Conexión
                    connection.Open();

                    // Ejecutar Consulta
                    cmd.ExecuteNonQuery();

                    // Guardar Resultados
                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    message = Convert.ToString(cmd.Parameters["Message"].Value);
                }
            }
            catch (Exception e)
            {
                result = false;
                message = e.Message;
            }

            return result;
        }
    }
}
