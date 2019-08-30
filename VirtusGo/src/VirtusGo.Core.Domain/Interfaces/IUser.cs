using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace VirtusGo.Core.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        int GetUserId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}