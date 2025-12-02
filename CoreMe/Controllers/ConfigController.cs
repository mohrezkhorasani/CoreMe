using Application.DTO;
using Application.Interface;
using Application.Interface.IUsecase;
using AutoMapper;
using CoreMe.VM;
using Microsoft.AspNetCore.Mvc;
using Presenter;
using Presistence.Entities;

namespace CoreMe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IGetConfigUseCase _IGetConfigUseCase { get; }
        public ApiPresenter<GetConfigResponse> _GetConfigResponse { get; }

        private readonly ILogger<ConfigController> _logger;

        public ConfigController(IMapper mapper, IGetConfigUseCase iGetConfigUseCase, ApiPresenter<GetConfigResponse> getConfigResponse, ILogger<ConfigController> logger)
        {
            _mapper = mapper;
            _IGetConfigUseCase = iGetConfigUseCase;
            _GetConfigResponse = getConfigResponse;
            _logger = logger;
        }

        [HttpPost("GetConfig")]
        public async Task<IActionResult> GetConfig(GetConfigVM vm) 
        {
            GetConfigRequest req = _mapper.Map<GetConfigRequest>(vm);

            await _IGetConfigUseCase.handleAsync(new GetConfigRequest
            {
                GeneralHeaders = GeneralHeader.GetGeneralHeaders(Request),
                
            }, _GetConfigResponse);
            return _GetConfigResponse.jsonContentResult;
        }
    }
}