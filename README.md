# rc15-hax

`rc15-hax` is a developer-friendly Windows-only no-hook internal cheat for the Robocraft 2015 project.

<div align="center">
    <img src="resources/showcase.gif" />
</div>

## Requirements

- Windows 10/11
- [Microsoft .NET SDK 6.0.2](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.300-windows-x64-installer)
- [Microsoft .NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-developer-pack-offline-installer)
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

Download [Robocraft 2015](https://drive.google.com/file/d/1T3i7x2OC0GuELEWjSt_fuWAge-xAsZEi/view?usp=sharing) and register an account [here](https://phoenixsoftworks.net/register.html). Run the following command on Git bash when you have logged into the game. Read the [wiki](https://github.com/winstxnhdw/rc15-hax/wiki/Features) to learn about its features.

```bash
sh launch.sh
```

## Development

>**Note**: If you plan to do development, whether on your own or to contribute, please look at the [Development Guidelines](https://github.com/winstxnhdw/rc15-hax/wiki/Development-Guidelines) in the wiki to learn about some of the pervasive issues.

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

Most cheats on GitHub, like [MuckInternal](https://github.com/win32kbase/MuckInternal), contain a lot of redundant boilerplate that Visual Studio generates—bloating the codebase and ruining the developing experience—requiring the user to install Visual Studio just to build the source code. On the otherhand, this repository can be developed on/used completely via the command line (or more specifically Git bash).

## Featured

Have a funny video of you using this cheat that you are willing to share? Create a GIF and submit a pull request to this repository! Want to stay anonymous? Hit me up on Telegram.

<div align="center">
    <img src="resources/phantom.gif" />
    <p align="center">By courtesy of @suggondeez</p>
</div>

<div align="center">
    <img src="resources/Dima81.gif" />
    <p align="center">By courtesy of @Dima81</p>
</div>
