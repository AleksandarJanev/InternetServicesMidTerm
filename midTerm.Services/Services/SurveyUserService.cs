using AutoMapper;
using Microsoft.EntityFrameworkCore;
using midTerm.Data;
using midTerm.Data.Entities;
using midTerm.Models.Models;
using midTerm.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace midTerm.Services.Services
{
    public class SurveyUserService : ISurveyUserService
    {
        private readonly midTermDbContext _context;
        private readonly IMapper _mapper;

        public SurveyUserService(midTermDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SurveyUserModelBase>> Get()
        {
            var users = await _context.SurveyUsers.ToListAsync();
            return _mapper.Map<IEnumerable<SurveyUserModelBase>>(users);
        }

        public async Task<SurveyUserModelExtended> Get(int id)
        {
            var user = await _context.SurveyUsers
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<SurveyUserModelExtended>(user);
        }

        public async Task<SurveyUserModelBase> Insert(SurveyUserCreateModel model)
        {
            var entity = _mapper.Map<SurveyUser>(model);

            await _context.SurveyUsers.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<SurveyUserModelBase>(entity);
        }

        public async Task<SurveyUserModelBase> Update(SurveyUserUpdateModel model)
        {
            var entity = _mapper.Map<SurveyUser>(model);

            _context.SurveyUsers.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await SaveAsync();

            return _mapper.Map<SurveyUserModelBase>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.SurveyUsers.FindAsync(id);
            _context.SurveyUsers.Remove(entity);
            return await SaveAsync() > 0;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
