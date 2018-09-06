using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace GISProgram.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/GISProgram/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
                else if (context.ClientId == "web")
                {
                    var expectedUri = new Uri(context.Request.Uri, "/GISProgram/");
                    context.Validated(expectedUri.AbsoluteUri);
                }
            }

            return Task.FromResult<object>(null);
        }

        //public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        //{
        //    if (context.ClientId == _publicClientId)
        //    {
        //        Uri expectedRootUri;
        //        if (!string.IsNullOrEmpty(context.Request.Query["returnUrl"]))
        //        {
        //            expectedRootUri = new Uri(context.Request.Query["returnUrl"]);
        //        }
        //        else
        //        {
        //            expectedRootUri = new Uri(context.Request.Uri, "/");
        //        }

        //        if (expectedRootUri.AbsoluteUri == context.RedirectUri)
        //        {
        //            context.Validated();
        //        }
        //        else if (context.ClientId == "web")
        //        {
        //            var expectedUri = new Uri(context.Request.Query["returnUrl"]);
        //            context.Validated(expectedUri.AbsoluteUri);
        //        }
        //    }

        //    return Task.FromResult<object>(null);
        //}
    }
}