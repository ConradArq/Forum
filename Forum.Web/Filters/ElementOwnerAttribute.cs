using Forum.Repositories.Managers;
using Forum.Repositories.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Utilities;
using Resources;

namespace Forum.Web.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ElementOwnerAttribute : ActionFilterAttribute
    {
        public Type EntityType { get; set; }
        public string RequestKeyArgumentName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string keyArgumentName = RequestKeyArgumentName ?? "id";

                if (filterContext.RouteData.Values[keyArgumentName] != null && typeof(IElementOwnerRepository).IsAssignableFrom(EntityType))
                {
                    bool isOwnElement = ElementOwnerManager.UserOwnElement(EntityType, Convert.ToInt32(filterContext.RouteData.Values[keyArgumentName].ToString()), filterContext.HttpContext.User.Identity.GetUserId<int>());

                    if (!isOwnElement)
                    {
                        filterContext.Result = Utils.GetErrorViewResult(filterContext.Controller.ViewData, UIResources.NotActionElementAuthorized);
                    }
                }
                else
                {
                    filterContext.Result = Utils.GetErrorViewResult(filterContext.Controller.ViewData, null);
                }

            }
            catch (Exception ex)
            {
                filterContext.Result = Utils.GetErrorViewResult(filterContext.Controller.ViewData, null);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}