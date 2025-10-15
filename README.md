## Laborator 1 SR
Ioan Teodorescu - EGOV

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `clean_name` | string | Identificator normalizat al albumului (litere mici, cu cratime) |
| `album` | string | Titlul complet al albumului |
| `release_year` | string | Anul in care a fost lansat albumul |
| `genre` | string | Clasificarea genului muzical |

albumele sunt importate in recombee cu urmatoarea structura:

- **id al elementului**: `album-{index}` (ex.: `album-0`, `album-1`)
- **proprietati**: toate campurile din fisierul .csv sunt stocate ca proprietati ale elementului
- **dimensiune lot**: 100 de elemente per API call

codul este disponibil aici: https://github.com/iioan/SR_laborator/tree/main/SR_lab/SR_lab
