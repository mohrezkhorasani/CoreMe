

using Application.DTO;
using Application.DTO.Generals;

namespace Application.Interface.IUsecase
{

    public interface IGetConfigUseCase : IUseCaseRequestHandler<GetConfigRequest, GenericResponse<GetConfigResponse>> { }
}
