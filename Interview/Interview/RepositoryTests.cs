using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Interview
{

    public class RepositoryTests
    {
        private IRepository<MockStoreable, int> repository;
        private IEnumerable<MockStoreable> allRepoObjects;
        private MockStoreable newRepoObject;
        private MockStoreable existingRepoObject;
        private MockStoreable expectedRepoObject;

        [Test]
        public void Test_Repository_Returns_IEnumerable()
        {
            repository = new Repository<MockStoreable, int>();
            allRepoObjects = repository.GetAll();
            Assert.IsInstanceOf<IEnumerable<MockStoreable>>(allRepoObjects);
        }


        [Test]
        public void Test_Repository_GetById()
        {
            repository = new Repository<MockStoreable, int>();
            existingRepoObject = new MockStoreable { Id = 100 };
            repository.Save(existingRepoObject);
            expectedRepoObject = repository.Get(100);
            Assert.AreEqual(expectedRepoObject.Id, existingRepoObject.Id);
        }

        [Test]
        public void Test_Repository_Delete()
        {
            repository = new Repository<MockStoreable, int>();
            existingRepoObject = new MockStoreable { Id = 100 };
            repository.Save(existingRepoObject);
            repository.Delete(100);
            allRepoObjects = repository.GetAll();

            Assert.IsFalse(allRepoObjects.Contains(existingRepoObject));
        }

        [Test]
        public void Test_Repository_Save()
        {
            repository = new Repository<MockStoreable, int>();
            newRepoObject = new MockStoreable { Id = 100 };
            repository.Save(newRepoObject);
            allRepoObjects = repository.GetAll();
            Assert.IsTrue(allRepoObjects.Contains(newRepoObject));
        }

    }
}
