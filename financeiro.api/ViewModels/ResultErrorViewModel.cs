﻿namespace financeiro.api.ViewModels
{
    public class ResultErrorViewModel
    {
        public string Erros { get; private set; }

        public ResultErrorViewModel(string erros)
        {
            Erros = erros;
        }
    }
}
