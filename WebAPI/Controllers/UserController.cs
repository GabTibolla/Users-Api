using API.Application.DTOs;
using API.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDTO userDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.CreateUserAsync(userDTO);
            return Ok(user);
        }

        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }

        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro inesperado", detail = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var users = await _userService.GetUsersAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro inesperado", detail = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromQuery] string email, UserDTO userDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.UpdateUser(email, userDTO);

            if (user == null)
            {
                return BadRequest(new { message = "Usuário não encontrado" });
            }

            return Ok(user);

        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro inesperado", detail = ex.Message });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] string email)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.DeleteUser(email);

            if (user == null)
            {
                return BadRequest(new { message = "Usuário não encontrado" });
            }

            return Ok(user == true ? "Deletado com sucesso" : "Não foi possível deletar");

        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro inesperado", detail = ex.Message });
        }
    }
}
