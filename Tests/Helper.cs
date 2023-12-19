using Days;
using Xunit;

namespace Tests
{
    public class Helper
    {
        [Fact]
        public void Range_IsOverlapping()
        {
            Assert.True(Range.IsOverlapping(new Range(1, 3), new Range(2, 4)));
            Assert.True(Range.IsOverlapping(new Range(1, 3), new Range(3, 4)));
            Assert.False(Range.IsOverlapping(new Range(1, 3), new Range(4, 5)));
            Assert.True(Range.IsOverlapping(new Range(2, 4), new Range(1, 3)));
            Assert.True(Range.IsOverlapping(new Range(3, 4), new Range(1, 3)));
            Assert.False(Range.IsOverlapping(new Range(4, 5), new Range(1, 3)));
        }

        [Fact]
        public void Range_GetIntersection()
        {
            //intersection(1, 3)(4, 5) `shouldBe` []
            //intersection(4, 5)(1, 3) `shouldBe` []
            var result = Range.GetIntersection(new Range(1, 3), new Range(2, 4));
            Assert.Equal(new Range(2, 3), result);
            result = Range.GetIntersection(new Range(1, 3), new Range(3, 4));
            Assert.Equal(new Range(3, 3), result);
            result = Range.GetIntersection(new Range(1, 4), new Range(2, 3));
            Assert.Equal(new Range(2, 3), result);
            result = Range.GetIntersection(new Range(2, 4), new Range(1, 3));
            Assert.Equal(new Range(2, 3), result);
            result = Range.GetIntersection(new Range(3, 4), new Range(1, 3));
            Assert.Equal(new Range(3, 3), result);
            result = Range.GetIntersection(new Range(2, 3), new Range(1, 4));
            Assert.Equal(new Range(2, 3), result);
        }

        [Fact]
        public void Range_Substraction()
        {
            var result = Range.Substract(new Range(1, 3), new Range(2, 4));
            var should = new Range[] { new Range(1, 1) };
            Assert.Equal(should, result);
            result = Range.Substract(new Range(1, 3), new Range(3, 4));
            should = new Range[] { new Range(1, 2) };
            Assert.Equal(should, result);
            result = Range.Substract(new Range(1, 3), new Range(4, 5));
            should = new Range[] { new Range(1, 3) };
            Assert.Equal(should, result);
            result = Range.Substract(new Range(1, 4), new Range(2, 3));
            should = new Range[] { new Range(1, 1), new Range(4, 4) };
            Assert.Equal(should, result);
            result = Range.Substract(new Range(2, 4), new Range(1, 3));
            should = new Range[] { new Range(4, 4) };
            Assert.Equal(should, result);
            result = Range.Substract(new Range(3, 4), new Range(1, 3));
            should = new Range[] { new Range(4, 4) };
            Assert.Equal(should, result);
            result = Range.Substract(new Range(4, 5), new Range(1, 3));
            should = new Range[] { new Range(4, 5) };
            Assert.Equal(should, result);
            result = Range.Substract(new Range(2, 3), new Range(1, 4));
            should = System.Array.Empty<Range>();
            Assert.Equal(should, result);
        }
    }
}
