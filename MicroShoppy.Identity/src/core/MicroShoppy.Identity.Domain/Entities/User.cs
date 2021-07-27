using System;
using System.Collections.Generic;
using System.Linq;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Domain.Entities
{
    public class User : AuditableEntity<Guid>
    {
        public Email Email { get; protected set; }
        public UserName UserName { get; protected set; }
        public UserPassword UserPassword { get; protected set; }
        public ICollection<Role> Roles { get; protected set; }

        protected User()
        {
            Roles = new List<Role>();
        }
        public User(Guid id, DateTime createdAt, Email email, UserName userName, UserPassword userPassword) : base(id, createdAt)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email), $"{nameof(Email)} property in {nameof(User)} entity must not be null.");
            }

            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName), $"{nameof(UserName)} property in {nameof(User)} entity must not be null.");
            }

            if (userPassword == null)
            {
                throw new ArgumentNullException(nameof(userPassword), $"{nameof(UserPassword)} property in {nameof(User)} entity must not be null.");
            }

            Email = email;
            UserName = userName;
            UserPassword = userPassword;
            Roles = new List<Role>();
        }

        public User(Guid id, DateTime createdAt, Email email, UserName userName, UserPassword userPassword, params Role[] roles) : base(id, createdAt)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email), $"{nameof(Email)} property in {nameof(User)} entity must not be null.");
            }

            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName), $"{nameof(UserName)} property in {nameof(User)} entity must not be null.");
            }

            if (userPassword == null)
            {
                throw new ArgumentNullException(nameof(userPassword), $"{nameof(UserPassword)} property in {nameof(User)} entity must not be null.");
            }

            Email = email;
            UserName = userName;
            UserPassword = userPassword;
            Roles = roles.ToList();
        }

    }
}