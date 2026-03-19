namespace DoYouKnowIt.Application.Interfaces.LoginInterfaces
{
    public interface IAuthenticationService
    {
        public Task<bool> IsAuthenticatedAsync(string username, string password);

    }
}
