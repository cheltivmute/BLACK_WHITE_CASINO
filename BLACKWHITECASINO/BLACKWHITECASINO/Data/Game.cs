using System;
using System.Collections.Generic;

#nullable disable

namespace BLACKWHITECASINO.Data
{
    public partial class Game
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserGameId { get; set; }
        public string Name { get; set; }
        public string Bet { get; set; }
        public string Result { get; set; }
        public string Profit { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}
