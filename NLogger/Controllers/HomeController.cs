using NLog;
using NLog.Targets;
using NLogger.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NLogger.Controllers
{
    public class HomeController : BaseController
    {
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly NLog.Logger peachlogger = NLog.LogManager.GetLogger("PeachOrder");

        public ActionResult Index()
        {
            //Logger logger = LogManager.GetCurrentClassLogger();   
            peachlogger.Debug("test log");

            try
            {
                logger.Debug("Error occured in");
                LogManager.Configuration.Variables["user"] = "milind";
                try
                {
                    int x = 0;
                    int y = 5;
                    int z = y / x;                   
                }
                catch (Exception ex)
                {
                    throw ex;
                    //logger.ErrorException("Error occured in Home controller Index Action", ex);
                    //logger.ErrorException("Error occured in Home controller Index Action", ex);
                    //logger.ErrorException("There was a serious problem communicating with on the network", webEx);
                }
                return View();
            }
            catch (Exception ex)
            {
                //NLog.LogManager.GetCurrentClassLogger().Error(ex);
                throw ex;
            }
        }

        public ActionResult About()
        {
            try
            {
                int x = 0;
                int y = 5;
                int z = y / x;
            }
            catch (Exception ex)
            { }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}