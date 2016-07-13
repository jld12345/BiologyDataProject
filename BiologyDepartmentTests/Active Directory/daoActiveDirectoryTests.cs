using NUnit.Framework;
using BiologyDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using ActiveDirectory;

namespace BiologyDepartment.Tests
{
    [TestFixture()]
    public class daoActiveDirectoryTests
    {
        [Test()]
        public void ValidateCredentialsTest()
        {
            daoActiveDirectory dao = new daoActiveDirectory();

            if (!dao.ValidateCredentials("james", "ImWay2c@@l"))
                Assert.Fail("Credentials did not validate");
            else if (dao.ValidateCredentials("james", "failme"))
                Assert.Fail("Credential should fail");
            else
                Assert.Pass("Validate Creditionals should work.");
        }

        [Test()]
        public void SetPrincipalContextTest()
        {
            daoActiveDirectory dao = new daoActiveDirectory();
           // dao.SetPrincipalContext("james", "ImWay2c@@l");
            if (dao.principalContext == null)
                Assert.Fail("Principal Context is null");
            else
                Assert.Pass("Principal Context should work");

        }

        [Test()]
        public void GetDBContextTest()
        {

        }

        [Test()]
        public void IsUserExpiredTest()
        {

        }

        [Test()]
        public void IsUserExisitingTest()
        {

        }

        [Test()]
        public void IsAccountLockedTest()
        {

        }

        [Test()]
        public void GetUserTest()
        {

        }

        [Test()]
        public void GetGroupTest()
        {

        }

        [Test()]
        public void SetUserPasswordTest()
        {

        }

        [Test()]
        public void EnableUserAccountTest()
        {

        }

        [Test()]
        public void DisableUserAccountTest()
        {

        }

        [Test()]
        public void ExpireUserPasswordTest()
        {

        }

        [Test()]
        public void UnlockUserAccountTest()
        {

        }

        [Test()]
        public void CreateNewUserTest()
        {

        }

        [Test()]
        public void DeleteUserTest()
        {

        }

        [Test()]
        public void CreateNewGroupTest()
        {

        }

        [Test()]
        public void AddUserToGroupTest()
        {

        }

        [Test()]
        public void RemoveUserFromGroupTest()
        {

        }

        [Test()]
        public void IsUserGroupMemberTest()
        {

        }

        [Test()]
        public void GetUserGroupsTest()
        {

        }

        [Test()]
        public void GetUserAuthorizationGroupsTest()
        {

        }

        [Test()]
        public void GetPrincipalContextTest()
        {

        }

        [Test()]
        public void GetPrincipalContextTest1()
        {

        }
    }
}