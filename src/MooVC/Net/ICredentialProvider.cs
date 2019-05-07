namespace MooVC.Net
{
    using System.Net;

    public interface ICredentialProvider
    {
        ICredentials GetCurrentUser();
    }
}