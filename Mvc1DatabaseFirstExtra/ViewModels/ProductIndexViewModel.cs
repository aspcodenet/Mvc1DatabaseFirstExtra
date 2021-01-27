using System.Collections.Generic;

namespace Mvc1DatabaseFirstExtra.ViewModels
{

    // SES 10:30
    public class ProductIndexViewModel
    {
        public string SearchCategory { get; set; }
        public string SearchWord { get; set; }
        public List<string> Names { get; set; }
    }
}