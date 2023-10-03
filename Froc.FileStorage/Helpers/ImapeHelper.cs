namespace Forc.FileStorage.Helpers
{
    public static class ImapeHelper
    {
        public static byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!String.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
                return bytes;
            }
            throw new ApplicationException("File is empty");
        }
    }
}
