@echo off
if not exist "LicznikKlikniec.exe" (
    echo Brak pliku LicznikKlikniec.exe. Trwa kompilacja...
    call build.bat
)
start "" "LicznikKlikniec.exe"
