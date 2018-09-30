namespace CeoApi.Shares
{
    public class ShareHolder
    {
        public ShareHolder(string name, float amountPaid, int ownedShares, float percentage)
        {
            Name = name;
            AmountPaid = amountPaid;
            OwnedShares = ownedShares;
            Percentage = percentage;
        }

        public string Name { get; private set; }
        public float Percentage { get; private set; }
        public float AmountPaid { get; private set; }
        public int OwnedShares { get; private set; }
    }
}