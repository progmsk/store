using System;
using System.Collections.Generic;

namespace Store.Web.Contractors
{
    public interface IWebContractorService
    {
        string Name { get; }

        Uri StartSession(IReadOnlyDictionary<string, string> parameters, Uri returnUri);
    }
}
