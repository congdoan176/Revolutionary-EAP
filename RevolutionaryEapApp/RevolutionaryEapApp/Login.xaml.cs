using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ResizableFlyout
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            if (this.Email.Text == "")
            {
                this.error_UserName.Text = "Bạn chưa nhập email!";
            }
            else
            {
                this.error_UserName.Visibility = Visibility.Collapsed;
            }
            if (this.Password.Password == "")
            {
                this.error_Password.Text = "Bạn chưa nhập mật khẩu!";
            }
            else
            {
                this.error_Password.Visibility = Visibility.Collapsed;
            }
        }
    }
}
