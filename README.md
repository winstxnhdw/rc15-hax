# rc15-hax

Internal cheats for Robocraft 2015.

## Requirements

- Windows 10
- Microsoft .NET SDK 6.0.2
- Microsoft .NET Framework 4.8

## Installation

Recursively clone the repository

```bash
git clone --recursive https://github.com/winstxnhdw/rc15-hax.git
```

Build and install the dependencies

```bash
sh requirements.sh
```

## Usage

Download [Robocraft 2015](https://drive.google.com/file/d/1T3i7x2OC0GuELEWjSt_fuWAge-xAsZEi/view?usp=sharing) and register an account [here](https://phoenixsoftworks.net/register.html). Finally, run the following bash script to inject our assembly into the game.

```bash
sh launch.sh
```

## Development

### Testing hax

Use the `--dev` flag on `launch.sh` to build before injecting.

```bash
sh launch.sh --dev
```

### Building dnSpy

Build and publish dnSpy

```bash
sh requirements_dev.sh
```

Run dnSpy.exe

```bash
dnSpy48/dnSpy.exe &
```
