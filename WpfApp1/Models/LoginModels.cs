namespace WpfApp1.Models
{
    public class LoginRequestModel
    {
        public string UserName;
        public string Password;

        public LoginRequestModel(string UserName,string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
    }

    public class LoginRequestInternalModel
    {
        public string UserName;
        public string Password;

        public LoginRequestInternalModel(string UserName, string PasswordHash)
        {
            this.UserName = UserName;
            this.Password = PasswordHash;
        }
    }

    public class LoginResponseModel
    {
        public bool IsLoggedIn;
        public string UserName;

        public LoginResponseModel(bool IsLoggedIn, string UserName)
        {
            this.IsLoggedIn = IsLoggedIn;
            this.UserName = UserName;
        }
    }

}
