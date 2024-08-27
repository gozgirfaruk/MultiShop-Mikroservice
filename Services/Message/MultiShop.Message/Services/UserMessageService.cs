using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var values = _mapper.Map<UserMessage>(createMessageDto);
            await _context.UserMessages.AddAsync(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values =await _context.UserMessages.FindAsync(id);
             _context.UserMessages.Remove(values);
            await _context.SaveChangesAsync();

        }

        public async Task<List<ResultInboxMessageDto>> GetAllInboxAsync(string id)
        {
            var values = await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultSendboxMessageDto>> GetAllSendboxAsync(string id)
        {
            var values = await _context.UserMessages.Where(x=>x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task<GetMessageByIdDto> GetMessageByIdDto(int id)
        {
            var values = await _context.UserMessages.Where(x => x.UserMessageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetMessageByIdDto>(values);

        }
    }
}
