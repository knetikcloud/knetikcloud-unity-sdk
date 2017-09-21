using com.knetikcloud.Client;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikEditorWindow : EditorWindow
    {
        private KnetikUserCredentials mUserCredentials;

        private GUIContent mProjectSettingsHeaderLabel;
        private GUIContent mBaseUrl;
        private GUIContent mGrantType;
        private GUIContent mClientId;
        private GUIContent mClientSecret;

        private GUIContent mUserSettingsHeaderLabel;
        private GUIContent mUserId;
        private GUIContent mPassword;

        private GUIContent mSaveButton;

        [MenuItem("Knetik Cloud/Project Settings...")]
        private static void KnetikCloudProjectSettings()
        {
            EditorWindow.GetWindow<KnetikEditorWindow>("Knetik Editor Window");
        }

        private void OnEnable()
        {
            // Ensure the settings are loaded (if available)
            KnetikEditorConfigurationManager.Initialize();

            mUserCredentials = KnetikUserCredentials.Load();

            mProjectSettingsHeaderLabel = new GUIContent("Project KnetikConfiguration", "Project wide settings that should be checked into source control (if used).");

            mBaseUrl = new GUIContent("Base URL", "The base URL for your project.  E.g. https://<my_project_name>.devsandbox.knetikcloud.com");
            mGrantType = new GUIContent("Grant Type", "The type of credentials you will use to authenticate.  E.g. 'password', 'client_credentials', 'facebook', or 'google'.");
            mClientId = new GUIContent("Client ID", "The client ID as configured in the administrative panel.");
            mClientSecret = new GUIContent("Client Secret", "Optional: Only used with a grant type of 'client_credentials'.");

            mUserSettingsHeaderLabel = new GUIContent("Per User Settings", "Optional: Per developer settings that are only used if the grant type is set to 'password'.");
            mUserId = new GUIContent("User Id", "Optional: User account to use for development if the grant type is set to 'client_credentials'.");
            mPassword = new GUIContent("Password", "Optional: User password to use for development if the grant type is set to 'client_credentials'.");

            mSaveButton = new GUIContent("Save");
        }

        private void OnGUI()
        {
            DrawProjectSettingsGUI();
            DrawUserSettingsGUI();

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

            KnetikEditorConfigurationManager.BaseUrl = EditorGUILayout.TextField(mBaseUrl, KnetikEditorConfigurationManager.BaseUrl);
            KnetikEditorConfigurationManager.GrantType = EditorGUILayout.TextField(mGrantType, KnetikEditorConfigurationManager.GrantType);
            KnetikEditorConfigurationManager.ClientId = EditorGUILayout.TextField(mClientId, KnetikEditorConfigurationManager.ClientId);
            KnetikEditorConfigurationManager.ClientSecret = EditorGUILayout.TextField(mClientSecret, KnetikEditorConfigurationManager.ClientSecret);
            EditorGUILayout.Space();
        }

        private void DrawUserSettingsGUI()
        {
            EditorGUILayout.LabelField(mUserSettingsHeaderLabel, EditorStyles.boldLabel);
            mUserCredentials.UserId = EditorGUILayout.TextField(mUserId, mUserCredentials.UserId);
            mUserCredentials.Password = EditorGUILayout.TextField(mPassword, mUserCredentials.Password);
            EditorGUILayout.Space();
        }

        private void SaveSettings()
        {
            KnetikEditorScriptableObjectUtis.SavePersistentData();
            KnetikUserCredentials.Save(mUserCredentials);
        }
    }
}
