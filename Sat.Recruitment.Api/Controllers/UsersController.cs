using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Business.User;
using Sat.Recruitment.Models.Helpers;
using Sat.Recruitment.Models.Helpers.UserValidation;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserBusiness _business;

        public UsersController(IMapper mapper, IUserBusiness business)
        {
            _mapper = mapper;
            _business = business;
        }

        [HttpGet("")]
        public IActionResult GetAll()
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
        public IActionResult GetByEmail(string email)
        {
            try
            {
                EmailValidator.ValidateEmail(email);
                return Ok(_mapper.Map<UserDto>(_business.GetByEmail(email)));
            }
            catch (Exception ex)
            {
                var result = new ObjectResult(ex.Message);
                result.StatusCode = 404;
                return result;
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            try
            {
                UserValidatorWrapper.Validate(user);
                _business.Insert(user);
                return Ok();
            }
            catch(Exception ex)
            {
                var result = new ObjectResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }
    }
}
