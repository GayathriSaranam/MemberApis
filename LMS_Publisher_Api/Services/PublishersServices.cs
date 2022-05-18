using LibraryReact.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryReact.Services
{
    public class PublishersServices : IPublishersServices
    {
        public static readonly List<Publisher> publisher = new List<Publisher>()
        {
            new Publisher {PublisherID="P101",PublisherName="Akash" },
            new Publisher { PublisherID = "P102", PublisherName = "Aayush"},
        };

        public async Task<IEnumerable<Publisher>> GetPublishers()
        {
            return publisher;

        }

        public async Task<Publisher> GetPublisherById(string publisherObj)
        {
            return publisher.SingleOrDefault(c => c.PublisherID == publisherObj);
        }


        public async Task<Publisher> CreatePublisher(Publisher publisherObj)
        {
            publisher.Add(publisherObj);
            return publisherObj;
        }

        public async Task<Publisher> UpdatePublisher(Publisher publisherObj)
        {
            var result = publisher.Find(c => c.PublisherID == publisherObj.PublisherID);

            if (result != null)
            {
                result.PublisherName = publisherObj.PublisherName;

                return result;
            }

            return null;

        }

        public async Task<Publisher> DeletePublisher(string publisherObj)
        {
            var result = publisher.Find(c => c.PublisherID == publisherObj);
            if (result != null)
            {
                publisher.Remove(result);

            }
            return result;
        }
    }
}

