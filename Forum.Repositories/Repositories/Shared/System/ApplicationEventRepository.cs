using Forum.Core.Enums.System;
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
    public class ApplicationEventRepository : GenericRepository<SysAppEvent>, IApplicationEventRepository
    {

        public static void SaveError(Exception e, string source)
        {
            if (!string.IsNullOrEmpty(Forum.Utilities.Utils.GetWebConfigParameter("system:TrackEventErrorType")) && Forum.Utilities.Utils.GetWebConfigParameter("system:TrackEventErrorType") == "true")
            {
                SysAppEvent sysAppEvent = new SysAppEvent()
                {
                    UserID = UserID,
                    UserIP = HttpContext.Current.Request.UserHostAddress,
                    Description = string.Format("Message: {0}; Source: {1}", e.Message, source),
                    Trace = e.StackTrace,
                    SysAppEventTypeID = (int)SysAppEventTypes.ERROR,
                    CreationDate = DateTime.Now
                };

                Insert(sysAppEvent);
            }
        }

        public static void SaveInfo(string info)
        {
            if (!string.IsNullOrEmpty(Forum.Utilities.Utils.GetWebConfigParameter("system:TrackEventInfoType")) && Forum.Utilities.Utils.GetWebConfigParameter("system:TrackEventInfoType") == "true")
            {
                SysAppEvent sysAppEvent = new SysAppEvent()
                {
                    UserID = UserID,
                    UserIP = HttpContext.Current.Request.UserHostAddress,
                    Description = info,
                    SysAppEventTypeID = (int)SysAppEventTypes.INFO,
                    CreationDate = DateTime.Now
                };

                Insert(sysAppEvent);
            }
        }

        private static int? UserID
        {
            get
            {
                var userID = (int?)HttpContext.Current.User.Identity.GetUserId<int>();
                return userID > 0 ? userID : null;
            }
        }

        private static void Insert(SysAppEvent entity)
        {
            try
            {
                using (FContext ctx = new FContext())
                {
                    ctx.SysAppEvent.Add(entity);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                // Continue execution if logging process throws exception
            }
        }
    }
}
