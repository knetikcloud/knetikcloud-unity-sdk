using com.knetikcloud.Client;
using com.knetikcloud.Credentials;
using KnetikUnityEditor;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikCloudEditorConfigurationManager
    {
        [SerializeField]
        private static KnetikCloudProjectSettings sProjectSettings;

        [SerializeField]
        private static KnetikCloudCredentials sCloudCredentials;

        public static bool IsAppNameSet
        {
            get
            {
                return ((sProjectSettings != null) && !string.IsNullOrEmpty(sProjectSettings.AppName));
            }
        }

        public static string AppName
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.AppName : null;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.AppName = value;
                }
            }
        }

        public static string ClientId
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.ClientId : null;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.ClientId = value;
                }
            }
        }

        public static bool ProductionToggle
        {
            get
            {
                return (sProjectSettings != null) && sProjectSettings.ProductionToggle;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.ProductionToggle = value;
                }
            }
        }

        public static string ClientSecret
        {
            get
            {
                return (sCloudCredentials != null) ? sCloudCredentials.ClientSecret : null;
            }
            set
            {
                if (sCloudCredentials != null)
                {
                    sCloudCredentials.ClientSecret = value;
                }
            }
        }

        public static string StagingURL
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.StagingURL : null;
            }
        }

        public static void Initialize()
        {
            // NOTE: When the play button is pressed, all editor objects are unloaded so we need to reload things:  https://blogs.unity3d.com/2012/10/25/unity-serialization/
            if (sProjectSettings == null)
            {
                sProjectSettings = KnetikEditorScriptableObjectUtis.LoadPersistentData<KnetikCloudProjectSettings>(KnetikCloudProjectSettings.SaveDataPath);
                if (sProjectSettings == null)
                {
                    sProjectSettings = ScriptableObject.CreateInstance<KnetikCloudProjectSettings>();
                    KnetikEditorAssetDatabaseUtils.CreateAssetAndDirectories(sProjectSettings, KnetikCloudProjectSettings.SaveDataPath);
                }
            }

            if (sCloudCredentials == null)
            {
                sCloudCredentials = KnetikEditorScriptableObjectUtis.LoadPersistentData<KnetikCloudCredentials>(KnetikCloudCredentials.SaveDataPath);
                if (sCloudCredentials == null)
                {
                    sCloudCredentials = ScriptableObject.CreateInstance<KnetikCloudCredentials>();
                    KnetikEditorAssetDatabaseUtils.CreateAssetAndDirectories(sCloudCredentials, KnetikCloudCredentials.SaveDataPath);
                }
            }
        }

        public static void SetDirty()
        {
            if (sProjectSettings != null)
            {
                EditorUtility.SetDirty(sProjectSettings);
            }

            if (sCloudCredentials != null)
            {
                EditorUtility.SetDirty(sCloudCredentials);
            }
        }
    }
}
