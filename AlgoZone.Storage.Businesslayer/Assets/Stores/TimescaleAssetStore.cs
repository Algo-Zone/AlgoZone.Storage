using System;
using System.Collections.Generic;
using System.Linq;
using AlgoZone.Storage.Businesslayer.Assets.Models;
using AlgoZone.Storage.Businesslayer.Assets.Stores;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.Assets.Stores
{
    public sealed class TimescaleAssetStore : IAssetStore
    {
        #region Fields

        private readonly TimescaleDbContext _db;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public TimescaleAssetStore(IMapper mapper, TimescaleDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void AddAsset(Asset asset)
        {
            var entity = _mapper.Map<Datalayer.TimescaleDB.Entities.Asset>(asset);
            if (entity == null)
                return;

            _db.Assets.Add(entity);
            _db.SaveChanges();

            asset.Id = entity.Id;
        }

        /// <inheritdoc />
        public IEnumerable<Asset> GetAllAssets()
        {
            return _db.Assets.Select(_mapper.Map<Asset>).ToList();
        }

        /// <inheritdoc />
        public Asset GetAssetById(int id)
        {
            var entity = _db.Assets.Find(id);
            if (entity == null)
                return null;

            return _mapper.Map<Asset>(entity);
        }

        /// <inheritdoc />
        public Asset GetAssetByName(string name)
        {
            var entity = _db.Assets.FirstOrDefault(c => c.Name == name);
            if (entity == null)
                return null;

            return _mapper.Map<Asset>(entity);
        }

        #endregion
    }
}