using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using PermissionManagementSystem.Models;
using SqlSugar;

namespace PermissionManagementSystem.Base
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("HS_SYS_USER")]
    public partial class HS_SYS_USER : ObservableObject
    {
        public HS_SYS_USER()
        {

        }
        /// <summary>
        /// Desc:编号
        /// Default:newid()
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public virtual int ID { get; set; }

        /// <summary>
        /// Desc:登录名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string LoginName { get; set; }

        /// <summary>
        /// Desc:真实姓名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Password { get; set; }

        /// <summary>
        /// Desc:邮箱
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Email { get; set; }

        /// <summary>
        /// Desc:手机号码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Mobile { get; set; }

        /// <summary>
        /// Desc:所属部门
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeptID { get; set; }

        /// <summary>
        /// Desc:部门名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeptName { get; set; }

        /// <summary>
        /// Desc:职位名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PosName { get; set; }

        /// <summary>
        /// Desc:角色
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Role { get; set; }

        /// <summary>
        /// Desc:权限等级
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AuthorityLevel { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:DateTime.Now
        /// Nullable:True
        /// </summary>           
        public DateTime UpdateDateTime { get; set; }

        /// <summary>
        /// Desc:插入时间
        /// Default:DateTime.Now
        /// Nullable:True
        /// </summary>           
        public DateTime InsertDateTime { get; set; }
    }
}
