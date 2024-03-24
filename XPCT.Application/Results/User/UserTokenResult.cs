using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Application.Results.User
{
    public enum UserTokenStatus
    {
        Success,
        UserNotFound,
        InternalError,
        ErrorGeneratingUserToken
    }
    public class UserTokenResult
    {
        public UserTokenStatus Status { get; private set; }
        public string Message { get; private set; }
        public string? Token { get; private set; }
        public DateTime? DueDate { get; private set; }

        public UserTokenResult(UserTokenStatus status, string message, string? token, DateTime? dueDate)
        {
            Status = status;
            Message = message;
            Token = token;
            DueDate = dueDate;
        }


        public static UserTokenResult Success(string token, DateTime dueDate) =>
            new(UserTokenStatus.Success, "Token generated successfully", token, dueDate);
        public static UserTokenResult UserNotFound() =>
            new(UserTokenStatus.UserNotFound, "the user was not found", null, null);
        public static UserTokenResult InternalError(string message) =>
            new(UserTokenStatus.InternalError, message, null, null);
        public static UserTokenResult ErrorGeneratingUserToken() =>
            new(UserTokenStatus.ErrorGeneratingUserToken, "an error occoured at generating the user token", null, null);
    }
}
