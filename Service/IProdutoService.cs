using farmacia.Model;

namespace farmacia.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task <IEnumerable<Produto>> GetByNomeELaboratorio(string nome, string laboratorio);

        Task<IEnumerable<Produto>> GetByNomeOuLaboratorio(string nome, string laboratorio);

        Task<IEnumerable<Produto>> GetByBetweenPreco(decimal precoInicial, decimal precoFinal);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);
    }
}
