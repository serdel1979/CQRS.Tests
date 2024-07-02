using CQRSPractica.Application.DTOs;
using CQRSPractica.Infraestructure;
using CQRSPractica.Infraestructure.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractica.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTaskHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.TaskItems.FirstOrDefaultAsync(t=>t.Id == request.Id);
            if (task == null)
            {
                return false;
            }
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
