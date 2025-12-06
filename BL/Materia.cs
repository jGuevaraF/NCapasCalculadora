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
        public static void Add()
        {
            SqlConnection context = new SqlConnection();
            context.ConnectionString = DL.Connection.GetConnection();

            SqlCommand command = new SqlCommand();
            command.Connection = context;
            string insert = "INSERT INTO Materia (Nombre, Promedio, FechaRegistro) VALUES ('SqlClient', 8.5, '2025/10/10 12:00:00')";
            command.CommandText = insert;

            context.Open(); //abran 

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                //inserto bien
            }
            else
            {
                //insert no se hizo bien
            }


            context.Close();
        }

        public static bool Delete()
        {
            SqlConnection context = new SqlConnection();
            context.ConnectionString = DL.Connection.GetConnection();

            SqlCommand command = new SqlCommand();
            command.Connection = context;
            string insert = "DELETE FROM Materia WHERE IdMateria = 1";
            command.CommandText = insert;

            context.Open(); //abran 

            int rowsAffected = command.ExecuteNonQuery();

            context.Close();

            if (rowsAffected > 0)
            {

                return true;
            }
            else
            {
                return false;

            }
        }

        public static List<ML.Materia> GetAll()
        {
            List<ML.Materia> materias = new List<ML.Materia>();

            using (SqlConnection context = new SqlConnection())
            {
                context.ConnectionString = DL.Connection.GetConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = context;
                command.CommandText = "SELECT * FROM Materia";

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

                        materias.Add(registroBD);
                    }


                }

                return materias;

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
