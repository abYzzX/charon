# Charon sprite font format

This format is used by the `CharonSpriteFont` class. It is a simple binary format.

## Format

### Header

| Pos | Size | Description      |
|-----|------|------------------|
| 0   | 3    | CSF              |
| 3   | 2    | Version          |
| 5   | 2    | Font size        |
| 7   | 2    | Font line height |
| 9   | 2    | Font width       |
| 11  | 2    | Font height      |
| 13  | 2    | Font x offset    |
| 15  | 2    | Font y offset    |
| 17  | 2    | Font x advance   |
| 19  | 8    | Texture Size     |
| 27  | 2    | Character Count  |
| 29  | n    | Character Data   |
| n   | -    | Texture          |

### Character Data

| Pos | Size | Description        |
|-----|------|--------------------|
| 0   | 2    | Character          |
| 2   | 2    | X Offset           |
| 4   | 2    | Y Offset           |
| 6   | 2    | Width              |
| 8   | 2    | Height             |
| 10  | 2    | X Advance          |
| 12  | 4    | X-Texture position |
| 16  | 4    | Y-Texture position |

