namespace ProdutosApp.API.Dtos
{
    /// <summary>
    /// DTO para entrada de dados de produtos na API.
    /// </summary>
    public record ProdutoRequest(
        string Nome,        //Nome do produto
        string Descricao,   //Descrição do produto
        decimal Preco,      //Preço do produto
        int Quantidade      //Quantidade em estoque
        );
}
