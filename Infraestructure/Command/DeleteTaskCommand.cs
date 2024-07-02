using MediatR;

namespace CQRSPractica.Infraestructure.Command
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
