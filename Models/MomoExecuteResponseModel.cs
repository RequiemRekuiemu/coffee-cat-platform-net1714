﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MomoExecuteResponseModel
    {
        public string OrderId { get; set; }
        public string Amount { get; set; }
        public string OrderInfo { get; set; }
        public string ErrorCode { get; set; }
    }
}
