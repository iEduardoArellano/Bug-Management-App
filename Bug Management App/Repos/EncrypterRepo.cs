using Bug_Management_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Management_App.Repos
{
    public class EncrypterRepo : IEncrypter
    {
        public string encryptPassword(string password)
        {
            string result;

            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encrypted);

            return result;
        }
    }
}