using System;

namespace Store.Web.Contractors
{
    public interface IWebContractorService
    {
        string UniqueCode { get; }

        string GetUri { get; }
    }
}
