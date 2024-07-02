using CQRSPractica.Application.DTOs;
using MediatR;

namespace CQRSPractica.Infraestructure.Command
{
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted)
        : IRequest<TaskItemDTO>;

}
