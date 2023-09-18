using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Interfaces.Hash
{
    public interface IHasUse
    {
        public abstract static byte[] HashPassWord(HMAC hMAC, string entry);
    }
}
