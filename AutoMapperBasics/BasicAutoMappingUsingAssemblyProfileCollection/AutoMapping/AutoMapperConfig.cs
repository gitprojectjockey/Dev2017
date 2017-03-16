using AutoMapper;
using System.Reflection;

namespace BasicAutoMapping.AutoMapping
{
    public class AutoMapperConfig
    {
        public virtual MapperConfiguration RegisterMappings()
        {
            var myAssemply = Assembly.GetExecutingAssembly();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(myAssemply);
            });
            Mapper.Configuration.CompileMappings();
            //Mapper.AssertConfigurationIsValid();
            return Mapper.Configuration as MapperConfiguration;
        }
    }
}
