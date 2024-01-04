using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
using PermissionManagementSystem.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionManagementSystem.Models
{
    public class Users : HS_SYS_USER
    {
        public Users()
        {
        }
        public HS_SYS_USER ToHS_SYS_USER()
        {
            HS_SYS_USER hsSysUser = new HS_SYS_USER()
            {
                ID = this.ID,
                LoginName = this.LoginName,
                Name = this.Name,
                Password = this.Password,
                Email = this.Email,
                Mobile = this.Mobile,
                DeptID = this.DeptID,
                DeptName = this.DeptName,
                PosName = this.PosName,
                Role = this.Role,
                AuthorityLevel = this.AuthorityLevel,
                UpdateDateTime = this.UpdateDateTime,
                InsertDateTime = this.InsertDateTime,
            };
            return hsSysUser;
        }

        public Users(HS_SYS_USER user)
        {
            this.ID = user.ID;
            this.LoginName = user.LoginName;
            this.Name = user.Name;
            this.Password = user.Password;
            this.Email = user.Email;
            this.Mobile = user.Mobile;
            this.DeptID = user.DeptID;
            this.DeptName = user.DeptName;
            this.PosName = user.PosName;
            this.Role = user.Role;
            this.AuthorityLevel = user.AuthorityLevel;
            this.UpdateDateTime = user.UpdateDateTime;
            this.InsertDateTime = user.InsertDateTime;
        }
        private int id;
        public new int ID
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        private string loginName;
        public new string LoginName
        {
            get => loginName;
            set => SetProperty(ref loginName, value);
        }
        private string name;
        public new string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string password;
        public new string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        private string email;
        public new string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        private string mobile;
        public new string Mobile
        {
            get => mobile;
            set => SetProperty(ref mobile, value);
        }
        private string deptID;
        public new string DeptID
        {
            get => deptID;
            set => SetProperty(ref deptID, value);
        }
        private string deptName;
        public new string DeptName
        {
            get => deptName;
            set => SetProperty(ref deptName, value);
        }
        private string posName;
        public new string PosName
        {
            get => posName;
            set => SetProperty(ref posName, value);
        }
        private string role;
        public new string Role
        {
            get => role;
            set => SetProperty(ref role, value); 
        }
        private string authorityLevel;
        public new string AuthorityLevel
        {
            get => authorityLevel;
            set => SetProperty(ref authorityLevel, value);
        }
        private DateTime updateDateTime;
        public new DateTime UpdateDateTime
        {
            get => updateDateTime;
            set => SetProperty(ref updateDateTime, value);
        }
        private DateTime insertDateTime;
        public new DateTime InsertDateTime
        {
            get => insertDateTime;
            set => SetProperty(ref insertDateTime, value);
        }
    }
}
