using CQRSPractica.Application.DTOs;
using MediatR;

namespace CQRSPractica.Infraestructure.Queries
{
    public record GetAllTasksQuery : IRequest<IEnumerable<TaskItemDTO>>;
}
