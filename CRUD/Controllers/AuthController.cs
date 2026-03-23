using CRUD.Data;
using CRUD.Model;
using CRUD.Model.CRUD.Model;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register-musico")]
        public async Task<IActionResult> RegisterMusico(Musico musico)
        {
            _context.Musicos.Add(musico);
            await _context.SaveChangesAsync();
            return Ok("Músico registrado com sucesso!");
        }

        [HttpPost("register-ouvinte")]
        public async Task<IActionResult> RegisterOuvinte(Ouvinte ouvinte)
        {
            _context.Ouvintes.Add(ouvinte);
            await _context.SaveChangesAsync();
            return Ok("Ouvinte registrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string senha)
        {
            var musico = await _context.Musicos
                .FirstOrDefaultAsync(m => m.NomeArtistico == username && m.Senha == senha);

            if (musico != null)
            {
                var token = _tokenService.GenerateToken(username, "Musico");
                return Ok(new { token });
            }

            var ouvinte = await _context.Ouvintes
                .FirstOrDefaultAsync(o => o.Email == username && o.Senha == senha);

            if (ouvinte != null)
            {
                var token = _tokenService.GenerateToken(username, "Ouvinte");
                return Ok(new { token });
            }

            return Unauthorized("Credenciais inválidas");
        }
    }
}