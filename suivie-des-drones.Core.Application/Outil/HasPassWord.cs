using suivie_des_drones.Cores.Interfaces.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Core.Application.Outil
{
    public class HasPassWord : IHasUse
    {

        public static byte[] HashPassWord(HMAC hMAC, string entry)
        {
            byte[] retour = hMAC.ComputeHash(Encoding.UTF8.GetBytes(entry));
            hMAC.Dispose();
            return retour;
        }
    }
}
