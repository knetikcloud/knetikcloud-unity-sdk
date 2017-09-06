using UnityEngine;
using UnityEditor;


namespace com.knetikcloud.UnityEditor
{
    public static class KnetikEditorExtensions
    {
        [MenuItem("Knetik Cloud/Sign up...")]
        private static void SignUp()
        {
            Application.OpenURL("http://knetikcloud.com/");
        }

        [MenuItem("Knetik Cloud/Getting Started...")]
        private static void GettingStarted()
        {
            Application.OpenURL("https://sandbox.knetikcloud.com/index.html");
        }

        [MenuItem("Knetik Cloud/API Docs...")]
        private static void APIDocs()
        {
            Application.OpenURL("https://sandbox.knetikcloud.com/api.html");
        }
    }
}
