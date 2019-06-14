using System;

namespace Se7en.OpenCvSharp
{
    /// <summary>
	/// The exception that is thrown by OpenCvSharp. 
	/// </summary>
	public class OpenCvSharpException : Exception
	{
		
		public OpenCvSharpException()
		{
		}

		
		/// <param name="message"></param>
		public OpenCvSharpException(string message) : base(message)
		{
		}

		
		/// <param name="messageFormat"></param>
		/// <param name="args"></param>
		public OpenCvSharpException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args))
		{
		}

		
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public OpenCvSharpException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}