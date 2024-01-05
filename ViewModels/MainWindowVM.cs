using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using PermissionManagementSystem.Base;
using PermissionManagementSystem.Models;
using PermissionManagementSystem.Views;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace PermissionManagementSystem.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        public MainWindowVM()
        {
            LoginCommand = new RelayCommand<Window>(ExecuteLogin , CanExecuteLogin);
            CloseWindowCommand = new RelayCommand<Window>(ExecuteCloseWindow, CanExecuteCloseWindow);
        }
        public Users LoginUser { get; set; } = new Users(new HS_SYS_USER());
        public RelayCommand<Window> LoginCommand { get; private set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));

            }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));

            }
        }
        /// <summary>
        /// 用户登录逻辑
        /// </summary>
        private void ExecuteLogin(Window window)
        {
            ErrorMessage = " ";
            if (string.IsNullOrEmpty(LoginUser.LoginName))
            {
                ErrorMessage = "用户名不能为空！";
                return;
            }
            if (string.IsNullOrEmpty(LoginUser.Password))
            {
                ErrorMessage = "密码不能为空！";
                return;
            }
            SqlHelper sqlHelper = new SqlHelper();
            List<HS_SYS_USER> dbUsersList = SqlHelper.GetUserForLogin(LoginUser.LoginName, LoginUser.Password);
            if (dbUsersList.Count == 0)
            {
                ErrorMessage = "用户名或密码错误，请重新登录！"; 
            }
            else
            {
                foreach (var users in dbUsersList)
                {
                    string name = users.Name;
                    string password = users.Password;
                    if (name != null && password != null)
                    {
                        GobalValues.UserName = users.Name;
                        GobalValues.Role = users.Role;
                        MessageBox.Show("登录成功");
                        var setWindow = new SetWindow();
                        setWindow.Show();
                        window.Close();
                    }
                }
            }
        }
        private bool CanExecuteLogin(Window window)
        {
            return true;
        }
        private void ExecuteCloseWindow(Window window)
        {
            window.Close();
        }
        private bool CanExecuteCloseWindow(Window window)
        {
            return true;
        }
    }
}

