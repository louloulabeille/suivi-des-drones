using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
//using suivie_des_drones.Cores.Interfaces.Hash;


namespace suivi_des_drones.Core.Models
{
    public class Login
    {


        public int Id { get; set; }
        public string Email { get; set; } = string.Empty!;
        private string _password = string.Empty!;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = HashPassword(value);
            }
        }

        public static string HashPassword(string password)
        {
            byte[] tmpSource = Encoding.ASCII.GetBytes(password);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            return string.Join("", tmpHash);
        }

        /*public static byte[] HashPassword(string password, suivie_des_drones.Cores.Interfaces.Hash.IHasUSe hasUSe )
        {
            byte[] tmpSource = Encoding.ASCII.GetBytes(password);
            HMACMD5 hMACMD5 = new();
            return new MD5CryptoServiceProvider().ComputeHash(tmpSource);

        }*/

    }
}
