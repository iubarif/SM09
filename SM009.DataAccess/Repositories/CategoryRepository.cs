using SM09.Common.Entities;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(DataContext context):base(context)
        {

        }
    }
}
