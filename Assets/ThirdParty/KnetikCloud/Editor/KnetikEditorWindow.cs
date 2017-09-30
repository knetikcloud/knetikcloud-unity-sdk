using com.knetikcloud.Client;
using com.knetikcloud.Credentials;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikEditorWindow : EditorWindow
    {
        private KnetikUserCredentials mUserCredentials;

        private GUIContent mProjectSettingsHeaderLabel;
        private GUIContent mAppName;
        private GUIContent mClientId;

        private GUIContent mClientCredentialsHeaderLabel;
        private GUIContent mClientSecret;

        private GUIContent mUserCredentialsHeaderLabel;
        private GUIContent mUserCredentialsId;
        private GUIContent mUserCredentialsPassword;

        private GUIContent mSaveButton;

        [MenuItem("Knetik Cloud/Project Settings...")]
        private static void KnetikCloudProjectSettings()
        {
            GetWindow<KnetikEditorWindow>("Knetik Editor Window");
        }

        private void OnEnable()
        {
            // Ensure the settings are loaded (if available)
            KnetikEditorConfigurationManager.Initialize();
            mUserCredentials = KnetikUserCredentials.Load();

            mProjectSettingsHeaderLabel = new GUIContent("Project KnetikConfiguration", "Project wide settings that should be checked into source control (if used).");
            mAppName = new GUIContent("App Name", "The App Name for your project as configured in the KnetikCloud Web interface.  E.g. 'my-first-game' (without quotes).");
            mClientId = new GUIContent("Client ID", "The client ID as configured in the KnetikCloud Web interface.");

            mClientCredentialsHeaderLabel = new GUIContent("Client Credentials", "Optional: Settings that apply if the grant type is 'client_credentials'.\nShould be checked into source control (if used).");
            mClientSecret = new GUIContent("Client Secret", "Optional: Must match the secret configured in the KnetikCloud Web interface.");

            mUserCredentialsHeaderLabel = new GUIContent("User Credentials", "Optional: Per developer settings that apply if the grant type is 'password'.");
            mUserCredentialsId = new GUIContent("User Id", "Optional: Per developer user account to use.");
            mUserCredentialsPassword = new GUIContent("Password", "Optional: Per developer account password to use.");

            mSaveButton = new GUIContent("Save");
        }

        private void OnGUI()
        {
            DrawProjectSettingsGUI();
            DrawClientCredentialsGUI();
            DrawUserCredentialsGUI();

            if (GUI.changed)
            {
                KnetikEditorConfigurationManager.SetDirty();
            }

            if (GUILayout.Button(mSaveButton))
            {
                SaveSettings();
            }

            Repaint();
        }

        private void DrawProjectSettingsGUI()
        {
            EditorGUILayout.LabelField(mProjectSettingsHeaderLabel, EditorStyles.boldLabel);

            KnetikEditorConfigurationManager.AppName = EditorGUILayout.TextField(mAppName, KnetikEditorConfigurationManager.AppName);
            KnetikEditorConfigurationManager.ClientId = EditorGUILayout.TextField(mClientId, KnetikEditorConfigurationManager.ClientId);
            EditorGUILayout.Space();
        }

        private void DrawClientCredentialsGUI()
        {
            EditorGUILayout.LabelField(mClientCredentialsHeaderLabel, EditorStyles.boldLabel);
            KnetikEditorConfigurationManager.ClientSecret = EditorGUILayout.TextField(mClientSecret, KnetikEditorConfigurationManager.ClientSecret);
            EditorGUILayout.Space();
        }

        private void DrawUserCredentialsGUI()
        {
            EditorGUILayout.LabelField(mUserCredentialsHeaderLabel, EditorStyles.boldLabel);
            mUserCredentials.UserId = EditorGUILayout.TextField(mUserCredentialsId, mUserCredentials.UserId);
            mUserCredentials.Password = EditorGUILayout.PasswordField(mUserCredentialsPassword, mUserCredentials.Password);
            EditorGUILayout.Space();
        }

        private void SaveSettings()
        {
            KnetikEditorScriptableObjectUtis.SavePersistentData();
            KnetikUserCredentials.Save(mUserCredentials);
        }
    }
}
