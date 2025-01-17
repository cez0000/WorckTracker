﻿using Microsoft.AspNetCore.Mvc;
using WorkTracker.Data;
using WorkTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkTracker.Controllers
{
    public class SummaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SummaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(!User.IsInRole("Admin"))
            {
                return NotFound();
            }
            return View(new ActivityFilterViewModel());
        }

        [HttpPost]
        public IActionResult Index(ActivityFilterViewModel filter)
        {
            if (!ModelState.IsValid)
            {
                return View(filter);
            }

            var statistics = _context.Activity
                .Include(a => a.ActivityType)
                .Include(a => a.User)
                .AsEnumerable()
                .Where(a => a.Date >= filter.StartDate && a.Date <= filter.EndDate)
                .GroupBy(a => new { a.User.Email, a.ActivityType.Name })
                .Select(group => new ActivityStatisticsViewModel
                {
                    EmployeeEmail = group.Key.Email,
                    Activity = group.Key.Name,
                    TotalHours = FormatDuration(group.Sum(a => a.Duration.TotalHours)),
                })
                .ToList();

            ViewBag.Filter = filter;
            return View("FilteredResults", statistics);
        }
        private string FormatDuration(double totalHours)
        {

            int hours = (int)totalHours;


            int minutes = (int)((totalHours - hours) * 60);


            return $"{hours:D2}:{minutes:D2}";
        }
    }
    
}