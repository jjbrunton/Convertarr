using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Convertarr.Data.Models
{
    public class SubtitleStream : MediaStream
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubtitleStreamId { get; set; }

        //
        // Summary:
        //     Subtitle language
        public required string Language { get; set; }
        //
        // Summary:
        //     Default
        public int? Default { get; set; }
        //
        // Summary:
        //     Forced
        public int? Forced { get; set; }
        //
        // Summary:
        //     Title
        public required string Title { get; set; }
    }
}