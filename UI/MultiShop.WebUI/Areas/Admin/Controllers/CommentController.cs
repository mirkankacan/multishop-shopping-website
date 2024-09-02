using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CommentDTOs;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comments";
            ViewBag.v3 = "Comment List";
            ViewBag.v0 = "Comment Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<ResultCommentDTO>>("https://localhost:7171/api/Comment");
            if (response != null)
            {
                return View(response);
            }

            return View();
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7171/api/Comment?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { Area = "Admin" });
            }
            return View();
        }

        [Route("UpdateComment/{id}"), HttpGet]
        public async Task<IActionResult> UpdateComment(Guid id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comments";
            ViewBag.v3 = "Update Comment";
            ViewBag.v0 = "Comment Operations";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<UpdateCommentDTO>($"https://localhost:7171/api/Comment/{id}");
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateComment/{id}"), HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO updateCommentDTO)
        {
            updateCommentDTO.CreationDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7171/api/Comment", updateCommentDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
        [Route("CreateComment"), HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDTO createCommentDTO)
        {
            createCommentDTO.CommentID = Guid.NewGuid();
            createCommentDTO.CreationDate = DateTime.Now;
            createCommentDTO.ImageUrl = "";
            createCommentDTO.Status = false;

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7171/api/Comment", createCommentDTO);
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }
    }
}