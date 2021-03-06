﻿using System;
using System.Collections.Generic;

namespace LinqDB.Models
{
    public partial class Language
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public bool? IsOfficial { get; set; }
        public float Percentage { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
    }
}
