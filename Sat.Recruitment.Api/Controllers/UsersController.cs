using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Business.User;
using Sat.Recruitment.Models.Helpers;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserBusiness _business;
        private readonly UserValidator _userValidator;

        public UsersController(IMapper mapper, IUserBusiness business)
        {
            _mapper = mapper;
            _business = business;
            _userValidator = new UserValidator();
        }

        [HttpGet("")]
        public ActionResult<List<UserDto>> GetAll()
        {
            try
            {
                return Ok(_mapper.Map<List<UserDto>>(_business.GetAll()));
            }
            catch (Exception ex)
            {
                var result = new ObjectResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }

        [HttpGet("/{email}")]
        public ActionResult<UserDto> GetByEmail(string email)
        {
            try
            {
                EmailValidator.ValidateEmail(email);
                return Ok(_mapper.Map<UserDto>(_business.GetByEmail(email)));
            }
            catch (Exception ex)
            {
                var result = new ObjectResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreateUser([FromBody] UserDto user)
        {
            try
            {
                ValidationResult result = _userValidator.Validate(user);

                if(!result.IsValid)
                {
                    string errorMsg = "";
                    
                    foreach(var error in result.Errors)
                    {
                        errorMsg = string.Join(",", $"Error in {error.PropertyName} {error.ErrorMessage}");
                    }
                    
                    return new ResponseDto()
                    {
                        IsSuccess = false,
                        Msg = errorMsg
                    };
                }

                _business.Insert(user);
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Msg = ""
                };
            }
            catch(Exception ex)
            {
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Msg = ex.Message
                };
            }
        }
    }
}
