using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RevolutionaryEapApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string API_LOGIN = "";
        public MainPage()
        {
            this.InitializeComponent();
        }

        public object JsonConvert { get; private set; }

        private async void Login_Button(object sender, RoutedEventArgs e)
        {
            Dictionary<String, String> LoginInfor = new Dictionary<string, string>();
            LoginInfor.Add("email", this.Email.Text);
            LoginInfor.Add("password", this.Password.Password);

            // Lay token
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(LoginInfor), System.Text.Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(API_LOGIN, content).Result;
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // save file...
                Debug.WriteLine("Debug Success:" + responseContent);
                // Doc token
                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(responseContent);

                // Luu token
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                StorageFile file = await folder.CreateFileAsync("token.txt", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, responseContent);
            }
            else
            {
                Debug.WriteLine(responseContent);
            }
            

            if (this.Email.Text == "")
            {
                this.error_UserName.Text = "Please enter introduction";
            }
            if (this.Password.Password == "")
            {
                this.error_Password.Text = "Please enter introduction";
            }
        }
    }
}
