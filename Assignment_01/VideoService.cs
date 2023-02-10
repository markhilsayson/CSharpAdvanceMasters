using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public class VideoService
    {
        public List<Video> SetToNotAvailable(string identifier,List<Video> Videos)
        {
            Videos.Where(x => x.Id == identifier).ToList().ForEach(x => x.IsAvailable = false);
            return Videos.Where(p => p.IsAvailable).ToList();
        }
    }
}
