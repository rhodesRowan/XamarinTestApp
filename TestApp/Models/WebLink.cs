using System;
namespace TestApp.Models
{
    public class WebLink
    {
        public readonly string url;
        public readonly string identifier;
        public readonly string hex;

        public WebLink(string url, string identifier, string hex)
        {
            this.url = url;
            this.identifier = identifier;
            this.hex = hex;
        }
    }
}
