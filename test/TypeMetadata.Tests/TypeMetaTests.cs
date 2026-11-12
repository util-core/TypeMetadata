using Xunit;
using TypeMetadata.Tests.Samples;

namespace TypeMetadata.Tests;

/// <summary>
/// TypeMeta 类型元数据测试
/// </summary>
public class TypeMetaTests {
    /// <summary>
    /// int 的元数据:整数、值类型,非可空、非枚举,UnderlyingType 为自身
    /// </summary>
    [Fact]
    public void TestInt() {
        Assert.True( TypeMeta<int>.IsInteger );
        Assert.True( TypeMeta<int>.IsValueType );
        Assert.False( TypeMeta<int>.IsNullable );
        Assert.False( TypeMeta<int>.IsEnum );
        Assert.Equal( typeof( int ), TypeMeta<int>.Type );
        Assert.Equal( typeof( int ), TypeMeta<int>.UnderlyingType );
    }

    /// <summary>
    /// int? 的元数据:解包后仍为整数,IsNullable 为真,UnderlyingType 为 int
    /// </summary>
    [Fact]
    public void TestNullableInt() {
        Assert.True( TypeMeta<int?>.IsInteger );
        Assert.True( TypeMeta<int?>.IsNullable );
        Assert.Equal( typeof( int ), TypeMeta<int?>.UnderlyingType );
    }

    /// <summary>
    /// 枚举类型识别为枚举,且因基础类型为 int 同时识别为整数
    /// </summary>
    [Fact]
    public void TestEnum() {
        Assert.True( TypeMeta<TestColor>.IsEnum );
        Assert.True( TypeMeta<TestColor>.IsInteger );
        Assert.False( TypeMeta<TestColor>.IsNullable );
    }

    /// <summary>
    /// 可空枚举经基础类型解包后识别为枚举,IsNullable 为真
    /// </summary>
    [Fact]
    public void TestNullableEnum() {
        Assert.True( TypeMeta<TestColor?>.IsEnum );
        Assert.True( TypeMeta<TestColor?>.IsNullable );
    }

    /// <summary>
    /// string 为引用类型:非值类型、非整数、非枚举
    /// </summary>
    [Fact]
    public void TestString() {
        Assert.False( TypeMeta<string>.IsValueType );
        Assert.False( TypeMeta<string>.IsInteger );
        Assert.False( TypeMeta<string>.IsEnum );
    }

    /// <summary>
    /// long 基础类型的枚举同样识别为整数,支持 long.MaxValue 边界值
    /// </summary>
    [Fact]
    public void TestLongEnum() {
        Assert.True( TypeMeta<TestLong>.IsEnum );
        Assert.True( TypeMeta<TestLong>.IsInteger );
    }
}
