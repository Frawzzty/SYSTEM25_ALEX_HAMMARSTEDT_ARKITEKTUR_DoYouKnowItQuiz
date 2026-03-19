namespace DoYouKnowIt.Application.Facades
{
    public interface ILoginFacade
    {
        Task<bool> UserIsAdminAsync();
        Task<bool> UserIsLoggedIn();
        public Task<bool> UserLogin(string username, string password);
        public void UserLogout();
    }
}
