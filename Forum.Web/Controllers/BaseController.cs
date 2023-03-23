using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Forum.Repositories.Managers;
using Forum.Core.Enums.Users;
using Forum.Repositories.Repositories.Users;
using Forum.Repositories.Repositories.Shared.System;

namespace Forum.Web.Controllers
{
    public class BaseController : Controller
    {
        public int CurrentUserID
        {
            get { return System.Web.HttpContext.Current.User.Identity.GetUserId<int>(); }
        }

        public ApplicationRoles CurrentUserRole
        {
            get { return RoleRepository.GetUserRoleByUserID(CurrentUserID); }
        }

        public void LogError(Exception e, string source)
        {
            ApplicationEventRepository.SaveError(e, source);
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    if (filterContext.ExceptionHandled)
        //    {
        //        return;
        //    }
        //    filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/Shared/Error.aspx"
        //    };

        //    LogError(filterContext.Exception, "BaseController:OnException");

        //    filterContext.ExceptionHandled = true;
        //}

    }
}