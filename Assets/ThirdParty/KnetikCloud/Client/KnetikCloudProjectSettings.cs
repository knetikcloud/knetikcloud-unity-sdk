using System;
using UnityEngine;

namespace com.knetikcloud.Client
{
    [Serializable]
    public class KnetikCloudProjectSettings : ScriptableObject
    {
        public const string SaveDataPath = "Assets\\Resources\\KnetikCloud\\KnetikCloudSettings.asset";
        public const string ResourceName = "KnetikCloud\\KnetikCloudSettings";

        public string AppName;
        public string ClientId;
        public bool ProductionToggle;

        public string StagingURL
        {
            get
            {
                if (string.IsNullOrEmpty(AppName))
                {
                    return string.Empty;
                }

                return string.Format("https://{0}.devsandbox.knetikcloud.com", AppName);
            }
        }


        public bool IsConfiguredProperly
        {
            get { return (!string.IsNullOrEmpty(AppName) && (!string.IsNullOrEmpty(ClientId))); }
        }

        public KnetikCloudProjectSettings()
        {
            AppName = string.Empty;
            ClientId = string.Empty;
            ProductionToggle = false;
        }

        public static KnetikCloudProjectSettings Load()
        {
            return Resources.Load<KnetikCloudProjectSettings>(ResourceName);
        }
    }
}
