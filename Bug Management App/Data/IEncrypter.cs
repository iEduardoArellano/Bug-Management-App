namespace Bug_Management_App.Data
{
    public interface IEncrypter
    {

        string EncryptPassword(string password);
    }
}