﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientAssistance.Models
{
    public class PatientAssistance
    {
        
        public int id { get; set; }
        public int LevelOfPain { get; set; }
        public string HospitalName { get; set; }
        public int AveProcessTime { get; set; }
        public int PatientCount { get; set; }
        public int WaitingTime { get; set; }

    }
}