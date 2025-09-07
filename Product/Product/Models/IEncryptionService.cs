using Microsoft.AspNetCore.DataProtection;
using System.Globalization;

namespace Product.Models
{
    public interface IEncryptionService
    {
        string Protect(decimal price);
        decimal Unprotect(string protectedPrice);
    }

    public class DataProtectionEncryptionService : IEncryptionService
    {
        private readonly IDataProtector _protector;

        public DataProtectionEncryptionService(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("Product.Price.v1");
        }

        public string Protect(decimal price)
        {
            // use invariant culture for consistency
            return _protector.Protect(price.ToString(CultureInfo.InvariantCulture));
        }

        public decimal Unprotect(string protectedPrice)
        {
            var plain = _protector.Unprotect(protectedPrice);
            return decimal.Parse(plain, CultureInfo.InvariantCulture);
        }
    }
}
