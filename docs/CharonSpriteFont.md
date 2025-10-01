# Charon sprite font format

This format is used by the `CharonSpriteFont` class. It is a simple binary format.

## Format

### Header

| Pos | Size | Description      |
|-----|------|------------------|
| 0   | 3    | CSF              |
| 3   | 1    | Version          |
| 4   | 2    | Font size        |
| 6   | 2    | Font line height |
| 8   | 8    | Texture Size     |
| 16  | 2    | Character Count  |
| 18  |      | Character Data   |
|     |      | Texture          |
|     |      | Extended Data    |

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

### Extended Data

Extended data is a list of a name-value string list. 
Each string is terminated by a null character.

Known names:
- FontName
- FontFamily
- FontStyle
- FontVersion
- Author
- Copyright
- License
