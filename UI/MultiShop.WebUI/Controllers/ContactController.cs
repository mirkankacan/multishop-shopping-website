﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CatalogDTOs.ContactDTOs;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDTO createContactDTO)
        {
            createContactDTO.IsRead = false;
            createContactDTO.SendDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7135/api/Contact", createContactDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}