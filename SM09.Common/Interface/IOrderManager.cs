using SM09.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Interface
{
    public interface IOrderManager : IActionManager
    {
        DTOOrder PrintInvoice(int Id);
    }
}
