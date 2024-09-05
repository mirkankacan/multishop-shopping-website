using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.CommentDTOs;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comments";
            ViewBag.v3 = "Comment List";
            ViewBag.v0 = "Comment Operations";

            var response = await _commentService.GetAllCommentsAsync(cancellationToken);
            if (response != null)
            {
                return View(response);
            }

            return View();
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(Guid id, CancellationToken cancellationToken)
        {
            var response = await _commentService.DeleteCommentAsync(id, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { Area = "Admin" });
            }
            return RedirectToAction("Index", "Comment", new { Area = "Admin" });
        }

        [Route("UpdateComment/{id}"), HttpGet]
        public async Task<IActionResult> UpdateComment(Guid id, CancellationToken cancellationToken)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comments";
            ViewBag.v3 = "Update Comment";
            ViewBag.v0 = "Comment Operations";

            var response = await _commentService.GetByIdCommentAsync(id, cancellationToken);
            if (response != null)
            {
                return View(response);
            }
            return View();
        }

        [Route("UpdateComment/{id}"), HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO updateCommentDTO, CancellationToken cancellationToken)
        {
            updateCommentDTO.CreationDate = DateTime.Now;

            var response = await _commentService.UpdateCommentAsync(updateCommentDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("CreateComment"), HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDTO createCommentDTO, CancellationToken cancellationToken)
        {
            createCommentDTO.CommentID = Guid.NewGuid();
            createCommentDTO.CreationDate = DateTime.Now;
            createCommentDTO.ImageUrl = "";
            createCommentDTO.Status = false;

            var response = await _commentService.CreateCommentAsync(createCommentDTO, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }
    }
}