using System.Runtime.CompilerServices;
using Kutokasta.Console.IO;
using Kutokasta.Console.Learning;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("Kutokasta.Console.Tests")]
namespace Kutokasta.Console
{
    internal class Program
    {
        private static void Main()
        {
            var serviceCollection = GetServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var learningDispatcher = serviceProvider.GetService<ILearningDispatcher>();
            learningDispatcher.ProceedAllLearningSets();
        }

        private static IServiceCollection GetServiceCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IConsoleWrapper, ConsoleWrapper>();
            serviceCollection.AddTransient<IDirectoryInfoWrapper, DirectoryInfoWrapper>();
            serviceCollection.AddTransient<IFileWrapper, FileWrapper>();
            serviceCollection.AddTransient<ILearningDispatcher, LearningDispatcher>();
            serviceCollection.AddTransient<IResultDisplayer, ResultDisplayer>();
            serviceCollection.AddTransient<ILearningSetReader, LearningSetReader>();
            serviceCollection.AddTransient<IWageFinder, WageFinder>();
            serviceCollection.AddTransient<IWageLimitProvider, WageLimitProvider>();

            return serviceCollection;
        }
    }
}