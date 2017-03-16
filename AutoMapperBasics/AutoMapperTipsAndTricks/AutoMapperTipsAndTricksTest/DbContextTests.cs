using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipsAndTricksData.Context;
using TipsAndTricksData.Entities;
using System.Linq;
using System.Diagnostics;

namespace AutoMapperTipsAndTricksTest
{
    [TestClass]
    public class DbContextTests
    {
        TipsAndTricksDBContext _db;
        [TestInitialize()]
        public void Initialize()
        {
            _db = new TipsAndTricksDBContext();
        }

        [TestMethod]
        public void Test_Context_returns_Non_Null_Value()
        {
            Hospital h = _db.Hospitals.Find(4);
            Assert.IsNotNull(h);
        }

        [TestMethod]
        public void Test_Context_returns_Correct_ID()
        {
            Hospital h = _db.Hospitals.Find(4);
            Assert.AreEqual(h.Id, 4);
        }

        [TestMethod]
        public void Test_Context_returns_2_Docters_Per_Hospital()
        {
            _db.Database.Log += l => Debug.WriteLine(l);
            //Eager Loading Doctors with Hospitals
            var hospitals = _db.Hospitals.Include("Doctors").ToList<Hospital>();
            foreach (var h in hospitals)
            {
                Assert.AreEqual(h.Doctors.Count, 2);
            }
        }

        [TestMethod]
        public void Test_Context_returns_Correct_Hopital_Doctors()
        {
            _db.Database.Log += l => Debug.WriteLine(l);
            //Eager Loading Doctors with Hospitals
            var hospital = _db.Hospitals.Include("Doctors").ToList<Hospital>().FirstOrDefault(h => h.Id == 3);
            var doctors = _db.Doctors.Where(d => d.Id == 5 || d.Id == 9).ToList();
            CollectionAssert.AreEquivalent(hospital.Doctors.ToList<Doctor>(), doctors);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _db.Dispose();
        }
    }
}
