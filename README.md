# FileBasedApp

[Türkçe](#türkçe) · [English](#english)

---

## Türkçe

.NET **file-based app** örneği: geleneksel `.csproj` dosyası olmadan tek bir C# kaynak dosyasından derlenip çalıştırılabilen küçük bir konsol programıdır.

## Ne yapar?

- İki adet `TestModel` örneği oluşturur, bir listeye ekler.
- Aynı listeyi sırayla **System.Text.Json** ve **Newtonsoft.Json** ile serileştirir ve konsola yazar.
- Çıktıları karşılaştırmayı kolaylaştırmak için araya bir ayraç satırı koyar.

## Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download) veya file-based uygulamaları destekleyen güncel bir .NET SDK (file-based apps için dokümantasyona göre .NET 10+).

## Çalıştırma

Proje klasöründe:

```bash
dotnet run FileBasedApp.cs
```

İsteğe bağlı kısayol (SDK sürümüne göre):

```bash
dotnet FileBasedApp.cs
```

## Dosya yapısı

| Dosya | Açıklama |
|--------|-----------|
| `FileBasedApp.cs` | Giriş noktası, `#:` yönergeleri, üst düzey ifadeler ve `TestModel` sınıfı |

## File-based yönergeleri (`#:`)

Kaynak dosyanın başında SDK tarafından okunan satırlar:

- **`#:package NewtonSoft.Json@13.0.3`** — NuGet paket referansı (Newtonsoft ile serileştirme için; kaynak dosyadaki paket adıyla aynı).
- **`#:property PublishAot=false`** — File-based modda varsayılan **Native AOT** açık olduğunda reflection tabanlı JSON API’leri sorun çıkarabildiği için AOT yayını kapatılır; böylece `System.Text.Json` ve Newtonsoft ile tipik serileştirme kullanımı çalışır.

> Not: `#:` satırları C# derleyicisi tarafından yok sayılır; anlamlarını .NET SDK üretir.

## Kod düzeni

- **Üst düzey ifadeler** uygulamanın girişini oluşturur (`Main` açık yazılmaz).
- **`TestModel`** aynı derleme biriminde, dosyanın alt kısmında tanımlıdır; file-based tek dosya çalıştırmada başka `.cs` dosyası otomatik dahil edilmediği için model burada tutulur.
- `micJson` ve `NTS` **using alias** ile kütüphane adları kısaltılmıştır.

## Bağımlılıklar

- **NewtonSoft.Json** 13.0.3 (NuGet, `#:package` ile)
- **System.Text.Json** — .NET ile birlikte gelir

## İlgili dokümantasyon

- [File-based apps (.NET)](https://learn.microsoft.com/dotnet/core/sdk/file-based-apps)
- [C# preprocessor directives — File-based apps](https://learn.microsoft.com/dotnet/csharp/language-reference/preprocessor-directives#file-based-apps)

---

## English

A .NET **file-based app** sample: a small console program built and run from a single C# source file without a traditional `.csproj` project file.

### What it does

- Creates two `TestModel` instances and adds them to a list.
- Serializes the same list with **System.Text.Json** and **Newtonsoft.Json**, in order, and writes the results to the console.
- Inserts a separator line between outputs to make comparison easier.

### Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or a current .NET SDK that supports file-based apps (per documentation, .NET 10+ for this workflow).

### How to run

From the project folder:

```bash
dotnet run FileBasedApp.cs
```

Optional shorthand (depends on SDK version):

```bash
dotnet FileBasedApp.cs
```

### File layout

| File | Description |
|------|-------------|
| `FileBasedApp.cs` | Entry point, `#:` directives, top-level statements, and the `TestModel` class |

### File-based directives (`#:`)

Lines at the top of the source file that the SDK interprets:

- **`#:package NewtonSoft.Json@13.0.3`** — NuGet package reference (for Newtonsoft serialization; matches the package id used in the source file).
- **`#:property PublishAot=false`** — In file-based mode, **Native AOT** publishing is enabled by default and can break reflection-based JSON APIs; disabling AOT keeps typical `System.Text.Json` and Newtonsoft usage working.

> Note: Lines starting with `#:` are ignored by the C# compiler; the .NET SDK gives them meaning.

### Code layout

- **Top-level statements** provide the app entry point (`Main` is not written explicitly).
- **`TestModel`** is defined in the same compilation unit at the bottom of the file; with single-file file-based runs, other `.cs` files are not included automatically, so the model lives here.
- `micJson` and `NTS` are **using aliases** that shorten library names.

### Dependencies

- **NewtonSoft.Json** 13.0.3 (NuGet via `#:package`)
- **System.Text.Json** — ships with the .NET runtime

### Further reading

- [File-based apps (.NET)](https://learn.microsoft.com/dotnet/core/sdk/file-based-apps)
- [C# preprocessor directives — File-based apps](https://learn.microsoft.com/dotnet/csharp/language-reference/preprocessor-directives#file-based-apps)
