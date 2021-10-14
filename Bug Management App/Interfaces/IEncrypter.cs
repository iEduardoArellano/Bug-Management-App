using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Management_App.Interfaces
{
    public interface IEncrypter
    {
        string EncryptPassword(string password);
    }
}
