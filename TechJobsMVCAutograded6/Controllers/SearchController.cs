using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        return View();
    }
    public IActionResult Results(string searchType, string searchTerm)
    {
        List<Job> jobs = new();
        if (searchTerm == "all" || string.IsNullOrEmpty(searchTerm))
        {
            jobs = JobData.FindAll();
            ViewBag.title = "All Jobs";
        }
        else 
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.title = "Result for " + searchTerm + "in " + searchType;
        }
        ViewBag.jobs = jobs;
        ViewBag.columns = ListController.ColumnChoices;
        return View("Index");
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
}

