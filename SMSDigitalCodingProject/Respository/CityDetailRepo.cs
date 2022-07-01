using Microsoft.EntityFrameworkCore;
using SMSDigitalCodingProject.Model;

namespace SMSDigitalCodingProject.Respository
{
    public class CityDetailRepo : ICityDetailRepo
    {

        readonly DatabaseContext _dbContext;

        public CityDetailRepo(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CityDetail>> GetCityDetails()
        {

            if (_dbContext != null)
            {
                return await _dbContext.CityDetails.ToListAsync();
            }
            return null;
        }

        public async Task<CityDetail> GetCityDetailById(int? id)
        {

            if (_dbContext != null)
            {
                CityDetail? cityDetails = await _dbContext.CityDetails.FindAsync(id);
                if (cityDetails != null)
                {
                    return cityDetails;
                }
            }
            return null;
        }

        public async Task<int> AddCityDetail(CityDetail citydetail)
        {

            if (_dbContext != null)
            {
                //Add the city details
                await _dbContext.CityDetails.AddAsync(citydetail);

                //Commit the transaction
                await _dbContext.SaveChangesAsync();
                return citydetail.Id;
            }
            return 0;

        }

        public async Task UpdateCityDetail(CityDetail citydetail)
        {
            if (_dbContext != null)
            {
                //Update the city details
                _dbContext.CityDetails.Update(citydetail);

                //Commit the transaction
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteCityDetail(int? id)
        {
            int result = 0;

            if (_dbContext != null)
            {
                CityDetail? cityDetail = await _dbContext.CityDetails.FindAsync(id);

                if (cityDetail != null)
                {
                    //Delete the city details
                    _dbContext.CityDetails.Remove(cityDetail);

                    //Commit the transaction
                    result = await _dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
    

        public bool CheckCity(int id)
        {
            return _dbContext.CityDetails.Any(e => e.Id == id);
        }
    }
}
