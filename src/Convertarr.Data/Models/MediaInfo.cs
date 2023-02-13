using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertarr.Data.Models
{
    public class MediaInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaInfoId { get; set; }

        // Summary:
        //     Duration of media
        public TimeSpan Duration { get; set;}

        public virtual IEnumerable<VideoStream> VideoStreams {get;set;}

        public virtual IEnumerable<AudioStream> AudioStreams {get;set;}

        public virtual IEnumerable<SubtitleStream> SubtitleStreams {get;set;}
    }
}
