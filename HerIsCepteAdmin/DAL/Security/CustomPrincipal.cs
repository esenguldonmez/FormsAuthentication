using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace HerIsCepteAdmin.DAL.Security
{
    public interface ICustomIdentity : IIdentity
    {
        int UserId { get; }
        string Email { get; }
    }

    public class CustomIdentity : ICustomIdentity
    {
        public string AuthenticationType => originalIdentity.AuthenticationType;
        public bool IsAuthenticated => originalIdentity.IsAuthenticated;
        public string Name => originalIdentity.Name;
        public int UserId { get; private set; }
        public string Email { get; private set; }

        private readonly IIdentity originalIdentity;

        public CustomIdentity(IIdentity originalIdentity, int userId, string email)
        {
            this.originalIdentity = originalIdentity;
            UserId = userId;
            Email = email;
        }
    }

    public class CustomPrincipal : IPrincipal
    {
        public ICustomIdentity Identity { get; private set; }

        IIdentity IPrincipal.Identity => Identity;

        public bool IsInRole(string role)
        {
            string[] Roles = { "Admin", "Kullanıcı", "Personel" };

            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string username, int userId, string email)
        {
            this.Identity = new CustomIdentity(new GenericIdentity(username), userId, email);
        }

        public int UserId => Identity.UserId;
        public string Name => Identity.Name;
        public string Email => Identity.Email;
    }
}