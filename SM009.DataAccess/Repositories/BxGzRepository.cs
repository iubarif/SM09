using SM09.Common.Entities;
using SM09.Common.Entities.Discount;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.DataAccess.Repositories
{
    public class BxGzRepository : Repository<BxGz>
    {
        public BxGzRepository(DataContext context):base(context)
        {

        }
    }
}
