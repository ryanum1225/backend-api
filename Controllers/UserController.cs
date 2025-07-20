using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace TechHiveSolutions.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    // Simulate fetching data from a server.
    List<User> users = new List<User>
    {
        new User{EmployeeID = 1, Name = "Jack"},
        new User{EmployeeID = 2, Name = "Rosemary"}
    };

    // GET : Retrieve all Users.
    [HttpGet]
    public ActionResult<List<User>> GetAll() => users;

    // GET by ID.
    [HttpGet("{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = users.FirstOrDefault(u => u.EmployeeID == id);
        return user != null ? Ok(user) : NotFound();
    }

    // POST : Add a new User.
    [HttpPost]
    public ActionResult<User> Create(User newUser)
    {
        newUser.EmployeeID = users.Count + 1;
        users.Add(newUser);
        return CreatedAtAction(nameof(GetById), new { id = newUser.EmployeeID }, newUser);
    }

    // PUT : Update an existing product.
    [HttpPut("{id}")]
    public ActionResult Update(int id, User updatedUser)
    {
        var user = users.FirstOrDefault(u => u.EmployeeID == id);
        if (user == null) return NotFound();

        user.Name = updatedUser.Name;
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var user = users.FirstOrDefault(u => u.EmployeeID == id);
        if (user == null) return NotFound();

        users.Remove(user);
        return NoContent();
    }

}