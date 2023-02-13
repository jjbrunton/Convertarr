using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Convertarr.Core.Converters;
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
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<string, string>().ConvertUsing<NullStringConverter>();
                    cfg.CreateMap<IVideoStream, Data.Models.VideoStream>();
                    cfg.CreateMap<IAudioStream, Data.Models.AudioStream>();
                    cfg.CreateMap<ISubtitleStream, Data.Models.SubtitleStream>();
                }
                );
                var mapper = new Mapper(config);

                Debug.WriteLine($"Starting analysis for {dbFile.FilePath}");
                var fileInfo = await FFmpeg.GetMediaInfo(dbFile.FilePath);
            dbFile.MediaInfo = new Convertarr.Data.Models.MediaInfo
                {
                    Duration = fileInfo.Duration,
                    VideoStreams = fileInfo.VideoStreams.Select(x => mapper.Map<Data.Models.VideoStream>(x)),
                    AudioStreams = fileInfo.AudioStreams.Select(x => mapper.Map<Data.Models.AudioStream>(x)),
                    SubtitleStreams = fileInfo.SubtitleStreams.Select(x => mapper.Map<Data.Models.SubtitleStream>(x))
                };

                this._context.Update(dbFile);
                await this._context.SaveChangesAsync();

        }
    }
}
