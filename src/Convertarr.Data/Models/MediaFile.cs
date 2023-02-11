using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Convertarr.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Convertarr.Data
{
    public class MediaFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int MediaFileId { get; set; }

         public string FilePath {get;set;}

         public long FileSize { get; set; }

         public DateTime LastWrite { get; set; } = DateTime.UtcNow;

        public virtual MediaInfo? MediaInfo { get; set; }

         public DateTime LastScanned { get; set; } = DateTime.UtcNow;
    }
}