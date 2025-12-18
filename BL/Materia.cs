using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Connection.GetConnection();

                    SqlCommand command = new SqlCommand();
                    command.Connection = context;
                    string query = "MateriaAdd";
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    command.Parameters.AddWithValue("@Promedio", materia.Promedio);
                    command.Parameters.AddWithValue("@FechaRegistro", materia.FechaRegistro);
                    command.Parameters.AddWithValue("@Costo", materia.Costo);


                    context.Open(); //abran 

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        //inserto bien
                        result.Correct = true;
                    }
                    else
                    {
                        //insert no se hizo bien
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar";
                    }


                    context.Close();


                }



            }
            catch (Exception ex)
            {
                //error
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static ML.Result Delete(int idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Connection.GetConnection();

                    SqlCommand command = new SqlCommand();
                    command.Connection = context;
                    string insert = "MateriaDelete";
                    command.CommandText = insert;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdMateria", idMateria);

                    context.Open(); //abran 

                    int rowsAffected = command.ExecuteNonQuery();

                    context.Close();

                    if (rowsAffected > 0)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el id";

                    }

                }



            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static ML.Result GetAll()
        {
            //List<ML.Materia> materias = new List<ML.Materia>();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>(); //null => cero

            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Connection.GetConnection();

                    SqlCommand command = new SqlCommand();
                    command.Connection = context;
                    command.CommandText = "MateriaGetAll";
                    command.CommandType = CommandType.StoredProcedure;


                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);



                    if (dataTable.Rows.Count > 0)
                    {


                        //traigo informacion
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ML.Materia registroBD = new ML.Materia();
                            registroBD.IdMateria = Convert.ToInt32(row[0]);
                            registroBD.Nombre = Convert.ToString(row[1]);
                            registroBD.Promedio = Convert.ToDecimal(row[2]);
                            registroBD.FechaRegistro = Convert.ToDateTime(row[3]);
                            registroBD.Costo = Convert.ToDecimal(row[4]);

                            result.Objects.Add(registroBD);
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static ML.Result GetById(int idMateria)
        {
            //List<ML.Materia> materias = new List<ML.Materia>();
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Connection.GetConnection();

                    SqlCommand command = new SqlCommand();
                    command.Connection = context;
                    command.CommandText = "MateriaGetById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdMateria", idMateria);


                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);



                    if (dataTable.Rows.Count > 0)
                    {

                        DataRow row = dataTable.Rows[0];
                        //traigo informacion

                        ML.Materia registroBD = new ML.Materia();
                        registroBD.IdMateria = Convert.ToInt32(row[0]);
                        registroBD.Nombre = Convert.ToString(row[1]);
                        registroBD.Promedio = Convert.ToDecimal(row[2]);
                        registroBD.FechaRegistro = Convert.ToDateTime(row[3]);
                        registroBD.Costo = Convert.ToDecimal(row[4]);

                        result.Object = registroBD;


                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existe ese ID";
                    }


            }
        }



        public static ML.Materia GetById(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            using (SqlConnection context = new SqlConnection())
            {
                context.ConnectionString = DL.Connection.GetConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = context;

                string query = "SELECT IdMateria, Nombre, Promedio, FechaRegistro FROM Materia WHERE IdMateria = @IdMateria";

                command.CommandText = query;

                command.Parameters.AddWithValue("@IdMateria", IdMateria);


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    materia.IdMateria = Convert.ToInt32(row[0]);
                    materia.Nombre = row[1].ToString();
                    materia.Promedio = Convert.ToInt32(row[2]);
                    materia.FechaRegistro = Convert.ToDateTime(row[3]);
                }

            }
            return materia;
        }

    }
}
