using System;
using System.Collections.Generic;

#nullable disable

namespace BLACKWHITECASINO.Data
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserTransactionId { get; set; }
        public string Operation { get; set; }
        public string Summ { get; set; }
        public string TotalBefore { get; set; }
        public string TotalAfter { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}
