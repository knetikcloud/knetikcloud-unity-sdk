using UnityEngine;


namespace com.knetikcloud.Client
{
    public class KnetikUserCredentials
    {
        private const string UserIdKey = "UserId";
        private const string PasswordIdKey = "Password";

        public string UserId;
        public string Password;

        public KnetikUserCredentials()
        {
            UserId = string.Empty;
            Password = string.Empty;
        }

        public static void Save(KnetikUserCredentials credentials)
        {
            PlayerPrefs.SetString(UserIdKey, credentials.UserId);
            PlayerPrefs.SetString(PasswordIdKey, credentials.Password);
        }

        public static KnetikUserCredentials Load()
        {
            KnetikUserCredentials credentials = new KnetikUserCredentials
            {
                UserId = PlayerPrefs.GetString(UserIdKey),
                Password = PlayerPrefs.GetString(PasswordIdKey)
            };


            return credentials;
        }
    }
}
