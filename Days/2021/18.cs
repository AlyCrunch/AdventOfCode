namespace Days._2021
{
    public static class SnailFish
    {
        public static int SumAllSnailfishNumbers(string[] datas)
        {
            var numbers = datas.Select(x => new Pair(x));
            var first = numbers.First();
            return numbers.Skip(1).Aggregate(first, (p, item) => Pair.Add(p, item))
                .Magnitude();
        }

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
            public Pair(){}

            private static Pair Split(int value)
                => new(value / 2, value / 2 + value % 2);
            public void TrySplit()
            {
                if(LeftValue.HasValue && LeftValue >= 10)
                {
                    var p = Split(LeftValue.Value);
                    LeftValue = null;
                    p.Parent = this;
                    Left = p;
                }
                else Left?.TrySplit();

                if (RightValue.HasValue && RightValue >= 10)
                {
                    var p = Split(RightValue.Value);
                    RightValue = null;
                    p.Parent = this;
                    Right = p;
                }
                else Right?.TrySplit();
            }
            public void TryExplode()
            {
                if (Depth > 4 && IsBothValue())
                {
                    var l = LeftValue.GetValueOrDefault();
                    var r = RightValue.GetValueOrDefault();
                    if (Parent is null) throw new Exception($"No parent found (source [{l},{r}]) : " + this.ToString());
                    if (Parent.LeftValue is not null)
                    {
                        FindParentWherePairIsLeft(r);
                        Parent.LeftValue += l;
                        Parent.RightValue = 0;
                        Parent.Right = null;

                    }
                    else if (Parent.RightValue is not null)
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

            public static Pair Add(Pair first, Pair second)
            {
                var third = first + second;

                while (third.IsValueGreaterThan10() || third.IsDepthOver4())
                {
                    third.TryExplode();
                    third.TrySplit();
                }

                return third;
            }

            private (Pair? p, int? v) GetFormatValue(string value)
            => value.Contains(',') ? (new Pair(value, this), null) : (null, int.Parse(value[..]));
            private void FindParentWherePairIsLeft(int value)
            {
                if (Parent is null) return; 
                if (Parent.Left is not null && Parent.Left == this)
                {
                    if (Parent.Right is not null)
                        Parent.Right.AddToTheLeftmost(value);
                    else if (Parent.RightValue is not null)
                        Parent.RightValue += value;
                }
                else
                    Parent.FindParentWherePairIsLeft(value);
            }
            private void FindParentWherePairIsRight(int value)
            {
                if (Parent is null) return;
                if (Parent.Right is not null && Parent.Right == this)
                {
                    if (Parent.Left is not null)
                        Parent.Left.AddToTheLeftmost(value);
                    else if (Parent.LeftValue is not null)
                        Parent.LeftValue += value;
                }
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
            private bool IsValueGreaterThan10()
            {
                if (LeftValue.HasValue && LeftValue.Value >= 10) return true;
                if (RightValue.HasValue && RightValue.Value >= 10) return true;
                bool left = false, right = false;
                if (Left is not null) left = Left.IsValueGreaterThan10();
                if (Right is not null) right = Right.IsValueGreaterThan10();

                return left || right;
            }
            private bool IsDepthOver4()
            {
                if (Depth > 4) return true;
                bool left = false, right = false;
                if (Left is not null) left = Left.IsDepthOver4();
                if (Right is not null) right = Right.IsDepthOver4();

                return left || right;
            }
            private bool IsBothValue()
                => LeftValue.HasValue && RightValue.HasValue;

            public new string ToString()
                => "[" + ((LeftValue is null) ? Left?.ToString() : $"{LeftValue}") + ","
                + ((RightValue is null) ? Right?.ToString() : $"{RightValue}") + "]";
            public int Magnitude()
                => (LeftValue.HasValue ? LeftValue * 3 : Left.Magnitude() * 3).Value +
                    (RightValue.HasValue ? RightValue * 2 : Right.Magnitude() * 2).Value;

            public static Pair operator +(Pair l, Pair r)
                => new(l, r);
            public static bool operator ==(Pair? l, Pair? r)
            {
                if (l is null && r is null)
                {
                    return true;
                }

                if (l is not null && r is not null)
                {
                    return l.LeftValue == r.LeftValue && l.RightValue == r.RightValue
                    && l.Left == r.Left && l.Right == r.Right;
                }

                return false;
            }
            public static bool operator !=(Pair? l, Pair? r) => !(l == r);
            public override bool Equals(object? obj)
            {
                if (obj is not Pair) return false;

                Pair pair = (Pair)obj;

                if (this is null && pair is null)
                {
                    return true;
                }

                if (this is not null && pair is not null)
                {
                    return LeftValue == pair.LeftValue && RightValue == pair.RightValue
                    && Left == pair.Left && Right == pair.Right;
                }

                return false;
            }
            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }
        }
    }
}