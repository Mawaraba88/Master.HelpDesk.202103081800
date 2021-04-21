using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpDeskWeb.Service
{
    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetApplication();

        IEnumerable<SelectListItem> GetAssistant();

       

    }
}
