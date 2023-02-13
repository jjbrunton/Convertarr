using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Convertarr.Data.Models
{
    public class VideoStream : MediaStream
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VideoStreamId { get; set; }

        //
        // Summary:
        //     Rotation angle
        public int? Rotation { get; set; }
        //
        // Summary:
        //     Forced
        public int? Forced { get; set; }
        //
        // Summary:
        //     Default
        public int? Default { get; set; }
        //
        // Summary:
        //     Video bitrate
        public long Bitrate { get; set; }
        //
        // Summary:
        //     Screen ratio
        public string Ratio { get; set; }
        //
        // Summary:
        //     Frame rate
        public double Framerate { get; set; }
        //
        // Summary:
        //     Height
        public int Height { get; set; }
        //
        // Summary:
        //     Width
        public int Width { get; set; }
        //
        // Summary:
        //     Duration
        public TimeSpan Duration { get; set; }
        //
        // Summary:
        //     Pixel Format
        public required string PixelFormat { get; set; }
    }
}