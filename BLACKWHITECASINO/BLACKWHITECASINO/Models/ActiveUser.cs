using BLACKWHITECASINO.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLACKWHITECASINO.Models
{
    public class ActiveUser
    {
        public static User activeUser { get; set; }
        public static Transaction activeTotal { get; set; }
        public static int Age { get; set; }
        

        public static int AgeFind(DateTime bd)
        {
            ActiveUser.Age = DateTime.Now.Year - bd.Year - 1 +
            ((DateTime.Now.Month > bd.Month || DateTime.Now.Month == bd.Month && DateTime.Now.Day >= bd.Day) ? 1 : 0);
            return ActiveUser.Age;
        }

        public static void UpdateState(BLACK_WHITE_CASINOContext context)
        {
            context.Entry(ActiveUser.activeUser).State = EntityState.Modified;
        }
    }
}
