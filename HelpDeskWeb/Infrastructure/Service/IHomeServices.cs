
using HelpDeskWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskWeb.Service
{
    public interface IHomeServices
    {
       IList<TicketViewModel> GetIndexViewModel(int numberOfTickets);
    }
}
