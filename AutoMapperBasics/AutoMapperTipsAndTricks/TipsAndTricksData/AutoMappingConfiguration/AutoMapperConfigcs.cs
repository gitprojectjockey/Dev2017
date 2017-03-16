using AutoMapper;
using System;
using System.Reflection;

namespace TipsAndTricksData.AutoMappingConfiguration
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
            try
            {

                Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
            return Mapper.Configuration as MapperConfiguration;
        }
    }
}
