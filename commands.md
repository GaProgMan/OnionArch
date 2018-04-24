## Build nuget Package

    nuget pack OnionArch.nuspec

- Assumes you are in the root of the repo
- Requires `.template.config` directory to be named `template.config`
- Requires all `bin` and `obj` directories to be deleted
- Requires installation of nuget.exe
  - Including Mono on non-Windows environments

## Add to Local Template List (for testing)

    dotnet new --install .

- Assumes you are in the root of the repo
- Requires `template.config` directory to be named `.template.config`

## Remove From Local Template List (for testing)

    dotnet new --uninstall /home/jay/Code/OnionArch

- Assumes that `/home/jay/Code/OnionArch` is the absolute path for `.template.config` directory
- Requires `template.config` directory to be named `.template.config`