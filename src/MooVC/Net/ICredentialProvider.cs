namespace MooVC.Net
{
    using System;
    using System.Net;

    [Obsolete]
    public interface ICredentialProvider
    {
        ICredentials GetCurrentUser();
    }
}