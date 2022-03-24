$currentPath = Split-Path -parent $MyInvocation.MyCommand.Definition

$balzorOutputPath = 'blazor-app\.output'
$reactPublicOutput = 'react-app\public'

Set-Location $currentPath

Remove-Item $balzorOutputPath -Recurse -ErrorAction Ignore
Remove-Item (Join-Path -Path $reactPublicOutput -ChildPath '_framework') -Recurse -ErrorAction Ignore

dotnet publish 'blazor-app\BlazorApp.sln' --configuration Release --output $balzorOutputPath

Copy-Item -Path (Join-Path -Path $balzorOutputPath -ChildPath 'wwwroot\_framework') -Destination (Join-Path -Path $reactPublicOutput -ChildPath '_framework') -Recurse -Verbose

Set-Location (Join-Path -Path $currentPath -ChildPath 'react-app')

npm update

react-scripts start