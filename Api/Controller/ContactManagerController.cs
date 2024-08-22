using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContactManagerController : ControllerBase 
{

    private readonly ContactStorage contactStorage;

    public ContactManagerController(ContactStorage contactStorage) 
    {
        this.contactStorage = contactStorage;
    }

    [HttpPost("contracts")]
    public IActionResult Add ([FromBody] Contact contact) 
    {
        var res = contactStorage.Add(contact);
        if(res) return Created();
        return Conflict("Не корректный ID");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetAll()
    {
        return Ok(contactStorage.GetAll());
    }

    [HttpPost("contact")]
    public IActionResult GetById(Guid id)
    {
        var contact = contactStorage.GetById(id);
        if(contact != null) return Ok(contact);
        return NotFound();
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult Delete(Guid id)
    {
       var res = contactStorage.Delete(id);
       if(res) return NoContent();
       return BadRequest("Ошибка ID");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult Update([FromBody] ContactDto contactDto, Guid id)
    {
       var res = contactStorage.Update(contactDto, id);
       if(res) return Ok();
       return Conflict("Не корректный ID");
    }
}