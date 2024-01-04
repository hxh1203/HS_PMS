using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PermissionManagementSystem.Models;
using PermissionManagementSystem.Views;
using SqlSugar;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Windows.Input;
using System;
using PermissionManagementSystem.Base;
using System.Net.WebSockets;

namespace PermissionManagementSystem.ViewModels
{
    public class SetWindowVM : ObservableRecipient
    {
        public SetWindowVM()
        {
            InitUsersList();
            AddUsersCommand = new RelayCommand<Window>(ExecuteAddUsers, CanExecuteAddUsers);
            SelectByNameCommand = new RelayCommand(SelectByName);
            RefreshCommand = new RelayCommand(Refresh);
            CloseWindowCommand = new RelayCommand<Window>(ExecuteCloseWindow, CanExecuteCloseWindow);
            ShowAddWindowCommand = new RelayCommand<Window>(ExecuteOpenWindow, CanExecuteOpenWindow);
            DeleteSelectedRowCommand = new RelayCommand(DeleteSelectedRow, CanDeleteSelectedRow);
            UpdateSelectedRowCommand = new RelayCommand(UpdateSelectedRow, CanUpdateSelectedRow);
            RefreshLogCommand = new RelayCommand(RefreshLog);
            ShowUserInfoCommand = new RelayCommand(ShowUserInfo);
        }
        private ObservableCollection<Users> _usersList;
        public ObservableCollection<Users> UsersList { get => _usersList; set => SetProperty(ref _usersList, value); }
        private List<OPERATION_LOG> _logList;
        public List<OPERATION_LOG> LogList { get => _logList; set => SetProperty(ref _logList, value); }
        public HS_SYS_USER NewUser { get; set; } = new HS_SYS_USER();
        public Users UserInfo { get; set; } = new Users();
        public Users UserSelected { get; set; } = new Users();
        public SetModel SetModel { get; set; } = new SetModel();
        public OPERATION_LOG Log { get; set; } = new OPERATION_LOG();
        public RelayCommand<Window> CloseWindowCommand { get; private set; }
        public RelayCommand<Window> AddUsersCommand { get; set; }
        public RelayCommand<Window> ShowAddWindowCommand { get; set; }
        public RelayCommand SelectByNameCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand DeleteSelectedRowCommand { get; set; }
        public RelayCommand UpdateSelectedRowCommand { get; set; }
        public RelayCommand RefreshLogCommand { get; set; }
        public RelayCommand ShowUserInfoCommand { get; set; }


        /// <summary>
        /// 初始化用户列表
        /// </summary>
        private void InitUsersList()
        {
            UserInfo.Name = GobalValues.UserName;
            UserInfo.Role = GobalValues.Role;
            if (UserInfo.Role == "超级管理员" || UserInfo.Role == "管理员")
            {
                SetModel.IsAdmin = true;
            }
            else
            {
                SetModel.IsAdmin = false;
            }
            List<HS_SYS_USER> dbUsersList = SqlHelper.Query();
            LogList = SqlHelper.QueryLog();
            UsersList = new ObservableCollection<Users>(dbUsersList.Select(u => new Users(u)).ToList());
        }

        private void GenerateLog(string operationType, string operationInfo)
        {
            if (UserInfo.Name != null)
            {
                Log.UserName = UserInfo.Name;
                Log.OperationTime = DateTime.Now;
                SqlHelper.InsertLog(Log);
            }

        }

        /// <summary>
        /// 新增用户方法
        /// </summary>
        private void ExecuteAddUsers(Window window)
        {
            List<HS_SYS_USER> dbUsersList = SqlHelper.Query();
            UsersList = new ObservableCollection<Users>(dbUsersList.Select(u => new Users(u)).ToList());
            bool UserisExist = UsersList.Any(user => user.LoginName == NewUser.LoginName);
            NewUser.InsertDateTime = DateTime.Now;
            NewUser.UpdateDateTime = DateTime.Now;
            if (!UserisExist)
            {
                SqlHelper.Insert(NewUser);
            }
            Log.OperationType = "新增用户";
            Log.OperationInfo = "新增了一个";
            Log.OperationInfo += $"{NewUser.Role}";
            Log.OperationInfo += "**";
            Log.OperationInfo += $"{NewUser.Name}";
            Log.OperationInfo += "**。";
            GenerateLog(Log.OperationType, Log.OperationInfo);
            window.Close();
        }
        private bool CanExecuteAddUsers(Window window)
        {
            return true;
        }

        /// <summary>
        /// 通过用户名检索
        /// </summary>
        private void SelectByName()
        {
            List<HS_SYS_USER> dbUsersList = SqlHelper.GetUserByName(SetModel.TextBySearchName);
            UsersList = new ObservableCollection<Users>(dbUsersList.Select(u => new Users(u)).ToList());
        }

        /// <summary>
        ///  刷新界面
        /// </summary>
        private void Refresh()
        {
            List<HS_SYS_USER> dbUsersList = SqlHelper.Query();
            UsersList = new ObservableCollection<Users>(dbUsersList.Select(u => new Users(u)).ToList());

        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="window"></param>
        private void ExecuteCloseWindow(Window window)
        {
            window.Close();
        }
        private bool CanExecuteCloseWindow(Window window)
        {
            return true;
        }
        /// <summary>
        /// 开启新窗口
        /// </summary>
        /// <param name="window"></param>
        private void ExecuteOpenWindow(Window window)
        {
            var addUsersWindow = new AddUsers();
            addUsersWindow.Show();
        }
        private bool CanExecuteOpenWindow(Window window)
        {
            return true;
        }
        /// <summary>
        /// 删除选中行
        /// </summary>
        private void DeleteSelectedRow()
        {
            if (SetModel.SelectedItem != null)
            {
                SqlHelper.DeleteBySelected(SetModel.SelectedItem.ID);
            }
            Log.OperationType = "删除用户";
            Log.OperationInfo = "删除了";
            Log.OperationInfo += $"{SetModel.SelectedItem.Role}";
            Log.OperationInfo += "**";
            Log.OperationInfo += $"{SetModel.SelectedItem.Name}";
            Log.OperationInfo += "**。";
            GenerateLog(Log.OperationType, Log.OperationInfo);
        }
        private bool CanDeleteSelectedRow()
        {
            return true;
        }

        /// <summary>
        /// 更新选中行修改
        /// </summary>
        private void UpdateSelectedRow()
        {
            if (SetModel.SelectedItem != null)
            {
                if (SetModel.SelectedItem is Users usersInstance)
                {
                    HS_SYS_USER hsSysUser = usersInstance.ToHS_SYS_USER();
                    SqlHelper.Update(hsSysUser);
                }
                Log.OperationType = "修改用户";
                Log.OperationInfo = "修改了";
                Log.OperationInfo += $"{SetModel.SelectedItem.Role}";
                Log.OperationInfo += "**";
                Log.OperationInfo += $"{SetModel.SelectedItem.Name}";
                Log.OperationInfo += "**的用户信息。";
                GenerateLog(Log.OperationType, Log.OperationInfo);
            }
        }
        private void RefreshLog()
        {
            LogList = SqlHelper.QueryLog();
        }
        private bool CanUpdateSelectedRow()
        {
            return true;
        }
        private void ShowUserInfo()
        {
            if (SetModel.SelectedItem != null)
            {
                SqlHelper.GetUserBySelected(SetModel.SelectedItem.ID);

            }
            var userInfoWindow = new UserTotalInfo();
            userInfoWindow.Show();
        }


    }

}
