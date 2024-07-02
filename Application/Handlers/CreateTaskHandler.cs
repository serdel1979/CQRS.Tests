using CQRSPractica.Application.DTOs;
using CQRSPractica.Domain;
using CQRSPractica.Infraestructure;
using CQRSPractica.Infraestructure.Command;
using MediatR;

namespace CQRSPractica.Application.Handlers
{
    public class CreateTaskHandler
        : IRequestHandler<CreateTaskCommand, TaskItemDTO>
    {
        private readonly ApplicationDbContext _context;

        public CreateTaskHandler(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<TaskItemDTO> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            TaskItem task = new TaskItem
            {
                Description = request.Description,
                Title = request.Title
            };
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return new TaskItemDTO { Id = task.Id, Description = request.Description, IsCompleted = task.IsCompleted, Title = request.Title };
        }
    }
}
