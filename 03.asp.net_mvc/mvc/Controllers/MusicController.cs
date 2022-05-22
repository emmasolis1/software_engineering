using Microsoft.AspNetCore.Mvc;
using lab03.Models;
using System;

namespace lab03.Controllers
{
  public class MusicController : Controller
  {
    public IActionResult Index() {
      var favorite_song = get_song_info();
      ViewBag.main_title = "My favorite song information";
      return View(favorite_song);
    }

    public MusicModel get_song_info() {
      MusicModel my_favorite_song = new MusicModel();
      my_favorite_song.name = "Yo quiero ser como tu.";
      my_favorite_song.release_date = new DateTime(year: 2015, month: 4, day: 21);
      my_favorite_song.language = "Spanish";
      my_favorite_song.genre = "Gospel";
      my_favorite_song.number_likes = 1000;
      my_favorite_song.category = "Original";

      return my_favorite_song;
    }
  }
}
