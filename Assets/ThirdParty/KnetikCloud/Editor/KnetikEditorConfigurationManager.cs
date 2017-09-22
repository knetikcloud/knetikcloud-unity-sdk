using com.knetikcloud.Client;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikEditorConfigurationManager
    {
        [SerializeField]
        private static KnetikProjectSettings sProjectSettings;

        public static bool IsBaseUrlSet
        {
            get
            {
                return ((sProjectSettings != null) && !string.IsNullOrEmpty(sProjectSettings.BaseUrl));
            }
        }

        public static string BaseUrl
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.BaseUrl : null;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.BaseUrl = value;
                }
            }
        }

        public static string GrantType
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.GrantType : null;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.GrantType = value;
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

        public static string ClientSecret
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.ClientSecret : null;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.ClientSecret = value;
                }
            }
        }

        public static void Initialize()
        {
            // NOTE: When the play button is pressed, all editor objects are unloaded so we need to reload things:  https://blogs.unity3d.com/2012/10/25/unity-serialization/
            if (sProjectSettings == null)
            {
                sProjectSettings = KnetikEditorScriptableObjectUtis.LoadPersistentData<KnetikProjectSettings>(KnetikProjectSettings.SaveDataPath);
                if (sProjectSettings == null)
                {
                    sProjectSettings = ScriptableObject.CreateInstance<KnetikProjectSettings>();
                    KnetikEditorAssetDatabaseUtils.CreateAssetAndDirectories(sProjectSettings, KnetikProjectSettings.SaveDataPath);
                }
            }
        }

        public static void SetDirty()
        {
            if (sProjectSettings != null)
            {
                EditorUtility.SetDirty(sProjectSettings);
            }
        }
    }
}
