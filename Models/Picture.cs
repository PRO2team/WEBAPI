namespace Webapi.Models
{
    public class Picture
    {
        public int PictureID { get; set; }
        public byte[] Bytes { get; set; }
        public string Filename { get; set; }
        public string? Filepath { get; set; }
    }
}
