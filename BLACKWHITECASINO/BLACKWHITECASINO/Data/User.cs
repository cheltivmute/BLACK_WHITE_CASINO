using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BLACKWHITECASINO.Data
{
    public partial class User
    {
        public User()
        {
            Games = new HashSet<Game>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal Total { get; set; }
        public int GameQuantity { get; set; }
        public int TransactionQuantity { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
