using System;
using System.IO;
using System.Linq;
using System.Text;
using SysCryptography = System.Security.Cryptography;
namespace Se7en.Security.Cryptography {
    public class Aes {

        public static string EncryptText(string message, string key) {
            SysCryptography.Aes aescrypt = SysCryptography.Aes.Create();
            aescrypt.Key = ExtendKey(key, 32);
            aescrypt.IV = CreateBlockSize(16);

            using (MemoryStream mStream = new MemoryStream())
            using (SysCryptography.CryptoStream cStream = new SysCryptography.CryptoStream(mStream, aescrypt.CreateEncryptor(), SysCryptography.CryptoStreamMode.Write)) {

                byte[] plainBytes = Encoding.UTF8.GetBytes(message);
                cStream.Write(plainBytes, 0, plainBytes.Length);
                cStream.Flush();

                byte[] encryptedBytes = mStream.ToArray();
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string DecryptText(string message, string key) {
            SysCryptography.Aes aescrypt = SysCryptography.Aes.Create();
            aescrypt.Padding = SysCryptography.PaddingMode.Zeros;
            aescrypt.Key = ExtendKey(key, 32);
            aescrypt.IV = CreateBlockSize(16);

            using (MemoryStream mStream = new MemoryStream())
            using (SysCryptography.CryptoStream cStream = new SysCryptography.CryptoStream(mStream, aescrypt.CreateDecryptor(), SysCryptography.CryptoStreamMode.Write)) {
                byte[] encryptedBytes = Convert.FromBase64String(message);
                cStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                cStream.Flush();

                byte[] plainText = mStream.ToArray();
                return Encoding.UTF8.GetString(plainText);
            }
        }


        public static void EncryptFile(string filePath, string key) {
            SysCryptography.Aes aescrypt = SysCryptography.Aes.Create();
            aescrypt.Key = ExtendKey(key, 32);
            aescrypt.IV = CreateBlockSize(16);

            string cryptPath = Path.ChangeExtension(filePath, ".crypt");
            using(FileStream inputStream = new FileStream(filePath, FileMode.Open))
            using(FileStream outputStream = new FileStream(cryptPath, FileMode.OpenOrCreate))
            using(SysCryptography.CryptoStream cStream = new SysCryptography.CryptoStream(outputStream, aescrypt.CreateEncryptor(), SysCryptography.CryptoStreamMode.Write)) {
                int data;
                while ((data = inputStream.ReadByte()) != -1)
                    cStream.WriteByte((byte) data);
            }
        }

        public static void DecryptFile(string filePath, string key, string extension = ".txt") {
            SysCryptography.Aes aescrypt = SysCryptography.Aes.Create();
            aescrypt.Padding = SysCryptography.PaddingMode.Zeros;
            aescrypt.Key = ExtendKey(key, 32);
            aescrypt.IV = CreateBlockSize(16);

            string cryptPath = Path.ChangeExtension(filePath, extension);
            using (FileStream inputStream = new FileStream(filePath, FileMode.Open))
            using (FileStream outputStream = new FileStream(cryptPath, FileMode.OpenOrCreate))
            using (SysCryptography.CryptoStream cStream = new SysCryptography.CryptoStream(outputStream, aescrypt.CreateDecryptor(), SysCryptography.CryptoStreamMode.Write)) {
                int data;
                while ((data = inputStream.ReadByte()) != -1)
                    cStream.WriteByte((byte)data);
            }
        }

        private static byte[] ExtendKey(string key, int length) {
            byte[] extendedkey = new byte[length];
            byte[] currentKey = Encoding.UTF8.GetBytes(key);

            Array.Copy(currentKey, extendedkey, currentKey.Length);
            return extendedkey;
        }

        private static byte[] CreateBlockSize(int size) {
            if (size <= byte.MaxValue) {
                return Enumerable.Range(0, size).Cast<byte>().ToArray();
            }
            throw new ArgumentException(nameof(size));
        }
    }
}
