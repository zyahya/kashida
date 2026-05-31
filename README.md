# Kashida || كـشـيـدة

Kashida is a lightweight C# utility for applying and removing Arabic Kashida (elongation) characters while preserving diacritics. It is implemented as a single static class with simple and safe APIs.

## ✅ What it does

- Inserts Kashida between eligible Arabic letters
- Preserves diacritics (tashkeel/harakat)
- Skips ligature cases like **"لا"**
- Removes all Kashida characters when needed

## 📦 Installation

```
dotnet add package Kashida
```

## ✨ API Reference

### `string Apply(this string text, int kashidaCount = 1)`

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

### `string Clear(string text)`

Removes all Kashida characters from the input while preserving diacritics.

**Parameters**

- `text`: The input string.

**Returns**

- A new string without Kashida characters.

## ✅ Example Usage

```csharp
using Kashida;

var text = "السَّلَامُ عَلَيْكُمْ";

// Add Kashida
var elongated = text.Apply(2); // الـسَّـلَامُ عَـلَـيْـكُـمْ

// Remove Kashida
var cleared = Kashida.Clear(elongated); // السَّلَامُ عَلَيْكُمْ
```

## ✅ How Kashida Placement Works

- Only letters in the elongatable list are eligible.
- The next _real_ character (ignoring diacritics) must connect from the right.
- If diacritics exist after the current character, Kashida is inserted **after** them.
- The combination **"لا"** is skipped.

## 📌 Supported Unicode Range

- Arabic block: `U+0600` → `U+06FF`
- Diacritics: `U+064B` → `U+0652`, plus `U+0653`, `U+0654`

## 🧪 Tests

Unit tests are available in the `tests/Kashida.Tests` project and cover:

- Apply logic
- Clear logic
- Diacritic-safe behavior

## 🧾 License

MIT
