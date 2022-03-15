using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.v2.WebApi.Rebeld.Business.Impl.Services;
using VY.v2.WebApi.Rebeld.Data.Contracts.Entities;
using VY.v2.WebApi.Rebeld.Data.Contracts.Repository;
using VY.v2.WebApi.Rebeld.Dtos.Dtos;
using Xunit;

namespace VY.v2.WebApi.Rebeld.XUnitTest
{
    public class RebeldServiceTest
    {
        [Fact]
        public void WhenRebeldIsAdded_ReturnsResult()
        {
        
            //Arrange
            RebeldEntity rebeld = new RebeldEntity();
            RebeldDto dto = new RebeldDto();

            //Act
            Mock<IRebeldRepository> repo = new Mock<IRebeldRepository>();
            repo.Setup(c => c.AddAsync(rebeld)).Returns(Task.FromResult(rebeld));

            Mock<IMapper> mapper = new Mock<IMapper>();
            mapper.Setup(c => c.Map<RebeldEntity, RebeldDto>(rebeld)).Returns(dto);
            mapper.Setup(c => c.Map<RebeldDto, RebeldEntity>(dto)).Returns(rebeld);

            RebeldService rebeldService = new RebeldService(mapper.Object, new Mock<ILogger<RebeldService>>().Object, repo.Object);

            var service = rebeldService.AddRebeldAsync(dto);
            repo.Verify(c => c.AddAsync(rebeld), Times.Once());
            //repo.Verify(c => c.AddAsync(It.IsAny<Rebeld>()), Times.Once());

            //Assert
            Assert.Equal(dto.Name, rebeld.Name);
            Assert.NotNull(dto);
        }           
    }
}
