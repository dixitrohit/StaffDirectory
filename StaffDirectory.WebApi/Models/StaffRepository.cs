using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace StaffDirecotry.WebAPI.Models
{
    /// <summary>
    /// Repository used to perform DML operations
    /// </summary>
    public class StaffRepository

    {
        /// <summary>
        /// Fetch entire Staff collection
        /// </summary>
        /// <returns></returns>
        internal List<Staff> RetrieveStaff()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/StaffData.json");
            var json = System.IO.File.ReadAllText(filePath);
            var staff = JsonConvert.DeserializeObject<List<Staff>>(json);
            return staff;
        }
        /// <summary>
        /// Creates new Staff entry
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        internal object Save(Staff staff)
        {
            var stafff = this.RetrieveStaff();
            var maxID = stafff.Max(s => s.StaffID);
            staff.StaffID = maxID + 1;
            stafff.Add(staff);
            WriteData(stafff);
            return staff;
        }
        /// <summary>
        /// Write Staff data into json file
        /// </summary>
        /// <param name="stafff"></param>
        /// <returns></returns>
        private bool  WriteData(List<Staff> stafff)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/StaffData.json");

            var json = JsonConvert.SerializeObject(stafff, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }

        /// <summary>
        /// Save individual Staff entry
        /// </summary>
        /// <param name="id"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        internal object Save(int id, Staff staff)
        {
            // Read in the existing staff items
            var stafff = this.RetrieveStaff();

            int nStaffCount = stafff.Count();
            if (staff.StaffID <= nStaffCount)
            {
                stafff[staff.StaffID - 1] = staff;
            }
            else
            {
                return null;
            }
            WriteData(stafff);
            return staff;
        }
    }
}