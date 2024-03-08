# YouCanHaveANumberBetween

A simple program that takes 2-5 arguments and generates a text file output

https://discord.com/channels/283467363729408000/586931790208434203/1215647840886587432

# Notes

This program uses invariant culture for converting Doubles to Strings, and Strings to Doubles.
*(This means `.` will be used as the decimal point.)*

# Usage

```
YouCanHaveANumberBetween <min:Int or Double> <max:Int or Double> [dateformat:String] [usedouble:Boolean] [seed:Int]
```

## `dateformat` Format
```
{0} = Day (DD)
{1} = Month (MM)
{2} = Year (YYYY)
{3} = Hour {HH}
{4} = Minute {MM}
{5} = Second {SS}

Default is "{0}-{1}-{2}-{3}-{4}-{5}"
```

## `usedouble`

Is case-insensitive.

# Examples

## Simple Example

#### Command Line Instructions
```
C:\Program>YouCanHaveANumberBetween 1 100
```

#### Text File Output
###### DD-MM-YYYY-HH-MM-SS.txt
```
Generated a random integer value between 1 and 100
Returned 2
```

## Rename Text File

#### Command Line Instructions
```
C:\Program>YouCanHaveANumberBetween 1 100 "output"
```

#### Text File Output
###### output.txt
```
Generated a random integer value between 1 and 100
Returned 43
```

## Custom Date Format

#### Command Line Instructions
```
C:\Program>YouCanHaveANumberBetween 1 100 "number-of-{2}"
```

#### Text File Output
###### number-of-YYYY.txt
```
Generated a random integer value between 1 and 100
Returned 69
```

## Seeing Double

#### Command Line Instructions
```
C:\Program>YouCanHaveANumberBetween 1 100 "{0}-{1}-{2}-{3}-{4}-{5}" true
```

#### Text File Output
###### DD-MM-YYYY-HH-MM-SS.txt
```
Generated a random decimal value between 1 and 100
Returned 69.93679084022814
```
###### nice

## Double Input

#### Command Line Instructions
```
C:\Program>YouCanHaveANumberBetween 1.5 2.5 "{0}-{1}-{2}-{3}-{4}-{5}" true
```

#### Text File Output
###### DD-MM-YYYY-HH-MM-SS.txt
```
Generated a random decimal value between 1.5 and 2.5
Returned 1.6009828722714252
```

## Seeded Output

#### Command Line Instructions
```
C:\Program>YouCanHaveANumberBetween 1 100 "{0}-{1}-{2}-{3}-{4}-{5}" true 5174123
```

#### Text File Output
###### DD-MM-YYYY-HH-MM-SS.txt
```
Generated a random decimal value between 1 and 100
Returned 84.52262926451985
```
