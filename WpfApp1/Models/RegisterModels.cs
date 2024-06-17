namespace WpfApp1.Models
{
    public class RegisterRequestModel
    {
        public string UserName;
        public string Password;

        public RegisterRequestModel(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
    }

    public class RegisterRequestInternalModel
    {
        public string UserName;
        public string Password;

        public RegisterRequestInternalModel(string UserName, string PasswordHash)
        {
            this.UserName = UserName;
            this.Password = PasswordHash;
        }
    }

    public class RegisterResponseModel
    {
        public bool ResultOk;

        public RegisterResponseModel(bool ResultOk)
        {
            this.ResultOk = ResultOk;
        }
    }

}
