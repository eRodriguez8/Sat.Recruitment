namespace Sat.Recruitment.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            SetupMockObjects();
        }

        internal abstract void SetupMockObjects();
    }
}
