using StoreAppModel;
using Xunit;

namespace StoreAppModelUnitTest
{
    public class UnitTest1
    {
        /// <summary>
        /// checks validation and set with valid data
        /// </summary>
        [Theory]
        [InlineData(20)]
        [InlineData(10)]
        [InlineData(11)]
        public void OrderIdValidData(int p_orderID)
        {
            //Arrange
            Order obj = new Order();

             //Act
            obj.OrderID = p_orderID;

            //Assert
            Assert.NotNull(obj.OrderID); 
            Assert.Equal(p_orderID, obj.OrderID); 
        }

        /// <summary>
        /// checks validation and checks if fails
        /// </summary>
        [Theory]
        [InlineData(-12)]
        [InlineData(-34)]
        [InlineData(0)]
        public void OrderIdInvalidData(int p_orderID)
        {
            //arrange
            Order obj = new Order();

            //act & assert
            Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
                {
                    obj.OrderID = p_orderID ;
                }
            
            );
        }

         [Theory]
        [InlineData("cm@yahoo.com")]
        [InlineData("dm@gmail.com")]
        public void EmailValidData(string p_email)
        {
            //Arrange
            Customer obj = new Customer();

             //Act
            obj.Email = p_email;

            //Assert
            Assert.NotNull(obj.Email); 
            Assert.Equal(p_email, obj.Email); 
        }

        /// <summary>
        /// checks validation and checks if fails
        /// </summary>
        [Theory]
        [InlineData("hello!")]
        [InlineData("aaskjuefhakljh")]
        public void EmailInvalidData(string p_email)
        {
            //arrange
            Customer obj = new Customer();

            //act & assert
            Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
                {
                    obj.Email = p_email ;
                }
            
            );
        }
    }

}