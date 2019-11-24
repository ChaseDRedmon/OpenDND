using System.Threading.Tasks;
using OpenDND.Data.Repositories.App;

namespace OpenDND.Services.BehaviorConfiguration
{
    public interface IBehaviourConfigurationService
    {
        Task LoadBehaviourConfiguration();
    }

    public class BehaviourConfigurationService : IBehaviourConfigurationService
    {
        private readonly IBehaviourConfigurationRepository _behaviourConfigurationRepository;
        private readonly IBehaviourConfiguration _behaviourConfiguration;

        public BehaviourConfigurationService(IBehaviourConfigurationRepository behaviourConfigurationRepository, IBehaviourConfiguration behaviourConfiguration)
        {
            _behaviourConfigurationRepository = behaviourConfigurationRepository;
            _behaviourConfiguration = behaviourConfiguration;
        }

        public Task LoadBehaviourConfiguration()
        {
            //var behaviours = await _behaviourConfigurationRepository.GetBehaviours();
            return Task.CompletedTask;
        }
    }
}