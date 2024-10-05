using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExploreADODOTNET.Entity;
using System.Reflection.Metadata.Ecma335;

namespace ExploreADODOTNET.DAL
{
    public class GradeDAL<T> : IGenericDAL<T> where T : Grade
    {
        public string  conStr = "Server=IRIS\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public  bool Create(T obj)         
        {
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_Insert_Grade";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param = new SqlParameter("@GradeName", SqlDbType.VarChar);
                    param.Value = obj.GradeName;
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

        public bool Update(T obj)
        {
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_Update_Grade";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param = new SqlParameter("@GradeName", SqlDbType.VarChar);
                    param.Value = obj.GradeName;
                    sqlCmd.Parameters.Add(param);

                    param = new SqlParameter("@GradeId", SqlDbType.Int);
                    param.Value = obj.GradeId;
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

        public bool DeleteById(int id)
        {
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_Delete_Grade";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param = new SqlParameter("@GradeId", SqlDbType.Int);
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

        public DataTable GetAll()
        {
            List<T> lstT = new List<T>();

            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "select * from Grade";
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;

                }
            }
        }

    }
}
