using PermissionManagementSystem.Base;
using PermissionManagementSystem.ViewModels;
using PermissionManagementSystem.Views;
using System.Windows;
using System.Windows.Input;

namespace PermissionManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.txtLoginId.Focus();
            this.DataContext = new MainWindowVM();
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
