﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Core.Models.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
