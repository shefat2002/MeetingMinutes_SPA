using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingMinutes.Web.Controllers;

public class MeetingMinutesController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IMeetingMinutesService _meetingMinutesService;
    private readonly IProductServiceService _productService;

    public MeetingMinutesController(ICustomerService customerService, IMeetingMinutesService meetingMinutesService, IProductServiceService productService)
    {
        _customerService = customerService;
        _meetingMinutesService = meetingMinutesService;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewModel = new MeetingMinutesViewModel
        {
            CorporateCustomers = await _customerService.GetAllCorporateCustomersAsync(),
            IndividualCustomers = new List<IndividualCustomer>(),
            ProductsServices = await _productService.GetAllProductServicesAsync(),
            MeetingDate = DateTime.Now,
            MeetingTime = DateTime.Now.TimeOfDay
        };
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomersByType(string customerType)
    {
        if (customerType == "Corporate")
        {
            var corporateCustomers = await _customerService.GetAllCorporateCustomersAsync();
            return Json(corporateCustomers);
        }
        else
        {
            var individualCustomers = await _customerService.GetAllIndividualCustomersAsync();
            return Json(individualCustomers);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsServices()
    {
        var productsServices = await _productService.GetAllProductServicesAsync();
        return Json(productsServices);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveMeetingMinutes(MeetingMinutesViewModel model)
    {
        if(!ModelState.IsValid)
        {
            model.CorporateCustomers = await _customerService.GetAllCorporateCustomersAsync();
            model.IndividualCustomers = await _customerService.GetAllIndividualCustomersAsync();
            model.ProductsServices = await _productService.GetAllProductServicesAsync();
            return View("Create", model);
        }
        var master = new MeetingMinutesMaster
        {
            CustomerType = model.CustomerType.ToString(),
            CustomerId = model.CustomerId,
            MeetingDate = model.MeetingDate,
            MeetingTime = model.MeetingTime,
            MeetingPlace = model.MeetingPlace,
            MeetingAgenda = model.MeetingAgenda,
            MeetingDiscussion = model.MeetingDiscussion,
            MeetingDecision = model.MeetingDecision,
            ClientAttendees = model.ClientAttendees,
            HostAttendees = model.HostAttendees
        };

        var details = model.Details.Select(d => new MeetingMinutesDetail
        {
            MasterId = d.MasterId,
            ProductServiceId = d.ProductServiceId,
            Quantity = d.Quantity,
            Unit = d.Unit,
        }).ToList();
        try
        {
            int masterId = await _meetingMinutesService.SaveMeetingMinutesAsync(master, details);
            TempData["SuccessMessage"] = "Meeting minutes saved successfully.";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"An error occurred while saving meeting minutes: {ex.Message}");
            model.CorporateCustomers = await _customerService.GetAllCorporateCustomersAsync();
            model.IndividualCustomers = await _customerService.GetAllIndividualCustomersAsync();
            model.ProductsServices = await _productService.GetAllProductServicesAsync();
            return View("Index");
        }
    }

}
