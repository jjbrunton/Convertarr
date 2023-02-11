using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convertarr.Data;
using Convertarr.Data.Models;
using Hangfire;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

namespace Convertarr.Core
{
    public class MediaInfoService
    {
        private readonly ConvertarrContext _context;

        public MediaInfoService(ConvertarrContext context)
        {
            _context = context;
        }

        public void UpdateMediaAnalysis()
        {


            foreach (var filePath in this._context.Files.ToList())
            {
                BackgroundJob.Enqueue(() => this.UpdateMediaInfoForMediaFile(filePath));
            }
        }

        public async Task UpdateMediaInfoForMediaFile(MediaFile file)
        {
                
                var dbFile = _context.Files.FirstOrDefault(x => x.MediaFileId == file.MediaFileId);
                if (dbFile == null)
                {
                    return;
                }

                Debug.WriteLine($"Starting analysis for {dbFile.FilePath}");
                var fileInfo = await FFmpeg.GetMediaInfo(dbFile.FilePath);
            dbFile.MediaInfo = new Convertarr.Data.Models.MediaInfo
                {
                    Codec = fileInfo.VideoStreams.First().Codec
                };

                this._context.Update(dbFile);
                await this._context.SaveChangesAsync();

        }
    }
}
