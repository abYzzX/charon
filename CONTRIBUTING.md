# Contributing to Charon Game Engine

Thank you for considering contributing to Charon! This document provides guidelines and information for contributors.

## 🎯 Philosophy

Charon is built around three core principles:

1. **Modularity**: Everything is a module. Backends are swappable, features are composable.
2. **Clean Abstractions**: Public interfaces hide implementation details. Users work with `ISoundEffect`, not `SdlSoundEffect`.
3. **Convention over Configuration**: Smart defaults, but full control when needed.

## 🏗️ Architecture Overview

### Module System

Charon uses a module-based architecture where each module is self-contained:

```
Abyzz.Charon.Audio/              # Public interfaces
├── ISoundEffect.cs
├── IMusicPlayer.cs
└── IAudioMixer.cs

Abyzz.Charon.Audio.Sdl3Mixer/    # SDL3 implementation
├── SdlSoundEffect.cs            # internal
├── SdlMusicPlayer.cs            # internal
└── CharonSdl3MixerModule.cs     # DI registration
```

**Key Rules:**
- ✅ Interfaces are `public` in abstraction projects (`Abyzz.Charon.Audio`)
- ✅ Implementations are `internal` in backend projects (`Abyzz.Charon.Audio.Sdl3Mixer`)
- ✅ Users never directly instantiate implementations
- ✅ Dependency Injection provides implementations via interfaces

### Dependency Injection

All services are registered through modules:

## 🔧 Development Setup

### Prerequisites

- **.NET 9.0 SDK** or later
- **C# 13** support
- **JetBrains Rider** or **Visual Studio 2022+** (recommended)
- **Git** for version control

### Getting Started

1. **Fork the repository**
   ```bash
   git clone https://github.com/abYzzX/charon.git
   cd charon
   ```

2. **Build the solution**
   ```bash
   cd dotnet
   dotnet build
   ```

3. **Run the demo**
   ```bash
   dotnet run --project app/Abyzz.Charon.Demo
   ```

## 📝 Contribution Guidelines

### Code Style

- **Follow C# conventions**: PascalCase for public members, camelCase for private fields with `_` prefix
- **Use modern C# features**: Records, pattern matching, file-scoped namespaces, collection expressions
- **Keep interfaces clean**: Only expose what users need
- **Write XML documentation**: All public APIs must have XML docs

Example:
```csharp
/// <summary>
/// Plays a sound effect with optional looping.
/// </summary>
/// <param name="loops">Number of times to loop. 1 = play once, -1 = infinite.</param>
void Play(int loops = 1);
```

### Adding a New Backend

Want to add OpenAL support alongside SDL3? Follow this pattern:

1. **Create abstraction interfaces** (if not exist)
   ```
   Abyzz.Charon.Audio/
   └── ISoundEffect.cs
   ```

2. **Create backend implementation**
   ```
   Abyzz.Charon.Audio.OpenAl/
   ├── OpenAlSoundEffect.cs      # internal
   └── CharonOpenAlModule.cs
   ```

3. **Register in DI**
   ```csharp
   services.AddSingleton<IAudioMixer, OpenAlMixer>();
   ```

4. **Users swap backends by changing module reference** - no code changes required!

### Adding a New Feature

1. **Design the interface first** - what should the public API look like?
2. **Implement for one backend** - usually SDL3
3. **Write tests** - ensure it works as expected
4. **Document it** - XML docs + README updates

### Pull Request Process

1. **Create a feature branch**
   ```bash
   git checkout -b feature/audio-spatial-positioning
   ```

2. **Make your changes**
   - Follow code style guidelines
   - Add tests where applicable
   - Update documentation

3. **Test thoroughly**
   ```bash
   dotnet build
   dotnet test
   ```

4. **Commit with clear messages**
   ```bash
   git commit -m "feat(audio): add spatial audio positioning support"
   ```

5. **Push and create PR**
   ```bash
   git push origin feature/audio-spatial-positioning
   ```

### Commit Message Format

We follow [Conventional Commits](https://www.conventionalcommits.org/):

```
<type>(<scope>): <description>

[optional body]
[optional footer]
```

**Types:**
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `refactor`: Code refactoring
- `perf`: Performance improvements
- `test`: Adding tests
- `chore`: Build process or tooling changes

**Examples:**
```
feat(audio): add music fade-in/fade-out support
fix(ecs): resolve query update race condition
docs(readme): update installation instructions
refactor(rendering): consolidate batch systems
```

## 🧪 Testing

### Running Tests

```bash
dotnet test
```

### Writing Tests

- Place tests in corresponding `*.Tests` projects
- Use xUnit framework
- Mock dependencies with interfaces
- Test both happy paths and edge cases

## 📚 Documentation

### Code Documentation

- All public APIs require XML documentation
- Use `<summary>`, `<param>`, `<returns>`, `<exception>` tags
- Provide usage examples in `<example>` tags for complex APIs

### README Updates

When adding major features:
1. Update feature list in README.md
2. Add usage examples
3. Update architecture diagrams if applicable

## 🐛 Reporting Issues

### Bug Reports

Include:
- **Description**: What happened vs. what you expected
- **Steps to Reproduce**: Minimal code example
- **Environment**: OS, .NET version, hardware
- **Logs/Screenshots**: Any relevant error messages

### Feature Requests

Include:
- **Use Case**: What problem does this solve?
- **Proposed API**: How should it look to users?
- **Alternatives**: What other approaches did you consider?

## 💬 Community

- **GitHub Issues**: Bug reports and feature requests
- **Discussions**: General questions and ideas
- **Pull Requests**: Code contributions

## 📜 Code of Conduct

Be respectful, inclusive, and constructive. We're all here to build something great together.

## 🎓 Learning Resources

- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [SDL3 Wiki](https://wiki.libsdl.org/SDL3/)
- [Game Programming Patterns](https://gameprogrammingpatterns.com/)

## 📄 License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

**Thank you for contributing to Charon!** 🎮✨
