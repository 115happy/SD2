using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Views
{
    public static class Strings
    {
        public static class Global
        {
            // public const string BackupFileDirectory = @"~\bin\BackupFiles\";
            public const string AppName = "虚拟宠物医院学习软件";
            public const string ConnectionStringName = "VetAppDBContext";
            public const string ServerDataLocation = @"\\VetAppServer\VetAppData\";

            public const string BackupFileDirectory = ServerDataLocation + @"BackupSql\";
            public const string BackupFileName = @"backup.sql";
            public const string InstrumentPicDirectory = ServerDataLocation + @"pics\instruments\";

        }

        public static class Keys
        {
            public const string LoginErrValidation = "LoginErrValidation";
            public const string AuthUserTempData = "User";
        }

        public static class JsonKeys
        {
            public const string Message = "message";
            public const string Data = "data";
        }

        public static class Home
        {
            public const string Account = "用户管理";
            public const string About = "关于我们";
            public const string SystemManager = "系统管理";
            public const string RolePlay = "职能学习";
            public const string CaseLearning = "病例学习";
            public const string Navigation = "3D导览";
            public const string BtnLogIn = "登录";
            public const string BtnLogOut = "登出";
        }

        public static class Login
        {
            public const string FormLoginText = "登录";
            public const string BtnLoginText = "登录";
            public const string LblUsername = "用户名：";
            public const string LblPassword = "密码：";
            public const string LblIsToRememberMe = "记住我";
            public const string LoginErrValidationValue = "用户名和密码不匹配，请检查！";
            public const string ValidationSummaryErrMsg = "登陆失败.";
        }

        public static class About
        {
            public const string MainMsg = "制作组：115happy.";
            public const string AdditionalInfo = "加盟方式：QQ 764359824。期待与您的合作，我们竭诚为您服务！";

        }

        public static class Account
        {
            public const string MsgInputErr = "参数错误，请联系管理员。";
            public const string MsgExsistingPasswordErr = "请输入不同的密码。";
            public const string MsgDiffPasswordErr = "两次输入密码不一致，请检查！";
            public const string MsgEmptyPasswordErr = "输入密码不能为空，请检查！";
            public const string MsgSuccess = "修改成功！";
            public const string MsgException = "操作失败，请联系管理员。";
            public const string LblUserId = "用户ID：";
            public const string LblUsername = "用户名：";
            public const string LblNewPassword = "新密码：";
            public const string LblConfirmPassword = "确认密码：";
            public const string BtnSubmit = "确认";


        }

        public static class SystemManager
        {
            public const string UserManage = "用户管理";
            public const string BaseFunctionManage = "基本结构和功能管理";
            public const string RoleManage = "角色管理";
            public const string CaseManage = "病例管理";
            public const string BackUpAndRecoverManage = "备份与恢复管理";
            public static readonly string[] Manage = { "UserManage", "BaseFunctionManage", "RoleManage", "CaseManage", "BackUpAndRecoveryManage" };
        }

        public static class BackupAndRecovery
        {
            public const string BackupSuccess = "备份成功！";
            public const string RecoverySuccess = "数据恢复成功！";
            public const string Processing = "正在备份或恢复中，请稍等。";
            public const string DumpFileNotFound = "没有备份文件！";
            public const string BackupError = "备份过程中出现问题，请联系开发者。";
            public const string RecoveryError = "恢复过程中出现问题，请联系开发者。";
            public const string ViewNameBound = "Index";
        }

        public static class FeedbackMessageBox
        {
            public const string Title = "操作信息";
            public const string BtnOK = "好的";
        }
    }
}