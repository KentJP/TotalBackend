using System;
using System.Collections.Generic;
using System.Text;

namespace TotalBackend.Core.Entity
{
    public class User
    {
        private int Id { get; set; }
        private int Igg { get;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }
}
