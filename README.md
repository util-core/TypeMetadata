# TypeMetadata

[English](README.en.md) | 简体中文

每个泛型类型的静态元数据缓存。

每个泛型类型 `T` 一份静态缓存,全应用共享唯一所有权,避免多个类库各自重复解析、重复存储同一类型的元数据。
类型信息在首次访问时解析一次,之后每次访问都是静态字段读取,不抛异常。

完整文档:[src/TypeMetadata/README.md](src/TypeMetadata/README.md)。

## 安装

```bash
dotnet add package TypeMetadata --version 1.0.0-preview.1
```

## 作者

何镇汐

## License

MIT
