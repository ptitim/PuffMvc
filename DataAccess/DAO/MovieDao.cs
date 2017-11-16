using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MovieDao : BaseDao
    {

        public List<int> GetMovieIdByTitle(List<string> list)
        {
            List<int> listOfId = new List<int>();

            var movies = this.context.Movies.Where(mv => list.Any(ls => mv.Name.Contains(ls)));

            listOfId = movies.Select(mv => mv.Id).Distinct().ToList();

            return listOfId;
        }
    }
}
