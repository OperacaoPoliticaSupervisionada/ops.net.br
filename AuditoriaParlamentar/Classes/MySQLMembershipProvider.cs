using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Collections;
using AuditoriaParlamentar.Classes;
using System.Linq;

/*

-- Please, send me an email (andriniaina@gmail.com) if you have done some improvements or bug corrections to this file

You will have to change MySqlMembershipProvider::encryptionKey to a random hexadecimal value of your choice

CREATE TABLE `users` (
  `PKID` varchar(36) collate latin1_general_ci NOT NULL default '',
  `Username` varchar(255) collate latin1_general_ci NOT NULL default '',
  `ApplicationName` varchar(100) collate latin1_general_ci NOT NULL default '',
  `Email` varchar(100) collate latin1_general_ci NOT NULL default '',
  `Comment` varchar(255) collate latin1_general_ci default NULL,
  `Password` varchar(128) collate latin1_general_ci NOT NULL default '',
  `PasswordQuestion` varchar(255) collate latin1_general_ci default NULL,
  `PasswordAnswer` varchar(255) collate latin1_general_ci default NULL,
  `IsApproved` tinyint(1) default NULL,
  `LastActivityDate` datetime default NULL,
  `LastLoginDate` datetime default NULL,
  `LastPasswordChangedDate` datetime default NULL,
  `CreationDate` datetime default NULL,
  `IsOnLine` tinyint(1) default NULL,
  `IsLockedOut` tinyint(1) default NULL,
  `LastLockedOutDate` datetime default NULL,
  `FailedPasswordAttemptCount` int(11) default NULL,
  `FailedPasswordAttemptWindowStart` datetime default NULL,
  `FailedPasswordAnswerAttemptCount` int(11) default NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime default NULL,
  PRIMARY KEY  (`PKID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci; 


*/


namespace AuditoriaParlamentar
{

    public sealed class MySqlMembershipProvider : MembershipProvider
    {

        //
        // Global connection string, generated password length, generic exception message, event log info.
        //

        private int newPasswordLength = 8;
        private string eventSource = "MySqlMembershipProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string tableName = "Users";
        private string connectionString;

        private const string encryptionKey = "42524153494C5045474153414641444F";

        //
        // If false, exceptions are thrown to the caller. If true,
        // exceptions are written to the event log.
        //

        private bool pWriteExceptionsToEventLog;

        public bool WriteExceptionsToEventLog
        {
            get { return pWriteExceptionsToEventLog; }
            set { pWriteExceptionsToEventLog = value; }
        }


        //
        // System.Configuration.Provider.ProviderBase.Initialize Method
        //

        public override void Initialize(string name, NameValueCollection config)
        {
            //
            // Initialize values from web.config.
            //

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "MySqlMembershipProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample MySql Membership provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            pApplicationName = GetConfigValue(config["applicationName"],
                                            System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
            pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
            pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
            pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
            pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
            pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
            pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
            pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));
            pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            string temp_format = config["passwordFormat"];
            if (temp_format == null)
            {
                temp_format = "Hashed";
            }

            switch (temp_format)
            {
                case "Hashed":
                    pPasswordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    pPasswordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    pPasswordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");
            }

            //
            // Initialize MySqlConnection.
            //

