using System;
using System.Collections.Generic;
using System.Linq;
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
            var airGraphTask = TryGetAsync<AirGraphNode>(1);
            airGraphTask.Wait();
            if (airGraphTask.Result == null)
            {
                var airGraph = new AirGraphNode { Id = 1 };
                var postTask = UpdateAsync(airGraph);
                postTask.Wait();

                if (Configuration.Bootstrapping != null)
                {
                    Configuration.Bootstrapping(this);
                }
            }
        }

        /// <summary>
        /// Gets the index id.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public async Task<long> GetIndexId(string name)
        {
            var node = await TryGetAsync<AirGraphNode>(1);
            var edge = node.IdsByIndexName.FirstOrDefault(f => f.Item1 == name);
            if (edge == null)
            {
                throw new KeyNotFoundException();
            }

            return edge.Item2;
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
        public async Task UpdateAsync(IAirEntity item)
        {
            if (item.Id == 0)
            {
                throw new ArgumentException("The item does not currently exist.");
            }

            var serialiser = Configuration.Serialisation.Get(item.GetType());
            var data = serialiser.Serialise(item);
            await Configuration.Storage.SetAsync(item.Id, data);
        }

        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task AddAsync(IAirEntity item)
        {
            await SetServerId(item);
            var serialiser = Configuration.Serialisation.Get(item.GetType());
            var data = serialiser.Serialise(item);
            await Configuration.Storage.AddAsync(item.Id, data);
        }

        public Task AddAsync(IEnumerable<IAirEntity> items)
        {
            return Task.WhenAll(items.Select(AddAsync));
        }

        /// <summary>
        /// SetServerId
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns on completion</returns>
        private Task SetServerId(IAirEntity item)
        {
            // await Configuration.Storage.GetLockAsync(1);
            // var node = await TryGetAsync<AirGraphNode>(1);
            // item.Id = node.NextAvailableId++;
            // await UpdateAsync(node);
            // Configuration.Storage.ReleaseLockAsync(1);
            item.Id = Configuration.IdFactory.GetNextId();
            return Task.Factory.StartNew(() => { });
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}