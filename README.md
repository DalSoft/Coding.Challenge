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

(~30 mins) Get a naive solution working, with a verifying test and benchmarked.

This solution just reads the filestream line by line with a 64kb buffer (Rather than ReadAllLines), and uses 'words' RegEx to find the all the words.

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.17134.1246 (1803/April2018Update/Redstone4)
Intel Core i7-4750HQ CPU 2.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]     : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  DefaultJob : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT


```
|                 Method |     Mean |    Error |   StdDev |
|----------------------- |---------:|---------:|---------:|
| BenchmarkParseTextFile | 59.70 ms | 0.484 ms | 0.452 ms |

## Iteration 2

> Branch iteration-2 / master

(~20 mins) I wanted to see if loading the file into a List first, and then using Parallel foreach (making use of the TaskScheduler under the hood), performed better especially on my multi core CPU.

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.17134.1246 (1803/April2018Update/Redstone4)
Intel Core i7-4750HQ CPU 2.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]     : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  DefaultJob : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT


```
|                 Method |     Mean |    Error |   StdDev |
|----------------------- |---------:|---------:|---------:|
| BenchmarkParseTextFile | 31.03 ms | 0.360 ms | 0.337 ms |

## Improvements 

* If we were working with large files loading into a List might not be the best idea because of memory pressure. 

* Using RegEx is expensive - working directly with strings might be quicker (but harder to read). 

* Investigate using Utf8String to avoid UTF-8 to .NET string UTF-16 conversion.

* Consider using a Queue but given the example file size probably wouldn't improve the benchmark.

* Investigate Span<T> and RecyclableMemoryStreamManager (if processing large files and memory pressure was a concern).

## Bug

Both the sample bash program and this program incorrectly find 's' as a word, for example in "Michael S. Hart <hart@pobox.com>".

