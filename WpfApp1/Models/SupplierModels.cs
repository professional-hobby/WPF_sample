namespace WpfApp1.Models
{
    public class AddQuantityRequestModel
    {
        public string UserName;
        public int Quantity;

        public AddQuantityRequestModel(string UserName,int Quantity)
        {
            this.UserName = UserName;
            this.Quantity = Quantity;
        }
    }

    public class AddQuantityResponseModel
    {
        public bool ResultOk;

        public AddQuantityResponseModel(bool ResultOk)
        {
            this.ResultOk = ResultOk;
        }
    }
}
