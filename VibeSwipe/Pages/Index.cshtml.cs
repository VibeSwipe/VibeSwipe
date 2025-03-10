using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VibeSwipe.Application.Queries.Users;

namespace VibeSwipe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator _mediator;

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async void OnGet()
        {
            _logger.LogWarning("{C}", await _mediator.Send(new GetUsersQuery()));
        }
    }
}
