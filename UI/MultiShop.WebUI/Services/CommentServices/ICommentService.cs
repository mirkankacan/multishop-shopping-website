using MultiShop.DTOLayer.DTOs.CommentDTOs;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDTO>> GetAllCommentsAsync(CancellationToken cancellationToken);

        Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDTO createCommentDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDTO updateCommentDTO, CancellationToken cancellationToken);

        Task<HttpResponseMessage> DeleteCommentAsync(Guid id, CancellationToken cancellationToken);

        Task<GetByIdCommentDTO> GetByIdCommentAsync(Guid id, CancellationToken cancellationToken);

        Task<List<ResultCommentDTO>> GetCommentListByProductId(string productId, CancellationToken cancellationToken);
    }
}