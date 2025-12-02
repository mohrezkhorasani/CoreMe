using Application.DTO.Generals;
using Application.DTO.Models;
using Application.Interface.IUsecase;
using System;
using System.Collections.Generic;
using static Application.General.Statics;

namespace Application.DTO
{

   


    #region GetConfig
    public class GetConfigRequest : BaseParentRequest, IUseCaseRequest<GenericResponse<GetConfigResponse>>
    {
        public string Key { get; set; }

    }

    public class GetConfigResponse : BaseParentResponce
    {
        
    }
    #endregion






}
