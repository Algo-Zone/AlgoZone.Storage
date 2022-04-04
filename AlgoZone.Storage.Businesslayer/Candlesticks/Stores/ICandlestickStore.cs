﻿using System;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;

namespace AlgoZone.Storage.Businesslayer.Candlesticks.Stores
{
    public interface ICandlestickStore
    {
        #region Methods

        /// <summary>
        /// Adds a candlestick to the store.
        /// </summary>
        /// <param name="candlestick">The candlestick to add.</param>
        void AddCandlestick(Candlestick candlestick);

        /// <summary>
        /// Checks whether a candlestick already exists.
        /// </summary>
        /// <param name="candlestick">The candlestick to check.</param>
        /// <returns></returns>
        bool CheckIfCandlestickExists(Candlestick candlestick);

        /// <summary>
        /// Gets a candlestick by it's open time and trading pair id.
        /// </summary>
        /// <param name="openTime">The open time of the candlestick.</param>
        /// <param name="tradingPairId">The id of the trading pair.</param>
        /// <returns></returns>
        Datalayer.TimescaleDB.Entities.Candlestick GetCandlestickEntity(DateTime openTime, int tradingPairId);

        /// <summary>
        /// Updates a candlestick in the store.
        /// </summary>
        /// <param name="candlestick">The candlestick to update.</param>
        void UpdateCandlestick(Candlestick candlestick);

        #endregion
    }
}