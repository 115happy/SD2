using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using static VetTrainer.Views.Strings.Global;
using MySql.Data.MySqlClient;
using System.IO;
using static VetTrainer.Views.Strings.BackupAndRecovery;

namespace VetTrainer.Controllers.Apis
{
    public class BackupAndRecoveryController : ApiController
    {
        string dumpFileLocation = BackupFileDirectory + BackupFileName;
        [HttpPost]
        [Route("api/Backup")]
        public IHttpActionResult PostBackup()
        {
            string msg = string.Empty;
            //string returnViewName = ViewNameBound;
            try
            {
                //if (!System.IO.Directory.Exists(Server.MapPath(BackupFileDirectory)))
                //System.IO.Directory.CreateDirectory(Server.MapPath(BackupFileDirectory));
                if (!System.IO.Directory.Exists(BackupFileDirectory))
                    System.IO.Directory.CreateDirectory(BackupFileDirectory);
                BackupMySql();
                msg = BackupSuccess;
                var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                return Ok(str);
            }
            catch (IOException ex)
            {
                var s = ex.Message;
                msg = Processing;
                var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                return Ok(str);
            }
            catch (MySqlException ex)
            {
                var s = ex.Message;
                msg = BackupError;
                var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                return Ok(str);
            }
        }

        [HttpPost]
        [Route("api/Recover")]
        public IHttpActionResult PostRecover()
        {
            string msg = string.Empty;
            //string returnViewName = ViewNameBound;

            //if (!System.IO.File.Exists(Server.MapPath(dumpFileLocation)))
            if (!System.IO.File.Exists(dumpFileLocation))
            {
                msg= DumpFileNotFound;
                var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                return Ok(str);
            }
            try
            {
                RecoverMySql();
                msg = RecoverySuccess;
                var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                return Ok(str);
            }
            catch (IOException ex)
            {
                var s = ex.Message;
                msg = Processing;
                var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                return Ok(str);
            }
            catch (MySqlException ex)
            {
                var s = ex.Message;
                msg = RecoveryError;
                var str = "{ \"Message\" : \"" + msg + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                return Ok(str);
            }
        }

        protected void BackupMySql()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;

            // Important Additional Connection Options
            connectionString += ";charset=utf8;convertzerodatetime=true;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup backuper = new MySqlBackup(cmd))
                    {
                        cmd.Connection = connection;
                        connection.Open();
                        //backuper.ExportToFile(Server.MapPath(dumpFileLocation));
                        backuper.ExportToFile(dumpFileLocation);
                        connection.Close();
                    }
                }
            }
        }

        protected void RecoverMySql()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;

            // Important Additional Connection Options
            connectionString += ";charset=utf8;convertzerodatetime=true;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup backuper = new MySqlBackup(cmd))
                    {
                        cmd.Connection = connection;
                        connection.Open();
                        //backuper.ImportFromFile(Server.MapPath(dumpFileLocation));
                        backuper.ImportFromFile(dumpFileLocation);
                        connection.Close();
                    }
                }
            }
        }
    }
}
