using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;

namespace LibraryReact.Services
{
    public interface IPublishersServices
    {
        Task<IEnumerable<Publisher>> GetPublishers();
        Task<Publisher> GetPublisherById(string publisherobj);
        Task<Publisher> UpdatePublisher(Publisher publisherobj);
        Task<Publisher> CreatePublisher(Publisher publisherobj);
        Task<Publisher> DeletePublisher(string publisherobj);

    }
}