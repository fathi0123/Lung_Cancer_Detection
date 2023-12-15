using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paymentauthorization.Enums
{
    [Flags]

    public enum Role
    {
        SystemAdmin = 1,
        NormalUser = 2,

    }

}