using System;
using System.Collections.Generic;

namespace WebCore.Models
{
    public class PersonOnDutyInfoModel
    {
        public DateTime SelectTime { get; set;}
        public string Location { get; set; }
        public List<string> Infos { get; set; }
    }
}

