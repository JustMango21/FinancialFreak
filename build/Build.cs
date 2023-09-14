using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution]
    readonly Solution Solution;

    readonly AbsolutePath BinFolder = RootDirectory / "bin";

    Target Clean => _ => _
        .Executes(() =>
        {
            FileSystemTasks.EnsureCleanDirectory(BinFolder);
            DotNetClean(_ => _
            .SetProject(Solution)
            );
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => s
           .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
           .SetProjectFile(Solution)
           .SetConfiguration(Configuration)
           .EnableNoRestore());
        });

}
