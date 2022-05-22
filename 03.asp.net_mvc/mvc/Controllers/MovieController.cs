using Microsoft.AspNetCore.Mvc;
using lab03.Models;
using System;
using System.Collections.Generic;


namespace lab03.Controllers {
  public class MovieController : Controller {
    public IActionResult Index() {
      var movies = get_list_of_movies();
      ViewBag.main_title = "List of my favorities movies.";
      return View(movies);
    }

    private List<MovieModel> get_list_of_movies() { 
      List<MovieModel> movies = new List<MovieModel>();
      movies.Add(new MovieModel {
        id = 1,
        name = "Grown Ups 2",
        genre = "Comedy",
        release_date = new DateTime(year: 2001, month: 12, day: 5)
      });

      movies.Add(new MovieModel {
        id = 2,
        name = "Toy Story",
        genre = "Family/Comedy",
        release_date = new DateTime(year: 1995, month: 11, day: 22)
      });

      movies.Add(new MovieModel {
        id = 1,
        name = "Fast and Furious 7",
        genre = "Action",
        release_date = new DateTime(year: 2017, month: 4, day: 19)
      });

      return movies;
    }
  }
}
