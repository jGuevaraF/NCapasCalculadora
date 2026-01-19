using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
                    command.Parameters.AddWithValue("@UserName", materia.UserName);
                    //command.Parameters.AddWithValue("@IdSemestre", materia.IdSemestre);


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
        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection())
                {
                    context.ConnectionString = DL.Connection.GetConnection();

                    SqlCommand command = new SqlCommand();
                    command.Connection = context;

                    string query = "SELECT IdMateria, Nombre, Promedio, FechaRegistro, Costo, UserName, IdSemestre FROM Materia WHERE IdMateria = @IdMateria";

                    command.CommandText = query;

                    command.Parameters.AddWithValue("@IdMateria", IdMateria);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = Convert.ToInt32(row[0]);
                        materia.Nombre = row[1].ToString();
                        materia.Promedio = Convert.ToInt32(row[2]);
                        materia.FechaRegistro = Convert.ToDateTime(row[3]);
                        materia.Costo = Convert.ToDecimal(row[4]);
                        materia.UserName = row[5].ToString();




                        //if (row[6] == DBNull.Value)
                        //{
                        //    materia.IdSemestre = 0;
                        //}
                        //else
                        //{
                        //    materia.IdSemestre = Convert.ToInt32(row[6]);
                        //}


                        result.Object = materia;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro la materia";
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

        public static ML.Result vwGetAll()
        {

        }
        public static ML.Result GetAllSPEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (DL_EF.JGuevaraDiciembreEntities context = new DL_EF.JGuevaraDiciembreEntities())
                {
                    var listaMaterias = context.MateriaGetAll(materia.Nombre, materia.Semestre.IdSemestre).ToList();

                    if (listaMaterias.Count > 0)
                    {
                        foreach (var materiaDB in listaMaterias)
                        {
                            ML.Materia materiaObj = new ML.Materia();

                            materiaObj.IdMateria = materiaDB.IdMateria;
                            materiaObj.Nombre = materiaDB.MateriaNombre;
                            materiaObj.Costo = materiaDB.Costo;
                            materiaObj.FechaRegistro = materiaDB.FechaRegistro.Value;
                            materiaObj.UserName = materiaDB.UserName;
                            materiaObj.Promedio = materiaDB.Promedio.Value;
                            materiaObj.Imagen = materiaDB.Imagen;

                            materiaObj.Semestre = new ML.Semestre();
                            materiaObj.Semestre.Nombre = materiaDB.SemestreNombre;

                            // ML.Semestre
                            result.Objects.Add(materiaObj);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron Materias";
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
        public static ML.Result AddSPEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JGuevaraDiciembreEntities context = new DL_EF.JGuevaraDiciembreEntities())
                {
                    var filasAfectadas = context.MateriaAdd(materia.Nombre, materia.Promedio, materia.FechaRegistro, materia.Costo, materia.UserName, materia.Semestre.IdSemestre, materia.Imagen, materia.Grupo.Nombre, materia.Grupo.Plantel.IdPlantel);

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar.";
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

        public static ML.Result UpdateSPEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JGuevaraDiciembreEntities context = new DL_EF.JGuevaraDiciembreEntities())
                {
                    var filasAfectadas = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Promedio, materia.FechaRegistro, materia.Costo, materia.UserName, materia.Semestre.IdSemestre, materia.Imagen,materia.Grupo.IdGrupo,  materia.Grupo.Nombre, materia.Grupo.Plantel.IdPlantel);

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar.";
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
        public static ML.Result GetByIdSPEF(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JGuevaraDiciembreEntities context = new DL_EF.JGuevaraDiciembreEntities())
                {
                    var query = context.MateriaGetById(IdMateria).SingleOrDefault();

                    if(query != null)
                    {                       
                        // Si encontro el registro
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.MateriaNombre;
                        materia.Costo = query.Costo;
                        materia.Promedio = query.Promedio.Value;
                        materia.FechaRegistro = query.FechaRegistro.Value;
                        materia.Imagen = query.Imagen;

                        materia.Semestre = new ML.Semestre();
                        materia.Semestre.IdSemestre = query.IdSemestre.Value;

                        materia.Grupo = new ML.Grupo();
                        materia.Grupo.IdGrupo = query.IdGrupo.Value;
                        materia.Grupo.Nombre = query.GrupoNombre;

                        materia.Grupo.Plantel = new ML.Plantel();
                        materia.Grupo.Plantel.IdPlantel = query.IdPlantel.Value;
                     
                        result.Object = materia;
                        result.Correct = true;
                    }
                    else
                    {
                        // No lo encontro
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al usuario";
                    }
                      
                }
            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}
