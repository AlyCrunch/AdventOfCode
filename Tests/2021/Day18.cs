using Days._2021;
using System.Linq;
using Xunit;

namespace Tests._2021
{
    public class Day18
    {
        private readonly static string[] test = new string[]
        {
            "[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]",
            "[[[5,[2,8]],4],[5,[[9,9],0]]]",
            "[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]",
            "[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]",
            "[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]",
            "[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]",
            "[[[[5,4],[7,7]],8],[[8,3],8]]",
            "[[9,3],[[9,9],[6,[4,9]]]]",
            "[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]",
            "[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]"
        };

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal("[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]"
                , SnailFish.Pair.Add(
                    new SnailFish.Pair("[[[[4,3],4],4],[7,[[8,4],9]]]"), 
                    new SnailFish.Pair("[1,1]"))
                .ToString());

            //Assert.Equal(4140,SnailFish.SumAllSnailfishNumbers(test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            //var dataset = Days.Helpers.ReadFile("Inputs\\year\\day.txt");
        }

        [Fact]
        public void SecondStarExample()
        {
        }

        [Fact]
        public void SecondStarSolution()
        {
        }
    }
}