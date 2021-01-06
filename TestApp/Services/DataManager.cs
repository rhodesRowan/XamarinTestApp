using System;
using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Services
{
    public class DataManager
    {
        public List<WebLink> getLocalWebLinks()
        {
            return LocalDataRepository.getUrlLinks();
        }
    }
}
