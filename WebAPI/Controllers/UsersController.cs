using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly static List<User> _users;
    private static int _index;

    static UsersController()
    {
        _users = new List<User>()
        {
            new User(){Id = 1, FirstName = "Melek", LastName = "Satıcı", Email = "melek@siliconmade.com"},
            new User(){Id = 2, FirstName = "İbrahim Caner", LastName = "Coşkun", Email = "ibrahim@siliconmade.com"},
            new User(){Id = 3, FirstName = "Duygu", LastName = "Altıntaş", Email = "duygu@siliconmade.com"},
        };

        _index = _users.Count + 1;
    }

    //Ekleme, silme, güncelleme, listeleme
    //Action

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_users);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);

        if (user is null)
            return NotFound("Bu id'de bir kullanıcı yok");

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserCreateDto dto)
    {
        //Manual Mapping - Auto Mapping (AutoMapper)
        User user = new User()
        {
            Id = _index++,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
        };

        _users.Add(user);

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromBody] UserUpdateDto dto, [FromRoute] int id)
    {
        var userToUpdate = _users.FirstOrDefault(u => u.Id == id);

        if(userToUpdate is null)
            return NotFound("Bu id'de bir kullanıcı yok");

        userToUpdate.FirstName = dto.FirstName;
        userToUpdate.LastName = dto.LastName;
        userToUpdate.Email = dto.Email;


        return Ok(userToUpdate);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute]int id)
    {
        var userToDelete = _users.FirstOrDefault(u => u.Id == id);

        if (userToDelete is null)
            return NotFound("Bu id'de bir kullanıcı yok");

        _users.Remove(userToDelete);

        return Ok(userToDelete);
    }

}
