using System.Collections.Generic;
using AlgoZone.Storage.Businesslayer.Assets.Models;

namespace AlgoZone.Storage.Businesslayer.Assets.Stores
{
    public interface IAssetStore
    {
        #region Methods

        /// <summary>
        /// Adds a new asset to the store.
        /// </summary>
        /// <param name="asset">The asset to add.</param>
        void AddAsset(Asset asset);

        /// <summary>
        /// Gets a list of all the assets in this store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Asset> GetAllAssets();

        /// <summary>
        /// Gets a asset by it's id.
        /// </summary>
        /// <param name="id">The id of the asset.</param>
        /// <returns></returns>
        Asset GetAssetById(int id);

        /// <summary>
        /// Gets a asset by it's name.
        /// </summary>
        /// <param name="name">The name of the asset.</param>
        /// <returns></returns>
        Asset GetAssetByName(string name);

        #endregion
    }
}