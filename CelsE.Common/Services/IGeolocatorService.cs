using System.Threading.Tasks;

namespace CelsE.Common.Services
{
    //Vídeo 19 https://www.youtube.com/watch?v=Tw0fpcAkyE4&list=PLuEZQoW9bRnSr1sM-49M7f6-inBcpp6kv&index=19
    public interface IGeolocatorService
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        Task GetLocationAsync();
    }
}