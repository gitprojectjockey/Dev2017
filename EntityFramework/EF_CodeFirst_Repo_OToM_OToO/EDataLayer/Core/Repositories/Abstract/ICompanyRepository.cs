﻿using EDataLayer.Core.Domain;
using EDataLayer.Core.Domain.ResultEntities;
using System.Collections.Generic;

namespace EDataLayer.Core.Repositories.Abstract
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<CompanyWithProductResult> CompaniesWithProducts();

        IEnumerable<CompanyWithProductResult> CompanyWithProducts(Company company);
    }
}