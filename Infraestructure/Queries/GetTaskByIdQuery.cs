using CQRSPractica.Application.DTOs;
using MediatR;

namespace CQRSPractica.Infraestructure.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskItemDTO>;
    
    
}
