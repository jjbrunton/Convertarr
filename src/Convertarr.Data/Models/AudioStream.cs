using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Convertarr.Data.Models
{
    public class AudioStream : MediaStream
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AudioStreamId { get; set; }

        //
        // Summary:
        //     Forced
        public int? Forced { get; set; }
        //
        // Summary:
        //     Title
        public required string Title { get; set; }
        //
        // Summary:
        //     Language
        public required string Language { get; set; }
        //
        // Summary:
        //     Channels
        public int Channels { get; set; }
        //
        // Summary:
        //     Sample Rate
        public int SampleRate { get; set; }
        //
        // Summary:
        //     Bitrate
        public long Bitrate { get; set; }
        //
        // Summary:
        //     Duration
        public TimeSpan Duration { get; set; }
        //
        // Summary:
        //     Default
        public int? Default { get; set; }
    }
}