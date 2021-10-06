using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Management_App.Data
{
    public class Encrypter : IEncrypter
    {
        public string EncryptPassword(string password)
        {
            if(password != null)
            {
                string result;
                byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(password);
                result = Convert.ToBase64String(encrypted);

                return result;
            }

            return password;
           
        }
    }
}
