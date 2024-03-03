using Cms.Core.Dtos.General;
using Cms.Core.UseCase.Interfaces;
using System.Net;
using static Cms.Core.Dtos.UseCase.EditPost;

namespace Cms.Api.Presenter
{
    public class PostApiPresenter<T> : IOutPutPort<GenericResponse<T>>
    {
        public JsonContentResult ContentResult { get; }
        public PostApiPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GenericResponse<T> response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = ContentResult.Serialize(response.Success ? (object)response.Data : (object)response.Errors);
        }
    }

}
