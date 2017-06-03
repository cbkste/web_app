using AutoMapper;

namespace web_app.Mappers
{
    public class MovieDbMapper : IMovieDbMapper
    {
        private readonly IMapper _mapper;

        public MovieDbMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public T Map<T1, T>(T1 input)
        {
            return _mapper.Map<T1, T>(input);
        }

        public T Map<T1, T>(T1 input, T output)
        {
            return _mapper.Map(input, output);
        }
    }
}