using StaffDirecotry.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace StaffDirecotry.WebAPI.Controllers
{
    
    public class StaffController : ApiController
    {
        
        // GET api/<controller>
        /// <summary>
        /// Gets full Staff collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Staff> Get()
        {
            var staffRepository = new StaffRepository();
            return staffRepository.RetrieveStaff();
        }

        // GET api/<controller>/5

        /// <summary>
        /// Get individul Staff member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Staff Get(int id)
        {
            Staff staff=null;
            var staffRepository = new StaffRepository();
            if (id > 0)
            {
                var staffMembers = staffRepository.RetrieveStaff();
                staff = staffMembers.FirstOrDefault(s => s.StaffID == id);
                
            }
            return staff;
        }

        // POST api/<controller>
        /// <summary>
        /// Creates new Staff entry
        /// </summary>
        /// <param name="staff"></param>
        public void Post([FromBody]Staff staff)
        {
            var staffRepository = new Models.StaffRepository();
            var newStaff = staffRepository.Save(staff);
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Updates existing Staff member
        /// </summary>
        /// <param name="id"></param>
        /// <param name="staff"></param>
        public void Put(int id, [FromBody]Staff staff)
            
        {
            var staffRepository = new Models.StaffRepository();
            var updateStaff = staffRepository.Save(id, staff);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}