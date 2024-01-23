namespace financeiro.dominio.ViewModels
{
    public class ResultErrorViewModel
    {
        public ICollection<String> Erros { get; private set; }

        public ResultErrorViewModel(ICollection<String> erros)
        {
            Erros = erros;
        }
    }
}
