using System.Collections.Generic;

namespace Mvc5RepeaterHelper.Models
{
    public class RepeaterOptions
    {
        public List<string> ExcludedList { get; set; }
        public List<string> TitleList { get; set; }
        public bool IsDetailEnabled { get; set; }
        public string DetailMethodName { get; set; }
        public string DetailParameterName { get; set; }
        public bool IsDeleteEnabled { get; set; }
        public string DeleteMethodName { get; set; }
        public string DeleteParameterName { get; set; }
    }
}
