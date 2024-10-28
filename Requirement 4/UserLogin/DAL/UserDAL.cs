using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin.Entity;
using System.Data.SqlClient;

namespace UserLogin.DAL
{
    public class UserDAL
    {
        public string conStr = "Server=IRIS\\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public string ValidateUser(Users user)
        {
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_Validate_User";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param1 = new SqlParameter("@UserName", SqlDbType.VarChar);
                    param1.Value = user.UserName;
                    sqlCmd.Parameters.Add(param1);
                    var param2 = new SqlParameter("@UserPass", SqlDbType.VarChar);
                    param2.Value = user.Password;
                    sqlCmd.Parameters.Add(param2);
                    var param3 = new SqlParameter("@Email", SqlDbType.VarChar);
                    param3.Value = user.Email;
                    sqlCmd.Parameters.Add(param3);

                    sqlCon.Open();

                    var rowsaffected = sqlCmd.ExecuteScalar();
                  
                      return rowsaffected.ToString();
                  

                }
            }
           
        }
        public bool Create(Users user)
        {
            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_Insert_Users";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param1 = new SqlParameter("@UserName", SqlDbType.VarChar);
                    param1.Value = user.UserName;
                    sqlCmd.Parameters.Add(param1);
                    var param2 = new SqlParameter("@UserPass", SqlDbType.VarChar);
                    param2.Value = user.Password;
                    sqlCmd.Parameters.Add(param2);
                    var param3 = new SqlParameter("@Email", SqlDbType.VarChar);
                    param3.Value = user.Email;
                    sqlCmd.Parameters.Add(param3);

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
                    sqlCmd.CommandText = "sp_Delete_Users";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var param = new SqlParameter("@UserId", SqlDbType.Int);
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

        public List<Users> GetAll()
        {
            List<Users> lstUser = new List<Users>();

            using (var sqlCon = new SqlConnection(conStr))
            {
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.CommandText = "sp_GetAll_Users";
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCon.Open();

                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Users user = new Users();
                        user.UserId = (int)reader["UserId"];
                        user.UserName = reader["UserName"].ToString();
                        user.Email = reader["Email"].ToString();
                        lstUser.Add(user);
                    }                   
                    return lstUser;

                }
            }
        }
    }
}
