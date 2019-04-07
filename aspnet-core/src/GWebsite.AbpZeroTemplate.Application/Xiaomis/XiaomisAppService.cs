using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Xiaomis;
using GWebsite.AbpZeroTemplate.Application.Share.Xiaomis.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
namespace GWebsite.AbpZeroTemplate.Web.Core.Xiaomis
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class XiaomisAppService : GWebsiteAppServiceBase, IXiaomisAppservice
    {
        private readonly IRepository<Xiaomi> xiaomiRepository;
        public XiaomisAppService(IRepository<Xiaomi> xiaomiRepository)
        {
            this.xiaomiRepository = xiaomiRepository;
        }
        #region Method
        public void CreateOrEditXiaomi(XiaomisInput xiaomisInput)
        {
            if (xiaomisInput.Id == 0)
            {
                Create(xiaomisInput);
            }
            else
            {
                Update(xiaomisInput);
            }
        }
        public void DeleteXiaomi(int id)
        {
            var xiaomiEnity = xiaomiRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (xiaomiEnity != null)
            {
                xiaomiEnity.IsDelete = true;
                xiaomiRepository.Update(xiaomiEnity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public XiaomisInput GetXiaomiForEdit(int id)
        {
            var xiaomiEnity = xiaomiRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (xiaomiEnity == null)
            {
                return null;
            }
            return ObjectMapper.Map<XiaomisInput>(xiaomiEnity);
        }

        public XiaomisForViewDto GetXiaomiForView(int id)
        {
            var xiaomiEnity = xiaomiRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (xiaomiEnity == null)
            {
                return null;
            }
            return ObjectMapper.Map<XiaomisForViewDto>(xiaomiEnity);
        }

        public PagedResultDto<XiaomisDto> GetXiaomi(XiaomisFilter input)
        {
            var query = xiaomiRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<XiaomisDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<XiaomisDto>(item)).ToList());
        }
        #endregion
        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(XiaomisInput xiaomisInput)
        {
            var xiaomiEnity = ObjectMapper.Map<Xiaomi>(xiaomisInput);
            SetAuditInsert(xiaomiEnity);
            xiaomiRepository.Insert(xiaomiEnity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(XiaomisInput xiaomisInput)
        {
            var xiaomiEnity = xiaomiRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == xiaomisInput.Id);
            if (xiaomiEnity == null)
            {
            }
            ObjectMapper.Map(xiaomisInput, xiaomiEnity);
            SetAuditEdit(xiaomiEnity);
            xiaomiRepository.Update(xiaomiEnity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
