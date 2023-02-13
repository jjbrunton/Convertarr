namespace Convertarr.Data.Models
{
    public class MediaStream
    {
        //
        // Summary:
        //     File source of stream
        public string Path { get; set; }
        //
        // Summary:
        //     Index of stream
        public int Index { get; set; }
        //
        // Summary:
        //     Format
        public string Codec { get; set; }
        //
        // Summary:
        //     Codec type
        public MediaStreamType MediaStreamType { get; set; }
    }
}