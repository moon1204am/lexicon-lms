using AutoMapper;
using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Shared.Dtos;

namespace LexiconLMS.Server.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModuleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ModuleDto>> GetModulesAsync(bool includeAll = false)
        {
            return _mapper.Map<IEnumerable<ModuleDto>>(await _unitOfWork.ModuleRepository.GetAllAsync(includeAll));
        }

        public async Task<ModuleDto> GetModuleAsync(Guid id)
        {
            return _mapper.Map<ModuleDto>(await _unitOfWork.ModuleRepository.GetAsync(id));
        }
        public async Task<ModuleDto> CreateModuleAsync(ModuleAddDto moduleAddDto)
        {
            var module = _mapper.Map<Module>(moduleAddDto);
            await _unitOfWork.ModuleRepository.CreateAsync(module);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ModuleDto>(module);
        }

        public async Task DeleteModuleAsync(Guid id)
        {
            var module = await _unitOfWork.ModuleRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            _unitOfWork.ModuleRepository.Delete(module);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateModuleAsync(Guid id, ModuleDto moduleDto)
        {
            var module = await _unitOfWork.ModuleRepository.GetAsync(id) ?? throw new ArgumentNullException(nameof(id));
            var moduleToUpdate = _mapper.Map(moduleDto, module);
            _unitOfWork.ModuleRepository.Update(moduleToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
