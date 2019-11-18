using Microsoft.AspNetCore.Http;
using System;

namespace Services.Supplier.API.Services
{
    public interface IIdentityService
    {
        string GetUserIdentity();
    }
}