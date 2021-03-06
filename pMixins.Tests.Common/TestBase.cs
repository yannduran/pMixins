﻿//----------------------------------------------------------------------- 
// <copyright file="TestBase.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, October 16, 2013 1:40:05 PM</date> 
// Licensed under the Apache License, Version 2.0,
// you may not use this file except in compliance with this License.
//  
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an 'AS IS' BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright> 
//-----------------------------------------------------------------------

using System.IO;
using System.Reflection;
using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure.IO;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace CopaceticSoftware.pMixins.Tests.Common
{
    [TestFixture]
    public abstract class TestBase : SpecBase
    {
        protected static ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected static readonly FilePath solutionFile =
            new FilePath(
                    Directory.GetCurrentDirectory(),
                    @"..\..\..\pMixins.sln");

        static TestBase()
        {
            Log4NetInitializer.Initialize();
        }

    }

    public static class Log4NetInitializer
    {
        private static bool _isInitialized;

        private static readonly object _lock = new object();

        public static void Initialize()
        {
            if (_isInitialized)
                return;

            lock (_lock)
            {
                if (_isInitialized)
                    return;

                var consoleAppender = new ConsoleAppender()
                {
                    Layout = new PatternLayout(@"%date{HH:mm:ss,fff} %-5level [%logger{2}] %message%newline"),
                    Threshold = Level.Info
                };


                log4net.Config.BasicConfigurator.Configure(consoleAppender);

               _isInitialized = true;
            }
        }
    }
}
