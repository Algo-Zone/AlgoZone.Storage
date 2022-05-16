using System;
using System.Linq;
using System.Threading.Tasks;
using AlgoZone.Storage.Api.Models;
using AlgoZone.Storage.Businesslayer.Candlesticks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlgoZone.Storage.Api.Controllers
{
    [ApiController]
    [Route("api/candlesticks")]
    [ApiVersion("1.0")]
    public class CandlestickController : ControllerBase
    {
        #region Fields

        private readonly ICandlestickManager _candlestickManager;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public CandlestickController(ICandlestickManager candlestickManager, IMapper mapper)
        {
            _candlestickManager = candlestickManager;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<ListResponse<CandlestickResponse>>> GetCandlesticks(string symbol, DateTime startDate = default, DateTime endDate = default)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                return BadRequest("symbol is empty");
            
            if(startDate == default)
                startDate = DateTime.MinValue;
            
            if(endDate == default)
                endDate = DateTime.MaxValue;
            
            var candlesticks = _candlestickManager.GetCandlesticks(symbol, startDate, endDate);

            var response = new ListResponse<CandlestickResponse>();
            
            response.Items = candlesticks.Select(_mapper.Map<CandlestickResponse>).ToList();
            response.TotalCount = candlesticks.Count;

            return Ok(response);
        }

        #endregion
    }
}