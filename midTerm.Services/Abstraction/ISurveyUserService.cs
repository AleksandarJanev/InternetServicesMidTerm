using midTerm.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace midTerm.Services.Abstraction
{
    public interface ISurveyUserService
    {
        Task<IEnumerable<SurveyUserModelBase>> Get();
        Task<SurveyUserModelExtended> Get(int id);
        Task<SurveyUserModelBase> Insert(SurveyUserCreateModel model);
        Task<SurveyUserModelBase> Update(SurveyUserUpdateModel model);
        Task<bool> Delete(int id);
    }
}
