using CommonLibrary;
using Microsoft.EntityFrameworkCore;
using ProfessionalsApi.Data;
using ProfessionalsApi.Models;
using ProfessionalsApi.Repository.IRepository;

namespace ProfessionalsApi.Repository
{
    public class ProfessionalRepository : IProfessionalRepository
    {

        private readonly ProfessionalApiContext _context;

        public ProfessionalRepository(ProfessionalApiContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangeStatus(int id,bool status)
        {
            var pro = await _context.Professionals.FindAsync(id);
            if (pro!=null)
            {
                pro.IsAvailable = status;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
           
        }

        public async Task<bool> ConfirmResponse(int id, bool confirmResponse, decimal rating)
        {
            var pro = await _context.Professionals.FindAsync(id);
            if (pro != null)
            {
                pro.IsConfirmed = confirmResponse;
                pro.Rating = rating;
                pro.TotalReviews = 1;
                pro.CummilativeRating = rating;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProfessional(int id)
        {
            var professionals = await _context.Professionals.FindAsync(id);
            if (professionals == null)
            {
                return false;
            }

            _context.Professionals.Remove(professionals);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Professionals>> GetAllProfessionals()
        {
            return await _context.Professionals.ToListAsync();
        }

        public async Task<Professionals> GetProfessional(int id)
        {
            var pro = await _context.Professionals.FindAsync(id);
            if (pro==null)
            {
                return new Professionals();
            }
            return pro;
        }

        public async Task<IEnumerable<Professionals>> GetProfessionalsByDomain(string domain)
        {
            return await _context.Professionals.Where(x=>x.Domain==domain).ToListAsync();
        }

        public async Task<bool> PostProfessional(RegistrationRequestDTO registrationRequestDTO)
        {
            var pro = new Professionals()
            {
                UserName = registrationRequestDTO.UserName,
                Email = registrationRequestDTO.Email,
                Phone = registrationRequestDTO.PhoneNo,
                Name = registrationRequestDTO.Name,
                
                Domain = registrationRequestDTO.Domain,
            };
            _context.Professionals.Add(pro);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Professionals> PutProfessional(int id,UpdateProfile updateProfile)
        {
            var pro = await _context.Professionals.FindAsync(id);
            if (pro == null)
            {
                return new Professionals();
            }
            pro.Address = updateProfile.Address;
            pro.Gender = updateProfile.Gender;
            pro.ProfilePic = updateProfile.ProfilePic;
            pro.BasePay = updateProfile.BasePay;
            pro.DOB = updateProfile.DOB;
            pro.DocumentPath = updateProfile.DocumentPath;  
            await _context.SaveChangesAsync();

            var domain = new Domains()
            {
                DomainName = pro.Domain,
                IsAvailable = pro.IsAvailable,
                ProfessionalId = pro.Id,
                ProfessionalName = pro.UserName,
            };
            await _context.Domains.AddAsync(domain);
            await _context.SaveChangesAsync();

            return pro;
        }
    }
}
