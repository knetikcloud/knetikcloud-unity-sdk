using com.knetikcloud.Client;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikEditorWindow : EditorWindow
    {
        private KnetikProjectSettings _projectSettings;
        private KnetikUserCredentials _userCredentials;

        private GUIContent _projectSettingsHeaderLabel;
        private GUIContent _baseUrl;
        private GUIContent _grantType;
        private GUIContent _clientId;
        private GUIContent _clientSecret;

        private GUIContent _userSettingsHeaderLabel;
        private GUIContent _userId;
        private GUIContent _password;

        private GUIContent _saveButton;

        [MenuItem("Knetik Cloud/Project Settings...")]
        private static void KnetikCloudProjectSettings()
        {
            EditorWindow.GetWindow<KnetikEditorWindow>("Knetik Editor Window");
        }

        private void OnEnable()
        {
            _projectSettings = KnetikEditorScriptableObjectUtis.LoadPersistentData<KnetikProjectSettings>(KnetikProjectSettings.SaveDataPath);
            if (_projectSettings == null)
            {
                _projectSettings = ScriptableObject.CreateInstance<KnetikProjectSettings>();
                KnetikEditorAssetDatabaseUtils.CreateAssetAndDirectories(_projectSettings, KnetikProjectSettings.SaveDataPath);
            }

            _userCredentials = KnetikUserCredentials.Load();

            _projectSettingsHeaderLabel = new GUIContent("Project KnetikConfiguration");

            _baseUrl = new GUIContent("Base URL");
            _grantType = new GUIContent("Grant Type");
            _clientId = new GUIContent("Client Id");
            _clientSecret = new GUIContent("Client Secret");

            _userSettingsHeaderLabel = new GUIContent("Per User Settings");
            _userId = new GUIContent("User Id");
            _password = new GUIContent("Password");

            _saveButton = new GUIContent("Save");
        }

        private void OnGUI()
        {
            DrawProjectSettingsGUI();
            DrawUserSettingsGUI();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(_projectSettings);
            }

            if (GUILayout.Button(_saveButton))
            {
                SaveSettings();
            }

            Repaint();
        }

        private void DrawProjectSettingsGUI()
        {
            EditorGUILayout.LabelField(_projectSettingsHeaderLabel, EditorStyles.boldLabel);

            _projectSettings.BaseUrl = EditorGUILayout.TextField(_baseUrl, _projectSettings.BaseUrl);
            _projectSettings.GrantType = EditorGUILayout.TextField(_grantType, _projectSettings.GrantType);
            _projectSettings.ClientId = EditorGUILayout.TextField(_clientId, _projectSettings.ClientId);
            _projectSettings.ClientSecret = EditorGUILayout.TextField(_clientSecret, _projectSettings.ClientSecret);
            EditorGUILayout.Space();
        }

        private void DrawUserSettingsGUI()
        {
            EditorGUILayout.LabelField(_userSettingsHeaderLabel, EditorStyles.boldLabel);
            _userCredentials.UserId = EditorGUILayout.TextField(_userId, _userCredentials.UserId);
            _userCredentials.Password = EditorGUILayout.TextField(_password, _userCredentials.Password);
            EditorGUILayout.Space();
        }

        private void SaveSettings()
        {
            KnetikEditorScriptableObjectUtis.SavePersistentData();
            KnetikUserCredentials.Save(_userCredentials);
        }
    }
}
