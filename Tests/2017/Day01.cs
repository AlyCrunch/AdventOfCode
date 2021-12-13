using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day01
    {
        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(3, InverseCaptcha.GetCaptcha("1122"));
            Assert.Equal(4, InverseCaptcha.GetCaptcha("1111"));
            Assert.Equal(0, InverseCaptcha.GetCaptcha("1234"));
            Assert.Equal(9, InverseCaptcha.GetCaptcha("91212129"));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var x = InverseCaptcha.GetCaptcha(Days.Helpers.ReadSingleLineFile("Inputs\\2017\\01.txt"));
            Assert.Equal(1089, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(6, InverseCaptcha.GetNewCaptcha("1212"));
            Assert.Equal(0, InverseCaptcha.GetNewCaptcha("1221"));
            Assert.Equal(4, InverseCaptcha.GetNewCaptcha("123425"));
            Assert.Equal(12, InverseCaptcha.GetNewCaptcha("123123"));
            Assert.Equal(4, InverseCaptcha.GetNewCaptcha("12131415"));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var x = InverseCaptcha.GetNewCaptcha(Days.Helpers.ReadSingleLineFile("Inputs\\2017\\01.txt"));
            Assert.Equal(1156, x);
        }
    }
}