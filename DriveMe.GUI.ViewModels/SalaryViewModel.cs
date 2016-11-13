using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Api.ViewModels.Base;

namespace Bigly.GUI.ViewModels
{
    public class SalaryViewModel:ViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rate { get; set; }
        public decimal Amount { get; set; }
        public DateTime Since { get; set; }
        public DateTime Till { get; set; }
    }
}
