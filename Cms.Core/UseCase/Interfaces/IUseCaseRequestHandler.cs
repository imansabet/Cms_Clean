using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.UseCase.Interfaces
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task HandleASync(TUseCaseRequest message, IOutPutPort<TUseCaseResponse> outputPort);
    }
    public interface IUseCaseRequest<out TUseCaseResponse> { }
    public interface IOutPutPort<in TUseCaseResponse> 
    {
        void Handle(TUseCaseResponse response);
    }

}