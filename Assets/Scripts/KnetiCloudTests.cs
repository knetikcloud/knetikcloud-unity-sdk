using com.knetikcloud.Api;
using com.knetikcloud.Credentials;
using com.knetikcloud.Events;
using com.knetikcloud.Model;
using KnetikUnity.Client;
using KnetikUnity.Events;
using KnetikUnity.Utils;
using UnityEngine;


namespace KnetikTests
{
    public class KnetiCloudTests : MonoBehaviour
    {
        #region Mono Behaviours
        private void Awake()
        {
            KnetikGlobalEventSystem.Subscribe<KnetikClientReadyResponseEvent>(OnClientReady);
            KnetikGlobalEventSystem.Subscribe<KnetikClientAuthenticateResponseEvent<OAuth2Resource>>(OnClientAuthenticateResponse);
        }

        private void Start()
        {
            // Due to order of initialization the client may send a notification of being ready before we setup our
            // listener for that event.  As such, we verify the status when the this object is initialized.
            KnetikGlobalEventSystem.Publish(new KnetikClientReadyRequestEvent(this));
        }

        private void OnDestroy()
        {
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientReadyResponseEvent>(OnClientReady);
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientAuthenticateResponseEvent<OAuth2Resource>>(OnClientAuthenticateResponse);
        }

        #endregion

        private void OnClientReady(KnetikClientReadyResponseEvent e)
        {
            if (e.ShouldProcess(this))
            {
                KnetikGlobalEventSystem.Publish(new KnetikCloudUserAuthenticateRequestEvent() { UserCredentials = KnetikUserCredentials.Load() });
            }
        }

        private static void OnClientAuthenticateResponse(KnetikClientAuthenticateResponseEvent<OAuth2Resource> e)
        {
            KnetikLogger.Log("*** CLIENT AUTHENTICATED SUCCESSFULLY ***");
            GetUserId();
        }

        private static void GetUserId()
        {
            UsersApi userApi = new UsersApi();
            userApi.GetUserComplete += GetUserComplete;

            userApi.GetUser("me");
        }

        private static void GetUserComplete(long responseCode, UserResource response)
        {
            KnetikLogger.Log("*** USER RETRIEVED SUCCESSFULLY ***");
            KnetikLogger.Log(response.ToString());

            KnetikLogger.Log("=== POLYMORPHIC TEST CONFIRMATION ===");

            foreach (string key in response.AdditionalProperties.Keys)
            {
                KnetikLogger.Log(string.Format("{0}\n{1}", key, response.AdditionalProperties[key]));
            }
        }
    }
}
