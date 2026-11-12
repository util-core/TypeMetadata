# TypeMetadata

English | [简体中文](README.md)

A static metadata cache per generic type for .NET.

One static cache per generic type `T`, owned once per application, so libraries never parse and
store the same type information over and over. It is resolved once on first access; every read
after that is a static field access and never throws.

Full documentation: [src/TypeMetadata/README.en.md](src/TypeMetadata/README.en.md).

## Install

```bash
dotnet add package TypeMetadata --version 1.0.0-preview.1
```

## Author

何镇汐

## License

MIT
