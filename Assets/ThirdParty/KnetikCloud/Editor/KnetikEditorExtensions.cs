using UnityEngine;
using UnityEditor;


namespace com.knetikcloud.UnityEditor
{
    public static class KnetikEditorExtensions
    {
        public const string GettingStartedMenuItem = "Knetik Cloud/Getting Started...";
        public const string ApiDocsMenuItem = "Knetik Cloud/API Docs...";

        static KnetikEditorExtensions()
        {
            KnetikEditorConfigurationManager.Initialize();
        }

        [MenuItem("Knetik Cloud/Sign up...")]
        private static void SignUp()
        {
            Application.OpenURL("http://knetikcloud.com/");
        }


        [MenuItem(GettingStartedMenuItem, true)]
        private static bool CheckGettingStarted()
        {
            return KnetikEditorConfigurationManager.IsAppNameSet;
        }

        [MenuItem(GettingStartedMenuItem)]
        private static void GettingStarted()
        {
            if (KnetikEditorConfigurationManager.IsAppNameSet)
            {
                Application.OpenURL(KnetikEditorConfigurationManager.BaseStagingUrl);
            }
        }

        [MenuItem(ApiDocsMenuItem, true)]
        private static bool CheckApiDocs()
        {
            return KnetikEditorConfigurationManager.IsAppNameSet;
        }

        [MenuItem(ApiDocsMenuItem)]
        private static void ApiDocs()
        {
            if (KnetikEditorConfigurationManager.IsAppNameSet)
            {
                Application.OpenURL(KnetikEditorConfigurationManager.BaseStagingUrl + "/api.html");
            }
        }
    }
}
