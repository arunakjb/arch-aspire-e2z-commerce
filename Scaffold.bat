@echo off
REM ============================================================
REM EF Core Scaffold for E2ZShopping (Database-First)
REM - Run this file from the solution root (E2ZShopping)
REM - Requires E2Z.DB.ORM.csproj with EF Core packages
REM - Uses DefaultConnection from localhost
REM ============================================================

cd /d "%~dp0"

REM Project that will contain DbContext and entities
set ORM_PROJECT=Services\Storage\Persistence\E2Z.DB.ORM.csproj
REM Provider and connection string name
set PROVIDER=Microsoft.EntityFrameworkCore.SqlServer
set CONNECTION_NAME=Data Source=localhost;Initial Catalog=E2ZDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;

REM Output folders (inside E2Z.DB.ORM project)
set OUTPUT_DIR=Models
set CONTEXT_DIR=Context
set CONTEXT_NAME=E2ZDbContext

echo.
echo Restoring packages for %ORM_PROJECT% ...
dotnet restore "%ORM_PROJECT%"
if %errorlevel% neq 0 (
    echo dotnet restore failed.
    pause
    exit /b %errorlevel%
)

echo.
echo Running EF Core scaffolding...
dotnet ef dbcontext scaffold "%CONNECTION_NAME%" %PROVIDER% ^
  --project "%ORM_PROJECT%" ^
  --startup-project "%ORM_PROJECT%" ^
  --output-dir "%OUTPUT_DIR%" ^
  --context-dir "%CONTEXT_DIR%" ^
  --context %CONTEXT_NAME% ^
  --use-database-names ^
  --data-annotations ^
  --force

if %errorlevel% == 0 (
    echo.
    echo Scaffolding completed successfully!
) else (
    echo.
    echo Scaffolding failed. Check the error above.
)

echo.
pause
