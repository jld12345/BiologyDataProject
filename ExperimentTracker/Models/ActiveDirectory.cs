using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Windows.Forms;

namespace ExperimentTracker
{
    public class ActiveDirectory
    { 
            private PrincipalContext _PrincipalContext;

            public PrincipalContext principalContext
            {
                get
                {
                    return this._PrincipalContext;
                }
            }

            public string ADUserName { get; set; }

            public string ADPass { get; set; }

            public string DBUser { get; set; }

            public string DBPass { get; set; }

            public string ADUserGroup { get; set; }

            public bool ValidateCredentials(string sUserName, string sPassword)
            {
                try
                {
                    _PrincipalContext = this.GetPrincipalContext(sUserName, sPassword, Properties.Settings.Default.MyActiveDirectory);
                    if (this._PrincipalContext == null)
                        return false;
                    bool flag = false;
                    try
                    {
                        string myActiveDirectory = Properties.Settings.Default.MyActiveDirectory;
                        using (LdapConnection ldapConnection = new LdapConnection(new LdapDirectoryIdentifier(myActiveDirectory)))
                        {
                            ldapConnection.Bind(new NetworkCredential(sUserName, sPassword, myActiveDirectory));
                            flag = true;
                        }
                    }
                    catch (LdapException ex)
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        this.GetDBContext(sUserName);
                        this.ADUserName = sUserName;
                        this.ADPass = sPassword;
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public void SetPrincipalContext(string sUserName, string sPassword, string ActiveDirectoryConnection)
            {
                this._PrincipalContext = this.GetPrincipalContext(sUserName, sPassword, ActiveDirectoryConnection);
            }

            public void GetDBContext(string sUserName)
            {
                UserPrincipal user = this.GetUser(sUserName);
                GroupPrincipal group = this.GetGroup("PostgresDatabaseAdmin");
                if (group == null && !group.Members.Contains(user))
                {
                    group = this.GetGroup("PostgresDatabaseUser");
                    if (group == null || group.Members.Contains(user))
                        return;
                }
                DirectoryEntry underlyingObject = group.GetUnderlyingObject() as DirectoryEntry;
                this.DBUser = underlyingObject.Properties["displayName"].Value.ToString();
                this.DBPass = underlyingObject.Properties["description"].Value.ToString();
                this.ADUserGroup = group.Name;
            }

            public bool IsUserExpired(string sUserName)
            {
                return !this.GetUser(sUserName).AccountExpirationDate.HasValue;
            }

            public bool IsUserExisiting(string sUserName)
            {
                return this.GetUser(sUserName) != null;
            }

            public bool IsAccountLocked(string sUserName)
            {
                return this.GetUser(sUserName).IsAccountLockedOut();
            }

            public UserPrincipal GetUser(string sUserName)
            {
                UserPrincipal byIdentity = UserPrincipal.FindByIdentity(this._PrincipalContext, sUserName);
                return byIdentity;
            }

            public GroupPrincipal GetGroup(string sGroupName)
            {
                GroupPrincipal byIdentity = GroupPrincipal.FindByIdentity(this._PrincipalContext, sGroupName);
                return byIdentity;
            }

            public void SetUserPassword(string sUserName, string sNewPassword, out string sMessage)
            {
                try
                {
                    this.GetUser(sUserName).SetPassword(sNewPassword);
                    sMessage = "The Password has been changed.";
                }
                catch (Exception ex)
                {
                    sMessage = ex.Message;
                }
            }

            public void EnableUserAccount(string sUserName)
            {
                UserPrincipal user = this.GetUser(sUserName);
                user.Enabled = new bool?(true);
                user.Save();
            }

            public void DisableUserAccount(string sUserName)
            {
                UserPrincipal user = this.GetUser(sUserName);
                user.Enabled = new bool?(false);
                user.Save();
            }

            public void ExpireUserPassword(string sUserName)
            {
                UserPrincipal user = this.GetUser(sUserName);
                user.ExpirePasswordNow();
                user.Save();
            }

            public void UnlockUserAccount(string sUserName)
            {
                UserPrincipal user = this.GetUser(sUserName);
                user.UnlockAccount();
                user.Save();
            }

            public UserPrincipal CreateNewUser(string sOU, string sUserName, string sPassword, string sGivenName, string sSurname)
            {
                if (this.IsUserExisiting(sUserName))
                    return this.GetUser(sUserName);
                UserPrincipal userPrincipal = new UserPrincipal(this._PrincipalContext, sUserName, sPassword, true);
                userPrincipal.UserPrincipalName = sUserName;
                userPrincipal.GivenName = sGivenName;
                userPrincipal.Surname = sSurname;
                userPrincipal.Save();
                return userPrincipal;
            }

            public bool DeleteUser(string sUserName)
            {
                try
                {
                    this.GetUser(sUserName).Delete();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public GroupPrincipal CreateNewGroup(string sOU, string sGroupName, string sDescription, GroupScope oGroupScope, bool bSecurityGroup)
            {
                GroupPrincipal groupPrincipal = new GroupPrincipal(this._PrincipalContext, sGroupName);
                groupPrincipal.Description = sDescription;
                groupPrincipal.GroupScope = new GroupScope?(oGroupScope);
                groupPrincipal.IsSecurityGroup = new bool?(bSecurityGroup);
                groupPrincipal.Save();
                return groupPrincipal;
            }

            public bool AddUserToGroup(string sUserName, string sGroupName)
            {
                return true;
            }

            public bool RemoveUserFromGroup(string sUserName, string sGroupName)
            {
                return true;
            }

            public GroupPrincipal IsUserGroupMember(string sUserName, string sGroupName)
            {
                UserPrincipal user = this.GetUser(sUserName);
                GroupPrincipal group = this.GetGroup(sGroupName);
                if (group != null && group.Members.Contains(user))
                    return group;
                return (GroupPrincipal)null;
            }

            public List<GroupPrincipal> GetUserGroups(string sUserName)
            {
                UserPrincipal user = this.GetUser(sUserName);
                List<GroupPrincipal> groupPrincipalList = new List<GroupPrincipal>();
                foreach (GroupPrincipal group in user.GetGroups())
                    groupPrincipalList.Add(group);
                return groupPrincipalList;
            }

            public ArrayList GetUserAuthorizationGroups(string sUserName)
            {
                ArrayList arrayList = new ArrayList();
                foreach (Principal authorizationGroup in this.GetUser(sUserName).GetAuthorizationGroups())
                    arrayList.Add((object)authorizationGroup.Name);
                return arrayList;
            }

            public PrincipalContext GetPrincipalContext(string sUserName, string sPassword, string ActiveDirectoryConnection)
            {
                try
                {
                    PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, ActiveDirectoryConnection, sUserName, sPassword);
                    return principalContext;
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(ex.ToString(), "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return (PrincipalContext)null;
                }
            }

            public PrincipalContext GetPrincipalContext(string sOU)
            {
                return new PrincipalContext(ContextType.Domain);
            }
        }
    }



