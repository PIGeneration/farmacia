using farmacia.Model;
using farmacia.Service;
using farmacia.Service.Implements;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace farmacia.Controller
{
    [Route("~/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        
        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;

        public ProdutoController(
            IProdutoService produtoService,
            IValidator<Produto> produtoValidator
            )
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _produtoService.GetById(id);

            if (Resposta is null)
            {
                return NotFound("Produto não encontrado!");
            }

            return Ok(Resposta);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            return Ok(await _produtoService.GetByNome(nome));
        }

        [HttpGet("nome/{nome}/elaboratorio/{laboratorio}")]
        public async Task<ActionResult> GetByNomeELaboratorio(string nome, string laboratorio)
        {
            return Ok(await _produtoService.GetByNomeELaboratorio(nome, laboratorio));
        }

        [HttpGet("nome/{nome}/oulaboratorio/{laboratorio}")]
        public async Task<ActionResult> GetByNomeOuLaboratorio(string nome, string laboratorio)
        {
            return Ok(await _produtoService.GetByNomeOuLaboratorio(nome, laboratorio));
        }

        [HttpGet("preco_inicial/{precoInicial}/preco_final/{precoFinal}")]
        public async Task<ActionResult> GetByBetweenPreco(decimal precoInicial, decimal precoFinal)
        {
            return Ok(await _produtoService.GetByBetweenPreco(precoInicial, precoFinal));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
                return BadRequest("Tema não encontrado!");

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.Id == 0)
                return BadRequest("Id da Produto é inválido!");

            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Update(produto);

            if (Resposta is null)
                return NotFound("Produto e/ou Tema não encontrados!");

            return Ok(Resposta);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaProduto = await _produtoService.GetById(id);

            if (BuscaProduto is null)
                return NotFound("Produto não encontrado!");

            await _produtoService.Delete(BuscaProduto);

            return NoContent();

        }

    }
}
