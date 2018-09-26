using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.DataAccess.Core
{
    public interface IDbFactory
    {
        DataContext GetDataContext { get; }
    }
}
