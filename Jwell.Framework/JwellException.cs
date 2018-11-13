using System;
using System.Runtime.Serialization;

namespace Jwell.Framework
{
    [Serializable]
    public class JwellException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        public JwellException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        public JwellException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public JwellException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public JwellException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
