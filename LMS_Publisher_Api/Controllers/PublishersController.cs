using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryReact.Services;
using LibraryReact.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace LibraryReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersServices _publisherServices;

        public PublishersController(IPublishersServices publisherServices)
        {
            _publisherServices = publisherServices;
        }

        [HttpGet("GetPublishers/")]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            try
            {
                return (await _publisherServices.GetPublishers()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetPublisherById/{id}")]
        public async Task<ActionResult<Publisher>> GetPublisherById(string id)
        {

            try
            {
                var result = await _publisherServices.GetPublisherById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("CreatePublisher/")]
        public async Task<ActionResult<Publisher>> CreatePublisher(Publisher publisherobj)
        {
            string message = "faild";
            try
            {
                if (publisherobj == null)
                    return BadRequest();

                var createpublisher = await _publisherServices.CreatePublisher(publisherobj);
                if (createpublisher != null)
                {
                    message = "success";
                }
                else
                {
                    message = "faild";
                }
            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpPut("UpdatePublisher/")]
        public async Task<ActionResult<Publisher>> Updatepublisher(Publisher publisherobj)
        {
            string message = "";
            try
            {
                if (publisherobj.PublisherID != publisherobj.PublisherID)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _publisherServices.UpdatePublisher(publisherobj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _publisherServices.UpdatePublisher(publisherobj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("DeletePublisher/{id}")]
        public async Task<ActionResult<Publisher>> DeletePublisher(string id)
        {
            string message = "";
            try
            {
                var publisherdelete = await _publisherServices.GetPublisherById(id);

                if (publisherdelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _publisherServices.DeletePublisher(id);
                    message = "success";
                }

            }
            catch (Exception)
            {
                message = "unable to delete";
                return Ok(message);
            }
            return Ok(message);
        }

    }
}
