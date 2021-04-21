using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskWeb.Service
{
    public abstract class BaseServices
    {
        protected IHelpDeskData Data { get; private set; }

        public BaseServices(IHelpDeskData data)
        {
            this.Data = data;
        }
    }
}