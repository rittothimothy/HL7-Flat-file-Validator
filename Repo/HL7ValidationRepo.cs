using System;
using System.Collections.Generic;
using System.Text;
using IRepo;
using UtilityServices;
using System.IO;
using DTO;

namespace Repo
{
    public class HL7ValidationRepo: IHL7ValidationRepo
    {
        public MessageDTO getHL7ValidationConfig()
        {
            MessageDTO _MessageDTO = new MessageDTO();
            string XMLFileName = Constants.ADT_XML_Config_FileName;
            _MessageDTO = Utility.getADTXMLConfig(XMLFileName);
            return _MessageDTO;
        }
    }
}
