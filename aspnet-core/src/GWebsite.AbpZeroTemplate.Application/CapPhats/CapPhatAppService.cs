using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.CapPhats;
using GWebsite.AbpZeroTemplate.Application.Share.CapPhats.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
namespace GWebsite.AbpZeroTemplate.Web.Core.CapPhats
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class CapPhatAppService : GWebsiteAppServiceBase, ICapPhatAppService
    {
        private readonly IRepository<CapPhat> capPhatrepository;
        public CapPhatAppService(IRepository<CapPhat> capPhatrepository)
        {
            this.capPhatrepository = capPhatrepository;
        }
        #region public method
        public void CreateOrEditCapPhat(CapPhatInput capPhatInput)
        {
            if (capPhatInput.Id == 0)
            {
                Create(capPhatInput);
            }
            else
            {
                Update(capPhatInput);
            }
        }

        public void DeleteCapPhat(int id)
        {
            var capPhatEntity = capPhatrepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (capPhatEntity != null)
            {
                capPhatEntity.IsDelete = true;
                capPhatrepository.Update(capPhatEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CapPhatInput GetCapPhatForEdit(int id)
        {
            var capPhatEntity = capPhatrepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (capPhatEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CapPhatInput>(capPhatEntity);
        }

        public CapPhatForViewDto GetCapPhatForView(int id)
        {
            var capPhatEntity = capPhatrepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (capPhatEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CapPhatForViewDto>(capPhatEntity);
        }
        #endregion
        #region Private Method
        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(CapPhatInput CapPhatInput)
        {
            var capPhatEnity = ObjectMapper.Map<CapPhat>(CapPhatInput);
            SetAuditInsert(capPhatEnity);
            capPhatrepository.Insert(capPhatEnity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(CapPhatInput CapPhatInput)
        {
            var capPhatEnity = capPhatrepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == CapPhatInput.Id);
            if (capPhatEnity == null)
            {
            }
            ObjectMapper.Map(CapPhatInput, capPhatEnity);
            SetAuditEdit(capPhatEnity);
            capPhatrepository.Update(capPhatEnity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
