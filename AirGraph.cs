using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Air
{
    /// <summary>
    /// AirGraph class.
    /// </summary>
    public class AirGraph : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirGraph" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public AirGraph(AirConfiguration configuration)
        {
            Configuration = configuration;
            Initialise();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public AirConfiguration Configuration { get; private set; }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        private void Initialise()
        {
            var airGraphTask = TryGetAsync<AirGraphNode>(0);
            airGraphTask.Wait();
            if (airGraphTask.Result == null)
            {
                BootstrapStorage();
            }
        }

        /// <summary>
        /// Bootstraps the storage.
        /// </summary>
        private void BootstrapStorage()
        {
            var airGraph = new AirGraphNode { Id = 0 };
            var postTask = PostAsync(airGraph);
            postTask.Wait();
        }

        /// <summary>
        /// Gets the index id.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public long GetIndexId(string name)
        {
            return 0;
        }

        /// <summary>
        /// Loads the node.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public async Task<T> TryGetAsync<T>(long id) where T : IAirEntity
        {
            var data = await Configuration.Storage.TryGetAsync(id);
            if (data == null)
            {
                return default(T);
            }

            var deserialiser = Configuration.Serialisation.Get(typeof(T));
            return deserialiser.Deserialise<T>(data);
        }

        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public async Task<IList<T>> TryGetAsync<T>(IEnumerable<long> ids) where T : IAirEntity
        {
            var items = new List<T>();
            foreach (var id in ids)
            {
                var item = await TryGetAsync<T>(id);
                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// Posts this instance.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task PostAsync(IAirEntity item)
        {
            var serialiser = Configuration.Serialisation.Get(item.GetType());
            var data = serialiser.Serialise(item);
            await Configuration.Storage.AddAsync(item.Id, data);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}