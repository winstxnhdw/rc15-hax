# rc15-hax

`rc15-hax` is a developer-friendly windows-only no-hook internal cheat for the Robocraft 2015 project.

## Requirements

- Windows 10
- Microsoft .NET SDK 6.0.2
- Microsoft .NET Framework 4.8
- C# 10.0

## Installation

Recursively clone the repository

```bash
git clone --recursive https://github.com/winstxnhdw/rc15-hax.git
```

Build and install the dependencies

```bash
sh requirements.sh
```

If you are planning to do development, use the `--dev` flag. This will compile dnSpy on top of the default requirements.

```bash
sh requirements.sh --dev
```

## Usage

Download [Robocraft 2015](https://drive.google.com/file/d/1T3i7x2OC0GuELEWjSt_fuWAge-xAsZEi/view?usp=sharing) and register an account [here](https://phoenixsoftworks.net/register.html). Read the [wiki](https://github.com/winstxnhdw/rc15-hax/wiki) to learn about its features.

```bash
sh launch.sh
```

## Development

> During development, never use the `System` and `System.Linq` namespace. RC15 uses an old and incompatible version of `mscorlib` which is incompatible with .NET 4.8.

Run the compiled dnSpy.exe

```bash
dnSpy48/dnSpy.exe &
```

Use the `--dev` flag on `launch.sh` to build before injecting.

```bash
sh launch.sh --dev
```

## Motivations

### Zero Executables

The repository contains zero executable to maintain transparency and assure the safe of the cheat—unlike the sketchy binaries that are found on forums like UnknownCheats/MPGH.

### No Visual Studio

Most cheats on GitHub, like [MuckInternal](https://github.com/win32kbase/MuckInternal), contain a lot of redundant boilerplate that Visual Studio generates, bloating the codebase and ruining the user experience—requiring the user to install Visual Studio just to build the source code. On the otherhand, this repository can be developed on/used completely via the command line (or more specifically Git bash).
