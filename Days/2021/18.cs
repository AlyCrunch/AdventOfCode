namespace Days._2021
{
    public static class SnailFish
    {

        public class Pair
        {
            public Pair? Parent { get; set; }
            public Pair? Left { get; set; }
            public Pair? Right { get; set; }

            public int? LeftValue { get; set; }
            public int? RightValue { get; set; }

            public int Depth
                => 1 + ((Parent is not null) ? Parent.Depth : 0);

            public Pair(string input, Pair? p = null)
            {
                Parent = p;

                var (left, right, _, _) = input[1..^1].Aggregate(
                    (left: "", right: "", bracket: 0, isLeft: true),
                    (s, c) =>
                    ((s.isLeft && !(s.bracket == 0 && c == ',')) ? s.left + c : s.left,
                    (!s.isLeft) ? s.right + c : s.right,
                    "[]".Contains(c) ? (c == '[') ? s.bracket + 1 : s.bracket - 1 : s.bracket,
                    (s.bracket != 0 || c != ',') && s.isLeft));

                try
                {
                    (Left, LeftValue) = GetFormatValue(left);
                    (Right, RightValue) = GetFormatValue(right);
                }
                catch (Exception e)
                {
                    throw new Exception($"left:{left},right:{right} : {e.Message}");
                }
            }
            public Pair(string left, string right)
            {
                (Left, LeftValue) = GetFormatValue(left);
                (Right, RightValue) = GetFormatValue(right);
            }

            public Pair(Pair left, Pair right)
            {
                Left = left;
                Right = right;
            }
            public Pair(int left, int right)
            {
                LeftValue = left;
                RightValue = right;
            }


            private (Pair? p, int? v) GetFormatValue(string value)
            => value.Contains(',') ? (new Pair(value, this), null) : (null, int.Parse(value[..]));

            public static Pair Split(int value)
                => new(value / 2, value / 2 + value % 2);
            public void Split(int value, bool isLeft)
            {
                var p = Split(value);
                p.Parent = this;
                if (isLeft)
                    Left = p;
                else
                    Right = p;
            }

            public void TryExplode()
            {
                if (Depth > 4 && IsBothValue())
                {
                    var l = LeftValue.Value;
                    var r = RightValue.Value;
                    if (Parent is null) throw new Exception($"No parent found (source [{l},{r}]) : " + this.ToString());
                    if (Parent.LeftValue is not null)
                    {
                        //throw new Exception("Parent Left value : " + Parent.LeftValue);
                        FindParentWherePairIsLeft(r);
                        Parent.LeftValue += l;
                        Parent.RightValue = 0;
                        Parent.Right = null;

                    }
                    if (Parent.RightValue is not null)
                    {
                        FindParentWherePairIsRight(l);
                        Parent.RightValue += r;
                        Parent.LeftValue = 0;
                        Parent.Left = null;
                    }
                }
                else
                {
                    if (Left is not null) Left.TryExplode();
                    if (Right is not null) Right.TryExplode();
                }
            }
            //[[[[[9,8],1],2],3],4]
            //[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]
            private void FindParentWherePairIsLeft(int value)
            {
                if (Parent is null) return; //throw new Exception("No parent found : (value: " + value + ") " + this.ToString());

                if (Parent.Left is not null && Parent.Left.Equals(this))
                    AddToTheRightmost(value);
                else
                    Parent.FindParentWherePairIsLeft(value);
            }
            private void FindParentWherePairIsRight(int value)
            {
                if (Parent is null) return; //throw new Exception("No parent found : " + this.ToString());
                if (Parent.Right is not null && Parent.Right.Equals(this))
                    AddToTheLeftmost(value);
                else
                    Parent.FindParentWherePairIsRight(value);
            }
            private void AddToTheRightmost(int value)
            {
                if (RightValue.HasValue)
                    RightValue += value;
                else
                    Right?.AddToTheRightmost(value);
            }
            private void AddToTheLeftmost(int value)
            {
                if (LeftValue.HasValue)
                    LeftValue += value;
                else
                    Left?.AddToTheLeftmost(value);
            }

            private bool IsBothValue()
                => LeftValue.HasValue && RightValue.HasValue;

            public new string ToString()
                => "[" + ((LeftValue is null) ? Left?.ToString() : $"{LeftValue}") + ","
                + ((RightValue is null) ? Right?.ToString() : $"{RightValue}") + "]";

            public int Magnitude()
                => ((LeftValue.HasValue) ? LeftValue * 3 : Left.Magnitude() * 3).Value +
                    ((RightValue.HasValue) ? RightValue * 2 : Right.Magnitude() * 2).Value;

            public static Pair operator +(Pair l, Pair r)
                => new(l, r);
            public bool Equals(Pair? pair)
            {
                if (this == null && pair == null)
                {
                    return true;
                }

                if (this != null && pair != null)
                {
                    return LeftValue == pair.LeftValue && RightValue == pair.RightValue
                    && Left.Equals(pair.Left) && Right.Equals(pair.Right);
                }
                return false;
            }
        }
    }
}