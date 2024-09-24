using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _commentContext.UserComments.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var value = await _commentContext.UserComments.FindAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            await _commentContext.SaveChangesAsync();
            return Ok("A comment has been created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var value = await _commentContext.UserComments.FindAsync(id);
            _commentContext.Remove(value);
            await _commentContext.SaveChangesAsync();
            return Ok("A comment has been deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            await _commentContext.SaveChangesAsync();
            return Ok("A comment has been updated successfully");
        }

        [HttpGet("CommentListByProductId")]
        public async Task<IActionResult> CommentListByProductId(string productId)
        {
            var values = await _commentContext.UserComments.Where(x => x.ProductID == productId).ToListAsync();
            return Ok(values);
        }
    }
}