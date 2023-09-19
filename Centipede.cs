using System;
using System.Collections.Generic;

public class Centipede
{

    #region Math_Units

    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float3 Val)
        {
            this.x = Val.x;
            this.y = Val.y;
            this.z = Val.z;
        }

        private static readonly Vector3 zeroVector = new Vector3(0f, 0f, 0f);

        private static readonly Vector3 oneVector = new Vector3(1f, 1f, 1f);

        private static readonly Vector3 upVector = new Vector3(0f, 1f, 0f);

        private static readonly Vector3 downVector = new Vector3(0f, -1f, 0f);

        private static readonly Vector3 leftVector = new Vector3(-1f, 0f, 0f);

        private static readonly Vector3 rightVector = new Vector3(1f, 0f, 0f);

        private static readonly Vector3 forwardVector = new Vector3(0f, 0f, 1f);

        private static readonly Vector3 backVector = new Vector3(0f, 0f, -1f);

        public Vector3 normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public float sqrMagnitude
        {
            get
            {
                return x * x + y * y + z * z;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(0, 0, 0).
        public static Vector3 zero
        {
            get
            {
                return zeroVector;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(1, 1, 1).
        public static Vector3 one
        {
            get
            {
                return oneVector;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(0, 0, 1).
        public static Vector3 forward
        {
            get
            {
                return forwardVector;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(0, 0, -1).
        public static Vector3 back
        {
            get
            {
                return backVector;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(0, 1, 0).
        public static Vector3 up
        {
            get
            {
                return upVector;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(0, -1, 0).
        public static Vector3 down
        {
            get
            {
                return downVector;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(-1, 0, 0).
        public static Vector3 left
        {
            get
            {
                return leftVector;
            }
        }

        //
        // Summary:
        //     Shorthand for writing Vector3(1, 0, 0).
        public static Vector3 right
        {
            get
            {
                return rightVector;
            }
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            float num = a.x - b.x;
            float num2 = a.y - b.y;
            float num3 = a.z - b.z;
            return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
        }

        public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
        {
            float num = vector.sqrMagnitude;
            if (num > maxLength * maxLength)
            {
                float num2 = (float)Math.Sqrt(num);
                float num3 = vector.x / num2;
                float num4 = vector.y / num2;
                float num5 = vector.z / num2;
                return new Vector3(num3 * maxLength, num4 * maxLength, num5 * maxLength);
            }

            return vector;
        }

        public static Vector3 Normalize(Vector3 value)
        {
            float num = Magnitude(value);
            if (num > 1E-05f)
            {
                return value / num;
            }

            return zero;
        }

        public static Vector3 Abs(Vector3 value)
        {
            return new Vector3(MathF.Abs(value.x), MathF.Abs(value.y), MathF.Abs(value.z));
        }

        public static float Magnitude(Vector3 vector)
        {
            return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        public static float SqrMagnitude(Vector3 vector)
        {
            return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
        }

        public static Vector3 Min(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(MathF.Min(lhs.x, rhs.x), MathF.Min(lhs.y, rhs.y), MathF.Min(lhs.z, rhs.z));
        }

        public static Vector3 Max(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(MathF.Max(lhs.x, rhs.x), MathF.Max(lhs.y, rhs.y), MathF.Max(lhs.z, rhs.z));
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(0f - a.x, 0f - a.y, 0f - a.z);
        }

        public static Vector3 operator *(Vector3 a, float d)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3 operator *(float d, Vector3 a)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3 operator /(Vector3 a, float d)
        {
            return new Vector3(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            float num = lhs.x - rhs.x;
            float num2 = lhs.y - rhs.y;
            float num3 = lhs.z - rhs.z;
            float num4 = num * num + num2 * num2 + num3 * num3;
            return num4 < 9.99999944E-11f;
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }

        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        }
    }

    public struct float3x3
    {
        /// <summary>Column 0 of the matrix.</summary>
        public float3 c0;
        /// <summary>Column 1 of the matrix.</summary>
        public float3 c1;
        /// <summary>Column 2 of the matrix.</summary>
        public float3 c2;

        public float3x3(float m00, float m01, float m02,
                        float m10, float m11, float m12,
                        float m20, float m21, float m22)
        {
            this.c0 = new float3(m00, m10, m20);
            this.c1 = new float3(m01, m11, m21);
            this.c2 = new float3(m02, m12, m22);
        }
    }

    public struct float3
    {
        /// <summary>x component of the vector.</summary>
        public float x;
        /// <summary>y component of the vector.</summary>
        public float y;
        /// <summary>z component of the vector.</summary>
        public float z;

        public float3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float3(float3 xyz)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
        }

        public float3 xyz
        {
            get { return new float3(x, y, z); }
            set { x = value.x; y = value.y; z = value.z; }
        }
    }

    public struct float4
    {
        // Summary:
        //     X component of the vector.
        public float x;

        //
        // Summary:
        //     Y component of the vector.
        public float y;

        //
        // Summary:
        //     Z component of the vector.
        public float z;

        //
        // Summary:
        //     W component of the vector.
        public float w;

        public float4(Vector3 Vector, float w)
        {
            this.x = Vector.x;
            this.y = Vector.y;
            this.z = Vector.z;
            this.w = w;
        }

        public float3 xyz
        {
            get { return new float3(x, y, z); }
            set { x = value.x; y = value.y; z = value.z; }
        }
    }

    public struct Quaternion
    {
        // Summary:
        //     X component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float x;

        //
        // Summary:
        //     Y component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float y;

        //
        // Summary:
        //     Z component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float z;

        //
        // Summary:
        //     W component of the Quaternion. Do not directly modify quaternions.
        public float w;

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Quaternion AngleAxis(float angle, Vector3 axis)
        {
            System.Numerics.Quaternion Quat = System.Numerics.Quaternion.CreateFromAxisAngle(new System.Numerics.Vector3(axis.x, axis.y, axis.z), angle * (MathF.PI / 180));
            return new Quaternion(Quat.X, Quat.Y, Quat.Z, Quat.W);
        }

        public static Vector3 operator *(Quaternion rotation, Vector3 point)
        {
            float num = rotation.x * 2f;
            float num2 = rotation.y * 2f;
            float num3 = rotation.z * 2f;
            float num4 = rotation.x * num;
            float num5 = rotation.y * num2;
            float num6 = rotation.z * num3;
            float num7 = rotation.x * num2;
            float num8 = rotation.x * num3;
            float num9 = rotation.y * num3;
            float num10 = rotation.w * num;
            float num11 = rotation.w * num2;
            float num12 = rotation.w * num3;
            Vector3 result = default(Vector3);
            result.x = (1f - (num5 + num6)) * point.x + (num7 - num12) * point.y + (num8 + num11) * point.z;
            result.y = (num7 + num12) * point.x + (1f - (num4 + num6)) * point.y + (num9 - num10) * point.z;
            result.z = (num8 - num11) * point.x + (num9 + num10) * point.y + (1f - (num4 + num5)) * point.z;
            return result;
        }
    }

    #endregion

    public class Mushroom
    {
        public Vector3 Position { get; internal set; }
        public Vector3 Scale { get; internal set; }
        private Centipede Board;

        private List<Vector3> Chunks = new List<Vector3>();

        public List<Vector3> GetChunks()
        {
            return Chunks;
        }

        public Mushroom(Vector3 Position, float Radius, float Height)
        {
            this.Position = Position;
            this.Scale = new Vector3(Radius, Height, 0);
        }

        public void SetBoard(Centipede Board)
        {
            this.Board = Board;

            UpdateChunks();
        }

        public Mushroom SetPos(Vector3 NewPosition)
        {
            if (Position != NewPosition)
            {
                this.Position = NewPosition;
                UpdateChunks();
            }
            return this;
        }

        public Mushroom SetRadius(float NewRadius)
        {
            if (Scale.x != NewRadius)
            {
                this.Scale = new Vector3(NewRadius, Scale.y, 0);
                UpdateChunks();
            }
            return this;
        }

        public Mushroom SetHeight(float NewHeight)
        {
            if (Scale.y != NewHeight)
            {
                this.Scale = new Vector3(Scale.x, NewHeight, 0);
                UpdateChunks();
            }
            return this;
        }

        public void UpdateChunks()
        {
            if (Board == null)
                return;
            List<Vector3> C = OverlapChunks();
            List<Vector3> Add = new List<Vector3>();
            List<Vector3> Remove = new List<Vector3>(Chunks);
            for (int i = 0; i < C.Count; i++)
            {
                if (!Chunks.Contains(C[i]))
                {
                    Add.Add(C[i]);
                    Chunks.Add(C[i]);
                }
                else
                {
                    Remove.Remove(C[i]);
                }
            }
            for (int i = 0; i < Remove.Count; i++)
            {
                Chunks.Remove(Remove[i]);
            }

            Board.AddChunks(this, Add);
            Board.RemoveChunks(this, Remove);
        }

        private List<Vector3> CornerCoords()
        {
            Vector3 Halfscale = Vector3.Abs(new Vector3(Scale.x * 2, Scale.y, Scale.x * 2) / 2);
            List<Vector3> Corners = new List<Vector3>
            {
                (new Vector3(Halfscale.x, Halfscale.y, Halfscale.z) + Position),
                (new Vector3(-Halfscale.x, Halfscale.y, Halfscale.z) + Position),
                (new Vector3(Halfscale.x, -Halfscale.y, Halfscale.z) + Position),
                (new Vector3(-Halfscale.x, -Halfscale.y, Halfscale.z) + Position),
                (new Vector3(Halfscale.x, Halfscale.y, -Halfscale.z) + Position),
                (new Vector3(-Halfscale.x, Halfscale.y, -Halfscale.z) + Position),
                (new Vector3(Halfscale.x, -Halfscale.y, -Halfscale.z) + Position),
                (new Vector3(-Halfscale.x, -Halfscale.y, -Halfscale.z) + Position)
            };

            return Corners;
        }

        private (Vector3 Max, Vector3 Min) GetBoundingBox()
        {
            List<Vector3> Cs = CornerCoords();
            Vector3 Max = Cs[0];
            Vector3 Min = Cs[0];

            for (int i = 0; i < Cs.Count; i++)
            {
                Max.x = MathF.Max(Max.x, Cs[i].x);
                Max.y = MathF.Max(Max.y, Cs[i].y);
                Max.z = MathF.Max(Max.z, Cs[i].z);

                Min.x = MathF.Min(Min.x, Cs[i].x);
                Min.y = MathF.Min(Min.y, Cs[i].y);
                Min.z = MathF.Min(Min.z, Cs[i].z);
            }

            return (Max, Min);
        }

        private List<Vector3> OverlapChunks()
        {
            (Vector3 Max, Vector3 Min) = GetBoundingBox();
            Vector3 Start = Board.GridSnap(Min);
            Vector3 End = Board.GridSnap(Max);
            List<Vector3> ChunksDetected = new List<Vector3>();
            for (float i = Start.x; i <= End.x; i += Board.GridSize * 2)
            {
                for (float j = Start.y; j <= End.y; j += Board.GridSize * 2)
                {
                    for (float k = Start.z; k <= End.z; k += Board.GridSize * 2)
                    {
                        ChunksDetected.Add(Board.GridSnap(i, j, k));
                    }
                }
            }
            return ChunksDetected;
        }

        public float CapsuleDistance(Vector3 Point)
        {
            return CapsuleDistance(Point, Position, Scale, Vector3.zero);
        }

        private static void sincos(float Angle, out float sin, out float cos)
        {
            sin = MathF.Sin(Angle);
            cos = MathF.Cos(Angle);
        }


        private static float3x3 AngleAxis3x3(float angle, Vector3 axis)
        {
            angle = angle * (3.14159265f / 180);
            float c, s;
            sincos(angle, out s, out c);

            float t = 1 - c;
            float x = axis.x;
            float y = axis.y;
            float z = axis.z;

            return new float3x3(
                t * x * x + c, t * x * y - s * z, t * x * z + s * y,
                t * x * y + s * z, t * y * y + c, t * y * z - s * x,
                t * x * z - s * y, t * y * z + s * x, t * z * z + c
                );
        }

        private static float3 mul(float3x3 matrix, float4 vector)
        {
            float3 y = new float3(vector.xyz);
            return new float3(
                (matrix.c0.x * y.x) + (matrix.c1.x * y.y) + (matrix.c2.x * y.z),
                (matrix.c0.y * y.x) + (matrix.c1.y * y.y) + (matrix.c2.y * y.z),
                (matrix.c0.z * y.x) + (matrix.c1.z * y.y) + (matrix.c2.z * y.z)
                );
        }

        private static Vector3 EyeRotation(Vector3 eye, Vector3 center, Vector3 Rotation)
        {
            eye = eye - center;
            Vector3 eyeY = new Vector3(mul((AngleAxis3x3(-Rotation.y, new Vector3(0, 1, 0))), new float4(eye, 1)).xyz);
            Vector3 eyeX = new Vector3(mul((AngleAxis3x3(-Rotation.x, new Vector3(1, 0, 0))), new float4(eyeY, 1)).xyz);
            Vector3 eyeZ = new Vector3(mul((AngleAxis3x3(-Rotation.z, new Vector3(0, 0, 1))), new float4(eyeX, 1)).xyz);
            return eyeZ;
        }

        public static float CapsuleDistance(Vector3 eye, Vector3 center, Vector3 size, Vector3 Rotation)
        {
            eye = EyeRotation(eye, center, Rotation);
            eye.y -= Clamp(eye.y, 0, size.y);
            return eye.magnitude - size.x;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }

            return value;
        }
    }

    public Dictionary<Vector3, List<Mushroom>> ActiveComponents = new Dictionary<Vector3, List<Mushroom>>();
    public float GridSize = 0.25f;

    public void AddMushroom(Mushroom Mush)
    {
        Vector3 Point = GridSnap(Mush.Position);
        if (!ActiveComponents.ContainsKey(Point))
            ActiveComponents.Add(Point, new List<Mushroom>());
        Mush.SetBoard(this);
    }

    public void RemoveMushroom(Mushroom Mush)
    {
        RemoveChunks(Mush, Mush.GetChunks());
    }

    private void AddChunks(Mushroom node, List<Vector3> Chunks)
    {
        foreach (var item in Chunks)
        {
            if (ActiveComponents.ContainsKey(item))
            {
                ActiveComponents[item].Add(node);
            }
            else
            {
                ActiveComponents.Add(item, new List<Mushroom>() { node });
            }
        }
    }

    private void RemoveChunks(Mushroom node, List<Vector3> Chunks)
    {
        foreach (var item in Chunks)
        {
            if (ActiveComponents.ContainsKey(item))
            {
                ActiveComponents[item].Remove(node);
                if (ActiveComponents[item].Count == 0)
                {
                    ActiveComponents.Remove(item);
                }
            }
        }
    }

    public float GetGridSize()
    {
        return GridSize;
    }

    public void SetGridSize(float Size)
    {
        GridSize = MathF.Max(0.01f, Size);
    }

    public Vector3 GridSnap(Vector3 Coord)
    {
        return GridSnap(Coord.x, Coord.y, Coord.z);
    }

    public Vector3 GridSnap(float CoordX, float CoordY, float CoordZ)
    {
        return new Vector3(
            MathF.Floor((CoordX + GridSize) / (GridSize * 2)) * (GridSize * 2),
            MathF.Floor((CoordY + GridSize) / (GridSize * 2)) * (GridSize * 2),
            MathF.Floor((CoordZ + GridSize) / (GridSize * 2)) * (GridSize * 2)
            );
    }

    public struct WaterFlowNode
    {
        public bool Obstructed;
        public Vector3 Position;
        public List<Vector3> Ring;
        public List<Vector3> SurfaceRing;
    }

    public WaterFlowNode[] GenerateClearPath(int Size, Vector3 StartPos, Vector3 EndPos)
    {
        WaterFlowNode[] Path = new WaterFlowNode[Size];
        Path[0].Position = StartPos;
        Path[Size - 1].Position = EndPos;

        Vector3 ChunkPos;

        Vector3 Direction = EndPos - StartPos;
        float Dist = Direction.magnitude / (Size - 1);
        Direction = Direction.normalized;
        List<Mushroom> Checked = new List<Mushroom>();

        int Points = 10;
        Vector3 RingPoint;
        Vector3 TestPoint;
        Vector3 TestPointDir;
        Vector3 MovePos;
        float SurfaceDist;
        float SwimDist;

        for (int i = 1; i < Size - 1; i++)
        {
            Direction = (EndPos - Path[i - 1].Position).normalized;
            Path[i].Position = Path[i - 1].Position + (Direction * Dist);

            ChunkPos = GridSnap(Path[i].Position);
            Checked.Clear();
            if (ActiveComponents.ContainsKey(ChunkPos))
            {
                float MinDist = float.MaxValue;
                foreach (var item in ActiveComponents[ChunkPos])
                {
                    if (!Checked.Contains(item))
                    {
                        Checked.Add(item);
                        MinDist = MathF.Min(MinDist, item.CapsuleDistance(Path[i].Position));
                    }
                }
                if (MinDist != float.MaxValue)
                {
                    Path[i].Position = Path[i - 1].Position + (Direction * Dist);
                    if (MinDist > 0)
                    {
                        Path[i].Obstructed = false;
                    }
                    else
                    {
                        Path[i].Obstructed = true;
                        Path[i].Ring = new List<Vector3>();
                        Path[i].SurfaceRing = new List<Vector3>();
                        RingPoint = (Vector3.Cross(Direction, Direction == Vector3.up ? Vector3.right : Vector3.up).normalized * 0.2f) + Path[i].Position;
                        SurfaceDist = float.MinValue;

                        MovePos = Path[i].Position;

                        for (int r = 0; r < Points; r++)
                        {
                            TestPoint = RoatatePoint(RingPoint, Path[i].Position, Direction, r * (360.0f / Points));
                            Path[i].Ring.Add(TestPoint);
                            TestPointDir = (TestPoint - Path[i].Position).normalized;
                            SwimDist = SwimUp(TestPoint, TestPointDir);
                            if (SwimDist > SurfaceDist)
                            {
                                SurfaceDist = SwimDist;
                                MovePos = TestPoint + (TestPointDir * MathF.Abs(SwimDist));
                            }
                            Path[i].SurfaceRing.Add(TestPoint + (TestPointDir * MathF.Abs(SwimDist)));
                        }

                        Path[i].Position = MovePos;
                    }
                }
            }
        }

        return Path;
    }

    private float SwimUp(Vector3 Point, Vector3 SwimDirection)
    {
        Vector3 ChunkPos = GridSnap(Point);
        List<Mushroom> Checked = new List<Mushroom>();
        float MinDist = 0;
        if (ActiveComponents.ContainsKey(ChunkPos))
        {
            foreach (var item in ActiveComponents[ChunkPos])
            {
                if (!Checked.Contains(item))
                {
                    Checked.Add(item);
                    MinDist = MathF.Min(MinDist, item.CapsuleDistance(Point));
                }
            }
            if (MinDist < 0 && (MathF.Abs(MinDist) - 0.01f > 0))
            {
                MinDist += SwimUp(Point + (SwimDirection * MathF.Abs(MinDist)), SwimDirection);
            }
        }
        return MinDist;
    }

    private Vector3 RoatatePoint(Vector3 Point, Vector3 Center, Vector3 Axis, float Angle)
    {
        return Quaternion.AngleAxis(Angle, Axis) * (Point - Center) + Center;
    }
}
