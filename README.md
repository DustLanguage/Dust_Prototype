# Dust [![Gitter room](https://badges.gitter.im/DustLanguage.png)](https://gitter.im/DustLanguage)

Dust is an open source programming language written in C# with .NET Core.

## Introduction

Dust is a simple and easy-to-understand programming language inspired by many other programming languages such as C#, Go, Rust, Swift, Elixir, F#, Dart and so on, but with a twist.
Type system is also in the works.

Contributions are more than welcome even if you don't have any experience
in programming language design, we're all here to learn. To learn more, see [Contributing](#contributing).

If you have any more questions regarding contributing, syntax or anything
else, please ask away in our [Gitter room](https://gitter.im/DustLanguage).

## Syntax

Planned syntax for a console hello world:
```c
let fn main() {
 println("Hello World") // Print text and add a new line.
 Println("from Dust!")
}
```
Properties (variables):
```c
let immutable = 0 + 1 + 2 + 3 // Immutable property with initializer
let mut mutable = 3 + 2 + 1 + 0 // Mutable property with initializer
```
Functions:
```c
let fn function(mut mutableParam, immutableParam) {// A function with a mutable and immutable parameter. Returns their sum
 mutableParam = 12 // Mutate the mutable parameter
     let result = mutableParam + immutableParam // Add them and store the sum into 'result' property
     return result // Return the result (sum)
}
```

More examples will be added soon but for now you can take a look at [this](
https://pastebin.com/hhiV7wc7) obsolete syntax mock just to get an overview of other planned features and concepts (not the syntax). 

If you have any suggestions please open an issue or send a message in our [Gitter room](https://gitter.im/DustLanguage).

## Contributing

As I said above contributions are more than welcome even if you don't have
any experience in programming language design. If you're willing to contribute, take a look at [these](https://github.com/DustLanguage/Dust/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22) issues.
