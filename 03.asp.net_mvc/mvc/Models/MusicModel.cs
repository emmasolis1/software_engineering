using Microsoft.AspNetCore.Mvc;
using System;

namespace lab03.Models
{
  public class MusicModel {
    public string name { get; set; }
    public DateTime release_date { get; set; }
    public string language { get; set; }
    public string genre { get; set; }
    public int number_likes { get; set; }
    public string category  { get; set; }
  }
}
