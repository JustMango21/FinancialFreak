<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <RootNamespace></RootNamespace>
    <NoWarn>CS0649;CS0169</NoWarn>
    <NukeRootDirectory>..</NukeRootDirectory>
    <NukeScriptDirectory>..</NukeScriptDirectory>
    <NukeTelemetryVersion>1</NukeTelemetryVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Nuke.Common" Version="6.2.1" />
  </ItemGroup>

  <ItemGroup>
    <None Remove="..\nuget.config" />
  </ItemGroup>

</Project>
