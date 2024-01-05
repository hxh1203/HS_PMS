
using Microsoft.EntityFrameworkCore;
using PermissionManagementSystem.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace PermissionManagementSystem.Base
{
    public class SqlHelper 
    {
        private static SqlSugarClient db;
        public  SqlHelper()
        {
            var ConnectionStr = "Data Source=localhost;Initial Catalog=HS.Argus.CloseLoopDataBaseA;User ID=sa;Password=HS123";
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionStr,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
            });
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        public static List<HS_SYS_USER> Query()
        { 
            return db.Queryable<HS_SYS_USER>().ToList();
        }

        /// <summary>
        /// 查询通过名字
        /// </summary>
        public static List<HS_SYS_USER> GetUserByName(string name)
        {
            return db.Queryable<HS_SYS_USER>().Where(c => c.Name == name).ToList();
        }

        /// <summary>
        /// 查询通过用户名和密码
        /// </summary>
        public static List<HS_SYS_USER> GetUserForLogin(string loginName , string password)
        {
            return db.Queryable<HS_SYS_USER>().Where(c => c.LoginName == loginName).Where(d => d.Password == password).ToList();
          
        }

        /// <summary>
        ///  插入新用户
        /// </summary>
        /// <returns></returns>
        public static void Insert(HS_SYS_USER users)
        {
             db.Insertable(users).ExecuteCommand();
        }

        /// <summary>
        ///  更新用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void Update(HS_SYS_USER users)
        {
             db.Updateable(users).ExecuteCommand();
        }

        /// <summary>
        ///  删除选中用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static void DeleteBySelected(int id)
        {
            db.Deleteable<HS_SYS_USER>().Where(c => c.ID == id).ExecuteCommand();
        }
        /// <summary>
        ///  获取选中用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<HS_SYS_USER> GetUserBySelected(int id)
        {
            return db.Queryable<HS_SYS_USER>().Where(c => c.ID == id).ToList();
        }
        /// <summary>
        /// 查询日志信息
        /// </summary>
        /// <returns></returns>
        public static List<OPERATION_LOG> QueryLog()
        {
            return db.Queryable<OPERATION_LOG>().ToList();
        }

        /// <summary>
        ///  插入日志
        /// </summary>
        /// <returns></returns>
        public static void InsertLog(OPERATION_LOG log)
        {
            db.Insertable(log).ExecuteCommand();
        }
    }
}
