# nand2tetris Jack Compiler

This is a .NET C# implementation of the nand2tetris Hack Platform Jack Compiler.
It takes `.jack` (Jack programming language) file(s) as an input and turns them
into `.vm` (Hack Virtual Machine language) file(s).

**This is a work in progress, project is not yet finished!**

## Projects

The solution consists of 4 projects:

- **Hack.JackCompiler.Lib** - all services and models that power the solution
- **Hack.JackCompiler.Lib.Tests** - unit tests of a subset of classes that are
  included in *Hack.JackCompiler.Lib*
- **Hack.JackCompiler.XmlUtilities** - a class library that contains a
  `SimpleXmlSerializer` to generate XML structure of Jack parse tree. It
  contains an extension method `ToXml()` for `IElement`.
- **Hack.JackCompiler.CLI** - a Console application that runs the `JackCompiler`,
  with proper input/output setup.

The code is written in an object-oriented way, so various responsibilities of
the solution are enclosed in their own classes.
