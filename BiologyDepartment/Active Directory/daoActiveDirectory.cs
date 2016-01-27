﻿using System;
using System.Collections;
using System.Text;
using System.DirectoryServices.AccountManagement;
using System.Data;
using System.Configuration;
using System.Net;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BiologyDepartment
{
    class daoActiveDirectory
    {

        #region Variables
        PrincipalContext _PrincipalContext = null;

        #endregion
        #region Validate Methods

        /// <summary>
        /// Validates the username and password of a given user
        /// </summary>
        /// <param name="sUserName">The username to validate</param>
        /// <param name="sPassword">The password of the username to validate</param>
        /// <returns>Returns True of user is valid</returns>
        public bool ValidateCredentials(string sUserName, string sPassword)
        {
            _PrincipalContext = GetPrincipalContext(sUserName, sPassword);

            bool valid = _PrincipalContext.ValidateCredentials(sUserName, sPassword);

            if (valid)
            {
                GetDBContext(sUserName);
                GlobalVariables.ADUserName = sUserName;
                GlobalVariables.ADPass = sPassword;
            }

            return valid;
        }

        public void SetPrincipalContext(string sUserName, string sPassword)
        {
            _PrincipalContext = GetPrincipalContext(sUserName, sPassword);
        }

        public void GetDBContext(string sUserName)
        {
            GroupPrincipal theGroup = null;

            if (IsUserGroupMember(sUserName, "Biology Project Admin"))
                theGroup = GetGroup("Biology Project Admin");
            else if (IsUserGroupMember(sUserName, "Biology Project Users"))
                theGroup = GetGroup("Biology Project Users");
            else
                return;

            DirectoryEntry de = (theGroup.GetUnderlyingObject() as DirectoryEntry);

            GlobalVariables.dbUser = de.Properties["oracleUser"].Value.ToString();
            GlobalVariables.dbPass = de.Properties["oraclePass"].Value.ToString();
            GlobalVariables.ADUserGroup = theGroup.Name;
        }

        /// <summary>
        /// Checks if the User Account is Expired
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if Expired</returns>
        public bool IsUserExpired(string sUserName)
        {
            UserPrincipal theUser = GetUser(sUserName);
            if (theUser.AccountExpirationDate != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if user exsists on AD
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if username Exists</returns>
        public bool IsUserExisiting(string sUserName)
        {
            if (GetUser(sUserName) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if user account is locked
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Retruns true of Account is locked</returns>
        public bool IsAccountLocked(string sUserName)
        {
            UserPrincipal theUser = GetUser(sUserName);
            return theUser.IsAccountLockedOut();
        }
        #endregion

        #region Search Methods

        /// <summary>
        /// Gets a certain user on Active Directory
        /// </summary>
        /// <param name="sUserName">The username to get</param>
        /// <returns>Returns the UserPrincipal Object</returns>
        public UserPrincipal GetUser(string sUserName)
        {
            UserPrincipal theUser = UserPrincipal.FindByIdentity(_PrincipalContext, sUserName);
            return theUser;
        }

        /// <summary>
        /// Gets a certain group on Active Directory
        /// </summary>
        /// <param name="sGroupName">The group to get</param>
        /// <returns>Returns the GroupPrincipal Object</returns>
        public GroupPrincipal GetGroup(string sGroupName)
        {
            GroupPrincipal theGroup = GroupPrincipal.FindByIdentity(_PrincipalContext, sGroupName);

            return theGroup;
        }

        #endregion

        #region User Account Methods

        /// <summary>
        /// Sets the user password
        /// </summary>
        /// <param name="sUserName">The username to set</param>
        /// <param name="sNewPassword">The new password to use</param>
        /// <param name="sMessage">Any output messages</param>
        public void SetUserPassword(string sUserName, string sNewPassword, out string sMessage)
        {
            try
            {
                UserPrincipal theUser = GetUser(sUserName);
                theUser.SetPassword(sNewPassword);
                sMessage = "The Password has been changed.";
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

        }

        /// <summary>
        /// Enables a disabled user account
        /// </summary>
        /// <param name="sUserName">The username to enable</param>
        public void EnableUserAccount(string sUserName)
        {
            UserPrincipal theUser = GetUser(sUserName);
            theUser.Enabled = true;
            theUser.Save();
        }

        /// <summary>
        /// Force disbaling of a user account
        /// </summary>
        /// <param name="sUserName">The username to disable</param>
        public void DisableUserAccount(string sUserName)
        {
            UserPrincipal theUser = GetUser(sUserName);
            theUser.Enabled = false;
            theUser.Save();
        }

        /// <summary>
        /// Force expire password of a user
        /// </summary>
        /// <param name="sUserName">The username to expire the password</param>
        public void ExpireUserPassword(string sUserName)
        {
            UserPrincipal theUser = GetUser(sUserName);
            theUser.ExpirePasswordNow();
            theUser.Save();

        }

        /// <summary>
        /// Unlocks a locked user account
        /// </summary>
        /// <param name="sUserName">The username to unlock</param>
        public void UnlockUserAccount(string sUserName)
        {
            UserPrincipal theUser = GetUser(sUserName);
            theUser.UnlockAccount();
            theUser.Save();
        }

        /// <summary>
        /// Creates a new user on Active Directory
        /// </summary>
        /// <param name="sOU">The OU location you want to save your user</param>
        /// <param name="sUserName">The username of the new user</param>
        /// <param name="sPassword">The password of the new user</param>
        /// <param name="sGivenName">The given name of the new user</param>
        /// <param name="sSurname">The surname of the new user</param>
        /// <returns>returns the UserPrincipal object</returns>
        public UserPrincipal CreateNewUser(string sOU, string sUserName, string sPassword, string sGivenName, string sSurname)
        {
            if (!IsUserExisiting(sUserName))
            {
                UserPrincipal theUser = new UserPrincipal(_PrincipalContext, sUserName, sPassword, true /*Enabled or not*/);

                //User Log on Name
                theUser.UserPrincipalName = sUserName;
                theUser.GivenName = sGivenName;
                theUser.Surname = sSurname;
                theUser.Save();

                return theUser;
            }
            else
            {
                return GetUser(sUserName);
            }
        }

        /// <summary>
        /// Deletes a user in Active Directory
        /// </summary>
        /// <param name="sUserName">The username you want to delete</param>
        /// <returns>Returns true if successfully deleted</returns>
        public bool DeleteUser(string sUserName)
        {
            try
            {
                UserPrincipal theUser = GetUser(sUserName);

                theUser.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Group Methods

        /// <summary>
        /// Creates a new group in Active Directory
        /// </summary>
        /// <param name="sOU">The OU location you want to save your new Group</param>
        /// <param name="sGroupName">The name of the new group</param>
        /// <param name="sDescription">The description of the new group</param>
        /// <param name="oGroupScope">The scope of the new group</param>
        /// <param name="bSecurityGroup">True is you want this group to be a security group, false if you want this as a distribution group</param>
        /// <returns>Retruns the GroupPrincipal object</returns>
        public GroupPrincipal CreateNewGroup(string sOU, string sGroupName, string sDescription, GroupScope oGroupScope, bool bSecurityGroup)
        {
            GroupPrincipal theGroup = new GroupPrincipal(_PrincipalContext, sGroupName);
            theGroup.Description = sDescription;
            theGroup.GroupScope = oGroupScope;
            theGroup.IsSecurityGroup = bSecurityGroup;
            theGroup.Save();

            return theGroup;
        }

        /// <summary>
        /// Adds the user for a given group
        /// </summary>
        /// <param name="sUserName">The user you want to add to a group</param>
        /// <param name="sGroupName">The group you want the user to be added in</param>
        /// <returns>Returns true if successful</returns>
        public bool AddUserToGroup(string sUserName, string sGroupName)
        {
            try
            {
                UserPrincipal theUser = GetUser(sUserName);
                GroupPrincipal theGroup = GetGroup(sGroupName);
                if (theUser != null && theGroup != null)
                {
                    if (!IsUserGroupMember(sUserName, sGroupName))
                    {
                        theGroup.Members.Add(theUser);
                        theGroup.Save();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Removes user from a given group
        /// </summary>
        /// <param name="sUserName">The user you want to remove from a group</param>
        /// <param name="sGroupName">The group you want the user to be removed from</param>
        /// <returns>Returns true if successful</returns>
        public bool RemoveUserFromGroup(string sUserName, string sGroupName)
        {
            try
            {
                UserPrincipal theUser = GetUser(sUserName);
                GroupPrincipal theGroup = GetGroup(sGroupName);
                if (theUser != null && theGroup != null)
                {
                    if (IsUserGroupMember(sUserName, sGroupName))
                    {
                        theGroup.Members.Remove(theUser);
                        theGroup.Save();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if user is a member of a given group
        /// </summary>
        /// <param name="sUserName">The user you want to validate</param>
        /// <param name="sGroupName">The group you want to check the membership of the user</param>
        /// <returns>Returns true if user is a group member</returns>
        public bool IsUserGroupMember(string sUserName, string sGroupName)
        {
            UserPrincipal theUser = GetUser(sUserName);
            GroupPrincipal theGroup = GetGroup(sGroupName);
            int count = theGroup.Members.Count();
            foreach(var name in theGroup.Members)
            {
                if (String.Equals(name.ToString(), theUser.ToString()))
                    return true;
            }

                return false;

        }

        /// <summary>
        /// Gets a list of the users group memberships
        /// </summary>
        /// <param name="sUserName">The user you want to get the group memberships</param>
        /// <returns>Returns an arraylist of group memberships</returns>
        public List<GroupPrincipal> GetUserGroups(string sUserName)
        {
            UserPrincipal theUser = GetUser(sUserName);

            List<GroupPrincipal> userGroups = new List<GroupPrincipal>();

            foreach (GroupPrincipal group in theUser.GetGroups())
                userGroups.Add(group);

            return userGroups;
        }

        /// <summary>
        /// Gets a list of the users authorization groups
        /// </summary>
        /// <param name="sUserName">The user you want to get authorization groups</param>
        /// <returns>Returns an arraylist of group authorization memberships</returns>
        public ArrayList GetUserAuthorizationGroups(string sUserName)
        {
            ArrayList myItems = new ArrayList();
            UserPrincipal theUser = GetUser(sUserName);

            PrincipalSearchResult<Principal> searchResult = theUser.GetAuthorizationGroups();

            foreach (Principal oResult in searchResult)
            {
                myItems.Add(oResult.Name);
            }
            return myItems;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Gets the base principal context
        /// </summary>
        /// <returns>Retruns the PrincipalContext object</returns>
        public PrincipalContext GetPrincipalContext(string sUserName, string sPassword)
        {
            PrincipalContext theContext = new PrincipalContext(ContextType.Domain, "54.187.120.10", sUserName, sPassword);
            return theContext;
        }

        /// <summary>
        /// Gets the principal context on specified OU
        /// </summary>
        /// <param name="sOU">The OU you want your Principal Context to run on</param>
        /// <returns>Retruns the PrincipalContext object</returns>
        public PrincipalContext GetPrincipalContext(string sOU)
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain);
            return oPrincipalContext;
        }

        #endregion

    }
}

