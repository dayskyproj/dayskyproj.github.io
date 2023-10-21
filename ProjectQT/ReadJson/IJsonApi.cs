using ProjectQT.Data.DataDating;
using ProjectQT.Data.DataQuizDimensional;

namespace ProjectQT.ReadJson
{
    public interface IJsonApi
    {
        Task<InfoQuizDimensional> JsonQuizDimensional(string version);
        Task<InfoDating> JsonDating(string version);
    }
}
