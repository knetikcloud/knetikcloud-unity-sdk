using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Credentials;
using com.knetikcloud.Events;
using com.knetikcloud.Model;
using com.knetikcloud.Utils;
using UnityEngine;


namespace KnetikTests
{
    public class KnetiApiTests : MonoBehaviour
    {
        #region Mono Behaviours
        private void Awake()
        {
            KnetikGlobalEventSystem.Subscribe<KnetikClientReadyResponseEvent>(OnClientReady);
            KnetikGlobalEventSystem.Subscribe<KnetikClientAuthenticatedEvent>(OnClientAuthenticated);
        }

        private void Start()
        {
            // Due to order of initialization the client may send a notification of being ready before we setup our
            // listener for that event.  As such, we verify the status when the this object is initialized.
            KnetikGlobalEventSystem.Publish(KnetikClientReadyRequestEvent.GetInstance(this));
        }

        private void OnDestroy()
        {
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientReadyResponseEvent>(OnClientReady);
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientAuthenticatedEvent>(OnClientAuthenticated);
        }

        #endregion

        private void OnClientReady(KnetikClientReadyResponseEvent e)
        {
            if (e.ShouldProcess(this))
            {
                KnetikClient.DefaultClient.AuthenticateWithUserCredentials(KnetikClient.ServerEnvironment.Staging, KnetikUserCredentials.Load());
//                KnetikClient.DefaultClient.AuthenticateWithClientCredentials(KnetikClient.ServerEnvironment.Staging, KnetikClientCredentials.Load());
            }
        }

        private void OnClientAuthenticated(KnetikClientAuthenticatedEvent e)
        {
            KnetikLogger.Log("*** TEST SUCCESSFUL***");
            GetUserId();
        }

        private void GetUserId()
        {
            UsersApi userApi = new UsersApi();
            userApi.GetUserComplete += GetUserComplete;

            userApi.GetUser("me");
        }

        private void GetUserComplete(UserResource response)
        {
            KnetikLogger.Log(response.ToString());
        }
    }
}
