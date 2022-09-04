using Opendata.Models;

namespace Opendata.Services
{
    public interface IOpendataService
    {
        Task GetJDocs();
        Task GetJDocs2();
    }
}