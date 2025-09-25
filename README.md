# Projektbeschreibung – Zahlen-Erkennung aus Textdatei

Dieses Projekt ist im Rahmen einer Coding-Challenge entstanden.  
Die Aufgabe besteht darin, ein Programm zu entwickeln, das aus einer Textdatei eingelesene Zahlen erkennt und diese korrekt auf dem Bildschirm ausgibt.

## Aufgabenstellung

In einer Textdatei sind die Zahlen `3, 2, 1, 4, 5` mithilfe von horizontalen und vertikalen Strichen kodiert.  
Das Programm wurde mit **.NET (Konsolenanwendung)** in **C#** erstellt.

## Ziele

- **Saubere Strukturierung**: Der Programmaufbau soll so gestaltet sein, dass mehrere Entwickler gleichzeitig daran arbeiten können.  
- **Modularität**: Einzelne Module sollen unabhängig voneinander entwickelt, ausgetauscht und getestet werden können.  

## UML-Diagramm

```mermaid
---
config:
  layout: elk
---
classDiagram
    direction LR
    class IDigitParser {
        <<interface>>
        +bool CanParse(string[] content, int rowIndex, int columnIndex)
        +string Parse()
        +int GetWidth()
        +int Priority
    }
    class IFileReader {
        <<interface>>
        +string[] ReadFile(string filePath)
    }
    class IOutputWriter {
        <<interface>>
        +void Write(string text)
        +void WriteLine(string text)
        +void WriteError(string message)
    }
    class IDigitScanner {
        <<interface>>
        +void ScanContent(string[] content)
    }
    class ScanPosition {
        +int Row
        +int Column
        +string[] Content
        +GetChar() char?
        +GetCharAt(int rowOffset, int columnOffset) char?
    }
    class DigitConstants {
        <<static>>
        +DIGIT_HEIGHT
        +DIGIT_1_WIDTH
        +DIGIT_2_WIDTH
        +DIGIT_3_WIDTH
        +DIGIT_4_WIDTH
        +DIGIT_5_WIDTH
    }
    class Digit1Parser {
        +int Priority
        +bool CanParse(string[], int, int)
        +string Parse()
        +int GetWidth()
    }
    class Digit2Parser {
        +int Priority
        +bool CanParse(string[], int, int)
        +string Parse()
        +int GetWidth()
    }
    class Digit3Parser {
        +int Priority
        +bool CanParse(string[], int, int)
        +string Parse()
        +int GetWidth()
    }
    class Digit4Parser {
        +int Priority
        +bool CanParse(string[], int, int)
        +string Parse()
        +int GetWidth()
    }
    class Digit5Parser {
        +int Priority
        +bool CanParse(string[], int, int)
        +string Parse()
        +int GetWidth()
    }
    class FileReader {
        +string[] ReadFile(string filePath)
    }
    class ConsoleOutputWriter {
        +void Write(string text)
        +void WriteLine(string text)
        +void WriteError(string message)
    }
    class DigitScanner {
        -IEnumerable~IDigitParser~ _parsers
        -IOutputWriter _outputWriter
        +ScanContent(string[] content)
    }
    class DependencyContainer {
        +IFileReader FileReader
        +IOutputWriter OutputWriter
        +IDigitScanner Scanner
        +IEnumerable~IDigitParser~ Parsers
    }
    class Program {
        +Main(string[] args)
    }
    IDigitParser <|.. Digit1Parser
    IDigitParser <|.. Digit2Parser
    IDigitParser <|.. Digit3Parser
    IDigitParser <|.. Digit4Parser
    IDigitParser <|.. Digit5Parser
    IFileReader <|.. FileReader
    IOutputWriter <|.. ConsoleOutputWriter
    IDigitScanner <|.. DigitScanner
    DigitScanner --> IDigitParser : uses
    DigitScanner --> IOutputWriter : uses
    DigitScanner --> ScanPosition : helper
    DependencyContainer --> FileReader
    DependencyContainer --> ConsoleOutputWriter
    DependencyContainer --> DigitScanner
    DependencyContainer --> IDigitParser
    Program --> DependencyContainer
    Program --> IFileReader
    Program --> IDigitScanner
```