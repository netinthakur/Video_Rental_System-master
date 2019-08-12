﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace Video_Rental_System
{
    //login class
    class User_Login
    {
       SqlConnection Sqlconn = new SqlConnection(@"Data Source=DHILLON\SQLEXPRESS;Initial Catalog=DbLogin;Integrated Security=True");
       SqlCommand Sqlcmd = new SqlCommand();
       SqlDataReader SqlReader;
       string Sqlstr;

        //User_Log_method() is accepting userid and password as a parameter and validating that input user ID and password is correct or not.
        public bool User_Log_method(int userid, string password)
        {
         
            try
            {
                Sqlcmd.Connection = Sqlconn;
                Sqlstr = "Select userid, password from Register where userid =  @UserName  and password =  @Password ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@UserName", userid), new SqlParameter("@Password", password) };
                Sqlcmd.Parameters.Add(parameterArray[0]);
                Sqlcmd.Parameters.Add(parameterArray[1]);
                Sqlcmd.CommandText = Sqlstr;
                Sqlconn.Open();
                SqlReader = Sqlcmd.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
                return false;
            }
            finally
            {
                if (SqlReader != null)
                {
                    SqlReader.Close();
                }
                if (Sqlconn != null)
                {
                    Sqlconn.Close();
                }
            }
            
        }

    }
}
