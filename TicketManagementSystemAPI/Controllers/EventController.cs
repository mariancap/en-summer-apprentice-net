using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystemAPI.Models;
using TicketManagementSystemAPI.Models.DTO;
using TicketManagementSystemAPI.Repositories;

namespace TicketManagementSystemAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
       

        public EventController(IEventRepository eventRepository,IMapper mapper)
        {
            _mapper=    mapper;
            _eventRepository = eventRepository;
        }
        [HttpGet]
        public ActionResult<List<EventDTO>> GetAll()
        {
           
            var events = _eventRepository.GetAll();
            var dtoEvents=new List<EventDTO>();

            foreach(var @event in events) {

                var eventDTO = new EventDTO()
                {
                    EventID = @event.EventId,
                    EventName = @event.EventName ?? string.Empty,
                    EventDescription = @event.EventDescription ?? string.Empty,
                    EventType = @event.EventType?.EventTypeName ?? string.Empty,
                    Venue = @event.Venue?.EventLocation ?? string.Empty
                };
                dtoEvents.Add(eventDTO);
            }

           

            return Ok(dtoEvents);


        }

        [HttpGet]
        public async  Task<ActionResult<EventDTO>> GetById(int id) {
            var @event = await _eventRepository.GetById(id);

            //var dtoEvent = new EventDTO()
            //{
            //    EventID = @event.EventId,
            //    EventName = @event.EventName ?? string.Empty,
            //    EventDescription = @event.EventDescription ?? string.Empty,
            //    EventType = @event.EventType?.EventTypeName ?? string.Empty,
            //    Venue = @event.Venue?.EventLocation ?? string.Empty
            //};

            var dtoEvent = _mapper.Map<EventDTO>(@event);

            return Ok(dtoEvent);
        
        }

        [HttpPatch]

        public async Task<ActionResult<EventPatchDTO>> Patch(EventPatchDTO eventPatch)
        {
            var eventEntity= await _eventRepository.GetById(eventPatch.EventId);
            if(eventEntity == null) { return NotFound(); }
            _mapper.Map(eventPatch, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete] 
        public async Task<ActionResult> Delete(int id) {

            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity == null) 
            { 
                return NotFound(); 
            }

            _eventRepository.delete(eventEntity);
            return NoContent();
        }

    }
}
