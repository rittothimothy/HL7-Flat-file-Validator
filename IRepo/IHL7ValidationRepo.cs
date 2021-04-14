using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace IRepo
{
    public interface IHL7ValidationRepo
    {
        MessageDTO getHL7ValidationConfig();
    }
}
