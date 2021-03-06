﻿//----------------------------------------------------------------------- 
// <copyright file="pMixinsOnItemSaveCodeGenerator.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Saturday, May 3, 2014 10:52:59 PM</date> 
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

using System;
using System.Linq;
using System.Reflection;
using CopaceticSoftware.CodeGenerator.StarterKit;
using CopaceticSoftware.CodeGenerator.StarterKit.Extensions;
using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure;
using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure.Caching;
using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure.IO;
using CopaceticSoftware.CodeGenerator.StarterKit.Logging;
using CopaceticSoftware.CodeGenerator.StarterKit.Threading;
using CopaceticSoftware.pMixins.VisualStudio.Extensions;
using CopaceticSoftware.pMixins.VisualStudio.IO;
using log4net;

namespace CopaceticSoftware.pMixins.VisualStudio.CodeGenerators
{
    /// <summary>
    /// Listens for <see cref="IVisualStudioEventProxy.OnProjectItemSaved"/>
    /// events.  If the save event is for a file containing a Mixin,
    /// this class regenerates the code behind for all Targets using
    /// the Mixins
    /// </summary>
    /// <remarks>
    /// Should be singleton.
    /// </remarks>
    public class pMixinsOnItemSaveCodeGenerator
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IVisualStudioCodeGenerator _visualStudioCodeGenerator;
        private readonly ICodeGeneratorContextFactory _codeGeneratorContextFactory;
        private readonly IpMixinsCodeGeneratorResponseFileWriter _responseFileWriter;
        private readonly ITaskFactory _taskFactory;
        private readonly ICodeGeneratorDependencyManager _codeGeneratorDependencyManager;

        public pMixinsOnItemSaveCodeGenerator(IVisualStudioEventProxy visualStudioEventProxy, IVisualStudioCodeGenerator visualStudioCodeGenerator, ICodeGeneratorContextFactory codeGeneratorContextFactory, IpMixinsCodeGeneratorResponseFileWriter responseFileWriter, ITaskFactory taskFactory, ICodeGeneratorDependencyManager codeGeneratorDependencyManager)
        {
            _visualStudioCodeGenerator = visualStudioCodeGenerator;
            _codeGeneratorContextFactory = codeGeneratorContextFactory;
            _responseFileWriter = responseFileWriter;
            _taskFactory = taskFactory;
            _codeGeneratorDependencyManager = codeGeneratorDependencyManager;

            visualStudioEventProxy.OnProjectItemSaveComplete += (s,a) => 
                GenerateCode(a.ClassFullPath, "ProjectItemSaveComplete");
            
            //Generate code on a Project Item Added incase it's an existing file.
            visualStudioEventProxy.OnProjectItemAdded += (s, a) => 
                GenerateCode(a.ClassFullPath, "OnProjectItemAdded");
        }

        private void GenerateCode(FilePath classFullPath, string eventName)
        {
            _taskFactory.StartNew(() =>
            {
                pMixinsOnSolutionOpenCodeGenerator.OnSolutionOpeningTask.Wait();

                using (new LoggingActivity("GenerateCode - " + eventName + " -- " + classFullPath))
                try
                {
                    //Generate code for the file saved
                    var currentFileContext =
                        _codeGeneratorContextFactory.GenerateContext(
                            s => s.GetValidPMixinFiles()
                                .Where(f => f.FileName.Equals(classFullPath)))
                            .ToArray();

                    if (currentFileContext.Length == 0)
                    {
                        _log.InfoFormat("No code will be genereated for [{0}]", classFullPath);

                        _responseFileWriter.ClearCodeBehindForSourceFile(classFullPath);
                    }
                    else
                    {
                        _visualStudioCodeGenerator
                            .GenerateCode(currentFileContext)
                            .Map(_responseFileWriter.WriteCodeGeneratorResponse);
                    }

                    //Generate code for dependencies
                    var filesToUpdate =
                        _codeGeneratorDependencyManager.GetFilesThatDependOn(classFullPath);

                    if (_log.IsDebugEnabled)
                        _log.DebugFormat("Will update [{0}]",
                            string.Join(Environment.NewLine,
                                filesToUpdate.Select(x => x.FileName)));

                    _visualStudioCodeGenerator
                        .GenerateCode(
                            _codeGeneratorContextFactory.GenerateContext(filesToUpdate))
                        .MapParallel(_responseFileWriter.WriteCodeGeneratorResponse);
                }
                catch (Exception exc)
                {
                    _log.Error("Exception in HandleProjectItemSaved", exc);
                }
            });
        }
    }
}
