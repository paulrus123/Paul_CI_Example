using UnityEngine;
using UnityEditor;
using System;

public class PaulBuildCommand : MonoBehaviour
{
    static string[] scenes = { "Assets/Scenes/SampleScene.unity" };

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
        var buildPath = GetArgument("customBuildPath");
        var buildTarget = GetBuildTarget();
        var buildName = GetArgument("customBuildName");
        if(buildPath==null || buildTarget==null || buildName == null)
        {
            throw new Exception("Exception: Name path or target is missing! ");
        }

        var buildReport = BuildPipeline.BuildPlayer(scenes, buildPath + buildName, buildTarget, BuildOptions.None);
    }
}