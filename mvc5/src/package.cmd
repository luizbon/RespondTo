@rem Add path to MSBuild Binaries
@if exist "%ProgramFiles%\MSBuild\14.0\bin" set PATH=%ProgramFiles%\MSBuild\14.0\bin;%PATH%
@if exist "%ProgramFiles(x86)%\MSBuild\14.0\bin" set PATH=%ProgramFiles(x86)%\MSBuild\14.0\bin;%PATH%

msbuild build.proj /t:MovePackages