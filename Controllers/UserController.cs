using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using projekt.Controllers.Resources;
using projekt.Models;
using projekt.Persistence;
using RestSharp;

namespace projekt.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = repository.GetUsers();

            if (users == null)
                return NotFound();

            var userResource = mapper.Map<QueryResult<User>, QueryResultResource<UserResource>>(users);
            return Ok(userResource);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id) {
            var user = repository.GetUser(id);
            
            if (user == null)
                return NotFound();

            var userResource = mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateUser(string id, [FromBody]UserResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userToSave = mapper.Map<UserResource, SaveUserResource>(userResource);

            var userToReturn = repository.UpdateUser(userToSave, id);

            var result = mapper.Map<User, UserResource>(userToReturn);
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}