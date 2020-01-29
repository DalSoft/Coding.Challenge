# Coding.Challenge

Given the attached text file as an argument, your program will read the file, and output the 20 most frequently used words in the file in order, along with their frequency. 
The output should be the same to that of the following bash program:

```bash
#!/usr/bin/env bash
cat $1 | tr -cs 'a-zA-Z' '[\n*]' | grep -v "^$" | tr '[:upper:]' '[:lower:]'| sort | uniq -c | sort -nr | head -20
```

## Solutions

Each branch is a iteration of the program design, and is benchmarked using https://benchmarkdotnet.org/

## Iteration 1

> Branch iteration-1

Get a naive solution working (~45 mins), with a verifying test and benchmarked.

This solution just reads the filestream line by line with a 64kb buffer (Rather than ReadAllLines), and uses 'words' RegEx to find the all the words.

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.17134.1246 (1803/April2018Update/Redstone4)
Intel Core i7-4750HQ CPU 2.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]     : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT


```
|                 Method |     Mean |    Error |   StdDev |
|----------------------- |---------:|---------:|---------:|
| BenchmarkParseTextFile | 62.08 ms | 0.983 ms | 0.920 ms |
