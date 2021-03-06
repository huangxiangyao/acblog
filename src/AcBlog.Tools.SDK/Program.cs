﻿using AcBlog.SDK;
using AcBlog.Tools.SDK.Commands;
using AcBlog.Tools.SDK.Models;
using System;
using System.CommandLine;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcBlog.Tools.SDK
{
    class Program
    {
        public static Workspace Workspace { get; private set; } = new Workspace(new DirectoryInfo(Environment.CurrentDirectory));

        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("AcBlog SDK for command-line.");

            rootCommand.AddCommand(new InitCommand().Build());
            rootCommand.AddCommand(new ConnectCommand().Build());
            rootCommand.AddCommand(new LoginCommand().Build());
            rootCommand.AddCommand(new LogoutCommand().Build());
            rootCommand.AddCommand(new ListCommand().Build());
            rootCommand.AddCommand(new NewCommand().Build());
            rootCommand.AddCommand(new PullCommand().Build());
            rootCommand.AddCommand(new PushCommand().Build());
            rootCommand.AddCommand(new FetchCommand().Build());

            await Workspace.Load();

            return await rootCommand.InvokeAsync(args);
        }
    }
}
