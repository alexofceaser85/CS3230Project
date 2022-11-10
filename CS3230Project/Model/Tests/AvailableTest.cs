namespace CS3230Project.Model.Tests
{
    /// <summary>
    /// Holds the information for a test for a visit
    /// </summary>
    public class AvailableTest : Test
    {
        /// <summary>
        /// Holds an available test
        ///
        /// Precondition: None
        /// Postcondition:
        /// this.Code == testCode
        /// AND this.Name == name
        /// </summary>
        /// <param name="testCode">The test code of the available test</param>
        /// <param name="name">The name of the available test</param>
        public AvailableTest(int testCode, string name)
        {
            base.Code = testCode;
            base.Name = name;
        }
    }
}
