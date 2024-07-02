using CQRSPractica.Application.DTOs;
using CQRSPractica.Infraestructure;
using CQRSPractica.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractica.Application.Handlers
{
    public class GetByIdTaskHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDTO>
    {
        private readonly ApplicationDbContext _context;

        public GetByIdTaskHandler(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<TaskItemDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task =  await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (task == null)
            {
                return null;
            }
            return new TaskItemDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            };
        }
    }
}
