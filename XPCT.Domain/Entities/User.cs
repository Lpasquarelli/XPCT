using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Operator { get; private set; }
        public Wallet? Wallet { get; private set; }

        public User(Guid id, string name, string email,bool Operator, Wallet wallet)
        {
            this.Id = id;
            this.Name = name;
            this.Operator = Operator;
            this.Email = email;
            this.Wallet = wallet;
        }

        public User(Guid id, string name, string email, bool Operator)
        {
            this.Id = id;
            this.Name = name;
            this.Operator = Operator;
            this.Email = email;
        }

        public User(string name, string email, bool Operator)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Operator = Operator;
            this.Email = email;
        }

        public void LoadWallet(Wallet wallet)
        {
            this.Wallet = wallet;
        }
    }
}
