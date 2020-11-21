using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CobrancaAPI.Controllers;
using CobrancaAPI.Models.Entity;
using CobrancaAPI.Models.Services;
using CobrancaAPI.Persistence.Repositories;

namespace CobrancaAPI.Services
{
    public class CobrancaService : ICobrancaService
    {
        private readonly ICobrancaRepository _cobrancaRepository;

        public CobrancaService(ICobrancaRepository cobrancaRepository)
        {
            _cobrancaRepository = cobrancaRepository;
        }

        public async Task<CobrancaResponse> Create(Cobranca cobranca)
        {
            try
            {
                await _cobrancaRepository.Create(cobranca);
                return new CobrancaResponse(cobranca);
            }
            catch (Exception ex)
            {
                return new CobrancaResponse($"An error ocurred while saving cobranca: {ex.Message}");
            }
        }

        public async Task<CobrancaListResponse> CreateMany(IEnumerable<Cobranca> cobrancas)
        {
            try
            {
                await _cobrancaRepository.CreateMany(cobrancas);
                return new CobrancaListResponse(cobrancas);
            }
            catch (Exception ex)
            {
                return new CobrancaListResponse($"An error ocurred while saving cobranca: {ex.Message}");
            }
        }

        public async Task<CobrancaListResponse> Query(IDictionary<string, string> cobrancaQuery)
        {
            try
            {
                IEnumerable<Cobranca> cobrancas = await _cobrancaRepository.Query(cobrancaQuery);
                return new CobrancaListResponse(cobrancas);
            }
            catch (Exception ex)
            {
                return new CobrancaListResponse($"An error ocurred while querying cobranca: {ex.Message}");
            }
        }
    }
}