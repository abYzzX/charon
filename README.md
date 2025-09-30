<div style="text-align: center; padding: 2em; align-items: center;">
  <img src="./assets/logo.png" width="200" height="200"/>
</div>

# Charon Game Engine

A modern, cross-platform 2D game engine built with C# and .NET 9.0, powered by SDL3 for hardware-accelerated graphics.

## Overview

Charon is designed to provide a clean, modular architecture for 2D game development. It combines the performance benefits of SDL3 with the productivity advantages of modern .NET, offering developers an intuitive API for creating cross-platform games.

## Key Features

### Modern Architecture
- Built on .NET 9.0 and C# 13.0 with the latest language features
- Clean separation of concerns with dependency injection using Autofac
- Modular service-oriented design for extensibility
- Memory-safe unsafe code for performance-critical operations

### Hardware-Accelerated Graphics
- SDL3 integration for cross-platform rendering
- Support for OpenGL and Vulkan graphics APIs
- Efficient 2D rendering with hardware acceleration
- Advanced geometry utilities including convex polygon triangulation

### Developer Experience
- Fluent API design for intuitive development
- Comprehensive configuration system without code changes
- Built-in debugging and logging support
- Hot reload capabilities through .NET ecosystem

### Cross-Platform Support
- Write once, run everywhere philosophy
- Native support for Windows, Linux, and macOS
- Consistent API across all platforms
- No platform-specific code required

## Quick Start

### Installation

Add the Charon packages to your project:

```xml
<PackageReference Include="Abyzz.Charon.Core" Version="1.0.0" />
<PackageReference Include="Abyzz.Charon.SDL3" Version="1.0.0" />
```

### Basic Game Setup

```csharp
using Charon;
using Charon.Extensions;

class Program
{
    static void Main()
    {
        var builder = new CharonGameBuilder()
            .AddFpsCounter()
            .UseMainScene<MyGameScene>();
        
        var game = builder.Build<MyGameModule>();
        game.Initialize();
        game.Run();
    }
}
```

### Creating a Scene

```csharp
public class MyGameScene : IScene
{
    private IRenderBatch _renderBatch;
    
    public required IKeyboardInputService KeyboardInputService { private get; init; }
    public required ICharonGame Game { private get; init; }
    public required Func<IRenderBatch> RenderBatchFactory { private get; init; }
    
    public void Initialize()
    {
        _renderBatch = RenderBatchFactory();
    }

    public void Update(IGameTime gameTime)
    {
        if (KeyboardInputService.IsKeyDown(Keys.KeyEscape))
        {
            Game.Shutdown();
        }
    }

    public void Render()
    {
        using (_renderBatch.Begin())
        {
            _renderBatch.DrawRectangle(10, 10, 100, 100, Color.Red);
        }
    }

    public void Dispose()
    {
        // Cleanup resources
    }
}
```

## Core Concepts

### Game Loop
Charon implements a classic game loop with precise frame rate control:
- Event handling for input and system events
- Update phase for game logic
- Render phase for drawing operations
- Automatic resource management and cleanup

### Service System
The engine uses a service-oriented architecture where game functionality is organized into services:
- Global services that run throughout the game lifecycle
- Configurable execution order for services
- Automatic dependency injection and lifecycle management

### Rendering Pipeline
The rendering system provides:
- Immediate mode rendering with render batches
- Support for primitive shapes (points, lines, polygons)
- Filled polygon rendering with automatic triangulation
- Matrix transformations for camera systems and projections

### Configuration
Engine behavior is controlled through a comprehensive settings system:
- Window configuration (size, fullscreen, resizable)
- Graphics settings (VSync, FPS limiting, clear color)
- Platform features (OpenGL, Vulkan support)
- Input handling options

## Project Structure

```
src/
├── Abyzz.Charon/                    # Core engine functionality
├── Abyzz.Charon.SDL3/               # SDL3 platform implementation
├── Abyzz.Charon.Modularity/         # Module system
└── Abyzz.Charon.Shared/             # Shared utilities

app/
└── Abyzz.Charon.Demo/               # Demo application
```

## Performance Characteristics

- **Memory Management**: Minimal allocations in hot paths with object pooling
- **Unsafe Optimizations**: Direct memory access for SDL operations
- **Hardware Acceleration**: Full GPU utilization through SDL3
- **Efficient Geometry**: Optimized algorithms for 2D math operations

## Extensibility

Charon is designed for extensibility:
- **Custom Services**: Implement `IGlobalService` for game-specific functionality
- **Module System**: Package related functionality into reusable modules
- **Rendering Extensions**: Add custom shapes and rendering primitives
- **Input Extensions**: Support for additional input devices and methods

## Requirements

- .NET 9.0 or later
- SDL3 runtime libraries (automatically managed via NuGet)
- Graphics drivers with OpenGL 3.3+ or Vulkan support

## Supported Platforms

- Windows 10/11 (x64, ARM64)
- Linux (x64, ARM64)
- macOS (x64, ARM64)

## Contributing

Charon welcomes contributions from the community. Whether you're fixing bugs, adding features, or improving documentation, your help is appreciated.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

## Acknowledgments

- SDL3 development team for the excellent multimedia library
- .NET team for the modern runtime and language features
- Autofac team for the dependency injection container
