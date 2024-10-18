using ExploreADODOTNET.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreADODOTNET.DAL
{
   public class SubjectDAL<T> : IGenericDAL<T> where T : Subject
    {
        public string conStr = "Server=IRIS\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public bool Create(T obj)
        {
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_Insert_Subject";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param1 = new SqlParameter("@SName", SqlDbType.VarChar);
                    param1.Value = obj.Name;
                    sqlCmd.Parameters.Add(param1);

                    var param2 = new SqlParameter("@StudentId", SqlDbType.Int);
                    param2.Value = Globals.StudentId; 
                    sqlCmd.Parameters.Add(param2);

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
            return true;
        }

        public bool DeleteById(int id)
        {
            return true;
        }

        public List<T> GetAll()
        {
            List<Subject> lstSub = new List<Subject>();

            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_GetAll_Subjects";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param = new SqlParameter("@StudentId", SqlDbType.Int);
                    param.Value = Globals.StudentId;
                    sqlCmd.Parameters.Add(param);

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Subject subject = new Subject();
                        subject.SubjectId = (int)reader[0];
                        subject.Name = reader[1].ToString();
                        lstSub.Add(subject);
                    }

                    List<T> targetList = new List<T>(lstSub.Cast<T>());
                    return targetList;

                }
            }
        }

    }
}
