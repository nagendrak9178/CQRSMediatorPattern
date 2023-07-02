using CQRSMediatR_Sample.Commands;
using CQRSMediatR_Sample.Notifications;
using CQRSMediatR_Sample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR_Sample.Controllers
{
    //follow this url https://code-maze.com/cqrs-mediatr-in-aspnet-core/
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        //Add a constructor to MediatR pattern. Imediator interface allows to send the messages to MediatR which then dispatches
        //to relevant handlers.Becuase we already installed dependency injection package, the instance will be resolved automatically.
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*
         From the MediatR version 9.0, the IMediator interface is split into two interfaces – ISender and IPublisher.
         So, even though we can still use the IMediator interface to send requests to a handler, if we want to be more strict about that,
        we can use the ISender interface instead. You don’t have to change anything else. This interface contains the Send method to send 
        requests to the handlers. Of course, for the notifications, you should use the IPublisher interface that contains the Publish method:
         */

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            //pass it to Handler method with input parameter "GetProductQuery"
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
           var result = await  _mediator.Send(new AddProductCommand(product));

            //Publih the notifications to EMail and Cache Invalidate Handlers which expect the "product" object as input parameter.
            await _mediator.Publish(new ProductAddedNotification(result));

            //return StatusCode(StatusCodes.Status201Created);
            //return Ok(result);

            /*
            // overload with three arguments
            return CreatedAtRoute(
                routeName: "SubscriberLink",
                routeValues: new { id = subscriber.Id },
                value: subscriber);
            */

            return CreatedAtRoute("GetProductByid", new { id = result.Id }, result );
           // return CreatedAtRoute($"GetProductByid",new { id = result.Id },result);

        }


        [HttpGet("GetProductByid/{id}", Name = "GetProductByid")]
        public async Task<ActionResult> GetProductById([FromRoute] int id)

        //[HttpGet("{id:int}", Name = "GetProductByid")]
        //public async Task<ActionResult> GetProductById(int id)
        {
            var result =  await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }



    }
}
