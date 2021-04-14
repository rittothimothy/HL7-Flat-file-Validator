using System;
using System.Collections.Generic;
using System.Text;
using IService;
using Service;
namespace ServiceFactory
{
    public static class FactoryService
    {
        public static IHL7ValidationService GetHL7ValidationServiceInstance()
        {
            return new HL7ValidationService();
        }
    }
}
