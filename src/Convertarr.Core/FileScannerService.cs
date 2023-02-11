using Convertarr.Data;
using System.Security.Cryptography;

namespace Convertarr.Core
{
    public class FileScannerService
    {
        private readonly ConvertarrContext _context;

        public FileScannerService(ConvertarrContext context)
        {
            _context = context;
        }

        public void Scan()
        {
            var directory = new DirectoryInfo("/media");
            var files = directory.GetFilesByExtensions(".mp4", ".mkv", ".avi");

            foreach (var fileInfo in files)
            {
                if (_context.Files.Any(x => x.FilePath == fileInfo.FullName) 
                    && _context.Files.First(x => x.FilePath == fileInfo.FullName).FileSize == fileInfo.Length 
                    && _context.Files.First(x => x.FilePath == fileInfo.FullName).LastWrite == fileInfo.LastWriteTime)
                {
                    continue;
                }

                var file = _context.Files.FirstOrDefault(x => x.FilePath == fileInfo.FullName);

                if (file != null)
                {
                    file.MediaInfo = null;
                    file.LastWrite = fileInfo.LastWriteTime;
                    file.FileSize = fileInfo.Length;
                    file.LastScanned = DateTime.UtcNow;
                    _context.Update(file);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Files.Add(new MediaFile()
                    {
                        FilePath = fileInfo.FullName,
                        LastWrite = fileInfo.LastWriteTime,
                        FileSize = fileInfo.Length,
                });
                    _context.SaveChanges();
                }
            }

            var allFiles = _context.Files.ToList();
        }

        private string GetHashForFilePath(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }
    }
}
