using EFCore.BulkExtensions;
using BlackBulkInsertCodeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace BlackBulkInsertCodeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentContext _appDbContext;
        private DateTime Start;
        private TimeSpan TimeSpan;


        //The "duration" variable contains Execution time when we doing the operations (Insert)  
        public HomeController(StudentContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Names> names = new List<Names>();            //start time now
            Start = DateTime.Now;
            //create fake data
            for (int i = 0; i < 100000; i++)
            {
                names.Add(new Names()
                {
                    Name = "BlackCoder_" + i,
                    UniqueID = Guid.NewGuid()
                });
            }

            //open database connection
            using (var transaction = _appDbContext.Database.BeginTransaction())
            {
                //insert list data using BlackBulkInsertCodeApp
                _appDbContext.BulkInsert(names);
                //commit, save changes
                transaction.Commit();
            }
            TimeSpan = DateTime.Now - Start; // check total time taken

            return View();
        }
    }
}