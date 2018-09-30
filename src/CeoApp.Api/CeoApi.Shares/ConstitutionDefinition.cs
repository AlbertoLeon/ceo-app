using System;
using System.Collections.Generic;
using System.Text;

namespace CeoApi.Shares
{
    /// <summary>
    /// A draft that helps to prepare a the constitution of a company before it is ready for public registry
    /// </summary>
    public class ConstitutionDefinition
    {
        private readonly List<ShareHolder> shareHolders;

        /// <summary>
        /// Set how a constituion of a company will be formed
        /// </summary>
        /// <param name="shareValue">The reference value in cents of one security (share)</param>
        public ConstitutionDefinition(int shareValue)
        {
            ShareValue = shareValue;
            shareHolders = new List<ShareHolder>();
        }

        public IEnumerable<ShareHolder> ShareHolders => shareHolders;
        /// <summary>
        /// The sum of the value of the securities (shares) entered in a firm's books
        /// </summary>
        public float BookValue { get; private set; }
        public int NumberOfShares { get; private set; }
        /// <summary>
        /// The reference value in cents of one security (share)
        /// </summary>
        public int ShareValue { get; private set; }

        /// <summary>
        /// Adds a new share holder and assign new shares to him based of the amount paid
        /// </summary>
        /// <param name="holderName"></param>
        /// <param name="amount">The total paid </param>
        public void AddHolder(string holderName, float amount)
        {
            int adquiredShares = CalculateNumberOfShares(amount);
            IncreaseShares(adquiredShares);
            IncreasValue(amount);
            var holder = new ShareHolder(holderName, amount, adquiredShares, CalculatePercentage(adquiredShares));

            shareHolders.Add(holder);
        }

        private void IncreasValue(float amount)
        {
            BookValue += amount;
        }

        private void IncreaseShares(int adquiredShares)
        {
            NumberOfShares += adquiredShares;
        }

        private int CalculateNumberOfShares(float investment)
        {
            return investment.ToCents() / ShareValue;
        }

        private float CalculatePercentage(int sharesToCompare)
        {
            return (sharesToCompare / NumberOfShares) * 100;
        }
    }
}
