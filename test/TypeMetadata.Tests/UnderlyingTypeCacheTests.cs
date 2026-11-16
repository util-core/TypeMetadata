using System;
using Xunit;
using TypeMetadata.Tests.Samples;

namespace TypeMetadata.Tests;

/// <summary>
/// UnderlyingTypeCache 基础类型缓存测试
/// </summary>
public class UnderlyingTypeCacheTests {
    /// <summary>
    /// 非可空类型返回自身
    /// </summary>
    [Fact]
    public void TestNonNullable() {
        Assert.Equal( typeof( int ), UnderlyingTypeCache.Get( typeof( int ) ) );
        Assert.Equal( typeof( string ), UnderlyingTypeCache.Get( typeof( string ) ) );
        Assert.Equal( typeof( TestColor ), UnderlyingTypeCache.Get( typeof( TestColor ) ) );
    }

    /// <summary>
    /// 可空类型返回基础类型,重复调用命中缓存结果一致
    /// </summary>
    [Fact]
    public void TestNullable() {
        Assert.Equal( typeof( int ), UnderlyingTypeCache.Get( typeof( int? ) ) );
        Assert.Equal( typeof( TestColor ), UnderlyingTypeCache.Get( typeof( TestColor? ) ) );
        Assert.Equal( typeof( TestColor ), UnderlyingTypeCache.Get( typeof( TestColor? ) ) );
    }

    /// <summary>
    /// 泛型值类型(如 ValueTuple)不是可空类型,返回自身而非第一个泛型参数
    /// </summary>
    [Fact]
    public void TestGenericStruct() {
        Assert.Equal( typeof( ValueTuple<int, string> ), UnderlyingTypeCache.Get( typeof( ValueTuple<int, string> ) ) );
    }

    /// <summary>
    /// 开放泛型 Nullable<> 不是可空实例,返回自身而非泛型参数
    /// </summary>
    [Fact]
    public void TestOpenGenericNullable() {
        Assert.Equal( typeof( Nullable<> ), UnderlyingTypeCache.Get( typeof( Nullable<> ) ) );
    }

    /// <summary>
    /// 空引用返回 null
    /// </summary>
    [Fact]
    public void TestNull() {
        Assert.Null( UnderlyingTypeCache.Get( null ) );
    }

    /// <summary>
    /// 清空缓存后仍能正确获取基础类型
    /// </summary>
    [Fact]
    public void TestClear() {
        Assert.Equal( typeof( int ), UnderlyingTypeCache.Get( typeof( int? ) ) );
        UnderlyingTypeCache.Clear();
        Assert.Equal( typeof( int ), UnderlyingTypeCache.Get( typeof( int? ) ) );
    }
}
