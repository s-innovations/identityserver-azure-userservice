using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.Default;

namespace IdentityServer.AzureAdUserService
{
    public class AdUserService : UserServiceBase
    {
        public AdUserService(string clientId, string clientSecret, string tenant)
        {

            //setup B2CGraphClient
        }
        
        public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            //TODO  RO FLOW to Azure AD Tenant, see unit tests for prototype.
            

            return base.AuthenticateLocalAsync(context);
        }

        public override Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            return base.PostAuthenticateAsync(context);
        }
        public override Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject; //Should be the objectid of the user.
            //TODO Check with graph client that the account is enabled. See properties of GetAllUsers in unit tests
            return base.IsActiveAsync(context);
        }
        public override Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject;
            //TODO Use graph client with subject as objectid to query for profile info.
            return base.GetProfileDataAsync(context);
        }
        public override Task SignOutAsync(SignOutContext context)
        {
            //TODO Investigate if there is a endpoint on azure ad
            return base.SignOutAsync(context);
        }

        public override Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            return base.PreAuthenticateAsync(context);
        }
        public override Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            return base.AuthenticateExternalAsync(context);
        }
    }
}
