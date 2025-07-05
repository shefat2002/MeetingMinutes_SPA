using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Domain.Enums;
using MeetingMinutes.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingMinutes.Web.Controllers;

public class MeetingMinutesController : Controller
{
    private readonly ICustomerService _customerService;

    public MeetingMinutesController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult>Index()
    {
        var viewModel = new CustomerViewModel
        {
            CustomerType = CustomerType.Corporate,
            CorporateCustomers = await _customerService.GetAllCorporateCustomersAsync(),
            IndividualCustomers = new List<IndividualCustomer>()
        };
        return View(viewModel);
    }


    [HttpGet]
    public async Task<IActionResult> GetCustomersByType(CustomerType customerType)
    {
        if (customerType == CustomerType.Corporate)
        {
            var corporateCustomers = (await _customerService.GetAllCorporateCustomersAsync());
            return Json(corporateCustomers);
        }
        else if (customerType == CustomerType.Individual)
        {
            var individualCustomers = (await _customerService.GetAllIndividualCustomersAsync());
            return Json(individualCustomers);
        }
        return BadRequest("Invalid customer type specified.");
    }
}
