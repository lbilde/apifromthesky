using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apifromthesky.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apifromthesky.Controllers
{
	[Route("api/[controller]")]
	public class TodoController : Controller
	{
		private readonly ITodoRepository _todoRepository;

		public TodoController(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		[HttpGet]
		public IEnumerable<TodoItem> GetAll()
		{
			return _todoRepository.GetAll();
		}

		[HttpGet("{id}", Name = "GetTodo")]
		public IActionResult GetById(long id)
		{
			var item = _todoRepository.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}
    }

	
}
