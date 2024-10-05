using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExploreADODOTNET.Entity;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ExploreADODOTNET.DAL
{
    public class StudentDAL<T> : IGenericDAL<T> where T : Student
    {

        public string conStr = "Server=IRIS\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public  bool Create(T obj)         
        {
            try
            {
                using (var sqlCon = new SqlConnection(conStr))
                {
                    using (var sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandText = "sp_Insert_Student";
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        var param = new SqlParameter("@StudentName", SqlDbType.VarChar);
                        param.Value = obj.StudentName;
                        sqlCmd.Parameters.Add(param);

                        param = new SqlParameter("@GradeName", SqlDbType.VarChar);
                        param.Value = obj.Grade;
                        sqlCmd.Parameters.Add(param);

                        sqlCon.Open();

                        var rowsaffected = sqlCmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            return true;
                        }
                        else return false;

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(T obj)
        {
            try
            {
                using (var sqlCon = new SqlConnection(conStr))
                {
                    using (var sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandText = "sp_Update_Student";
                        sqlCmd.CommandType = CommandType.StoredProcedure;


                        var param = new SqlParameter("@StudentId", SqlDbType.Int);
                        param.Value = obj.StudentId;
                        sqlCmd.Parameters.Add(param);


                        param = new SqlParameter("@StudentName", SqlDbType.VarChar);
                        param.Value = obj.StudentName;
                        sqlCmd.Parameters.Add(param);

                        param = new SqlParameter("@GradeName", SqlDbType.VarChar);
                        param.Value = obj.Grade;
                        sqlCmd.Parameters.Add(param);

                        sqlCon.Open();

                        var rowsaffected = sqlCmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            return true;
                        }
                        else return false;

                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon; 
                    sqlCmd.CommandText = "sp_Delete_Student";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param = new SqlParameter("@StudentId", SqlDbType.VarChar);
                    param.Value = id;
                    sqlCmd.Parameters.Add(param);
                    
                    sqlCon.Open();

                    var rowsaffected = sqlCmd.ExecuteNonQuery();
                    if (rowsaffected > 0)
                    {
                        return true;
                    }
                    else return false;

                }
            }

        }

        public List<T> GetAll()
        {
            List<Student> lstStud = new List<Student>();
          
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_GetAll_Student";
                    sqlCmd.CommandType = CommandType.StoredProcedure;                  

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentId = (int)reader[0];
                        student.StudentName = reader[1].ToString();
                        student.Grade = reader[2].ToString();
                        lstStud.Add(student);
                    }

                    List<T> targetList = new List<T>(lstStud.Cast<T>());

                    // var dt = new DataTable();
                    //dt.Load(reader);
                    // return dt;

                    return targetList;

                    }  
                }
            }
    }
}
