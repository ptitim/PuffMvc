using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface ISeanceDao
    {

        IEnumerable<Seance> GetSeancesByCinemas(List<int> cinemasIds);

        IEnumerable<Seance> GetSeancesByMovies(List<int> moviesIds);

        IEnumerable<Seance> GetSeancesByCity(List<string> cities); 
    }
}
