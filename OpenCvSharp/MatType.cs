using System;

namespace Se7en.OpenCvSharp
{
    /// <summary>
	/// Matrix data type (depth and number of channels)
	/// </summary>
	public struct MatType : IEquatable<MatType>, IEquatable<int>
	{

        public MatType(int value) => Value = value;

        public static implicit operator int(MatType self) => self.Value;

        public static implicit operator MatType(int value) => new MatType(value);
        public int Depth => Value & 7;
        public bool IsInteger => Depth < 5;
        public int Channels => (Value >> 3) + 1;

        public bool Equals(MatType other) => Value == other.Value;

        public bool Equals(int other) => Value == other;

        public override bool Equals(object other) => other != null && !(other.GetType() != typeof(MatType)) && this.Equals((MatType)other);

        public static bool operator ==(MatType self, MatType other) => self.Equals(other);

        public static bool operator !=(MatType self, MatType other) => !self.Equals(other);

        public static bool operator ==(MatType self, int other) => self.Equals(other);

        public static bool operator !=(MatType self, int other) => !self.Equals(other);

        public override int GetHashCode() => this.Value.GetHashCode();

        public override string ToString()
		{
			string s;
			switch (this.Depth)
			{
			case 0:
				s = "CV_8U";
				break;
			case 1:
				s = "CV_8S";
				break;
			case 2:
				s = "CV_16U";
				break;
			case 3:
				s = "CV_16S";
				break;
			case 4:
				s = "CV_32S";
				break;
			case 5:
				s = "CV_32F";
				break;
			case 6:
				s = "CV_64F";
				break;
			case 7:
				s = "CV_USRTYPE1";
				break;
			default:
				throw new OpenCvSharpException("Unsupported CvType value: " + this.Value);
			}
			int ch = this.Channels;
			if (ch <= 4)
			{
				return s + "C" + ch;
			}
			return string.Concat(new object[]
			{
				s,
				"C(",
				ch,
				")"
			});
		}

        public static MatType CV_8UC(int ch) => MakeType(0, ch);
        public static MatType CV_8SC(int ch) => MakeType(1, ch);
        public static MatType CV_16UC(int ch) => MakeType(2, ch);
        public static MatType CV_16SC(int ch) => MakeType(3, ch);
        public static MatType CV_32SC(int ch) => MakeType(4, ch);
        public static MatType CV_32FC(int ch) => MakeType(5, ch);
        public static MatType CV_64FC(int ch) => MakeType(6, ch);
        public static MatType MakeType(int depth, int channels)
		{
			if (channels <= 0 || channels >= 512)
			{
				throw new OpenCvSharpException("Channels count should be 1.." + 511);
			}
			if (depth < 0 || depth >= 8)
			{
				throw new OpenCvSharpException("Data type depth should be 0.." + 7);
			}
			return (depth & 7) + (channels - 1 << 3);
		}

		/// <summary>
		/// Entity value
		/// </summary>
		public int Value;

#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen
        private const int CV_CN_MAX = 512;


        private const int CV_CN_SHIFT = 3;

		private const int CV_DEPTH_MAX = 8;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_8U = 0;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_8S = 1;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_16U = 2;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_16S = 3;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_32S = 4;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_32F = 5;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_64F = 6;

		/// <summary>
		/// type depth constants
		/// </summary>
		public const int CV_USRTYPE1 = 7;
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen
		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_8UC1 = CV_8UC(1);
                                                 
		/// <summary>                            
		/// predefined type constants            
		/// </summary>                           
		public static readonly MatType CV_8UC2 = CV_8UC(2);
                                                 
		/// <summary>                            
		/// predefined type constants            
		/// </summary>                           
		public static readonly MatType CV_8UC3 = CV_8UC(3);
                                                 
		/// <summary>                            
		/// predefined type constants            
		/// </summary>                           
		public static readonly MatType CV_8UC4 = CV_8UC(4);
                                                 
		/// <summary>                            
		/// predefined type constants            
		/// </summary>                           
		public static readonly MatType CV_8SC1 = CV_8SC(1);
                                                 
		/// <summary>                            
		/// predefined type constants            
		/// </summary>                           
		public static readonly MatType CV_8SC2 = CV_8SC(2);
                                                 
		/// <summary>                            
		/// predefined type constants            
		/// </summary>                           
		public static readonly MatType CV_8SC3 = CV_8SC(3);
                                                 
		/// <summary>                            
		/// predefined type constants            
		/// </summary>                           
		public static readonly MatType CV_8SC4 = CV_8SC(4);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16UC1 = CV_16UC(1);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16UC2 = CV_16UC(2);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16UC3 = CV_16UC(3);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16UC4 = CV_16UC(4);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16SC1 = CV_16SC(1);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16SC2 = CV_16SC(2);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16SC3 = CV_16SC(3);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_16SC4 = CV_16SC(4);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32SC1 = CV_32SC(1);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32SC2 = CV_32SC(2);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32SC3 = CV_32SC(3);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32SC4 = CV_32SC(4);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32FC1 = CV_32FC(1);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32FC2 = CV_32FC(2);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32FC3 = CV_32FC(3);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_32FC4 = CV_32FC(4);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_64FC1 = CV_64FC(1);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_64FC2 = CV_64FC(2);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_64FC3 = CV_64FC(3);

		/// <summary>
		/// predefined type constants
		/// </summary>
		public static readonly MatType CV_64FC4 = CV_64FC(4);
	}
}