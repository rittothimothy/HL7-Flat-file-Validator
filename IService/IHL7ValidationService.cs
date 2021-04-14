using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace IService
{
    public interface IHL7ValidationService
    {
        public MessageDTO getHL7ValidationConfig();
    }
}
