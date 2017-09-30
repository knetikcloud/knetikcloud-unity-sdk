using System;
using UnityEngine;


namespace com.knetikcloud.Client
{
    [Serializable]
    public class KnetikProjectSettings : ScriptableObject
    {
        private const string StagingUrlFormat = "https://{0}.devsandbox.knetikcloud.com";
        private const string ProductionUrlFormat = "https://{0}.knetikcloud.com";

        [SerializeField]
        private string mAppName;

        [SerializeField]
        private string mStagingURL;

        [SerializeField]
        private string mProductionURL;

        public const string SaveDataPath = "Assets\\Resources\\KnetikCloud\\KnetikProjectSettings.asset";
        public const string ResourceName = "KnetikCloud\\KnetikProjectSettings";

        public string AppName
        {
            get { return mAppName; }
            set
            {
                mAppName = value;

                mStagingURL = string.Format(StagingUrlFormat, mAppName);
                mProductionURL = string.Format(ProductionUrlFormat, mAppName);
            }
        }

        public string ClientId;

        public string StagingUrl
        {
            get { return mStagingURL; }
        }

        public string ProductionUrl
        {
            get { return mProductionURL; }
        }

        public bool IsConfiguredProperly
        {
            get { return (!string.IsNullOrEmpty(AppName) && (!string.IsNullOrEmpty(ClientId))); }
        }

        public KnetikProjectSettings()
        {
            mAppName = string.Empty;
            ClientId = string.Empty;
        }

        public static KnetikProjectSettings Load()
        {
            return Resources.Load<KnetikProjectSettings>(ResourceName);
        }
    }
}
