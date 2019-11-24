using System.Threading.Tasks;

namespace OpenDND.Services
{
    public interface IBehavior
    {
        /// <summary>
        /// Starts executing the behavior's logic.
        /// </summary>
        /// <returns>A <see cref="Task>"/> which will complete when the operation has completed.</returns>
        Task StartAsync();

        /// <summary>
        /// Stops executing the behavior's logic.
        /// </summary>
        /// <returns>A <see cref="Task>"/> which will complete when the operation has completed.</returns>
        Task StopAsync();
    }
}