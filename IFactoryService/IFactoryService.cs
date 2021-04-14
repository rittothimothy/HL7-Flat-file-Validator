using System;
using System.Collections.Generic;
using System.Text;
using IService;
namespace IFactoryServices
{
    public interface IFactoryService
    {
        IHL7ValidationService GetHL7ValidationServiceInstance();
    }
}
