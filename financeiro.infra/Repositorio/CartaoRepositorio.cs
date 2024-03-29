﻿using financeiro.dominio.Entidades;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.dominio.ViewModels;
using financeiro.infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace financeiro.infra.Repositorio
{
    public class CartaoRepositorio : ICartaoRepositorio
    {
        private readonly DataContext _db;

        public CartaoRepositorio(DataContext dataContext)
        {
            _db = dataContext;
        }

        public async Task AdicionarAsync(Cartao cartao)
        {
            await _db.AddAsync(cartao);
        }

        public async Task<List<CartaoResultViewModel>> ObterCartoesAsync() => await _db.Cartoes
            .AsNoTracking()
            .Where(p => p.FlExcluido == false)
            .Select(p => new CartaoResultViewModel(p.IdCartao, p.NomeCartao, p.DiaVencimentoFatura)).ToListAsync();
        public async Task<Cartao?> BuscarPorIdAsync(int idCartao) => await _db.Cartoes.Where(c => c.IdCartao == idCartao && c.FlExcluido == false).FirstOrDefaultAsync();
    }
}
