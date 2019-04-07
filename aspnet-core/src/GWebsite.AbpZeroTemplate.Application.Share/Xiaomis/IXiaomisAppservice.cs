using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Xiaomis.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Xiaomis
{
    public interface IXiaomisAppservice
    {
        void CreateOrEditXiaomi(XiaomisInput customerInput);
        XiaomisInput GetXiaomiForEdit(int id);
        void DeleteXiaomi(int id);
        PagedResultDto<XiaomisDto> GetXiaomi(XiaomisFilter input);
        XiaomisForViewDto GetXiaomiForView(int id);
    }
}
