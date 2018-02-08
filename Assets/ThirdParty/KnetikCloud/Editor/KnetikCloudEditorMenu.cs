using KnetikUnityEditor;
using UnityEngine;
using UnityEditor;


namespace com.knetikcloud.UnityEditor
{
    public static class KnetikCloudEditorMenu
    {
        public const string GettingStartedMenuItem = "Knetik Cloud/Getting Started...";
        public const string ApiDocsMenuItem = "Knetik Cloud/API Docs...";

        static KnetikCloudEditorMenu()
        {
            KnetikCloudEditorConfigurationManager.Initialize();
        }

        [MenuItem("Knetik Cloud/Sign up...")]
        private static void SignUp()
        {
            Application.OpenURL(KnetikCloudConstants.KnetikCloudWebsiteUrl);
        }


        [MenuItem(GettingStartedMenuItem, true)]
        private static bool CheckGettingStarted()
        {
            return KnetikCloudEditorConfigurationManager.IsAppNameSet;
        }

        [MenuItem(GettingStartedMenuItem)]
        private static void GettingStarted()
        {
            if (KnetikCloudEditorConfigurationManager.IsAppNameSet)
            {
                Application.OpenURL(KnetikCloudEditorConfigurationManager.StagingUrl);
            }
        }

        [MenuItem(ApiDocsMenuItem, true)]
        private static bool CheckApiDocs()
        {
            return KnetikCloudEditorConfigurationManager.IsAppNameSet;
        }

        [MenuItem(ApiDocsMenuItem)]
        private static void ApiDocs()
        {
            if (KnetikCloudEditorConfigurationManager.IsAppNameSet)
            {
                Application.OpenURL(KnetikCloudEditorConfigurationManager.StagingUrl + "/api.html");
            }
        }
    }
}
