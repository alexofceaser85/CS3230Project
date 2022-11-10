using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Tests
{
    /// <summary>
    /// Holds the information for tests
    /// </summary>
    public abstract class Test
    {
        private int code;
        private string name;
        /// <summary>
        /// The test's code
        /// </summary>
        public int Code
        {
            get => this.code;
            
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(TestsErrorMessages.TestCodeForTestCannotBeLessThanZero);
                }
                this.code = value;
            }
        }

        /// <summary>
        /// The name of the test
        /// </summary>
        public string Name
        {
            get => this.name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(TestsErrorMessages.TestNameCannotBeNull);
                }

                if (value.Trim().Length == 0)
                {
                    throw new ArgumentException(TestsErrorMessages.TestNameCannotBeEmpty);
                }

                this.name = value;
            }
        }
    }
}
