using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using SenseFramework.Data.EntityFramework.Repositories;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace SenseFramework.Data.EntityFramework.UnitTests
{
    public class RepositoryTestClass
    {
        [Fact]
        public void CreateEntityCall()
        {
            SampleEntity entity = new SampleEntity();

            // setup
            var repo = new Mock<IRepository<SampleEntity, int>>();
            repo.Setup(t => t.CreateEntity(It.IsAny<SampleEntity>()))
                .Returns((SampleEntity target) => new SampleEntity
                {
                    Id = 1,
                    CreatedDateTime = DateTime.Now
                });

            // act
            var result = repo.Object.CreateEntity(entity);

            // assert
            repo.Verify(e => e.CreateEntity(entity), Times.Once);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetAllEntityCall()
        {
            var repo = new Mock<IRepository<SampleEntity, int>>();
            repo.Setup(t => t.GetAll()).Returns(() => new List<SampleEntity>()
            {
                new SampleEntity()
                {

                },
                new SampleEntity()
                {

                },
                new SampleEntity()
                {

                },
            });

            //act
            var result = repo.Object.GetAll();

            Assert.Equal(3, result.Count());

        }
    }

    public class SampleEntity : Entity<int>
    {

    }
}
