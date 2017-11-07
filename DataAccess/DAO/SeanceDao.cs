using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entity;

namespace DataAccess.DAO
{
    public class SeanceDao : BaseDao, ISeanceDao
    {
        public IEnumerable<Seance> GetSeancesByCinemas(List<int> cinemasIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seance> GetSeancesByCity(List<string> cities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seance> GetSeancesByMovies(List<int> moviesIds)
        {
            throw new NotImplementedException();
        }
    }
}
