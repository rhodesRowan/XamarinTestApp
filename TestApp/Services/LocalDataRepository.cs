using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using TestApp.Helpers;
using TestApp.Models;
using Xamarin.Forms;

namespace TestApp.Services
{
    public static class LocalDataRepository
    {

        public static List<WebLink> getUrlLinks()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Links.json");

            using (var reader = new StreamReader(stream))
            {
                var linksJsonString = reader.ReadToEnd();
                return Utilities.DeserializeFromJson<List<WebLink>>(linksJsonString);
            }
        }
    }
}
