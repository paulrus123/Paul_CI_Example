using UnityEngine;
using UnityEditor;
using System;

public class PaulBuildCommand : MonoBehaviour
{
    static string[] scenes = { "Assets/Scenes/Main.unity" };

    static string GetArgument(string name)
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].Contains(name))
            {
                return args[i + 1];
            }
        }
        return null;
    }

    static string GetBuildPath()
    {
        string buildPath = GetArgument("customBuildPath");
        Console.WriteLine(":: Received customBuildPath " + buildPath);
        if (buildPath == "")
        {
            throw new Exception("customBuildPath argument is missing");
        }
        return buildPath;
    }

    static BuildTarget GetBuildTarget()
    {
        string buildTargetName = GetArgument("customBuildTarget");
        Console.WriteLine(":: Received customBuildTarget " + buildTargetName);

        BuildTarget target;
        try
        {
            target = (BuildTarget)Enum.Parse(typeof(BuildTarget), buildTargetName);
        }
        catch(ArgumentException e)
        {
            Console.WriteLine(e);
            return BuildTarget.NoTarget;
        }

        return target;
    }

    static void PerformBuild()
    {
        var buildPath = GetBuildPath();
        var buildTarget = GetBuildTarget();

        var buildReport = BuildPipeline.BuildPlayer(scenes, buildPath, buildTarget, BuildOptions.None);
    }
}