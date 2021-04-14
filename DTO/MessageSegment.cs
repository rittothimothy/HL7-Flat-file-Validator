using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MessageSegment
    {
        public string SegmentCode { get; set; }
        public bool IsRequired { get; set; }
        public bool IsRepeatable { get; set; }
        public int Count { get; set; }
    }
}
