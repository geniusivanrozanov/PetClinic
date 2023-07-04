using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService appointmentService;
    private readonly IConfiguration config;

    public AppointmentController(IAppointmentService appointmentService, IConfiguration config)
    {
        this.appointmentService = appointmentService;
        this.config = config;
    }

    [HttpPost("calander")]
    [AllowAnonymous]
    public async Task<IActionResult> AddEventToGoogleAsync()
    {
        dsAuthorizationBroker.RedirectUri = "https://localhost:7124/accounts/google/sign-up";
        UserCredential credential = await dsAuthorizationBroker.AuthorizeAsync
        (
            new ClientSecrets
            {
                ClientId = "867055353627-vsg9n4r105df7ifv4dr2mqk4nhrortjn.apps.googleusercontent.com",
                ClientSecret = "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",
            },
            new[] { CalendarService.Scope.Calendar, "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile" },
            "veronikayatskova03@gmail.com",
            CancellationToken.None
        );

        // Create the service.
        var service = new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "Calendar API Sample",
        });  
        
        var myEvent = new Event
        {
            Summary = "Google Calendar Api Sample Code by Mukesh Salaria",
            Location = "Gurdaspur, Punjab, India",
            Start = new EventDateTime
            {
                DateTime = new DateTime(2015, 3, 2, 6, 0, 0),
            },
            End = new EventDateTime
            {
                DateTime = new DateTime(2015, 3, 2, 7, 30, 0),
            },
            Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" },
            Attendees = new List<EventAttendee>
            {
                new EventAttendee { Email = "programmer.mukesh01@gmail.com"}
            },
        };

        var recurringEvent = service.Events.Insert(myEvent, "primary");
        recurringEvent.SendNotifications = true;
        recurringEvent.Execute();  

        return Created("", "Event was created"); 
    }

    [HttpPost("calander")]
    public async Task<IActionResult> AddEventToGoogleAsync()
    {
        var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync
        (
            new ClientSecrets
            {
                ClientId = config["GoogleCredentials:ClientId"],
                ClientSecret = config["GoogleCredentials:ClientSecret"],
            },
            new[] { CalendarService.Scope.Calendar },
            "user",
            CancellationToken.None
        );

        // Create the service.
        var service = new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "Calendar API Sample",
        });  
        
        var myEvent = new Event
        {
            Summary = "Google Calendar Api Sample Code by Mukesh Salaria",
            Location = "Gurdaspur, Punjab, India",
            Start = new EventDateTime
            {
                DateTime = new DateTime(2015, 3, 2, 6, 0, 0),
            },
            End = new EventDateTime
            {
                DateTime = new DateTime(2015, 3, 2, 7, 30, 0),
            },
            Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" },
            Attendees = new List<EventAttendee>
            {
                new EventAttendee { Email = "programmer.mukesh01@gmail.com"}
            },
        };

        var recurringEvent = service.Events.Insert(myEvent, "primary");
        recurringEvent.SendNotifications = true;
        recurringEvent.Execute();  

        return Created("", "Event was created"); 
    }


    [HttpPost]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> AddAsync(AddAppointmentDto appointment)
    {
        await appointmentService.AddAppointmentAsync(appointment);
        return Created("", appointment);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.AdminRole)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await appointmentService.DeleteAppointmentAsync(id);
        return Ok(id);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var appointment = await appointmentService.GetAppointmentByIdAsync(id);
        return Ok(appointment);
    }

    [HttpGet]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> GetAllAsync()
    {
        var appointments = await appointmentService.GetAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpPut]
    [Authorize(Roles = Roles.AdminRole)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAppointmentDto appointment)
    {
        await appointmentService.UpdateAppointmentAsync(appointment);
        return Ok(appointment);
    }
}
