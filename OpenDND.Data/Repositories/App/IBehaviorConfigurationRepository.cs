using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDND.Data.Models.App;

namespace OpenDND.Data.Repositories.App
{
    public interface IBehaviourConfigurationRepository
    {
        Task<IEnumerable<BehaviourConfiguration>> GetBehaviours();
    }

    public class BehaviourConfigurationRepository : IBehaviourConfigurationRepository
    {
        private readonly OpenDNDContext _openDndContext;

        public BehaviourConfigurationRepository(OpenDNDContext openDndContext)
        {
            _openDndContext = openDndContext;
        }

        public async Task<IEnumerable<BehaviourConfiguration>> GetBehaviours()
        {
            return await _openDndContext.BehaviourConfigurations.ToListAsync();
        }
    }
}