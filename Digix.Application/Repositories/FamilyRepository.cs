using Microsoft.EntityFrameworkCore;

using Digix.Data;
using Digix.Domain.Entities;

namespace Digix.Application.Repositories
{
    public interface IFamilyRepository
    {
        Task<Family> CreateNewFamily(Family newFamily);

        Task<Family> GetFamilyById(int familyId);

        Task<FamilyAnalysis> CreateFamilyAnalysis(FamilyAnalysis familyAnalysis);

        Task<FamilyAnalysis> GetFamilyAnalysisById(int familyAnalysisId);

        Task<List<FamilyAnalysis>> GetListOfFamiliesByScore(int page, int pageSize);
    }


    public class FamilyRepository : IFamilyRepository
    {
        private readonly DataContext _dataContext;
        
        public FamilyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<FamilyAnalysis> CreateFamilyAnalysis(FamilyAnalysis familyAnalysis)
        {
            _dataContext.FamilyAnalyses.Add(familyAnalysis);

            await _dataContext.SaveChangesAsync();

            return await GetFamilyAnalysisById(familyAnalysis.Id);
        }

        public async Task<List<FamilyAnalysis>> GetListOfFamiliesByScore(int page, int pageSize)
        {
            var records = await _dataContext.FamilyAnalyses
                .Include(e => e.Family)
                .ThenInclude(e => e.FamilyMembers)
                .OrderByDescending(e => e.Score)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return records;
        }

        public async Task<FamilyAnalysis> GetFamilyAnalysisById(int familyAnalysisId)
        {
            var familyAnalysis = await _dataContext.FamilyAnalyses
                .Include(e => e.Family)
                .ThenInclude(e => e.FamilyMembers)
                .FirstOrDefaultAsync(e => e.Id == familyAnalysisId) ?? throw new Exception("Análise não encontrada");

            return familyAnalysis;
        }

        public async Task<Family> CreateNewFamily(Family newFamily)
        {
            _dataContext.Families.Add(newFamily);
            
            await _dataContext.SaveChangesAsync();

            var createdFamily = await _dataContext.Families
                .Include(e => e.FamilyMembers)
                .FirstAsync(e => e.Id == newFamily.Id);

            return createdFamily;
        }

        public async Task<Family> GetFamilyById(int familyId)
        {
            var family = await _dataContext.Families
                .Include(e => e.FamilyMembers)
                .Include(e => e.FamilyAnalysis)
                .FirstOrDefaultAsync(e => e.Id == familyId) ?? throw new Exception("Familia não encontrada");
            return family;
        }
    }
}
