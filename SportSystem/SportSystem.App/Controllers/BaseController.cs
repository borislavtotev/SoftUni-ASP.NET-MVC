using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportSystem.App.Data.UnitOfWork;

namespace SportSystem.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        protected ISportSystemData Data { get; private set; }
    }

}