using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpDeskWeb.Infrastructure.Populator
{
   public  interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetApplications();

        IEnumerable<SelectListItem> GetAuteurs();
        IEnumerable<SelectListItem> GetSatuts();
        IEnumerable<SelectListItem> GetPriorites();



    }
}
