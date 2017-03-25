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
        string dumpFileLocation = BackupFile;

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
            connectionString += ";charset=utf8;convertzerodatetime=true;";
            MySqlBackup backuper = new MySqlBackup(connectionString);
            try
            {
                backuper.ExportInfo.FileName = dumpFileLocation;
                backuper.ExportInfo.AsynchronousMode = false;
                backuper.Export();
            }
            catch (Exception) { throw; }
        }

        protected void RecoverMySql()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            MySqlBackup backuper = new MySqlBackup(connectionString);
            try
            {
                backuper.ImportInfo.FileName = dumpFileLocation;
                backuper.ImportInfo.AsynchronousMode = false;
                backuper.Import();
            }
            catch (Exception) { throw; }
        }
    }
}