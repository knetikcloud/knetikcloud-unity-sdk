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
        public string GrantType;

        public string ClientId;
        public string ClientSecret;

        public KnetikProjectSettings()
        {
            BaseUrl = string.Empty;
            GrantType = string.Empty;
            ClientId = string.Empty;
            ClientSecret = string.Empty;
        }

        public static KnetikProjectSettings Load()
        {
            return Resources.Load<KnetikProjectSettings>(ResourceName);
        }
    }
}
