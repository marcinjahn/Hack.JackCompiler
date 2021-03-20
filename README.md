# nand2tetris Jack Compiler

This is a .NET C# implementation of the nand2tetris Hack Platform Jack Compiler.
It takes `.jack` (Jack programming language) file(s) as an input and turns them
into `.vm` (Hack Virtual Machine language) file(s).

**This is a work in progress, project is not yet finished!**

## Projects

The solution consists of 2 projects:

- **Hack.JackCompiler.Lib** - all services and models that power the solution
- **Hack.JackCompiler.Lib.Tests** - unit tests of a subset of classes that are
  included in *Hack.JackCompiler.Lib*

The code is written in an object-oriented way, so various responsibilities of
the solution are enclosed in their own classes.