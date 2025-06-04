using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTasks
{
    public interface IOptionsBuilder
    {
        public Task<Configuration> LoadOptionsFromFileAsync(string path);
    }

    public class Configuration
    {

    }

    class AsyncInicialization
    {

        private Configuration opt = null!;
        private bool isInicialized;
        private Task<Configuration> inicializationTracker;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);

        public AsyncInicialization(string path, IOptionsBuilder opt)
        {
            inicializationTracker = opt.LoadOptionsFromFileAsync(path);
        }

        public async Task<Configuration> GetOptions(string path)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                if (inicializationTracker.IsFaulted)
                {
                    throw inicializationTracker.Exception;
                }

                if (!isInicialized)
                {
                    var options = await inicializationTracker;

                    opt = options;

                    isInicialized = true;
                }

                return opt;
            }

            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