            ConnectionStringSettings ConnectionStringSettings =
              ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            connectionString = ConnectionStringSettings.ConnectionString;


        }


        //
        // A helper function to retrieve config values from the configuration file.
        //

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }


        //
        // System.Web.Security.MembershipProvider properties.
        //


        private string pApplicationName;
        private bool pEnablePasswordReset;
        private bool pEnablePasswordRetrieval;
        private bool pRequiresQuestionAndAnswer;
        private bool pRequiresUniqueEmail;
        private int pMaxInvalidPasswordAttempts;
        private int pPasswordAttemptWindow;
        private MembershipPasswordFormat pPasswordFormat;

        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }

        public override bool EnablePasswordReset
        {
            get { return pEnablePasswordReset; }
        }


        public override bool EnablePasswordRetrieval
        {
            get { return pEnablePasswordRetrieval; }
        }


        public override bool RequiresQuestionAndAnswer
        {
            get { return pRequiresQuestionAndAnswer; }
        }


        public override bool RequiresUniqueEmail
        {
            get { return pRequiresUniqueEmail; }
        }


        public override int MaxInvalidPasswordAttempts
        {
            get { return pMaxInvalidPasswordAttempts; }
        }


        public override int PasswordAttemptWindow
        {
            get { return pPasswordAttemptWindow; }
        }


        public override MembershipPasswordFormat PasswordFormat
        {
            get { return pPasswordFormat; }
        }

        private int pMinRequiredNonAlphanumericCharacters;

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return pMinRequiredNonAlphanumericCharacters; }
        }

        private int pMinRequiredPasswordLength;

        public override int MinRequiredPasswordLength
        {
            get { return pMinRequiredPasswordLength; }
        }

        private string pPasswordStrengthRegularExpression;

        public override string PasswordStrengthRegularExpression
        {
            get { return pPasswordStrengthRegularExpression; }
        }

        //
        // System.Web.Security.MembershipProvider methods.
        //

        //
        // MembershipProvider.ChangePassword
        //

        public override bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            if (!ValidateUser(username, oldPwd))
                return false;


            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPwd, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Change password canceled due to new password validation failure.");


            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("UPDATE `" + tableName + "`" +
                    " SET Password = ?Password, LastPasswordChangedDate = ?LastPasswordChangedDate " +
                    " WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Password", MySqlDbType.VarChar, 255).Value = EncodePassword(newPwd);
            cmd.Parameters.Add("?LastPasswordChangedDate", MySqlDbType.Datetime).Value = DateTime.Now;
            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;


            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ChangePassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }



        //
        // MembershipProvider.ChangePasswordQuestionAndAnswer
        //

        public override bool ChangePasswordQuestionAndAnswer(string username,
                      string password,
                      string newPwdQuestion,
                      string newPwdAnswer)
        {
            if (!ValidateUser(username, password))
                return false;

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("UPDATE `" + tableName + "`" +
                    " SET PasswordQuestion = ?Question, PasswordAnswer = ?Answer" +
                    " WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Question", MySqlDbType.VarChar, 255).Value = newPwdQuestion;
            cmd.Parameters.Add("?Answer", MySqlDbType.VarChar, 255).Value = EncodePassword(newPwdAnswer);
            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;


            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ChangePasswordQuestionAndAnswer");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }



        //
        // MembershipProvider.CreateUser
        //

        public override MembershipUser CreateUser(string username,
                 string password,
                 string email,
                 string passwordQuestion,
                 string passwordAnswer,
                 bool isApproved,
                 object providerUserKey,
                 out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, password, true);

            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }



            if (RequiresUniqueEmail && GetUserNameByEmail(email) != "")
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser u = GetUser(username, false);

            if (u == null)
            {
                DateTime createDate = DateTime.Now;

                if (providerUserKey == null)
                {
                    providerUserKey = Guid.NewGuid();
                }
                else
                {
                    if (!(providerUserKey is Guid))
                    {
                        status = MembershipCreateStatus.InvalidProviderUserKey;
                        return null;
                    }
                }

                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `" + tableName + "`" +
                      " (PKID, Username, Password, Email, PasswordQuestion, " +
                      " PasswordAnswer, IsApproved," +
                      " Comment, CreationDate, LastPasswordChangedDate, LastActivityDate," +
                      " ApplicationName, IsLockedOut, LastLockedOutDate," +
                      " FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, " +
                      " FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)" +
                      " Values(?PKID, ?Username, ?Password, ?Email, ?PasswordQuestion, " +
                      " ?PasswordAnswer, ?IsApproved, ?Comment, ?CreationDate, ?LastPasswordChangedDate, " +
                      " ?LastActivityDate, ?ApplicationName, ?IsLockedOut, ?LastLockedOutDate, " + 
                      " ?FailedPasswordAttemptCount, ?FailedPasswordAttemptWindowStart, " +
                      " ?FailedPasswordAnswerAttemptCount, ?FailedPasswordAnswerAttemptWindowStart)", conn);

                cmd.Parameters.Add("?PKID", MySqlDbType.VarChar).Value = providerUserKey.ToString();
                cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
                cmd.Parameters.Add("?Password", MySqlDbType.VarChar, 255).Value = EncodePassword(password);
                cmd.Parameters.Add("?Email", MySqlDbType.VarChar, 128).Value = email;
                cmd.Parameters.Add("?PasswordQuestion", MySqlDbType.VarChar, 255).Value = passwordQuestion;
                cmd.Parameters.Add("?PasswordAnswer", MySqlDbType.VarChar, 255).Value = passwordAnswer==null?null: EncodePassword(passwordAnswer);
                cmd.Parameters.Add("?IsApproved", MySqlDbType.Bit).Value = isApproved;
                cmd.Parameters.Add("?Comment", MySqlDbType.VarChar, 255).Value = "";
                cmd.Parameters.Add("?CreationDate", MySqlDbType.Datetime).Value = createDate;
                cmd.Parameters.Add("?LastPasswordChangedDate", MySqlDbType.Datetime).Value = createDate;
                cmd.Parameters.Add("?LastActivityDate", MySqlDbType.Datetime).Value = createDate;
                cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;
                cmd.Parameters.Add("?IsLockedOut", MySqlDbType.Bit).Value = 0;	//false
                cmd.Parameters.Add("?LastLockedOutDate", MySqlDbType.Datetime).Value = createDate;
                cmd.Parameters.Add("?FailedPasswordAttemptCount", MySqlDbType.Int32).Value = 0;
                cmd.Parameters.Add("?FailedPasswordAttemptWindowStart", MySqlDbType.Datetime).Value = createDate;
                cmd.Parameters.Add("?FailedPasswordAnswerAttemptCount", MySqlDbType.Int32).Value = 0;
                cmd.Parameters.Add("?FailedPasswordAnswerAttemptWindowStart", MySqlDbType.Datetime).Value = createDate;

                try
                {
                    conn.Open();

                    int recAdded = cmd.ExecuteNonQuery();

                    if (recAdded > 0)
                    {
                        status = MembershipCreateStatus.Success;
                    }
                    else
                    {
                        status = MembershipCreateStatus.UserRejected;
                    }
                }
                catch (MySqlException e)
                {
                    if (WriteExceptionsToEventLog)
                    {
                        WriteToEventLog(e, "CreateUser");
                    }

                    status = MembershipCreateStatus.ProviderError;
                }
                finally
                {
                    conn.Close();
                }


                return GetUser(username, false);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }


            return null;
        }



        //
        // MembershipProvider.DeleteUser
        //

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `" + tableName + "`" +
                    " WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();

                if (deleteAllRelatedData)
                {
                    // Process commands to delete all data for the user in the database.
                }
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "DeleteUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
                return true;

            return false;
        }



        //
        // MembershipProvider.GetAllUsers
        //

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) FROM `" + tableName + "` " +
                                              "WHERE ApplicationName = ?ApplicationName", conn);
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = ApplicationName;

            MembershipUserCollection users = new MembershipUserCollection();

            MySqlDataReader reader = null;
            totalRecords = 0;

            try
            {
                conn.Open();
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar());

                if (totalRecords <= 0) { return users; }

                cmd.CommandText = "SELECT PKID, Username, Email, PasswordQuestion," +
                         " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                         " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate " +
                         " FROM `" + tableName + "` " +
                         " WHERE ApplicationName = ?ApplicationName " +
                         " ORDER BY Username Asc";

                using(reader = cmd.ExecuteReader())
				{
					int counter = 0;
					int startIndex = pageSize * pageIndex;
					int endIndex = startIndex + pageSize - 1;
	
					while (reader.Read())
					{
						if (counter >= startIndex)
						{
							MembershipUser u = GetUserFromReader(reader);
							users.Add(u);
						}
	
						if (counter >= endIndex) { cmd.Cancel(); }
	
						counter++;
					}
					reader.Close();
				}
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetAllUsers");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }

            return users;
        }


        //
        // MembershipProvider.GetNumberOfUsersOnline
        //

        public override int GetNumberOfUsersOnline()
        {

            TimeSpan onlineSpan = new TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0);
            DateTime compareTime = DateTime.Now.Subtract(onlineSpan);

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) FROM `" + tableName + "`" +
                    " WHERE LastActivityDate > ?CompareDate AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?CompareDate", MySqlDbType.Datetime).Value = compareTime;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            int numOnline = 0;

            try
            {
                conn.Open();

                numOnline = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetNumberOfUsersOnline");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            return numOnline;
        }



        //
        // MembershipProvider.GetPassword
        //

        public override string GetPassword(string username, string answer)
        {
            if (!EnablePasswordRetrieval)
            {
                throw new ProviderException("Password Retrieval Not Enabled.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Hashed)
            {
                throw new ProviderException("Cannot retrieve Hashed passwords.");
            }

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Password, PasswordAnswer, IsLockedOut FROM `" + tableName + "`" +
                  " WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            string password = "";
            string passwordAnswer = "";
            MySqlDataReader reader = null;

            try
            {
                conn.Open();

                using(reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
				{
					if (reader.HasRows)
					{
						reader.Read();
	
						if (reader.GetBoolean(2))
							throw new MembershipPasswordException("The supplied user is locked out.");
	
						password = reader.GetString(0);
						passwordAnswer = reader.GetString(1);
					}
					else
					{
						throw new MembershipPasswordException("The supplied user name is not found.");
					}
					reader.Close();
				}
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetPassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }


            if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
            {
                UpdateFailureCount(username, "passwordAnswer");

                throw new MembershipPasswordException("Incorrect password answer.");
            }


            if (PasswordFormat == MembershipPasswordFormat.Encrypted)
            {
                password = UnEncodePassword(password);
            }

            return password;
        }



        //
        // MembershipProvider.GetUser(string, bool)
        //

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT PKID, Username, Email, PasswordQuestion," +
                 " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                 " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate" +
                 " FROM `" + tableName + "` WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            MembershipUser u = null;
            MySqlDataReader reader = null;

            try
            {
                conn.Open();

                using(reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();
						u = GetUserFromReader(reader);
						reader.Close();
						
						if (userIsOnline)
						{
							MySqlCommand updateCmd = new MySqlCommand("UPDATE `" + tableName + "` " +
									  "SET LastActivityDate = ?LastActivityDate " +
									  "WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);
	
							updateCmd.Parameters.Add("?LastActivityDate", MySqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
							updateCmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
							updateCmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;
	
							updateCmd.ExecuteNonQuery();
						}
					}
					reader.Close();
				}
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUser(String, Boolean)");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }

                conn.Close();
            }

            return u;
        }


        //
        // MembershipProvider.GetUser(object, bool)
        //

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT PKID, Username, Email, PasswordQuestion," +
                  " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                  " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate" +
                  " FROM `" + tableName + "` WHERE PKID = ?PKID", conn);

            cmd.Parameters.Add("?PKID", MySqlDbType.VarChar).Value = providerUserKey;

            MembershipUser u = null;
            MySqlDataReader reader = null;

            try
            {
                conn.Open();

                using(reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();
						u = GetUserFromReader(reader);
						
						reader.Close();
						
						if (userIsOnline)
						{
							MySqlCommand updateCmd = new MySqlCommand("UPDATE `" + tableName + "` " +
									  "SET LastActivityDate = ?LastActivityDate " +
									  "WHERE PKID = ?PKID", conn);
	
							updateCmd.Parameters.Add("?LastActivityDate", MySqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
							updateCmd.Parameters.Add("?PKID", MySqlDbType.VarChar).Value = providerUserKey;
	
							updateCmd.ExecuteNonQuery();
						}
					}
					reader.Close();
				}
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUser(Object, Boolean)");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }

                conn.Close();
            }

            return u;
        }


        //
        // GetUserFromReader
        //    A helper function that takes the current row from the MySqlDataReader
        // and hydrates a MembershiUser from the values. Called by the 
        // MembershipUser.GetUser implementation.
        //

        private MembershipUser GetUserFromReader(MySqlDataReader reader)
        {
			object providerUserKey = new Guid(reader.GetValue(0).ToString());
            string username = reader.IsDBNull(1)                   ? "" : reader.GetString(1);
            string email = reader.IsDBNull(2)                      ? "" :reader.GetString(2);
            string passwordQuestion = reader.IsDBNull(3)           ? "" : reader.GetString(3);
            string comment = reader.IsDBNull(4)                    ? "" : reader.GetString(4);
            bool isApproved = reader.IsDBNull(5)                   ? false : reader.GetBoolean(5);
            bool isLockedOut = reader.IsDBNull(6)                  ? false : reader.GetBoolean(6);
            DateTime creationDate = reader.IsDBNull(7)             ? DateTime.Now : reader.GetDateTime(7);
            DateTime lastLoginDate = reader.IsDBNull(8)            ? DateTime.Now : reader.GetDateTime(8);
            DateTime lastActivityDate = reader.IsDBNull(9)         ? DateTime.Now : reader.GetDateTime(9);
            DateTime lastPasswordChangedDate = reader.IsDBNull(10) ? DateTime.Now : reader.GetDateTime(10);
            DateTime lastLockedOutDate = reader.IsDBNull(11)       ? DateTime.Now : reader.GetDateTime(11);

            MembershipUser u = new MembershipUser(this.Name,
                                                  username,
                                                  providerUserKey,
                                                  email,
                                                  passwordQuestion,
                                                  comment,
                                                  isApproved,
                                                  isLockedOut,
                                                  creationDate,
                                                  lastLoginDate,
                                                  lastActivityDate,
                                                  lastPasswordChangedDate,
                                                  lastLockedOutDate);

            return u;
        }


        //
        // MembershipProvider.UnlockUser
        //

        public override bool UnlockUser(string username)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("UPDATE `" + tableName + "` " +
                                              " SET IsLockedOut = 0, LastLockedOutDate = ?LastLockedOutDate " +
                                              " WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?LastLockedOutDate", MySqlDbType.Datetime).Value = DateTime.Now;
            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UnlockUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
                return true;

            return false;
        }


        //
        // MembershipProvider.GetUserNameByEmail
        //

        public override string GetUserNameByEmail(string email)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Username" +
                  " FROM `" + tableName + "` WHERE Email = ?Email AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Email", MySqlDbType.VarChar, 128).Value = email;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            string username = "";

            try
            {
                conn.Open();

                username = (string)cmd.ExecuteScalar();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUserNameByEmail");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (username == null)
                username = "";

            return username;
        }




        //
        // MembershipProvider.ResetPassword
        //

        public override string ResetPassword(string username, string answer)
        {
            if (!EnablePasswordReset)
            {
                throw new NotSupportedException("Password reset is not enabled.");
            }

            if (answer == null && RequiresQuestionAndAnswer)
            {
                UpdateFailureCount(username, "passwordAnswer");

                throw new ProviderException("Password answer required for password reset.");
            }

            string newPassword =
              System.Web.Security.Membership.GeneratePassword(newPasswordLength, MinRequiredNonAlphanumericCharacters);


            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Reset password canceled due to password validation failure.");

            int rowsAffected = 0;
            string passwordAnswer = "";

            using (Banco banco = new Banco())
            {
                banco.AddParameter("Username", username);

                using(MySqlDataReader reader = banco.ExecuteReader("SELECT PasswordAnswer, IsLockedOut FROM " + tableName + " WHERE Username = @Username"))
                {
                    if (reader.HasRows)
					{
						reader.Read();
	
						if (reader.GetBoolean(1))
							throw new MembershipPasswordException("The supplied user is locked out.");

                        try { passwordAnswer = reader.GetString(0); }
                        catch { passwordAnswer = ""; }
					}
					else
					{
						throw new MembershipPasswordException("The supplied user name is not found.");
					}
					
                    reader.Close();
				}
				
                if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
                {
                    UpdateFailureCount(username, "passwordAnswer");

                    throw new MembershipPasswordException("Incorrect password answer.");
                }

                banco.AddParameter("Password", EncodePassword(newPassword));
                banco.AddParameter("LastPasswordChangedDate", DateTime.Now);
                banco.AddParameter("Username", username);
               
                banco.ExecuteNonQuery("UPDATE " + tableName + " SET Password = @Password, LastPasswordChangedDate = @LastPasswordChangedDate WHERE Username = @Username AND IsLockedOut = 0");
                
                rowsAffected = Convert.ToInt32(banco.Rows);
            }

            if (rowsAffected > 0)
            {
                return newPassword;
            }
            else
            {
                throw new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
            }
        }


        //
        // MembershipProvider.UpdateUser
        //

        public override void UpdateUser(MembershipUser user)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("UPDATE `" + tableName + "`" +
                    " SET Email = ?Email, Comment = ?Comment," +
                    " IsApproved = ?IsApproved" +
                    " WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Email", MySqlDbType.VarChar, 128).Value = user.Email;
            cmd.Parameters.Add("?Comment", MySqlDbType.VarChar, 255).Value = user.Comment;
            cmd.Parameters.Add("?IsApproved", MySqlDbType.Bit).Value = user.IsApproved;
            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = user.UserName;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;


            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UpdateUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }
        }


        //
        // MembershipProvider.ValidateUser
        //

        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Password, IsApproved FROM `" + tableName + "`" +
                    " WHERE Username = ?Username AND ApplicationName = ?ApplicationName AND IsLockedOut = 0", conn);

            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            MySqlDataReader reader = null;
            bool isApproved = false;
            string pwd = "";

            try
            {
                conn.Open();

                using(reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
				{
					if (reader.HasRows)
					{
						reader.Read();
						pwd = reader.GetString(0);
						isApproved = reader.GetBoolean(1);
					}
					else
					{
						return false;
					}
					reader.Close();
				}
				
                if (CheckPassword(password, pwd))
                {
                    if (isApproved)
                    {
                        isValid = true;

                        MySqlCommand updateCmd = new MySqlCommand("UPDATE `" + tableName + "` SET LastLoginDate = ?LastLoginDate, LastActivityDate = ?LastActivityDate" +
                                                                " WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

                        updateCmd.Parameters.Add("?LastLoginDate", MySqlDbType.Datetime).Value = DateTime.Now;
                        updateCmd.Parameters.Add("?LastActivityDate", MySqlDbType.Datetime).Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        updateCmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
                        updateCmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    conn.Close();

                    UpdateFailureCount(username, "password");
                }
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ValidateUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }

            return isValid;
        }


        //
        // UpdateFailureCount
        //   A helper method that performs the checks and updates associated with
        // password failure tracking.
        //

        private void UpdateFailureCount(string username, string failureType)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT FailedPasswordAttemptCount, " +
                                              "  FailedPasswordAttemptWindowStart, " +
                                              "  FailedPasswordAnswerAttemptCount, " +
                                              "  FailedPasswordAnswerAttemptWindowStart " +
                                              "  FROM `" + tableName + "` " +
                                              "  WHERE Username = ?Username AND ApplicationName = ?ApplicationName", conn);

            cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            MySqlDataReader reader = null;
            DateTime windowStart = new DateTime();
            int failureCount = 0;

            try
            {
                conn.Open();

                using(reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
				{
					if (reader.HasRows)
					{
						reader.Read();
	
						if (failureType == "password")
						{
							failureCount = reader.GetInt32(0);
							windowStart = reader.GetDateTime(1);
						}
	
						if (failureType == "passwordAnswer")
						{
							failureCount = reader.GetInt32(2);
							windowStart = reader.GetDateTime(3);
						}
					}
					reader.Close();
				}
				
                DateTime windowEnd = windowStart.AddMinutes(PasswordAttemptWindow);

                if (failureCount == 0 || DateTime.Now > windowEnd)
                {
                    // First password failure or outside of PasswordAttemptWindow. 
                    // Start a new password failure count from 1 and a new window starting now.

                    if (failureType == "password")
                        cmd.CommandText = "UPDATE `" + tableName + "` " +
                                          "  SET FailedPasswordAttemptCount = ?Count, " +
                                          "      FailedPasswordAttemptWindowStart = ?WindowStart " +
                                          "  WHERE Username = ?Username AND ApplicationName = ?ApplicationName";

                    if (failureType == "passwordAnswer")
                        cmd.CommandText = "UPDATE `" + tableName + "` " +
                                          "  SET FailedPasswordAnswerAttemptCount = ?Count, " +
                                          "      FailedPasswordAnswerAttemptWindowStart = ?WindowStart " +
                                          "  WHERE Username = ?Username AND ApplicationName = ?ApplicationName";

                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("?Count", MySqlDbType.Int32).Value = 1;
                    cmd.Parameters.Add("?WindowStart", MySqlDbType.Datetime).Value = DateTime.Now;
                    cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
                    cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

                    if (cmd.ExecuteNonQuery() < 0)
                        throw new ProviderException("Unable to update failure count and window start.");
                }
                else
                {
                    if (failureCount++ >= MaxInvalidPasswordAttempts)
                    {
                        // Password attempts have exceeded the failure threshold. Lock out
                        // the user.

                        cmd.CommandText = "UPDATE `" + tableName + "` " +
                                          "  SET IsLockedOut = ?IsLockedOut, LastLockedOutDate = ?LastLockedOutDate " +
                                          "  WHERE Username = ?Username AND ApplicationName = ?ApplicationName";

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("?IsLockedOut", MySqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("?LastLockedOutDate", MySqlDbType.Datetime).Value = DateTime.Now;
                        cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
                        cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

                        if (cmd.ExecuteNonQuery() < 0)
                            throw new ProviderException("Unable to lock out user.");
                    }
                    else
                    {
                        // Password attempts have not exceeded the failure threshold. Update
                        // the failure counts. Leave the window the same.

                        if (failureType == "password")
                            cmd.CommandText = "UPDATE `" + tableName + "` " +
                                              "  SET FailedPasswordAttemptCount = ?Count" +
                                              "  WHERE Username = ?Username AND ApplicationName = ?ApplicationName";

                        if (failureType == "passwordAnswer")
                            cmd.CommandText = "UPDATE `" + tableName + "` " +
                                              "  SET FailedPasswordAnswerAttemptCount = ?Count" +
                                              "  WHERE Username = ?Username AND ApplicationName = ?ApplicationName";

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("?Count", MySqlDbType.Int32).Value = failureCount;
                        cmd.Parameters.Add("?Username", MySqlDbType.VarChar, 255).Value = username;
                        cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

                        if (cmd.ExecuteNonQuery() < 0)
                            throw new ProviderException("Unable to update failure count.");
                    }
                }
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UpdateFailureCount");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }
        }


        //
        // CheckPassword
        //   Compares password values based on the MembershipPasswordFormat.
        //

        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            if (pass1 == pass2)
            {
                return true;
            }

            return false;
        }


        //
        // EncodePassword
        //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        //

        private string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(encryptionKey);
                    encodedPassword =
                      Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return encodedPassword;
        }


        //
        // UnEncodePassword
        //   Decrypts or leaves the password clear based on the PasswordFormat.
        //

        private string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password =
                      Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        //
        // HexToByte
        //   Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        //

        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        //
        // MembershipProvider.FindUsersByName
        //

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) FROM `" + tableName + "` " +
                      "WHERE Username LIKE ?UsernameSearch AND ApplicationName = ?ApplicationName", conn);
            cmd.Parameters.Add("?UsernameSearch", MySqlDbType.VarChar, 255).Value = usernameToMatch;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = pApplicationName;

            MembershipUserCollection users = new MembershipUserCollection();

            MySqlDataReader reader = null;

            try
            {
                conn.Open();
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar());

                if (totalRecords <= 0) { return users; }

                cmd.CommandText = "SELECT PKID, Username, Email, PasswordQuestion," +
                  " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                  " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate " +
                  " FROM `" + tableName + "` " +
                  " WHERE Username LIKE ?UsernameSearch AND ApplicationName = ?ApplicationName " +
                  " ORDER BY Username Asc";

                using(reader = cmd.ExecuteReader())
				{
					int counter = 0;
					int startIndex = pageSize * pageIndex;
					int endIndex = startIndex + pageSize - 1;
	
					while (reader.Read())
					{
						if (counter >= startIndex)
						{
							MembershipUser u = GetUserFromReader(reader);
							users.Add(u);
						}
	
						if (counter >= endIndex) { cmd.Cancel(); }
	
						counter++;
					}
					reader.Close();
				}
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "FindUsersByName");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }

                conn.Close();
            }

            return users;
        }

        //
        // MembershipProvider.FindUsersByEmail
        //

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) FROM `" + tableName + "` " +
                                              "WHERE Email LIKE ?EmailSearch AND ApplicationName = ?ApplicationName", conn);
            cmd.Parameters.Add("?EmailSearch", MySqlDbType.VarChar, 255).Value = emailToMatch;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = ApplicationName;

            MembershipUserCollection users = new MembershipUserCollection();

            MySqlDataReader reader = null;
            totalRecords = 0;

            try
            {
                conn.Open();
                totalRecords = Convert.ToInt32(cmd.ExecuteScalar());

                if (totalRecords <= 0) { return users; }

                cmd.CommandText = "SELECT PKID, Username, Email, PasswordQuestion," +
                         " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                         " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate " +
                         " FROM `" + tableName + "` " +
                         " WHERE Email LIKE ?Username AND ApplicationName = ?ApplicationName " +
                         " ORDER BY Username Asc";

                using(reader = cmd.ExecuteReader())
				{
					int counter = 0;
					int startIndex = pageSize * pageIndex;
					int endIndex = startIndex + pageSize - 1;
	
					while (reader.Read())
					{
						if (counter >= startIndex)
						{
							MembershipUser u = GetUserFromReader(reader);
							users.Add(u);
						}
	
						if (counter >= endIndex) { cmd.Cancel(); }
	
						counter++;
					}
					reader.Close();
				}
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "FindUsersByEmail");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }

                conn.Close();
            }

            return users;
        }

        //
        // WriteToEventLog
        //   A helper function that writes exception detail to the event log. Exceptions
        // are written to the event log as a security measure to avoid private database
        // details from being returned to the browser. If a method does not return a status
        // or boolean indicating the action succeeded or failed, a generic exception is also 
        // thrown by the caller.
        //

        private void WriteToEventLog(Exception e, string action)
        {
            EventLog log = new EventLog();
            log.Source = eventSource;
            log.Log = eventLog;

            string message = "An exception occurred communicating with the data source.\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            log.WriteEntry(message);
        }

        internal String RecuperaSenhaEmail(String userName)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("username", userName);
                Object email = banco.ExecuteScalar("SELECT Email FROM users WHERE username = @username");

                if (email == DBNull.Value || email == null)
                {
                    return "Usuário não encontrado.";
                }
                else
                {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var random = new Random();
                    var chave = new string(
                        Enumerable.Repeat(chars, 30)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());

                    ArrayList destinatario = new ArrayList();
                    destinatario.Add(email);

                    Email envio = new Email();

                    if (envio.Enviar(destinatario, "[O.P.S.] Recuperação de senha", @"<html><body><p>Você solicitou a recuperação de senha no portal da OPS. Caso não tenha feito esta solicitação ignore este e-mail. <a href='http://www.ops.net.br/Account/ResetPassword.aspx?chave=" + chave + @"'>Clique aqui para gerar uma nova senha.</a></p></body></html>") == false)
                    {
                        return "Ocorreu um problema ao tentar recuperar sua senha. Tente novamente.";
                    }
                    else
                    {
                        banco.AddParameter("data", DateTime.Now.AddDays(-5));
                        banco.ExecuteNonQuery("DELETE FROM user_recover WHERE data < @data");

                        banco.AddParameter("chave", chave);
                        banco.AddParameter("username", userName);
                        banco.ExecuteNonQuery("INSERT INTO user_recover (chave, username, data) VALUES (@chave, @username, NOW())");
                    }
                }

                return "";
            }
        }

        internal String RecuperaSenha(String chave)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("chave", chave);
                Object userName = banco.ExecuteScalar("SELECT username FROM user_recover WHERE chave = @chave");

                if (userName == DBNull.Value || userName == null)
                {
                    return "";
                }

                String senha = "";

                try
                {
                    pEnablePasswordReset = true;
                    pPasswordFormat = MembershipPasswordFormat.Hashed;

                    senha = "Nova senha: " + ResetPassword(Convert.ToString(userName), null);

                    banco.AddParameter("username", Convert.ToString(userName));
                    banco.ExecuteScalar("DELETE FROM user_recover WHERE username = @username");

                }
                catch (Exception ex)
                {
                    return "Não foi possível recuperar sua senha";
                }

                return senha;
            }
        }
    }
}