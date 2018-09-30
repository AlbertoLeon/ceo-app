using System.Collections.Generic;

namespace CeoApi.Shares
{
    public class Constitution
    {
        public Constitution()
        {

        }

        public IEnumerable<ShareHolder> ShareHolders { get; private set; }
        public float BookValue { get; private set; }
        public float RealValue { get; private set; }
        public float NumberOfShares { get; private set; }
    }
}
