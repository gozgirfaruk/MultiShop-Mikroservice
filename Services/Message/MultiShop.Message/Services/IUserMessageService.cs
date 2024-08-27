using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetAllInboxAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetAllSendboxAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task<GetMessageByIdDto> GetMessageByIdDto(int id);
        Task DeleteMessageAsync(int id);



    }
}
