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
            public const string AppName = "虚拟宠物医院学习软件";
        }

        public static class Login
        {
            public const string FormLoginText = "登录";
            public const string BtnLoginText = "登录";
            public const string LblUsername = "用户名：";
            public const string LblPassword = "密码：";
            public const string LblIsToRememberMe = "记住我";
            public const string ErrValidationSummary = "用户名和密码不匹配，请检查！";
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
    }
}