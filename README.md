# rc15-hax

![main.yml](https://github.com/winstxnhdw/rc15-hax/actions/workflows/main.yml/badge.svg)

<p align="center"><b>World's first open-source internal cheat for Robocraft</b></p>

<div align="center">
    <img src="https://raw.githubusercontent.com/wiki/winstxnhdw/rc15-hax/resources/showcase.gif" />
</div>

## Abstract

`rc15-hax` is a feature-rich pure internal cheat for the [Robocraft 2015 project](https://github.com/phoenix-softworks/RC15-Launcher-Public) by [Phoenix Softworks](https://github.com/phoenix-softworks). Robocraft is an online vehicular combat game built with Unity Mono. This cheat is aimed at developers that absolutely despise the Visual Studio ecosystem, and since RC15 is Windows-only, so is the cheat. If you happen to not have any developing experience, installing this cheat may pose as a challenge—do try your best anyways!

## Requirements

- Windows 10 or higher
- [Microsoft .NET SDK](https://dotnet.microsoft.com/en-us/download)
- [Robocraft 2015 R4.1](https://drive.google.com/drive/folders/1k3W2OyI84EgYzKfXWOZ_vaffNR01taYn)

## Installation

If you are on Windows 11, follow the instructions [here](https://github.com/winstxnhdw/rc15-hax/wiki) instead. Otherwise, recursively clone this repository.

```bash
git clone --recursive https://github.com/winstxnhdw/rc15-hax.git
```

You can now build and install the dependencies by executing `requirements.bat`. It is not required to build dnSpy if you do not plan on doing any [development](#Development).

## Usage

Download [Robocraft 2015](https://drive.google.com/file/d/1T3i7x2OC0GuELEWjSt_fuWAge-xAsZEi/view?usp=sharing) and register an account [here](https://phoenixsoftworks.net/register.html). Execute `launch.bat` when you have entered the game lobby. Read the [wiki](https://github.com/winstxnhdw/rc15-hax/wiki/Features) to learn about its features.

## Development

[dnSpy](https://github.com/dnSpy/dnSpy) is included as a submodule when you recursively clone this directory. If you plan to contribute to the development, dnSpy is an invaluable tool for browsing the Robocraft source code. You may compile dnSpy by executing `requirements.bat` and entering `Y` when the prompt to build dnSpy appears. You can then run the compiled dnSpy executable.

```bash
dnSpy/dnSpy.exe &
```

## Motivations

### Zero Executables

The repository contains no executables. This assures the user that whatever that has been built originates from the repository and its submodules alone. Even with the best malware scanners, the best way to check for malware is with your own eyes. This level of transparency ensures the safety of the cheat, unlike the sketchy binaries that are found on forums like UnknownCheats/MPGH.

### No Visual Studio

Most cheats on GitHub, like [MuckInternal](https://github.com/win32kbase/MuckInternal), contain a lot of redundant boilerplate that Visual Studio generates—bloating the codebase and ruining the developer experience—requiring the user to install Visual Studio just to build the source code. On the otherhand, this cheat can easily be initialised by executing the `launch.bat` file.

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
