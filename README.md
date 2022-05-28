# rc15-hax

Internal cheats for Robocraft 2015. Most importantly, no [Visual Studio](https://en.wiktionary.org/wiki/dog_shit) required.

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

Download [Robocraft 2015](https://drive.google.com/file/d/1T3i7x2OC0GuELEWjSt_fuWAge-xAsZEi/view?usp=sharing) and register an account [here](https://phoenixsoftworks.net/register.html). Finally, run the following bash script to inject our assembly into the game. `Space + Esc` to open the menu.

```bash
sh launch.sh
```

## Development

> During development, never use the `System` namespace. RC15 uses an old and incompatible version of `mscorlib` which is incompatible with .NET 4.8.

Run the compiled dnSpy.exe

```bash
dnSpy48/dnSpy.exe &
```

Use the `--dev` flag on `launch.sh` to build before injecting.

```bash
sh launch.sh --dev
```
