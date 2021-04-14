using System;
using System.Collections.Generic;
using System.Text;
using IRepo;
namespace IFactory
{
    public interface IFactoryRepo
    {
        IHL7ValidationRepo GetHL7ValidationRepoInstance();
    }
}
