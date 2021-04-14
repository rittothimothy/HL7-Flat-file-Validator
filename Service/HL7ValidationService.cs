using System;
using System.Collections.Generic;
using System.Text;
using IService;
using IRepo;
using RepoFactory;
using DTO;

namespace Service
{
    public class HL7ValidationService : IHL7ValidationService
    {
        private static IHL7ValidationRepo hl7validation_repo{get;set;}
        public HL7ValidationService()
        {
            hl7validation_repo = FactoryRepo.GetHL7ValidationRepoInstance();
        }
        public MessageDTO getHL7ValidationConfig()
        {
            return hl7validation_repo.getHL7ValidationConfig();
        }
    }
}
