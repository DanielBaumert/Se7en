using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace Se7en {
    public class Decompressor {
        public bool GetAllCompressedFiles(DirectoryInfo directory, out FileInfo[] files) {
            if (directory.Exists) {
                using FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    files = directory.GetFiles().Where(file => file.Extension == ".compressed").ToArray();
                    return true;
                }
            }
            files = Array.Empty<FileInfo>();
            return false;
        }
        public static void DecompresAll(FileInfo[] paths) {
            foreach (FileInfo file in paths) {
                Decompres(file);
            }
        }
        public static void Decompres(FileInfo file) {
            if (file.Exists) {
                using Stream fileStream = File.OpenRead(file.FullName);
                using Stream fileStreamOut = File.OpenWrite(Path.ChangeExtension(file.FullName, ".dll"));
                using DeflateStream deflateStream = new DeflateStream(fileStream, CompressionMode.Decompress);
                int data = 0;
                while ((data = deflateStream.ReadByte()) != -1) {
                    fileStreamOut.WriteByte((byte)data);
                }
            }
        }
    }
}
