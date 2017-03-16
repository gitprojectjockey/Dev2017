using AutoMapper;
using BasicAutoMapping.AutoMapping;
using BasicAutoMapping.DTO;
using BasicAutoMapping.Entities;
using System;

namespace BasicAutoMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            //This goes in the startup
            var automapperConfig = new AutoMapperConfig().RegisterMappings();

            //Every single member has correlation with destination type. 
            //It may not be the right one (since there are always exception cases), 
            //but it at least tests that every property is moved from source type to destination.
            //will throw exception if not valid.
            automapperConfig.AssertConfigurationIsValid();

            //Get foo and bar entities  from database
            var fooEntity = new FooEntity() { EmployeeFName = "Foo", EmployeeLName = "Fooster" };
            var barEntity = new BarEntity() { PersonFirstName = "Bar", PersonLastName = "Cluster" };

            // auto map Entity to DTO
              var dtoFooModel = Mapper.Map(fooEntity, new FooDto(), typeof(FooEntity), typeof(DTO.FooDto));
            var dtoBarModel = Mapper.Map(barEntity, new BarDto(), typeof(BarEntity), typeof(DTO.BarDto));

            // Auto Map DTO Back to Entities
            var fooDTOFromUI = new FooDto() { EmployeeFName = "FooBackToEntity", EmployeeLName = "From Foo DTO" };
            var barDTOFromUI = new BarDto() { PersonFName = "BarBackToEntity", PersonLName = "FROM Bar DTO" };

            var entityFooModel = Mapper.Map(fooDTOFromUI, new FooEntity(), typeof(FooDto), typeof(FooEntity));
            var entityBarModel = Mapper.Map(barDTOFromUI, new BarEntity(), typeof(BarDto), typeof(BarEntity));

            //Get AddressEntity from database
            var addressEntity = new AddressEntity()
            {
                Street = "1751 Granger Cir",
                City = "Castle Rock",
                State = "CO",
                Zip = "80109"
            };

            // auto map Entity to DTO
            var addressDto = new AddressDisplayOnlyDto();
            Mapper.Map(addressEntity, addressDto, typeof(AddressEntity), typeof(AddressDisplayOnlyDto));
            var p = addressDto.CompleteAddress;
            Console.WriteLine(p);
            Console.ReadKey();


            //Get Person and Address entity from database
            PersonEntity personEntity = new PersonEntity()
            {
                FirstName = "Eric",
                LastName = "Norton",
                PersonAddress = addressEntity
            };

            //Map person entity and personEntity.Address to personDto
            var dtoPersonModel = Mapper.Map(personEntity, new PersonDto(), typeof(PersonEntity), typeof(PersonDto));




            //Get Person DTO from UI
            PersonDto personDto = new PersonDto()
            {
                FName = "Eric",
                LName = "Nordin",
                Street = "345 West Green St",
                City = "Castle Rock",
                State = "CO",
                ZipCode = "44565"
            };

            //Get Person DTO from UI and map back to person entity and address entity 
            PersonEntity entityPersonModel = Mapper.Map(personDto,new PersonEntity(), typeof(PersonDto), typeof(PersonEntity)) as PersonEntity;

        }
    }
}
