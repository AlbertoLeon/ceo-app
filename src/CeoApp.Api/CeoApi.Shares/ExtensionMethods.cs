using System;
using System.Collections.Generic;
using System.Text;

namespace CeoApi.Shares
{
    public static class ExtensionMethods
    {
        public static int ToCents(this float amount)
        {
            return (int)(amount * 100);
        }


    }
}
