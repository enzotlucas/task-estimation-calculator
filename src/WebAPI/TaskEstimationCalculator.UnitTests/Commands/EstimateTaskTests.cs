namespace TaskEstimationCalculator.UnitTests.Commands
{
    public class EstimateTaskTests
    {
        [Fact]
        public void EstimateTask_ValidTask_MustEstimateCorrectly()
        {
            //Arrange
            var mediator = Substitute.For<IMediator>();
            var command = new EstimateTask();
            var expectedResponse = new TaskEstimationViewModel();

            //Act
            var response = mediator.Send(command);

            //Assert
            response.Should().Be(expectedResponse);
        }

        [Fact]
        public void EstimateTask_InvalidTask_MustNotEstimateCorrectly()
        {
            //Arrange
            var mediator = Substitute.For<IMediator>();
            var command = new EstimateTask();
            var expectedResponse = new TaskEstimationViewModel();

            //Act
            var response = mediator.Send(command);

            //Assert
            response.Should().Be(expectedResponse);
        }
    }
}
