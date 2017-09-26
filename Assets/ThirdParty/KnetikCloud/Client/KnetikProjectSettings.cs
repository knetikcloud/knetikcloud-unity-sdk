using System;
using UnityEngine;


namespace com.knetikcloud.Client
{
    [Serializable]
    public class KnetikProjectSettings : ScriptableObject
    {
        public const string SaveDataPath = "Assets\\Resources\\KnetikCloud\\KnetikProjectSettings.asset";
        public const string ResourceName = "KnetikCloud\\KnetikProjectSettings";

        public string BaseUrl;
        public string ClientId;

        public bool IsConfiguredProperly
        {
            get { return (!string.IsNullOrEmpty(BaseUrl) && (!string.IsNullOrEmpty(ClientId))); }
        }

        public KnetikProjectSettings()
        {
            BaseUrl = string.Empty;
            ClientId = string.Empty;
        }

        public static KnetikProjectSettings Load()
        {
            return Resources.Load<KnetikProjectSettings>(ResourceName);
        }
    }
}
