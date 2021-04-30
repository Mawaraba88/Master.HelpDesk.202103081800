

namespace HelpDeskWeb.Infrastructure.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void CreateMappings(IConfiguration configuration);
    }
}