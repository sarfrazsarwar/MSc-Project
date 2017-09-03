using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class LogInInfoCalc
    {
        private string StrReviews;
        private DataTable DT = new DataTable("Userinfo");

        /// <summary>
        /// Get reviews of current users  
        /// </summary>
        public string GetReviews()
        {
            return StrReviews;
        }
      /// <summary>
      /// to insert the new user detail in database
      /// </summary>
        public void InsertRecord(List<string> dr)
        {
            {
                string str = "INSERT Into [Data_Analytics].[dbo].[User] ([User_Name] ,[Password],[Email]) VALUES "+
                                                            "('" + dr[0].ToString() + "','" + dr[1].ToString() + "','" + dr[2].ToString() + "')";
                DB_ACCESS.DbAccess.executeQuery(str);
            }
           
        }

        // To check the user exist in Database or not. if exist set user Reviews in StrReviews and return  UserID

        public int  GetUserInfoRecord(string strUserName, string strpass)
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[User] where [User_Name]= '" + strUserName + "'  AND [Password]= '" + strpass + "'";


            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            if (DT.Rows.Count > 0)
            {
                int UserId=0;
                DataRow dr = DT.Rows[0];
                 UserId=int.Parse(dr["User_ID"].ToString());
                 StrReviews = dr["Reviews"].ToString().Trim();
                DT.Clear();
                return UserId;
            }
            else
                return 0;
                
        }

        // Check the new user name already exist in database or not
        public int DuplicateUserInfoRecord(string strUserName)
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[User] where [User_Name]= '" + strUserName + "'  ";

           // AND [Password]= '" + strpass + "'
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            return DT.Rows.Count;
        }
        //Update user Reviews in database
        public DataTable UserReviewsUpdate(string str,int ID)
        {
            DT.Clear();
            string qury = " UPDATE [Data_Analytics].[dbo].[User] SET  [Reviews] ='" + str + "' WHERE [User_ID]='" + ID + "'";
            DB_ACCESS.DbAccess.executeQuery(qury);
            int rcord = DT.Rows.Count;
           
            return DT;
        }
        //Update user password in database
        public DataTable UserpasswordUpdate(string str, int ID)
        {
            DT.Clear();
            string qury = " UPDATE [Data_Analytics].[dbo].[User] SET  [password] ='" + str + "' WHERE [User_ID]='" + ID + "'";

            // AND [Password]= '" + strpass + "
            DB_ACCESS.DbAccess.executeQuery(qury);
            int rcord = DT.Rows.Count;

            return DT;
        }

       
    }
}
