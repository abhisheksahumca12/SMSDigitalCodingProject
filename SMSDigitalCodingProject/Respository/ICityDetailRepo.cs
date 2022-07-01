using SMSDigitalCodingProject.Model;

namespace SMSDigitalCodingProject.Respository
{
    public interface ICityDetailRepo
    {
        Task<List<CityDetail>> GetCityDetails();
        Task<CityDetail> GetCityDetailById(int? id);
        Task<int> AddCityDetail(CityDetail citydetail);
        Task UpdateCityDetail(CityDetail citydetail);
        Task<int> DeleteCityDetail(int? id);
        bool CheckCity(int id);
    }
}
