using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;


namespace XPCT.Application.Results.User
{
    public enum GetUserWalletsUpcommingDueDateStatus
    {
        Success,
        NoContent,
        InternalError,
        ErrorGettingUserWalletsUpcommingDueDateStatus
    }
    public class GetUserWalletsUpcommingDueDateResult
    {
        public GetUserWalletsUpcommingDueDateStatus Status { get; private set; }
        public IEnumerable<Domain.Entities.User>? Users { get; private set; }
        public string Message { get; private set; }
        
        public GetUserWalletsUpcommingDueDateResult(GetUserWalletsUpcommingDueDateStatus status, string message, IEnumerable<Domain.Entities.User>? users)
        {
            Status = status;
            Message = message;
            Users = users;
        }

        public static GetUserWalletsUpcommingDueDateResult Success(IEnumerable<Domain.Entities.User>? users) =>
            new(GetUserWalletsUpcommingDueDateStatus.Success, "researching completed successfully",users);
        public static GetUserWalletsUpcommingDueDateResult NoContent() =>
            new(GetUserWalletsUpcommingDueDateStatus.NoContent, "no content was found", null);
        public static GetUserWalletsUpcommingDueDateResult ErrorGettingUserWalletsUpcommingDueDateStatus(string message) =>
            new(GetUserWalletsUpcommingDueDateStatus.ErrorGettingUserWalletsUpcommingDueDateStatus, message, null);
        public static GetUserWalletsUpcommingDueDateResult InternalError(string message) =>
            new(GetUserWalletsUpcommingDueDateStatus.InternalError, message, null);
    }
}
