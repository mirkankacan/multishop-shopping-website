using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CommentDTOs;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public ProductListController(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.CategoryId = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment(string id)
        {
            ViewBag.ProductId = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDTO createCommentDTO, CancellationToken cancellationToken)
        {
            createCommentDTO.CommentID = Guid.NewGuid();
            createCommentDTO.ImageUrl = "";
            createCommentDTO.CreationDate = DateTime.Now;
            createCommentDTO.Status = false;
            createCommentDTO.ProductID = ViewBag.ProductId;
            createCommentDTO.Rating = 1;

            var response = await _commentService.CreateCommentAsync(createCommentDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}