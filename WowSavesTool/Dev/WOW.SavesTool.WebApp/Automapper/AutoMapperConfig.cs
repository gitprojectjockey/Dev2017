using AutoMapper;

namespace WOW.SavesTool.WebApp.Automapper
{
    public  class AutoMapperConfig
    {
        public virtual  MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperCoreConfiguration()); });
        }
    }
}