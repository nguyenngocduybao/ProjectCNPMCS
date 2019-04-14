using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ThuHois;
using GWebsite.AbpZeroTemplate.Application.Share.ThuHois.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
namespace GWebsite.AbpZeroTemplate.Web.Core.ThuHois
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ThuHoiAppService:GWebsiteAppServiceBase,IThuHoiAppService
    {
        private readonly IRepository<ThuHoi> thuHoirepository;
        public ThuHoiAppService(IRepository<ThuHoi> thuHoirepository)
        {
            this.thuHoirepository = thuHoirepository;
        }
        public void CreateOrEditThuHoi(ThuHoiInput thuHoiInput)
        {
            if (thuHoiInput.Id == 0)
            {
                Create(thuHoiInput);
            }
            else
            {
                Update(thuHoiInput);
            }
        }

        public void DeleteThuHoi(int id)
        {
            var thuHoiEnity = thuHoirepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (thuHoiEnity != null)
            {
                thuHoiEnity.IsDelete = true;
                thuHoirepository.Update(thuHoiEnity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ThuHoiForViewDto GetThuHoiForView(int id)
        {
            var thuHoiEnity = thuHoirepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (thuHoiEnity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ThuHoiForViewDto>(thuHoiEnity);
        }

        public ThuHoiInput GetThuHoiForEdit(int id)
        {
            var thuHoiEnity = thuHoirepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (thuHoiEnity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ThuHoiInput>(thuHoiEnity);
        }
        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(ThuHoiInput thuHoiInput)
        {
            var thuHoiEnity = ObjectMapper.Map<ThuHoi>(thuHoiInput);
            SetAuditInsert(thuHoiEnity);
            thuHoirepository.Insert(thuHoiEnity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(ThuHoiInput thuHoiInput)
        {
            var thuHoiEnity = thuHoirepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == thuHoiInput.Id);
            if (thuHoiEnity == null)
            {
            }
            ObjectMapper.Map(thuHoiInput, thuHoiEnity);
            SetAuditEdit(thuHoiEnity);
            thuHoirepository.Update(thuHoiEnity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
