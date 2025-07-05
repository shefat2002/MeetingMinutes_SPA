using MeetingMinutes.Application.ServiceInterface;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Domain.Enums;
using MeetingMinutes.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
    public async Task<IActionResult> GetCustomersByType(CustomerType customerType)
    {
        if (customerType == CustomerType.Corporate)
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
    }

}
