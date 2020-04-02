using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;
using Vidly.DAL;
using Vidly.DAL.UOW;
using System.Data.Entity;

namespace Vidly.BL.APIs
{
    public class ProfilesController : ApiController
    {
        private UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());
        private ObjectMapper ObjectMapper = new ObjectMapper();

        [HttpGet]
        public IHttpActionResult GetProfile(string userName)
        {
            var selectedUser = UOW.UserRepository.Find(u => u.UserName == userName, ChildrenOfEntities.NoChildren)
                .SingleOrDefault();

            if (selectedUser == null)
            {
                return BadRequest("user not found");
            }

            var selectedUserDto = ObjectMapper.Mapper.Map<ApplicationUser, UserDTO>(selectedUser);

            return Ok(selectedUserDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateProfile(string id, UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var selectedUser = UOW.UserRepository.FindAsNoTracking(u => u.Id == id)
                .SingleOrDefault();

            if (selectedUser == null)
            {
                return NotFound();
            }

            ObjectMapper.Mapper.Map<UserDTO, ApplicationUser>(userDto, selectedUser);

            selectedUser.Id = id;

            UOW.UserRepository.Update(selectedUser);
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }
    }
}