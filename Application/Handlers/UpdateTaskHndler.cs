using CQRSPractica.Application.DTOs;
using CQRSPractica.Domain;
using CQRSPractica.Infraestructure;
using CQRSPractica.Infraestructure.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractica.Application.Handlers
{
    public class UpdateTaskHndler : IRequestHandler<UpdateTaskCommand, TaskItemDTO>
    {
        private readonly ApplicationDbContext _context;

        public UpdateTaskHndler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<TaskItemDTO> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.TaskItems.FirstOrDefaultAsync(t=>t.Id == request.Id);
            if (task == null)
            {
                throw new KeyNotFoundException();
            }
            task.Title = request.Title;
            task.Description = request.Description;
            task.IsCompleted = request.IsCompleted;
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();
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
