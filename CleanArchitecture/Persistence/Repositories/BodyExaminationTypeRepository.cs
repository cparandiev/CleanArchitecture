using Application.Interfaces.Repositories;
using Domain.Entities.BodyExaminationResultAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class BodyExaminationTypeRepository : EfRepository<BodyExaminationType>, IBodyExaminationTypeRepository
    {
        public BodyExaminationTypeRepository(Context dbContext)
            : base(dbContext) { }
    }
}
