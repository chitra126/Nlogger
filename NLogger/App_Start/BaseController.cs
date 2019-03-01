using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLogger.App_Start
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Action Executed :" + filterContext.RouteData.Values["action"] + " of controller : " + filterContext.RouteData.Values["controller"]);
            //base.OnActionExecuted(filterContext);
        }

        // GET: Base
        protected override void OnException(ExceptionContext filterContext)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            logger.Error("Error occured in "+ filterContext.RouteData.Values["controller"] + " controller "+ filterContext.RouteData.Values["action"] + " Action", filterContext.Exception);

            filterContext.ExceptionHandled = true;
        }
    }
}