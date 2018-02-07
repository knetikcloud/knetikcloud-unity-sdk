using System.Collections.Generic;
using com.knetikcloud.Api;
using com.knetikcloud.Events;
using com.knetikcloud.Model;
using KnetikUnity.Client;
using KnetikUnity.Events;
using KnetikUnity.Exceptions;
using KnetikUnity.Utils;

namespace com.knetikcloud.Client
{
    /// <inheritdoc />
    /// <summary>
    /// The client that is responsible for making HTTP calls to the backend.
    /// </summary>
    public class KnetikCloudClient : KnetikClient
    {
        private const string StagingUrlFormat = "https://{0}.devsandbox.knetikcloud.com";
        private const string ProductionUrlFormat = "https://{0}.knetikcloud.com";
        private KnetikCloudProjectSettings mProjectSettings;
        private AccessTokenApi mAccessTokenApi;

        public override KnetikServerEnvironment ServerEnvironment
        {
            get
            {
                if ((mProjectSettings != null) && mProjectSettings.ProductionToggle)
                {
                    return KnetikServerEnvironment.Production;
                }

                return KnetikServerEnvironment.Staging;
            }
        }

        public override string BaseUrl
        {
            get
            {
                if (mProjectSettings == null)
                {
                    return string.Empty;
                }

                return string.Format((ServerEnvironment == KnetikServerEnvironment.Production) ? ProductionUrlFormat : StagingUrlFormat, mProjectSettings.AppName);
            }
        }

        public OAuth2Resource AuthToken { get; private set; }

        /// <summary>
        /// Authenticate with the server using user credentials
        /// </summary>
        protected void OnUserAuthenticateRequest(KnetikCloudUserAuthenticateRequestEvent e)
        {
            if (e.UserCredentials == null)
            {
                KnetikLogger.LogError("The event 'UserCredentials' cannot be null!");
                return;
            }

            if (!e.UserCredentials.IsConfigured)
            {
                KnetikLogger.LogError("The user credentials are not configured properly.  Please set them up in the editor window!");
                return;
            }

            SetupAccessTokenHelper();

            try
            {
                // Get access token
                mAccessTokenApi.GetOAuthToken(e.UserCredentials.GrantType, mProjectSettings.ClientId, null, e.UserCredentials.UserId, e.UserCredentials.Password, null, null);
            }
            catch (KnetikException)
            {
                // Error is already logged
            }
        }

        /// <summary>
        /// Authenticate with the server using secret client credentials
        /// </summary>
        protected void OnClientAuthenticateRequest(KnetikCloudClientAuthenticateRequestEvent e)
        {
            if (e.CloudCredentials == null)
            {
                KnetikLogger.LogError("The 'CloudCredentials' cannot be null!");
                return;
            }

            if (!e.CloudCredentials.IsConfigured)
            {
                KnetikLogger.LogError("The cloud credentials are not configured properly.  Please set them up in the editor window!");
                return;
            }

            SetupAccessTokenHelper();

            try
            {
                // Get access token
                mAccessTokenApi.GetOAuthToken(e.CloudCredentials.GrantType, mProjectSettings.ClientId, e.CloudCredentials.ClientSecret, null, null, null, null);
            }
            catch (KnetikException)
            {
                // Error is already logged
            }
        }

        /// <summary>
        /// Authenticate with the server using either a Google or Facebook open auth token.
        /// </summary>
        protected void OnTokenAuthenticateRequest(KnetikCloudTokenAuthenticateRequestEvent e)
        {
            if (e.TokenCredentials == null)
            {
                KnetikLogger.LogError("The 'tokenCredentials' cannot be null!");
                return;
            }

            if (!e.TokenCredentials.IsConfigured)
            {
                KnetikLogger.LogError("The token credentials are not configured properly.  Please set the token from the auth provider correctly.");
                return;
            }

            SetupAccessTokenHelper();

            try
            {
                // Get access token
                mAccessTokenApi.GetOAuthToken(e.TokenCredentials.GrantType, mProjectSettings.ClientId, null, null, null, e.TokenCredentials.Token, null);
            }
            catch (KnetikException)
            {
                // Error is already logged
            }
        }

        protected override void UpdateParamsForAuth(Dictionary<string, string> headerParams, List<string> authSettings)
        {
            if ((authSettings == null) || (authSettings.Count == 0))
            {
                return;
            }

            if (!authSettings.Contains("oauth2_client_credentials_grant") && !authSettings.Contains("oauth2_password_grant"))
            {
                return;
            }

            string authToken = string.Format("{0} {1}", mAccessTokenApi.GetOAuthTokenData.TokenType, mAccessTokenApi.GetOAuthTokenData.AccessToken);
            headerParams.Add("authorization", authToken);
        }

        protected override void Awake()
        {
            // Load project settings
            mProjectSettings = KnetikCloudProjectSettings.Load();
            if (mProjectSettings == null)
            {
                KnetikLogger.LogError("Unable to load project settings - please set them up in the editor window!");
                return;
            }

            if (!mProjectSettings.IsConfiguredProperly)
            {
                KnetikLogger.LogError("The project settings are not setup correctly - please set them in the editor window!");
                return;
            }

            KnetikGlobalEventSystem.Subscribe<KnetikCloudUserAuthenticateRequestEvent>(OnUserAuthenticateRequest);
            KnetikGlobalEventSystem.Subscribe<KnetikCloudClientAuthenticateRequestEvent>(OnClientAuthenticateRequest);
            KnetikGlobalEventSystem.Subscribe<KnetikCloudTokenAuthenticateRequestEvent>(OnTokenAuthenticateRequest);

            base.Awake();
        }

        protected override void OnDestroy()
        {
            KnetikGlobalEventSystem.Unsubscribe<KnetikCloudUserAuthenticateRequestEvent>(OnUserAuthenticateRequest);
            KnetikGlobalEventSystem.Unsubscribe<KnetikCloudClientAuthenticateRequestEvent>(OnClientAuthenticateRequest);
            KnetikGlobalEventSystem.Unsubscribe<KnetikCloudTokenAuthenticateRequestEvent>(OnTokenAuthenticateRequest);

            mAccessTokenApi = null;
            mProjectSettings = null;

            base.OnDestroy();
        }

        private void GetOAuthTokenComplete(long responseCode, OAuth2Resource response)
        {
            AuthToken = response;
            KnetikGlobalEventSystem.Publish(new KnetikClientAuthenticateResponseEvent<OAuth2Resource> (null) { AuthToken = AuthToken });
        }

        private void SetupAccessTokenHelper()
        {
            mAccessTokenApi = new AccessTokenApi();
            mAccessTokenApi.GetOAuthTokenComplete += GetOAuthTokenComplete;
        }
    }
}
