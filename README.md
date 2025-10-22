# Laborator SR
Ioan Teodorescu - EGOV

Pentru rularea proiectului:

Adaugati `DatabaseId` si `SecretToken` in `appsettings.json`

```bash
cd .\SR_lab\
dotnet run
```
Si selectati numarul laboratorului care vreti sa fie rulat!

## Laborator 1
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

codul este disponibil aici: https://github.com/iioan/SR_laborator/tree/main/SR_lab/SR_lab/lab1 

## Laborator 2
| Field | Type | Description                               |
|-------|------|-------------------------------------------|
| `customer_id` | string | Identificator unic al clientului          |
| `first_name`  | string | Prenumele clientului                      |
| `last_name`   | string | Numele de familie al clientului           |
| `country`     | string | Țara de proveniență a clientului          |
| `phone`       | string | Numărul de telefon principal al clientului |
| `email`       | string | Adresa de e-mail asociată clientului      |

codul este disponibil aici: https://github.com/iioan/SR_laborator/tree/main/SR_lab/SR_lab/lab2 
