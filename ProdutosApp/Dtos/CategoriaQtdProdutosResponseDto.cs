namespace ProdutosApp.Dtos
{
    /// <summary>
    /// Modelo de dados da consulta de somatório da 
    /// quantidade de produtos por cada categoria
    /// </summary>
    public class CategoriaQtdProdutosResponseDto
    {
        public string? Categoria { get; set; }
        public int QtdProdutos { get; set; }
    }
}
