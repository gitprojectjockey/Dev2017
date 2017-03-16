using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipsAndTricksData.Context;
using TipsAndTricksData.AutoMappingConfiguration;
using AutoMapper;
using TipsAndTricksData.Entities;
using TipsAndTricksData.DTO;
using System.Diagnostics;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;

namespace AutoMapperTipsAndTricksTest
{
    [TestClass]
    public class AutoMappingTests
    {
        TipsAndTricksDBContext _db;
        MapperConfiguration _mapperConfig;

        [TestInitialize]
        public void Initialize()
        {
            _db = new TipsAndTricksDBContext();
            _mapperConfig= new AutoMapperConfig().RegisterMappings();
        }

        [TestMethod]
        [ExpectedException(typeof(AutoMapperMappingException))]
        public void Configuration_Failes_With_AutoMapper_Exception()
        {
            //setup bad mapping
            var hospital = _db.Hospitals.Find(3);
            var doctor = _db.Doctors.Find(5);
            Mapper.Map(hospital, doctor, typeof(Hospital),typeof(Doctor));
        }

        [TestMethod]
        public void Map_Configuration_Hospital_To_DTOHealthCareWorker()
        {
            //Write SQL statement to output window.
            _db.Database.Log += log => Debug.WriteLine(log);
            var doctor = _db.Doctors.Include("Hospital").FirstOrDefault(d => d.Id == 8);
            var healthCareWorker = Mapper.Map(doctor, new DtoHealthCareWorker(), typeof(Doctor), typeof(DtoHealthCareWorker)) as DtoHealthCareWorker;
            StringAssert.Contains(healthCareWorker.Information, "FullName: Betty Joseph Title: DR Hostpital: NY City Hospital");
        }

        [TestMethod]
        public void Map_Configuration_Doctor_To_MedialPersonAndHospital_Include_Hospital()
        {
            //Write SQL statement to output window.
            _db.Database.Log += log => Debug.WriteLine(log);
            //using include to eager load the hospital the works at
            var doctor = _db.Doctors.Include("Hospital").FirstOrDefault(d => d.Id == 8);
            var medicalPersonAndHospital = Mapper.Map(doctor, new DtoMedicalPersonAndHospital(), typeof(Doctor), typeof(DtoMedicalPersonAndHospital)) as DtoMedicalPersonAndHospital;
            Assert.IsNotNull(medicalPersonAndHospital.Hospital);
        }

        [TestMethod]
        public void Map_Configuration_Doctor_To_MedialPerson_ignore_Title()
        {
            //Write SQL statement to output window.
            _db.Database.Log += log => Debug.WriteLine(log);
            var doctor = _db.Doctors.FirstOrDefault(d => d.Id == 8);
            var medicalPerson = Mapper.Map(doctor, new DtoMedicalPerson(), typeof(Doctor), typeof(DtoMedicalPerson)) as DtoMedicalPerson;
            Assert.IsNull(medicalPerson.Title);
        }


        [TestCleanup()]
        public void Cleanup()
        {
            _db.Dispose();
        }
    }
}
