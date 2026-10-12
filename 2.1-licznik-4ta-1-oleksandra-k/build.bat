@echo off
chcp 65001 >nul
echo =======================================
echo Kompilacja: Licznik Klikniec
echo =======================================

set CSC=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe
if not exist "%CSC%" set CSC=C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe

set WPF_DIR=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\WPF
if not exist "%WPF_DIR%" set WPF_DIR=C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF

if not exist "%CSC%" (
    echo [BLAD] Nie znaleziono kompilatora csc.exe w folderze .NET Framework!
    pause
    exit /b 1
)

echo Kompilowanie Program.cs -> LicznikKlikniec.exe ...
"%CSC%" /nologo /target:winexe /out:LicznikKlikniec.exe /r:System.dll /r:System.Core.dll /r:System.Xaml.dll /r:"%WPF_DIR%\WindowsBase.dll" /r:"%WPF_DIR%\PresentationCore.dll" /r:"%WPF_DIR%\PresentationFramework.dll" Program.cs

if %errorlevel% equ 0 (
    echo.
    echo [SUKCES] Aplikacja zostala pomyslnie skompilowana!
    echo Utworzono: LicznikKlikniec.exe
) else (
    echo.
    echo [BLAD] Kompilacja nie powiodla sie.
)
