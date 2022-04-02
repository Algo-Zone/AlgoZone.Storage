using System;
using AlgoZone.Storage.Businesslayer.Assets.Models;
using AlgoZone.Storage.Businesslayer.Assets.Stores;
using NLog;

namespace AlgoZone.Storage.Businesslayer.Assets
{
    public class AssetManager : IAssetManager
    {
        #region Fields

        private readonly IAssetStore _assetStore;

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        public AssetManager(IAssetStore assetStore)
        {
            _assetStore = assetStore;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public bool AddAsset(Asset asset)
        {
            if (asset.Id > 0)
                throw new ArgumentOutOfRangeException(nameof(asset));

            try
            {
                _assetStore.AddAsset(asset);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return false;
        }

        /// <inheritdoc />
        public Asset GetAsset(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            try
            {
                return _assetStore.GetAssetByName(name);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return null;
        }

        /// <inheritdoc />
        public Asset GetAsset(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            try
            {
                return _assetStore.GetAssetById(id);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return null;
        }

        #endregion
    }
}