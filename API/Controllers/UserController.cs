﻿using System.Threading.Tasks;
using Application.User;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class UserController: BaseController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<User>> CurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }

        [HttpPost("funds/add")]
        public async Task<ActionResult<Unit>> AddFunds(AddCash.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("funds/withdraw")]
        public async Task<ActionResult<Unit>> WithdrawFunds(WithdrawCash.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}