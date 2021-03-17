using AutoMapper;
using Microsoft.EntityFrameworkCore;
using midTerm.Data;
using midTerm.Data.Entities;
using midTerm.Models.Models.AnswerModels;
using midTerm.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace midTerm.Services.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly midTermDbContext _context;
        private readonly IMapper _mapper;

        public AnswerService(midTermDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<AnswerModelBase>> Get()
        {
            var answers = await _context.Answers.ToListAsync();
            return _mapper.Map<IEnumerable<AnswerModelBase>>(answers);
        }

        public async Task<AnswerModelExtended> Get(int id)
        {
            var answerById = await _context.Answers
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<AnswerModelExtended>(answerById);
        }

        public async Task<AnswerModelBase> Insert(AnswerCreateModel model)
        {
            var entity = _mapper.Map<Answers>(model);

            await _context.Answers.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<AnswerModelBase>(entity);
        }

        public async Task<AnswerModelBase> Update(AnswerUpdateModel model)
        {
            var entity = _mapper.Map<Answers>(model);

            _context.Answers.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await SaveAsync();

            return _mapper.Map<AnswerModelBase>(entity);
        }


        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(entity);
            return await SaveAsync() > 0;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
