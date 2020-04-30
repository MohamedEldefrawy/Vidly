using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.BL.Domain;
using Vidly.BL.DTOs;
using Vidly.DAL;
using Vidly.DAL.UOW;
using System.IO;
namespace Vidly.BL.APIs
{
    public class ProfilesController : ApiController
    {
        private UnitOFWork UOW = new UnitOFWork(new VidlyDbContext());
        private ObjectMapper ObjectMapper = new ObjectMapper();

        [HttpGet]
        public IHttpActionResult GetProfile(string userName)
        {
            var selectedUser = UOW.UserRepository.Find(u => u.UserName == userName)
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

            ObjectMapper.Mapper.Map(userDto, selectedUser);

            selectedUser.Id = id;

            UOW.UserRepository.Update(selectedUser);
            UOW.Complete();
            UOW.Dispose();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UplaodProfilePicture()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
       HttpContext.Current.Request.Files[0] : null;
            string fileName;
            if (file != null && file.ContentLength > 0)
            {
                Uri baseUri = new Uri("~/Images");
                fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), fileName);
                Uri myUri = new Uri(baseUri, fileName);
                fileName = myUri.ToString();
                file.SaveAs(fileName);
            }

            else
                fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), "Avatar.png");

            return Ok(fileName);
        }
    }
}