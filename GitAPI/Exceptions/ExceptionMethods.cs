using System.Net;

namespace GitAPI.Exceptions
{

    public static class ExceptionMethods
    {

        public static string ManageResponseExceptions(ResponseException ex)
        {
            switch (ex.StatusCode)
            {
                case HttpStatusCode.Forbidden:
                    {
                        return "You have no permission to do this action. Check your GitHub settings.";
                    }
                default:
                    {
                        return ex.StatusCode.ToString();
                    }
            }
        }
    }
}
