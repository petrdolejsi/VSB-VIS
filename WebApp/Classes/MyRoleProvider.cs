using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Library.Mapping;
using Library.Models;

namespace WebApp.Classes
{
    public class MyRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            Users user = new UsersMapper().SelectUser(username);

            if (user == null)
            {
                return false;
            }

            return roleName == user.Type;
        }

        public override string[] GetRolesForUser(string username)
        {
            Users user = new UsersMapper().SelectUser(username);

            if (user == null)
            {
                return new string[] { };
            }

            return new string[] { user.Type };
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}