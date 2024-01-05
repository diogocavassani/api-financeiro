﻿using financeiro.dominio.Entidade;
using financeiro.dominio.ViewModel;
using financeiro.infra.Repositorio;

namespace financeiro.aplicacao.App
{
    public class CartaoApp : AppBase
    {
        private readonly CartaoRepositorio _cartaoRepositorio;

        public CartaoApp(CartaoRepositorio cartaoRepositorio)
        {
            _cartaoRepositorio = cartaoRepositorio;
        }

        public async Task<CartaoResultViewModel?> BuscarPorIdAsync(int idCartao)
        {
            var cartao = await _cartaoRepositorio.BuscarPorIdAsync(idCartao);

            return cartao != null ? 
                new CartaoResultViewModel(cartao.IdCartao, cartao.NomeCartao, cartao.DiaVencimentoFatura) : null;
        }

        public async Task<bool> ExcluirCartaoAsync(int idCartao)
        {
            if (idCartao == 0)
            {
                return false;
            }
            var cartao = await _cartaoRepositorio.BuscarPorIdAsync(idCartao);
            if (cartao == null)
            {
                return false;
            }

            cartao.Excluir();
            await _cartaoRepositorio.SalvarDados();
            return true;
        }

        public async Task<List<CartaoResultViewModel>> ObterCartoesAsync()
        {
            return await _cartaoRepositorio.ObterCartoesAsync();
        }

        public async Task<CartaoResultViewModel> PersisteCartaoAsync(CartaoInputViewModel cartaoViewModel)
        {
            var cartao = new Cartao(cartaoViewModel.NomeCartao ?? "", cartaoViewModel.DiaVencimentoFatura);
            await _cartaoRepositorio.AdicionarAsync(cartao);
            return new CartaoResultViewModel(cartao.IdCartao, cartao.NomeCartao, cartao.DiaVencimentoFatura);
        }
    }
}