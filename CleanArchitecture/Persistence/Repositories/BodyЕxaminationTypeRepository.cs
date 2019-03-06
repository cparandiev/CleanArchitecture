using Application.Interfaces.Repositories;
using Domain.Entities.BodyЕxaminationResultAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class BodyЕxaminationTypeRepository : EfRepository<BodyЕxaminationType>, IBodyЕxaminationTypeRepository
    {
        public BodyЕxaminationTypeRepository(Context dbContext)
            : base(dbContext) { }
    }
}
