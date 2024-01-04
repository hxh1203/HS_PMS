
using PermissionManagementSystem;
using PermissionManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PermissionManagementSystem.Views
{
    /// <summary>
    /// AddUsers.xaml 的交互逻辑
    /// </summary>
    public partial class AddUsers : Window
    {
        public AddUsers()
        {

            InitializeComponent();
            this.DataContext = new SetWindowVM();
        }
        
        #region 窗口拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Point postion = e.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (postion.X >= 0 && postion.Y < this.ActualWidth && postion.Y >= 0 && postion.Y < this.ActualHeight)
                {
                    this.DragMove();
                }
            }

        }


        #endregion
    }

}
