using MultiShop.DTOLayer.DTOs.CommentDTOs;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDTO createCommentDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("Comment", createCommentDTO, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteCommentAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"Comment?id={id}", cancellationToken);
            return response;
        }

        public async Task<List<ResultCommentDTO>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultCommentDTO>>("Comment", cancellationToken);
            return response ?? new List<ResultCommentDTO>();
        }

        public async Task<GetByIdCommentDTO> GetByIdCommentAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdCommentDTO>($"Comment/{id}", cancellationToken);
            return response ?? new GetByIdCommentDTO();
        }

        public async Task<List<ResultCommentDTO>> GetCommentListByProductId(string productId, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultCommentDTO>>($"Comment/CommentListByProductId?productId={productId}", cancellationToken);
            return response ?? new List<ResultCommentDTO>();
        }

        public async Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDTO updateCommentDTO, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("Comment", updateCommentDTO, cancellationToken);
            return response;
        }
    }
}