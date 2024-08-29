using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUi.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(int id);
        Task<GetCommentById> GetCommentByIdAsync(int id);   
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<List<GetCommentById>> GetCommentForProductId(string id);

        Task<int> GetTotalCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPassiveCommentCount();


    }
}
