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
            KnetikEditorExtensions.LoadProjectSettings();

            mUserCredentials = KnetikUserCredentials.Load();

            mProjectSettingsHeaderLabel = new GUIContent("Project KnetikConfiguration");

            mBaseUrl = new GUIContent("Base URL");
            mGrantType = new GUIContent("Grant Type");
            mClientId = new GUIContent("Client Id");
            mClientSecret = new GUIContent("Client Secret");

            mUserSettingsHeaderLabel = new GUIContent("Per User Settings");
            mUserId = new GUIContent("User Id");
            mPassword = new GUIContent("Password");

            mSaveButton = new GUIContent("Save");
        }

        private void OnGUI()
        {
            DrawProjectSettingsGUI();
            DrawUserSettingsGUI();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(KnetikEditorExtensions.ProjectSettings);
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

            KnetikEditorExtensions.ProjectSettings.BaseUrl = EditorGUILayout.TextField(mBaseUrl, KnetikEditorExtensions.ProjectSettings.BaseUrl);
            KnetikEditorExtensions.ProjectSettings.GrantType = EditorGUILayout.TextField(mGrantType, KnetikEditorExtensions.ProjectSettings.GrantType);
            KnetikEditorExtensions.ProjectSettings.ClientId = EditorGUILayout.TextField(mClientId, KnetikEditorExtensions.ProjectSettings.ClientId);
            KnetikEditorExtensions.ProjectSettings.ClientSecret = EditorGUILayout.TextField(mClientSecret, KnetikEditorExtensions.ProjectSettings.ClientSecret);
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
