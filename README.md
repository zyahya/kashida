# Kashida || كـشــيــدة

A lightweight C# utility to add or remove Arabic Kashida (elongation) while safely preserving diacritics.

## 📦 Installation

```
dotnet add package Kashida
```

## ✅ Example Usage

```csharp
using Kashida;

var text = "السَّلَامُ عَلَيْكُمْ";

// Add Kashida
var elongated = text.ApplyKashida(); // الـسَّـلَامُ عَـلَـيْـكُـمْ

// Remove Kashida
var cleared = elongated.ClearKashida(); // السَّلَامُ عَلَيْكُمْ
```

## ✨ API Reference

### `string ApplyKashida(this string text, int kashidaCount = 1)`

Adds Kashida to elongatable letters while respecting Arabic joining rules and diacritics.

**Parameters**

- `text`: The input string.
- `kashidaCount`: Number of Kashida characters to insert. Default is 1.

**Returns**

- A new string with Kashida inserted where valid.

**Behavior notes**

- Kashida is inserted only between letters that can connect.
- Diacritics after a letter are kept and Kashida is inserted after them.
- The ligature **"لا"** is excluded.

### `string ClearKashida(this string text)`

Removes all Kashida characters from the input while preserving diacritics.

**Parameters**

- `text`: The input string.

**Returns**

- A new string without Kashida characters.

## 📌 Supported Unicode Range

- Arabic block: `U+0600` → `U+06FF`
- Diacritics: `U+064B` → `U+0652`, plus `U+0653`, `U+0654`

## 🧾 License

MIT
