Set-StrictMode -Version latest
$ErrorActionPreference = "Stop"


# Taken from psake https://github.com/psake/psake

<#
.SYNOPSIS
  This is a helper function that runs a scriptblock and checks the PS variable $lastexitcode
  to see if an error occcured. If an error is detected then an exception is thrown.
  This function allows you to run command-line programs without having to
  explicitly check the $lastexitcode variable.
.EXAMPLE
  exec { svn info $repository_trunk } "Error executing SVN. Please verify SVN command-line client is installed"
#>
function Exec
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
        [Parameter(Position=1,Mandatory=0)][string]$errorMessage = ("Error executing command {0}" -f $cmd)
    )
    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

set-location .\src\

$version = ($env:APPVEYOR_BUILD_VERSION)
Write-Output ("Version " + $version)

exec { & dotnet restore }

exec { & dotnet build Druid.Net.sln -c Release --version-suffix=$version -v q /nologo }
exec { & dotnet pack Druid.Net\Druid.Net.csproj -c Release -o ..\..\artifacts --include-symbols --no-build --version-suffix=$version }
