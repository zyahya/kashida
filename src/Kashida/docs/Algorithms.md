## Kashida algorithm

This document explains how the library inserts and removes Kashida (ـ) while preserving Arabic diacritics (ḥarakāt).

### Key rules

- Only elongatable letters can receive a Kashida.
- The next real character (skipping diacritics) must be able to connect from the right.
- The lam‑alef ligature ("لا") is excluded.
- Kashida is inserted **after** any diacritics that belong to the current letter.

### Apply: insert Kashida

**Inputs**: `text`, `kashidaCount` (default 1)
**Output**: new string with Kashida inserted where allowed.

Algorithm (high level):

1. Return early if `text` is empty.
2. Iterate through each character `current` in the text.
3. Append `current` to the output.
4. If `current` is a diacritic, continue.
5. Find the next _real_ character by skipping diacritics.
6. If the next real character exists and:
    - `current` is elongatable, and
    - the next real character connects from the right, and
    - the pair is not "لا",
      then:
    - copy any diacritics that belong to `current`,
    - append `kashidaCount` copies of Kashida,
    - advance the loop to skip the diacritics already copied.

**Diacritics handling**

Diacritics are preserved exactly where they are, and Kashida is placed _after_ them so word shapes remain correct.

### Clear: remove Kashida

**Inputs**: `text`
**Output**: new string with all Kashida removed.

Algorithm:

1. Return early if `text` is empty.
2. Replace all occurrences of Kashida with an empty string.

### Edge cases to consider

- Strings containing only diacritics.
- Words ending in an elongatable letter (no next real character).
- The lam‑alef ligature ("لا").
- Non‑Arabic characters and whitespace.

### Pseudocode

Apply:

1. For each index `i` in `text`:
    1. Append `text[i]`.
    2. If `text[i]` is diacritic, continue.
    3. Find `nextIndex` by skipping diacritics after `i`.
    4. If `nextIndex` is in range and all rules pass:
        - Append diacritics between `i` and `nextIndex`.
        - Append Kashida `kashidaCount` times.
        - Set `i = nextIndex - 1`.
