using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using static VetTrainer.Views.Strings.Global;
using MySql.Data.MySqlClient;
using System.IO;
using static VetTrainer.Views.Strings.BackupAndRecovery;

namespace VetTrainer.Controllers
{
    [AllowAnonymous]
    public class BackUpAndRecoveryManageController : Controller
    {
        string dumpFileLocation = BackupFileDirectory + BackupFileName;

        // GET: BackUpAndRecovery
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostBackup()
        {
            string returnViewName = ViewNameBound;
            try
            {
                //if (!System.IO.Directory.Exists(Server.MapPath(BackupFileDirectory)))
                //System.IO.Directory.CreateDirectory(Server.MapPath(BackupFileDirectory));
                if (!System.IO.Directory.Exists(BackupFileDirectory))
                    System.IO.Directory.CreateDirectory(BackupFileDirectory);
                BackupMySql();
                ViewBag.Message = BackupSuccess;
                return View(returnViewName);
            }
            catch (IOException ex)
            {
                var s = ex.Message;
                ViewBag.Message = Processing;
                return View(returnViewName);
            }
            catch (MySqlException ex)
            {
                var s = ex.Message;
                ViewBag.Message = BackupError;
                return View(returnViewName);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostRecover()
        {
            string returnViewName = ViewNameBound;

            //if (!System.IO.File.Exists(Server.MapPath(dumpFileLocation)))
            if (!System.IO.File.Exists(dumpFileLocation))
            {
                ViewBag.Message = DumpFileNotFound;
                return View(returnViewName);
            }
            try
            {
                RecoverMySql();
                ViewBag.Message = RecoverySuccess;
                return View(returnViewName);
            }
            catch (IOException ex)
            {
                var s = ex.Message;
                ViewBag.Message = Processing;
                return View(returnViewName);
            }
            catch (MySqlException ex)
            {
                var s = ex.Message;
                ViewBag.Message = RecoveryError;
                return View(returnViewName);
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

        //protected void BackupMySql_v1_5()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        //    connectionString += ";charset=utf8;convertzerodatetime=true;";
        //    MySqlBackup backuper = new MySqlBackup(connectionString);
        //    try
        //    {
        //        backuper.ExportInfo.FileName = dumpFileLocation;
        //        backuper.ExportInfo.AsynchronousMode = false;
        //        backuper.Export();
        //    }
        //    catch (Exception) { throw; }
        //}

        //protected void RecoverMySql_v1_5()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        //    MySqlBackup backuper = new MySqlBackup(connectionString);
        //    try
        //    {
        //        backuper.ImportInfo.FileName = dumpFileLocation;
        //        backuper.ImportInfo.AsynchronousMode = false;
        //        backuper.Import();
        //    }
        //    catch (Exception) { throw; }
        //}
    }
}