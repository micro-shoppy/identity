using System.Collections.Generic;

namespace MicroShoppy.Identity.Application.DTOs
{
    public class UserProfileDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}