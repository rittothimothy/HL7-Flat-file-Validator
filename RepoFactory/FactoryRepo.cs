using System;
using System.Collections.Generic;
using System.Text;
using IRepo;
using Repo;

namespace RepoFactory
{
    public static class FactoryRepo
    {
        public static IHL7ValidationRepo GetHL7ValidationRepoInstance()
        {
            return new HL7ValidationRepo();
        }
    }
}
