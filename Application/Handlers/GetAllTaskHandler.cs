using CQRSPractica.Application.DTOs;
using CQRSPractica.Infraestructure;
using CQRSPractica.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractica.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItemDTO>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllTaskHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TaskItemDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.TaskItems.ToListAsync(cancellationToken);

            return list.Select(task => new TaskItemDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            });

        }
    }
}
