using Forum.Core.Models.System;
using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Forum.Repositories.Repositories.Shared.System
{
    public class SysLoginLogRepository : GenericRepository<SysLoginLog>, ISysLoginLogRepository
    {
        public static bool SaveLog(int userID)
        {
            bool ok = false;
            try
            {
                using (FContext ctx = new FContext())
                {
                    ctx.SysLoginLog.Add(new SysLoginLog()
                    {
                        UserID = userID,
                        UserIP = HttpContext.Current.Request.UserHostAddress,
                        MachineName = global::System.Environment.MachineName,
                        CreationDate = DateTime.Now
                    });

                    ctx.SaveChanges();
                }

                ok = true;
            }
            catch (Exception e)
            {

            }

            return ok;
        }
    }
}
