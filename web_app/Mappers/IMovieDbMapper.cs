using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Mappers
{
    public interface IMovieDbMapper
    {
        T Map<T1, T>(T1 input);
        T Map<T1, T>(T1 input, T output);
    }
}
