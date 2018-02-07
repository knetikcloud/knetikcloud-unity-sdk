using System;
using UnityEngine;


namespace com.knetikcloud.Credentials
{
    [Serializable]
    public class KnetikCloudCredentials : ScriptableObject, IKnetikCredentials
    {
        public const string SaveDataPath = "Assets\\Resources\\KnetikCloud\\KnetikCloudCredentials.asset";
        public const string ResourceName = "KnetikCloud\\KnetikCloudCredentials";

        public string GrantType { get { return "client_credentials"; } }

        public bool IsConfigured { get { return !string.IsNullOrEmpty(ClientSecret); } }

        public string ClientSecret;

        public static KnetikCloudCredentials Load()
        {
            return Resources.Load<KnetikCloudCredentials>(ResourceName);
        }
    }
}
