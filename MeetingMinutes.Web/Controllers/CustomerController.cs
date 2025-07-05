using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingMinutes.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService) 
    {
        _customerService = customerService;
    }
    public async Task<IActionResult> Index()
    {
        var individualCustomers = await _customerService.GetAllIndividualCustomersAsync();
        var corporateCustomers = await _customerService.GetAllCorporateCustomersAsync();
        var viewModel = new CustomerViewModel
        {
            CustomerType = "Corporate",
            IndividualCustomers = individualCustomers,
            CorporateCustomers = corporateCustomers
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetIndividualCustomers()
    {
        try { 
            var customers = await _customerService.GetAllIndividualCustomersAsync();
            return Json(customers);
        }
        catch (Exception ex)
        {
            return BadRequest("Error loading customers: " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCorporateCustomers()
    {
        try { 
            var customers = await _customerService.GetAllCorporateCustomersAsync();
            return Json(customers);
        }
        catch (Exception ex)
        {
            return BadRequest("Error loading corporate customers: " + ex.Message);
        }

    }
}
