using CommunityToolkit.Mvvm.ComponentModel;
using PermissionManagementSystem.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionManagementSystem.Models
{
    public  class SetModel : ObservableObject
    {
        private string _textBySearchName;
        public new string TextBySearchName
        {
            get => _textBySearchName;
            set => SetProperty(ref _textBySearchName, value);
        }
        private bool _isAdmin;
        public new bool IsAdmin
        {
            get => _isAdmin;
            set => SetProperty(ref _isAdmin, value);
        }
        private Users _selectedItem;
        public new Users SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
    }
}
