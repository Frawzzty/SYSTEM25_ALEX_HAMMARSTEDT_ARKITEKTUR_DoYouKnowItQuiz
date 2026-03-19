namespace DoYouKnowIt.Application.Interfaces.LoginInterfaces
{
    public interface IAuthorizationService
    {
        public Task<bool> IsAuthorizedAsync(string role);
    }
}
