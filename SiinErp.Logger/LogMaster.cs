#region Usings
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
#endregion

namespace SiinErp.Logger
{
    /// <summary>
    /// A static class that emulates defualt log4net LogManager static class.
    /// The difference is that you can get various loggers istances based from an args.
    /// LogMaster will create a different logger repository for each new arg it will receive.
    /// </summary>
    public static class LogMaster
    {
        #region Const
        private const string RollingFileAppenderNameDefault = "Rolling";
        #endregion

        #region Constructors
        static LogMaster()
        {
        }
        #endregion

        #region Public Methods
        public static ILog GetLogger(string name, string path)
        {
            //It will create a repository for each different arg it will receive
            var repositoryName = name;

            ILoggerRepository repository = null;

            var repositories = LogManager.GetAllRepositories();
            foreach (var loggerRepository in repositories)
            {
                if (loggerRepository.Name.Equals(repositoryName))
                {
                    repository = loggerRepository;
                    break;
                }
            }

            if (repository == null)
            {
                //Create a new repository
                repository = LogManager.CreateRepository(repositoryName);

                Hierarchy hierarchy = (Hierarchy)repository;
                hierarchy.Root.Additivity = false;

                //Add appenders you need: here I need a rolling file and a memoryappender
                var rollingAppender = GetRollingAppender(repositoryName, path);
                hierarchy.Root.AddAppender(rollingAppender);

                BasicConfigurator.Configure(repository);
            }

            //Returns a logger from a particular repository;
            //Logger with same name but different repository will log using different appenders
            return LogManager.GetLogger(repositoryName, name);
        }
        #endregion

        #region Private Methods
        private static IAppender GetRollingAppender(string name, string path)
        {
            var level = Level.All;

            var rollingFileAppenderLayout = new PatternLayout("%date{HH:mm:ss,fff}|T%2thread|%25.25logger|%5.5level| %message%newline");
            rollingFileAppenderLayout.ActivateOptions();

            var rollingFileAppenderName = string.Format("{0}{1}", RollingFileAppenderNameDefault, name);

            var rollingFileAppender = new RollingFileAppender
            {
                Name = rollingFileAppenderName,
                Threshold = level,
                CountDirection = 0,
                AppendToFile = true,
                LockingModel = new FileAppender.MinimalLock(),
                StaticLogFileName = true,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                DatePattern = ".yyyy-MM-dd'.log'",
                Layout = rollingFileAppenderLayout,
                File = string.Format("{0}{1}.{2}.log", path, name, DateTime.Now.ToString("yyyyMMdd"))
            };
            rollingFileAppender.ActivateOptions();

            return rollingFileAppender;
        }
        #endregion
    }
}