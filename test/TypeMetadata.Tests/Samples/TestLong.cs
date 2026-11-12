namespace TypeMetadata.Tests.Samples;

/// <summary>
/// 测试用长整型枚举:long 基础类型,含 long.MaxValue 边界值
/// </summary>
public enum TestLong : long {
    Small = 1,
    Big = long.MaxValue
}
