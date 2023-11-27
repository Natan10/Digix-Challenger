using AutoMapper;
using Digix.Application.Dtos;
using Digix.Application.Repositories;
using Digix.Domain.Entities;
using Digix.Domain.Handlers;

namespace Digix.Application.Services
{
    public interface IFamilyService
    {
        public Task<FamilyDto> CreateNewFamily(CreateFamilyDto newFamily);

        public Task<FamilyAnalysisDto> RunFamilyAnalysis(int familyId); 

        public Task<FamilyAnalysisDto> GetFamilyAnalysis(int familyAnalysisId);

        Task<List<FamilyAnalysisDto>> GetListOfFamiliesByScore(int page, int pageSize);
    }

    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly IMapper _mapper;
        private readonly HandlerRules _handlerRules;

        public FamilyService(IFamilyRepository familyRepository, IMapper mapper, HandlerRules rules)
        {
            _familyRepository = familyRepository;
            _mapper = mapper;
            _handlerRules = rules;
        }

        public async Task<FamilyDto> CreateNewFamily(CreateFamilyDto newFamily)
        {
            var family = new Family();
            var members = _mapper.Map<List<Person>>(newFamily.Members);

            foreach (var member in members)
            {
                family.AddFamilyMember(member);
            }

            var response = await _familyRepository.CreateNewFamily(family) ?? throw new Exception("Erro ao criar nova familia");
            return _mapper.Map<FamilyDto>(response);
        }

        public async Task<FamilyAnalysisDto> GetFamilyAnalysis(int familyAnalysisId)
        {
            var familyAnalysis = await _familyRepository.GetFamilyAnalysisById(familyAnalysisId);

            return _mapper.Map<FamilyAnalysisDto>(familyAnalysis);
        }

        public async Task<List<FamilyAnalysisDto>> GetListOfFamiliesByScore(int page, int pageSize)
        {
            var familiesAnalysisOrdered = await _familyRepository.GetListOfFamiliesByScore(page, pageSize);

            var records = _mapper.Map<List<FamilyAnalysisDto>>(familiesAnalysisOrdered);

            return records;
        }

        public async Task<FamilyAnalysisDto> RunFamilyAnalysis(int familyId)
        {
           
            var family = await _familyRepository.GetFamilyById(familyId);

            if(family.FamilyAnalysis != null)
            {
                throw new Exception("A família já possui uma análise cadastrada");
            }

            var analysisRules = new AnalysisRules();

            var familyAnalysis = new FamilyAnalysis(family, analysisRules);

            familyAnalysis.ExecuteAnalysis(_handlerRules);

            var createdFamilyAnalysis = await _familyRepository.CreateFamilyAnalysis(familyAnalysis);

            return _mapper.Map<FamilyAnalysisDto>(createdFamilyAnalysis);    
        }
    }
}
