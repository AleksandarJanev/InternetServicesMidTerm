using midTerm.Models.Models.AnswerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace midTerm.Services.Abstraction
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerModelBase>> Get();
        Task<AnswerModelExtended> Get(int id);
        Task<AnswerModelBase> Insert(AnswerCreateModel model);
        Task<AnswerModelBase> Update(AnswerUpdateModel model);
        Task<bool> Delete(int id);
    }
}
