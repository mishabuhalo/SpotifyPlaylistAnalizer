using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyPlaylistAnalizer.Application.Models.Users
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public Followers Folowers { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public List<Image> Images { get; set; }
    }
}
