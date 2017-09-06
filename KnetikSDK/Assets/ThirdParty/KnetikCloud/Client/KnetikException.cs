using System;

namespace com.knetikcloud.Client
{
    /// <summary>
    /// Knetik Exception
    /// </summary>
    public class KnetikException : Exception
    {
        /// <summary>
        /// Gets or sets the error code (HTTP status code)
        /// </summary>
        /// <value>The error code (HTTP status code).</value>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error content (body json object)
        /// </summary>
        /// <value>The error content (Http response body).</value>
        public Object ErrorContent { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikException"/> class.
        /// </summary>
        public KnetikException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikException"/> class.
        /// </summary>
        /// <param name="errorCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        public KnetikException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikException"/> class.
        /// </summary>
        /// <param name="errorCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="errorContent">Error content.</param>
        public KnetikException(int errorCode, string message, Object errorContent = null) : base(message)
        {
            ErrorCode = errorCode;
            ErrorContent = errorContent;
        }
    }
}
