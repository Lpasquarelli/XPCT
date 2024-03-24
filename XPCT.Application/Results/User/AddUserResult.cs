using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.User
{
    public enum AddUserStatus
    {
        Success,
        ErrorCreatingUser,
        InternalError,
        EmailAlreadyUsing
    }

    public class AddUserResult
    {
        public AddUserStatus Status { get; private set; }
        public string Message { get; private set; }
        public IdentifyerResponse? User { get; private set; }

        public AddUserResult(AddUserStatus status, string message, IdentifyerResponse? user)
        {
            Status = status;
            Message = message;
            User = user;
        }

        public static AddUserResult Success(Guid id) =>
            new AddUserResult(AddUserStatus.Success, "User registered successfully", new IdentifyerResponse(id));

        public static AddUserResult ErrorCreatingUser(string message) =>
            new AddUserResult(AddUserStatus.ErrorCreatingUser, message, null);
        public static AddUserResult InternalError(string message) =>
            new AddUserResult(AddUserStatus.InternalError, message, null);
        public static AddUserResult EmailAlreadyUsing() =>
            new AddUserResult(AddUserStatus.EmailAlreadyUsing, "the email is already in use, please try another", null);

    }
}
