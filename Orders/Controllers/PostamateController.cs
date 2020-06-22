using Microsoft.AspNetCore.Mvc;
using Orders.Data.Repositories;

namespace Orders.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostamateController : ControllerBase
    {

	    private readonly IUnitOfWork unitOfWork;

	    public PostamateController(IUnitOfWork unitOfWork)
	    {
		    this.unitOfWork = unitOfWork;
	    }

	    // GET: api/Postamate/{postamateNumber}
		[HttpGet("{postamateNumber}")]
	    public IActionResult Get([FromRoute] string postamateNumber)
	    {
		    var postamate = unitOfWork.PostamateRepository.Get(postamateNumber);

		    if (postamate == null)
			    return NotFound($"Постамат с номером {postamateNumber} не найден");

		    return Ok(postamate);

		}
	}
}