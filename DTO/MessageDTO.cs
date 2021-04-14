using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MessageDTO
    {
        public string MessageCode { get; set; }
        public string MessageDescription { get; set; }
        public IList<MessageSegment> Segments { get; set; }

    }
}
