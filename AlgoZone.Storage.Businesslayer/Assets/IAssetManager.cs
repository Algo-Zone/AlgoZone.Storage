using AlgoZone.Storage.Businesslayer.Assets.Models;

namespace AlgoZone.Storage.Businesslayer.Assets
{
    public interface IAssetManager
    {
        #region Methods

        /// <summary>
        /// Adds a new asset to the store.
        /// </summary>
        /// <param name="asset">The asset to add.</param>
        /// <returns></returns>
        bool AddAsset(Asset asset);

        /// <summary>
        /// Gets a asset by it's name.
        /// </summary>
        /// <param name="name">The name of the asset.</param>
        /// <returns></returns>
        Asset GetAsset(string name);

        /// <summary>
        /// Gets a asset by it's id.
        /// </summary>
        /// <param name="id">The id of the asset.</param>
        /// <returns></returns>
        Asset GetAsset(int id);

        #endregion
    }
}