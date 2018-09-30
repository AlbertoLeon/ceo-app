using System;
using System.Collections.Generic;

namespace CeoApi.Shares
{
    public class CapTable
    {
        private readonly List<ShareHolder> _shareHolders;

        public CapTable(string companyName)
        {

        }

        public string CompanyName { get; private set; }
        public IEnumerable<ShareHolder> ShareHolders { get; set; }
    }
}
