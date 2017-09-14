using UnityEngine;
using UnityEditor;
using com.knetikcloud.Client;

namespace com.knetikcloud.UnityEditor
{
    public static class KnetikEditorExtensions
    {
        public const string GettingStartedMenuItem = "Knetik Cloud/Getting Started...";
        public const string ApiDocsMenuItem = "Knetik Cloud/API Docs...";

        public static KnetikProjectSettings ProjectSettings;

        static KnetikEditorExtensions()
        {
            LoadProjectSettings();
        }

        public static void LoadProjectSettings()
        {
            if (ProjectSettings == null)
            {
                ProjectSettings = KnetikEditorScriptableObjectUtis.LoadPersistentData<KnetikProjectSettings>(KnetikProjectSettings.SaveDataPath);
                if (ProjectSettings == null)
                {
                    ProjectSettings = ScriptableObject.CreateInstance<KnetikProjectSettings>();
                    KnetikEditorAssetDatabaseUtils.CreateAssetAndDirectories(ProjectSettings, KnetikProjectSettings.SaveDataPath);
                }
            }
        }

        [MenuItem("Knetik Cloud/Sign up...")]
        private static void SignUp()
        {
            Application.OpenURL("http://knetikcloud.com/");
        }

        [MenuItem(GettingStartedMenuItem)]
        private static void GettingStarted()
        {
            if ((ProjectSettings != null) && (!string.IsNullOrEmpty(ProjectSettings.BaseUrl)))
            {
                Application.OpenURL(ProjectSettings.BaseUrl);
            }
        }

        [MenuItem(GettingStartedMenuItem, true)]
        private static bool CheckGettingStarted()
        {
            return ((ProjectSettings != null) && (!string.IsNullOrEmpty(ProjectSettings.BaseUrl)));
        }

        [MenuItem(ApiDocsMenuItem)]
        private static void ApiDocs()
        {
            if ((ProjectSettings != null) && (!string.IsNullOrEmpty(ProjectSettings.BaseUrl)))
            {
                Application.OpenURL(ProjectSettings.BaseUrl + "/api.html");
            }
        }

        [MenuItem(ApiDocsMenuItem, true)]
        private static bool CheckApiDocs()
        {
            return ((ProjectSettings != null) && (!string.IsNullOrEmpty(ProjectSettings.BaseUrl)));
        }
    }
}
