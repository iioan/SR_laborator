## Laborator 1 SR
Ioan Teodorescu - EGOV

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `clean_name` | string | Normalized album identifier (lowercase, hyphenated) |
| `album` | string | Full album title |
| `release_year` | string | Year the album was released |
| `genre` | string | Music genre classification |

albumele sunt importate in recombee cu urmatoarea structura:

- **id al elementului**: `album-{index}` (ex.: `album-0`, `album-1`)
- **proprietati**: toate campurile din fisierul .csv sunt stocate ca proprietati ale elementului
- **dimensiune lot**: 100 de elemente per API call
