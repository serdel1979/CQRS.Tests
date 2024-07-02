using CQRSPractica.Application.DTOs;
using MediatR;

namespace CQRSPractica.Infraestructure.Command
{
    public record CreateTaskCommand(string Title, string Description) 
        : IRequest<TaskItemDTO>;





}
