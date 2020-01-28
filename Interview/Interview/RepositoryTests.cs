using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Interview
{
    public class RepositoryTests
    {
        private IRepository<MockStoreable, int> _repository;
        private IEnumerable<MockStoreable> _allRepoObjects;
        private MockStoreable _newRepoObject, _existingRepoObject, _expectedRepoObject;
        
        [Test]
        public void Test_Repository_Returns_IEnumerable()
        {
            _repository = new Repository<MockStoreable, int>();
            _allRepoObjects = _repository.GetAll();
            Assert.IsInstanceOf<IEnumerable<MockStoreable>>(_allRepoObjects);
        }

        [Test]
        public void Test_Repository_GetById()
        {
            _repository = new Repository<MockStoreable, int>();
            _existingRepoObject = new MockStoreable { Id = 100 };
            _repository.Save(_existingRepoObject);
            _expectedRepoObject = _repository.Get(100);
            Assert.AreEqual(_expectedRepoObject.Id, _existingRepoObject.Id);
        }

        [Test]
        public void Test_Repository_Delete()
        {
            _repository = new Repository<MockStoreable, int>();
            _existingRepoObject = new MockStoreable { Id = 100 };
            _repository.Save(_existingRepoObject);
            _repository.Delete(100);
            _allRepoObjects = _repository.GetAll();

            Assert.IsFalse(_allRepoObjects.Contains(_existingRepoObject));
        }

        [Test]
        public void Test_Repository_Save()
        {
            _repository = new Repository<MockStoreable, int>();
            _newRepoObject = new MockStoreable { Id = 100 };
            _repository.Save(_newRepoObject);
            _allRepoObjects = _repository.GetAll();
            Assert.IsTrue(_allRepoObjects.Contains(_newRepoObject));
        }

        [Test]
        public void Test_Repository_Save_NoDuplicates()
        {
            _repository = new Repository<MockStoreable, int>();
            _existingRepoObject = new MockStoreable { Id = 100 };
            _repository.Save(_newRepoObject);
            _newRepoObject = new MockStoreable { Id = 100 };
            _repository.Save(_newRepoObject);
            _allRepoObjects = _repository.GetAll();
            Assert.AreEqual(_allRepoObjects.Count(),1);
        }

    }
}
