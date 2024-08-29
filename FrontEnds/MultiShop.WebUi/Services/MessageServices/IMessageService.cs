using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUi.Services.MessageServices
{
    public interface IMessageService
    {
        //Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxDto>> GetAllInboxAsync(string id);
        Task<List<ResultSendboxDto>> GetAllSendboxAsync(string id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task<GetMessageByIdDto> GetMessageByIdDto(int id);
        //Task DeleteMessageAsync(int id);
        Task<int> GetTotalMessageCount();
    }
}
