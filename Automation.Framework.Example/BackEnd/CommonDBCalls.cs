using Automation.Framework.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Automation.Framework.Example.BackEnd
{
   public class CommonDBCalls
    {

        /// <summary>
        /// Retrieves a long string which has result of each record. each record values is separated by '|'
        /// </summary>
        /// <param name="SQLCommandLine">request query</param>
        /// <returns>Returns a long string with all row data, separated by '|'</returns>
        public static string SQLGetSeperatedList(string SQLCommandLine)
        {
            string CommaSeperatedUserList = "";
            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                SqlDataReader returnValue = insertcommand.ExecuteReader();

                while (returnValue.Read())
                {
                    CommaSeperatedUserList = CommaSeperatedUserList + returnValue.GetValue(0) + ",";
                }
            }
            return CommaSeperatedUserList;
        }

        /// <summary>
        /// Retrieves a list of all records returned by the query supplied
        /// </summary>
        /// <param name="SQLCommandLine">request query</param>
        /// <returns>Returns a list of all records returned by query and each record 
        /// separated by '|'
        /// </returns>
        public static string SQLGetCompleteRecord(string SQLCommandLine)
        {
            string CommaSeperatedUserList = "";
            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                SqlDataReader returnValue = insertcommand.ExecuteReader();

                while (returnValue.Read())
                {
                    for (int i = 0; i < returnValue.FieldCount; i++)
                    {
                        CommaSeperatedUserList = CommaSeperatedUserList + returnValue.GetValue(i) + ",";
                    }
                }
            }
            return CommaSeperatedUserList;
        }

        /// <summary>
        /// Retrieves a GUID 
        /// </summary>
        /// <param name="SQLCommandLine">Requested query</param>
        /// <returns>Returns GUID returned by query</returns>
        public static string SQLGetSingleResult(string SQLCommandLine, bool KeyInteractionTable = false)
        {
            string singleResult;

            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                try
                {
                    singleResult = insertcommand.ExecuteScalar().ToString();
                }
                catch
                { singleResult = ""; }
            }
            return singleResult;
        }

        /// <summary>
        /// Execute a sql query 
        /// </summary>
        /// <param name="SQLCommandLine">Scalar query</param>
        public static void ExecuteSQLCommand(string SQLCommandLine, bool KeyInteractionTable = false)
        {
            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                insertcommand.ExecuteScalar();
            }
        }
    }
}

