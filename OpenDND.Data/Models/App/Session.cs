namespace OpenDND.Data.Models.App
{
    public class Session
    {
        public int SessionId { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}