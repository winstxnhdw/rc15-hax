# rc15-hax

<p align="center"><b>World's first open-source internal cheat for Robocraft</b></p>

<div align="center">
    <img src="https://raw.githubusercontent.com/wiki/winstxnhdw/rc15-hax/resources/showcase.gif" />
</div>

## Abstract

`rc15-hax` is a pure internal cheat for the [Robocraft 2015 project](https://github.com/phoenix-softworks/RC15-Launcher-Public) by [Phoenix Softworks](https://github.com/phoenix-softworks). It is aimed at developers that absolutely despise the Visual Studio ecosystem, and since RC15 is Windows-only, so is the cheat. Currently, there is no code detouring, and so features, although rich, are still somewhat limited, but feel free to contribute!

## Requirements

- Any Windows platform with [Docker](https://docs.docker.com/desktop/windows/install/) installed
- [Git Bash](https://git-scm.com/download/win)
- [Microsoft .NET SDK](https://dotnet.microsoft.com/en-us/download)

## Installation

If you are on Windows 11, follow the instructions [here](https://github.com/winstxnhdw/rc15-hax/wiki) instead. Otherwise, recursively clone this repository.

```bash
git clone --recursive https://github.com/winstxnhdw/rc15-hax.git
```

Build and install the dependencies by executing `requirements.bat`. If you are planning to do development, you can execute teh following shell script with the `--dev` flag. This will compile dnSpy on top of the default requirements.

```bash
sh requirements.sh --dev
```

## Usage

Download [Robocraft 2015](https://drive.google.com/file/d/1T3i7x2OC0GuELEWjSt_fuWAge-xAsZEi/view?usp=sharing) and register an account [here](https://phoenixsoftworks.net/register.html). Execute `launch.bat` when you have entered the game lobby. Read the [wiki](https://github.com/winstxnhdw/rc15-hax/wiki/Features) to learn about its features.

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

The repository contains no executables. This assures the user that whatever that has been built originates from the repository and its submodules alone. Even with the best malware scanners, the best way to check for malware is with your own eyes. This level of transparency ensures the safety of the cheat, unlike the sketchy binaries that are found on forums like UnknownCheats/MPGH.

### No Visual Studio

Most cheats on GitHub, like [MuckInternal](https://github.com/win32kbase/MuckInternal), contain a lot of redundant boilerplate that Visual Studio generates—bloating the codebase and ruining the developer experience—requiring the user to install Visual Studio just to build the source code. On the otherhand, this repository can be used solely with a few commands 

## Featured

Have a funny video of you using this cheat that you are willing to share? Create a GIF and submit a pull request to this repository! Want to stay anonymous? Hit me up on Telegram.

<div align="center">
    <img src="https://raw.githubusercontent.com/wiki/winstxnhdw/rc15-hax/resources/phantom.gif" />
    <p align="center">By courtesy of @suggondeez</p>
</div>

<div align="center">
    <img src="https://raw.githubusercontent.com/wiki/winstxnhdw/rc15-hax/resources/Dima81.gif" />
    <p align="center">By courtesy of @Dima81#2505</p>
</div>

<div align="center">
    <img src="https://raw.githubusercontent.com/wiki/winstxnhdw/rc15-hax/resources/Joey_Kuruma.gif" />
    <p align="center">By courtesy of @JoeyK#5858</p>
</div>
