using CleanArchitecture.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Utility
{
    
    public class UtilityTest
    {
        [Fact]
        public void ValidateUserName_LengthLessThanFive_ReturnFalse()
        {
            //Arrange
            string userName = "Afi";
            bool expected=false;
            //Act
            bool actual = Helper.ValidateUserName(userName);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
