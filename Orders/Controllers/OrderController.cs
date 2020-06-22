using System.IO;
using Microsoft.AspNetCore.Mvc;
using Orders.Data.Repositories;
using Orders.Models;

namespace Orders.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IUnitOfWork unitOfWork;

		public OrderController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		// POST: api/Orders/Add
		[HttpPost("Add")]
		public IActionResult Add([FromBody]OrderApi requestOrder)
		{
			//Не доступные постоматы не должны отображаться на фронте вообще.
			if (!unitOfWork.PostamateRepository.IsAvailable(requestOrder.PostamateNumber))
				return BadRequest(new
				{
					field = "PostamateNumber",
					error = "Постомат не доступен."
				});

			if (requestOrder.Products.Count > 10)
				return BadRequest(new
				{
					field = "Products",
					error = "Ошибка запроса"
				});

			var order = requestOrder.ToOrder();
			try
			{
				unitOfWork.OrderRepository.Add(order);
				unitOfWork.Commit();
			}
			catch (InvalidDataException ex)
			{
				return BadRequest(ex);
			}

			order = unitOfWork.OrderRepository.Get(order.Number);
			return Ok(new OrderApi(order));
		}

		// GET: api/Orders/{orderNumber}
		[HttpGet("{orderNumber}")]
		public IActionResult Get([FromRoute] int orderNumber)
		{
			var order = unitOfWork.OrderRepository.Get(orderNumber);

			if (order == null)
				return NotFound($"Приказ с номером {orderNumber} не найден");

			return Ok(order);
		}

		// DELETE: api/Orders/{orderNumber}
		[HttpDelete("{orderNumber}")]
		public IActionResult Cancel([FromRoute] int orderNumber)
		{
			var order = unitOfWork.OrderRepository.Get(orderNumber);

			if (order == null)
				return NotFound($"Приказ с номером {orderNumber} не найден");

			unitOfWork.OrderRepository.Remove(order);
			unitOfWork.Commit();
			return Ok();
		}

		// PUT: api/Orders/Update 
		[HttpPut("Update")]
		public IActionResult Change([FromBody] OrderApi requestOrder)
		{
			var order = unitOfWork.OrderRepository.Get(requestOrder.Number);

			if (order == null)
				return NotFound($"Приказ с номером {requestOrder.Number} не найден");

			if (order.Number != requestOrder.Number || order.Status != requestOrder.Status)
				return BadRequest("Нельзя менять статус и номер заказа");

			var updatedOrder = requestOrder.ToOrder();
			unitOfWork.OrderRepository.Update(updatedOrder);
			unitOfWork.Commit();
			updatedOrder = unitOfWork.OrderRepository.Get(requestOrder.Number);

			return Ok(updatedOrder);
		}
	}
}
