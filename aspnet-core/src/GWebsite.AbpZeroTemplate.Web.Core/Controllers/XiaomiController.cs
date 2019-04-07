using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Xiaomis;
using GWebsite.AbpZeroTemplate.Application.Share.Xiaomis.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class XiaomiController : GWebsiteControllerBase
    {
        private readonly IXiaomisAppservice _xiaomisAppservice;

        public XiaomiController(IXiaomisAppservice xiaomisAppservice)
        {
            this._xiaomisAppservice = xiaomisAppservice;
        }

        [HttpGet]
        public string GetTest()
        {
            return "Test";
        }
        [HttpGet]
        public PagedResultDto<XiaomisDto> GetXiaomissByFilter(XiaomisFilter xiaomisFilter)
        {
            return _xiaomisAppservice.GetXiaomi(xiaomisFilter);
        }

        [HttpGet]
        public XiaomisInput GetXiaomiForEdit(int id)
        {
            return _xiaomisAppservice.GetXiaomiForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditXiaomi([FromBody] XiaomisInput input)
        {
            _xiaomisAppservice.CreateOrEditXiaomi(input);
        }

        [HttpDelete("{id}")]
        public void DeleteXiaomi(int id)
        {
            _xiaomisAppservice.DeleteXiaomi(id);
        }

        [HttpGet]
        public XiaomisForViewDto GetXiaomiForView(int id)
        {
            return _xiaomisAppservice.GetXiaomiForView(id);
        }
    }     
}

