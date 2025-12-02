using Application.DTO;
using Application.DTO.Generals;
using Application.General;
using Application.Interface;
using Application.Interface.IInfrastructure;
using Application.Interface.IUsecase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecase
{
    #region GetConfig
    public class GetConfigUseCase : IGetConfigUseCase
    {
        public IDBContext _repository { get; }
        public CommonMethods _commonMethods { get; }
        private readonly IWebHostEnvironment hosting;

        public GetConfigUseCase(IDBContext repository,
            IConfiguration configuration, IWebHostEnvironment hosting)
        {
            _repository = repository;
            this.hosting = hosting;
            _commonMethods = new CommonMethods(configuration, repository, hosting);
        }

        public async Task handleAsync(GetConfigRequest message,
            IOutPutPort<GenericResponse<GetConfigResponse>> outputPort)
        {

            outputPort.Handle(new GenericResponse<GetConfigResponse>
       (new GetConfigResponse
       {
           Message = "ok",
           Status = 200,

       }));

        }
    }
    #endregion

}