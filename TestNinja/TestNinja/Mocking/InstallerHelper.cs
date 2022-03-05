using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IDownload _download;

        public InstallerHelper(IDownload download)
        {
            _download = download;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                var url = string.Format("http://example.com/{0}/{1}", customerName, installerName);

                _download.DownloadFile(url,_setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }

    public class Download : IDownload
    {
        public void DownloadFile(string url, string setupDestinationFile)
        {
            var client = new WebClient();

            client.DownloadFile(url, setupDestinationFile);
        }
    }

    public interface IDownload
    {
        void DownloadFile(string url, string setupDestinationFile);
    }
        
}