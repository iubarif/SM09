﻿using SM09.Common.Entities;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.DataAccess.Repositories
{
    public class LineItemRepository : Repository<LineItem>
    {
        public LineItemRepository(DataContext context):base(context)
        {

        }
    }
}
