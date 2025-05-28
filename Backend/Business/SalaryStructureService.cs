using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Controllers;
using Backend.Model.Domain;
using Backend.Repository;

namespace Backend.Business
{
    public class SalaryStructureService: GenericService<SalaryStructure>,ISalaryStructure
    {
        // private readonly IGenericRepository<SalaryStructure> repository;
        public SalaryStructureService(IGenericRepository<SalaryStructure> repository) : base(repository)
        {
            // this.repository = repository;
        }
    }
}