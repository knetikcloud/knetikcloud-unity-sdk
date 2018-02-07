using System;

namespace KnetikUnity.Utils
{
    public static class KnetikTime
    {
        private static readonly DateTime sEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Retrive the current Unix time stamp in MS
        /// </summary>
        public static double UnixTimestampMs
        {
            get
            {
                DateTime dateTime = DateTime.UtcNow;
                TimeSpan unixDateTime = dateTime - sEpoch;
                return unixDateTime.TotalMilliseconds;
            }
        }
    }
}
