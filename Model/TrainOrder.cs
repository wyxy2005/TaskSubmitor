using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TrainOrder
    {
        public string TrainDate { get; set; }
        public string TrainNo { get; set; }
        public string TrainCode { get; set; }
        public string SeatType { get; set; }
        public string FromCode { get; set; }
        public string ToCode { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string SecretStr { get; set; }
    }
}
