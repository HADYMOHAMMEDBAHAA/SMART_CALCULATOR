# SMART_CALCULATOR

A C# (.NET 9) math expression engine with an interactive console front end. The solution is named **SMART_MATH_VERSION_TWO**. The engine, `SMART_MATH_CORE`, tokenizes a text expression, parses it into a result using a chain of precedence-level expression classes, and evaluates it over three value types: **Number**, **List** and **Matrix**.

> **About this document.** It describes what the code in the repository does today. Behavior was read from the source and, where marked "verified", confirmed by running the library. Anything that is not implemented is listed under [Current limitations](#current-limitations) and is not presented as a feature. No planned features are documented in the repository.

---

## Table of contents

1. [Features](#features)
2. [Solution structure](#solution-structure)
3. [Architecture overview](#architecture-overview)
4. [Execution pipeline](#execution-pipeline)
5. [Supported mathematical operations](#supported-mathematical-operations)
6. [Supported data types](#supported-data-types)
7. [Expression syntax and examples](#expression-syntax-and-examples)
8. [Build and run](#build-and-run)
9. [Extensibility guide](#extensibility-guide)
10. [Current limitations](#current-limitations)

---

## Features

Implemented:

- Evaluation of mathematical expressions typed as plain text.
- Operators: `+`, `-`, `*`, `/`, `^` (power) and `root`, with word aliases for some operators (for example `plus`, `sqrt`).
- Functions: `sin`, `cos`, `tan` (degrees) and `log`.
- Parentheses and nested expressions.
- Three value types: Number, List and Matrix, with element-wise operations on Lists and Matrices and true matrix multiplication for Matrix × Matrix.
- An interactive console loop (`Testing` project).
- A GitHub Actions workflow that restores and builds the solution (it does not run tests).

Not implemented (see [Current limitations](#current-limitations) for details): the `%` / `mod` operator evaluates to `ERROR`, the constant `bi` / `π` cannot be used, and there are no unit tests.

---

## Solution structure

```
SMART_MATH_VERSION_TWO.sln
├── SMART_MATH_CORE/          Class library (net9.0, no NuGet packages) - the whole engine
│   ├── Parser/
│   │   ├── Parsing.cs            Entry point: Parsing.Parse(string)
│   │   ├── Tokenizer/            Tokenizer.Tonenizes(string)
│   │   ├── Token/                Token, Input_Token, Operator_Token, Function_Token, Identifires_Token
│   │   ├── Token_Recognizer/     Token_Recognizer base class
│   │   └── Expression/           IExpression, Expression
│   ├── Primary/
│   │   ├── Primary_Value/        Primary_Value, Primary_Value_Type
│   │   ├── Token_To_Primary/     Token -> Primary_Value converters
│   │   ├── Primary_To_Token/     Primary_Value -> Token converters
│   │   └── Primary_To_String/    Primary_Value -> string converters
│   ├── Registery/
│   │   ├── Tokens/               Concrete tokens, recognizers and token registries
│   │   │   ├── Input_Tokens/         Number / List / Matrix tokens and recognizers
│   │   │   ├── Operators_Tokens/     + - * / ^ root %  and their registry/recognizer
│   │   │   ├── Function_Tokens/      Sin, Cos, Tan, Log and their registry/recognizer
│   │   │   ├── Identifier_Tokens/    Parentheses, brackets, curly brackets, comma, Bi
│   │   │   └── Tokens_Recognizers_Registery/
│   │   ├── Expressions/          Addition, Multiplication, Power, Function, Primary expressions
│   │   ├── Evaluators/           General, Addition, Multiply, Power evaluators
│   │   ├── Functions_Executers/  Per-operation, per-value-type executers + executers dictionary
│   │   └── Primary_Values/       Number, List and Matrix primary values
│   ├── Evaluator/                IEvaluator
│   ├── Configrations/            Configs.cs (Number_Type)
│   └── My_Lib/                   Matrix, Read_Number, Read_Numbers_List, Search_Algorithm
├── Testing/                  Console application (net9.0) - interactive loop
└── .github/workflows/        "SMART MATH - Build" (restore + Release build on .NET 9)
```

| Project | Type | Responsibility |
|---|---|---|
| `SMART_MATH_CORE` | Class library | Tokenizing, parsing, evaluation and value models |
| `Testing` | Console application | Reads a line, calls `Parsing.Parse`, prints each returned string. Despite its name it is a runner, not a test project |

---

## Architecture overview

The engine is organized around a **string → tokens → expression → value → string** flow.

| Concern | Main classes |
|---|---|
| Entry point | `Parsing.Parse` |
| Tokenizing | `Tokenizer`, `Token_Recognizer` and its subclasses, `Tokens_Recognizers_Registery` |
| Tokens | `Token` → `Input_Token`, `Operator_Token`, `Function_Token`, `Identifires_Token` |
| Parsing / precedence | `Expression` and the `IExpression` classes in `Registery/Expressions` |
| Value models | `Primary_Value` → `Number_Primary_Value`, `List_Primary_Value`, `Matrix_Primary_Value`; `Number_Type` |
| Evaluation | `IEvaluator`, `General_Evaluator`, `Addition_Evaluator`, `Multiply_Evaluator`, `Power_Evaluator` |
| Operation execution | `Functions_Executers_Dictionary`, `Function_Executer` and its per-operation subclasses |

Notes on the design as implemented:

- Concrete pieces live in `Registery/` and are connected through static registries (for example `Function_Token_Registery`, `Operators_Registry_Token`, `Primary_Values_Registery`, `Functions_Executers_Dictionary`).
- The parser is a **chain of precedence-level classes**, each of which creates the next level (it is not a general-purpose parser generator).
- There is no persistent syntax-tree object. Each `Process` call splits the token list and hands sub-lists to the next level, so the tree exists as the call structure.

### Precedence levels (lowest to highest)

| Level | Class | Operators handled |
|---|---|---|
| 1 | `Addition_Expression` | `+`, `-` (also unary) |
| 2 | `Multiplication_Expression` | `*`, `/`, `%` (`Reminder_Token`) |
| 3 | `Power_Expression` | `^`, `root` |
| 4 | `Function_Expression` | `sin`, `cos`, `tan`, `log` |
| 5 | `Primary_Expression` | Number / List / Matrix values and parenthesised groups |

---

## Execution pipeline

1. **Input.** `Testing/Program.cs` reads a line and calls `Parsing.Parse(string)`.
2. **Tokenizing.** `Tokenizer.Tonenizes` walks the string. At each position it tries the recognizers in this order (set in `Tokens_Recognizers_Registery`):
   `Matrix_Token_Recognizer` → `List_Recognizer_Token` → `Number_Recognizer_Token` → `Indentifier_Tokens_Recognizer` → `Function_Token_Recognize` → `Operator_Recognize_Token`.
   The first recognizer that returns a token wins. A character no recognizer matches is skipped.
3. **Expression processing.** `Expression.Process(ref List<Token>)` calls `Addition_Expression`, which passes sub-lists down through `Multiplication_Expression`, `Power_Expression` and `Function_Expression` to `Primary_Expression`.
4. **Token to value.** `Primary_Expression` asks `Primary_Values_Registery.IsPrimary` to turn value tokens into `Primary_Value` objects (via `Convert_Token_To_Primary`). A parenthesised group is unwrapped and processed again from the top.
5. **Evaluation.** The expression class calls its evaluator. `General_Evaluator` uses `Return_Type_Of_Operation.Get_Return_Type` to decide the result type, then looks up a `Function_Executer` in `Functions_Executers_Dictionary` by operator/function token and value type.
6. **Execution.** The `Function_Executer` computes the result and returns a `Primary_Value`.
7. **Output.** `Primary_Value.ConvertPrimaryToString()` returns a `List<string>`. `Program` prints each element on its own line. If anything inside `Process` throws, or the result is null, `Parsing.Parse` returns `["ERROR"]`.

### Worked example: `2 + 3 * 4`

```
Tokens:  [Number:2  Plus  Number:3  Multiply  Number:4]

Expression.Process
 └─ Addition_Expression.Process          splits at Plus
     ├─ Multiplication_Expression [2]            -> ... -> Primary_Expression -> Number 2
     └─ Multiplication_Expression [3 * 4]        -> Multiply_Function_Executer_Number -> 12
     Plus_Function_Executer_Number(2, 12)        -> 14
```

### Worked example: `sin(30)`

```
Tokens:  [Sin  (#1  Number:30  )#1]

Function_Expression finds Sin with no Left operand,
reads the parenthesised group as Right,
Primary_Expression unwraps it and re-enters Expression.Process([30]) -> Number 30,
Sin_Function_Execute_Number computes Math.Sin(30 * PI / 180)  -> 0.49999999999999994
```

### Worked example: matrix multiplication

```
{{1,2},{3,4}} * {{5,6},{7,8}}
Tokens:  [Matrix{1,2;3,4}  Multiply  Matrix{5,6;7,8}]
Multiply_Function_Executer_Matrix checks the dimensions and builds a new Matrix_Primary_Value
Result:  [[19, 22], [43, 50]]
```

---

## Supported mathematical operations

### Operators

| Operator | Syntax | Notes |
|---|---|---|
| Addition | `a + b` | Word alias `plus` verified. Also unary `+` |
| Subtraction | `a - b` | Also unary `-`, for example `-5` |
| Multiplication | `a * b` | Matrix × Matrix is a matrix product |
| Division | `a / b` | Division by zero gives `ERROR` |
| Power | `a ^ b` | Right-to-left: `2 ^ 3 ^ 2` = 512 |
| Root | `n root x` | `n` is the degree, `x` the radicand. Prefix form `root x` and the alias `sqrt` use degree 2 |
| Remainder | `%`, `mod`, `modulus` | Tokenized and parsed, but **no executer exists**: always `ERROR` |

Aliases are defined per token in each token class's `Aliases` list. Matching is case-insensitive prefix matching.

### Functions

| Function | Behavior |
|---|---|
| `sin(x)`, `cos(x)`, `tan(x)` | Argument is in **degrees** |
| `log(x)` | Base 10 for a Number. For a List, the first element is the base and the logarithm is applied to the remaining elements (`log({2,8})` = 3) |

Implicit multiplication works in front of a function: `2 sin(30)` = 2 × sin(30).

### Operations by value type

The table shows what was verified by running the library. An executer for each combination in the Number/List/Matrix families is registered in `Functions_Executers_Dictionary`, but only the entries marked verified were run.

| Operation | Number | List | Matrix |
|---|---|---|---|
| `+` `-` | verified | verified (List with Number, and List with List) | verified (Matrix with Matrix) |
| `*` | verified | verified (List with Number) | verified (Matrix with Number, Matrix with Matrix) |
| `/` | verified | verified (List with Number) | verified (Matrix with Number) |
| `^` | verified | verified (List with Number, element-wise) | verified (Matrix with Number, element-wise) |
| `sin` `cos` `tan` `log` | verified (`log` base 10) | `sin`, `tan` and `log` verified | `cos` verified; `sin`, `tan` and `log` executers present, not run |

Cross-type behavior:

- **List op Number** and **Matrix op Number** apply the operation element-wise.
- **List + List** of different lengths returns a result as long as the shorter list.
- **Matrix + Matrix** is element-wise. Mismatched shapes give `ERROR`.
- **List op Matrix** (for example `{1,2,3} * {{1,2},{3,4}}`) gives `ERROR`.

---

## Supported data types

| Type | Class | Stored as |
|---|---|---|
| Number | `Number_Primary_Value` | `Number_Type` (a mutable wrapper around `double`) |
| List | `List_Primary_Value` | `List<Number_Type>` |
| Matrix | `Matrix_Primary_Value` | `List<List<Number_Type>>` |

All numbers are parsed with `double.TryParse` (the comment in `Configs.cs` says `Number_Type` controls "if double or int in whole system").

Output formatting (from `ConvertPrimaryToString`): a Number returns `" "`, value, `" "`; a List returns that triple per element followed by `"\n"`; a Matrix returns the elements of each row followed by `"]\n"` (rows start with `"[ "`).

---

## Expression syntax and examples

### Literals

| Kind | Syntax | Example |
|---|---|---|
| Number | decimal digits | `42`, `3.5` |
| List | braces, comma-separated | `{1,2,3}` |
| Matrix | nested braces | `{{1,2},{3,4}}` |

Space-separated numbers without braces (for example `2 3`) are read by the List recognizer as a List.

### Examples

Results below were observed by running the library (built on .NET 8 in a scratch copy of the code).

| Expression | Result |
|---|---|
| `2 + 3 * 4` | `14` |
| `(2+3)*4` | `20` |
| `2 * 3 + 4` | `10` |
| `2 ^ 3 ^ 2` | `512` |
| `2 ^ 0.5` | `1.4142135623730951` |
| `10 / 4` | `2.5` |
| `sin(30)` | `0.49999999999999994` |
| `cos(60)` | `0.5000000000000001` |
| `tan(45)` | `0.9999999999999999` |
| `log(100)` | `2` |
| `2 sin(30)` | `0.9999999999999999` |
| `sin(cos(0))` | `0.01745240643728351` (that is sin(1°)) |
| `((2+3)*(4-1))+sin(30)*2` | `16` |
| `2 * (3 + (4 * (5 - 1)))` | `38` |
| `3 root 27` | `3` (degree 3 of 27; see the note under Operators) |
| `root 9` / `sqrt 9` | `3` |
| `3 plus 4` | `7` |
| `{1,2,3} + 10` | `{11, 12, 13}` |
| `{1,2,3} * 2` | `{2, 4, 6}` |
| `{1,2,3} + {10,20,30}` | `{11, 22, 33}` |
| `{{1,2},{3,4}} * {{5,6},{7,8}}` | `[[19, 22], [43, 50]]` |
| `{{1,2,3},{4,5,6}} * {{1,2},{3,4},{5,6}}` | `[[22, 28], [49, 64]]` |
| `{{1,2},{3,4}} * 2` | `[[2, 4], [6, 8]]` |
| `{{1,2},{3,4}} ^ 2` | `[[1, 4], [9, 16]]` |
| `10 / 0` | `ERROR` |
| `10 % 3` | `ERROR` (no executer for `%`) |

---

## Build and run

Requirements: the **.NET 9 SDK** (the projects target `net9.0`; the CI workflow installs `9.0.x`).

```bash
git clone https://github.com/HADYMOHAMMEDBAHAA/SMART_CALCULATOR.git
cd SMART_CALCULATOR

dotnet restore SMART_MATH_VERSION_TWO.sln
dotnet build   SMART_MATH_VERSION_TWO.sln --configuration Release

dotnet run --project Testing
```

The console prints `ENTER MATH EXPRESSION`. Type an expression and press Enter. Results are printed one fragment per line. The loop is `while (true)` with no exit command, so stop the program with Ctrl+C.

---

## Extensibility guide

These steps describe how the existing code is wired. Each registry or dictionary is static, so a new piece must be added to it in code. The steps were read from the source and were not tested by modifying it.

### Add a function (for example `abs`)

`Function_Expression` treats any `Function_Token` subclass generically, so no expression class needs to change.

1. Create `Abs_Token : Function_Token`, setting `Name`, `Aliases` and `Value` (follow `Sin_Token`).
2. Add `new Abs_Token()` to the list in `Function_Token_Registery.InitializeFunctionTokens`.
3. Write executers deriving from `Function_Executer` for the value types you want (Number, List, Matrix), overriding `Execute`.
4. In `Functions_Executers_Dictionary`, add a static dictionary of executers per `Primary_Value_Type`, fill it in `Initialize_Function_Executers_Dictionary`, and register it with `Function_Executers_Dictionary_.Add(new Abs_Token(), ...)`. The executer is found by matching the token `Name` against registered aliases.

### Add an operator at an existing precedence level

1. Create the token deriving from `Operator_Token` and register it in `Operators_Registry_Token`.
2. Add it to the type checks of the level's expression class (the expression classes test concrete token types such as `is Plus_Token`).
3. Add executers and register them in `Functions_Executers_Dictionary`.
4. For operators handled by `Multiply_Evaluator` or `Power_Evaluator`, add the matching branch in that evaluator.

### Add a new precedence level

Each level creates the next one directly, so a new level means a new `IExpression` class and editing the class above it (and the one below) to wire it in.

### Add a recognizer

Create a subclass of `Token_Recognizer` overriding `Recognize(string text, int start, out int end)`, and add it to `Tokens_Recognizers_Registery.Initailize_Recognizers`. Order matters: earlier recognizers take priority.

### Add a value type

This touches several places: the `Primary_Value_Type` enum, a new `Primary_Value` subclass, a token and recognizer, `Convert_Token_To_Primary` and `Primary_Values_Registery`, `Return_Type_Of_Operation`, the type branches in the evaluators, and executers for every operator and function that should support it.

---

## Current limitations

These are observed behaviors of the code as it stands. They are documented here so users are not surprised; they are not a roadmap.

**Evaluation order**

- Chains of `-` and `/` are evaluated right-to-left, because the right-hand side of an operator is processed as one sub-expression. Observed: `10 - 4 - 3` = `9`, `10 - 4 + 3` = `3`, `8 / 4 / 2` = `4`, `-5 + 3` = `-8`. `2 ^ 3 ^ 2` = `512` is the conventional right-associative result.
- Unary minus after `^` is not supported: `2 ^ -1` gives `ERROR`.

**Crashes (the process terminates)**

- These inputs caused a stack overflow in the verified runs: `bi`, `π`, `2 $ 3`, `2(3)`, `log(2,8)`. The recursion guard in `Expression` (`Memorization_IF_Stucked_In_Same_Expression`) is keyed by `List<Token>` reference, and the recursion that occurs builds new lists at each level.
- An unbalanced closing parenthesis (for example `2+3)`) throws from the tokenizer. `Parsing.Parse` only wraps the `Process` call in `try/catch`, and `Program.Main` has no `try/catch`, so the console application would terminate.

**Unsupported or incomplete**

- `%`, `mod` and `modulus` are parsed but have no executer, so they return `ERROR`.
- `bi` / `π` is tokenized (value `"3.14"`) but never becomes a value.
- Implicit multiplication works only in front of a function (`2 sin(30)`). `(2)(3)` returns `2` and `(2+1)(3+1)` returns `3`.
- Unmatched `(` returns `ERROR`.

**Silent input handling**

- Characters that no recognizer matches are skipped without a message. Observed: `sinn(1)` is evaluated as `sin(1)`; `1.5.2` is read as `5.2`.
- Operator, function and identifier matching is case-insensitive prefix matching with no word-boundary check.
- Every failure inside `Process` produces the same message, `ERROR`, with no detail (the `catch` block is empty).

**Operand order and shapes (observed, intent not confirmed from the code)**

- `5 - {1,2,3}` gives `{-4,-3,-2}` (the same as `{1,2,3} - 5`), and `{1,2,3} - {1,1,1}` gives `{0,-1,-2}`.
- `{1,2,3} / 2` gives `{2,1,0.667}` and `12 / {1,2,3}` gives `{0.083,0.167,0.25}`, so List division with a Number appears to apply the operands in reverse order.
- `{{1,2},{3,4}} - {{1,1},{1,1}}` gives `[[0,-1],[-2,-3]]`, which is the second matrix minus the first, so Matrix - Matrix also appears to apply the operands in reverse order.
- `{1,2,3} + {10,20}` returns a list as long as the shorter one.
- `{1,2,3} * {{1,2},{3,4}}` gives `ERROR`.

**Design and quality**

- Static global state is not thread-safe, and it grows during a session: the parenthesis registry (`Parenthesis_Identity`) and the `Expression` recursion-guard dictionary keep every entry they receive.
- Executers modify their input values in place.
- There are no unit tests, and CI only builds.
- Trigonometric functions use degrees only; `log` is base 10 (or list-based as described above).
- There is no variable, assignment or history feature, and no way to exit the console loop other than Ctrl+C.
