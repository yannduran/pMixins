﻿//----------------------------------------------------------------------- 
// <copyright file="OnProjectItemRemovedTest.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, May 7, 2014 3:11:54 PM</date> 
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

using System.Linq;
using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure;
using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure.VisualStudioSolution;
using Ninject;
using NUnit.Framework;

namespace CopaceticSoftware.CodeGenerator.StarterKit.Tests.IntegrationTests.VisualStudioEvents
{
    public class OnProjectItemRemovedTest : VisualStudioEventTestBase
    {
        public override void MainSetup()
        {
            base.MainSetup();

            // Set Initial Solution State
            MockFileWrapperBackingStore[MockSolutionFileContents.Solution.SolutionFileName] =
                MockSolutionFileContents.Solution.SolutionFileWithMainProject;

            MockFileWrapperBackingStore[MockSolutionFileContents.MainProject.ProjectFileName] =
                MockSolutionFileContents.MainProject.ProjectFileWithBasicClass;

            MockFileWrapperBackingStore[MockSolutionFileContents.MainProject.ProjectItems.BasicClass.ClassFileName] =
                MockSolutionFileContents.MainProject.ProjectItems.BasicClass.ClassFileContents;

            //Warm Caches by loading solution.
            var solution = TestSpecificKernel.Get<ISolutionFactory>().BuildCurrentSolution();

            //Ensure Basic Class is in the solution
            Assert.True(null != GetBasicFile(solution), "Basic File was already in Solution.  Test Environment is not valid.");

            //Simulate Project Item Removed (Basic Class)
            MockFileWrapperBackingStore[MockSolutionFileContents.MainProject.ProjectFileName] =
                MockSolutionFileContents.MainProject.ProjectFileWithNoClasses;

            MockFileWrapperBackingStore.Remove(MockSolutionFileContents.MainProject.ProjectItems.BasicClass.ClassFileName);

            //Fire Project Item Event
            EventProxy.FireOnProjectItemRemoved(this, new ProjectItemRemovedEventArgs
            {
                ClassFullPath = MockSolutionFileContents.MainProject.ProjectItems.BasicClass.ClassFileName,
                ProjectFullPath = MockSolutionFileContents.MainProject.ProjectFileName
            });
        }

        [Test]
        public void FileShouldBeLoadedIntoSolution()
        {
            var solution = TestSpecificKernel.Get<ISolutionFactory>().BuildCurrentSolution();

            Assert.True(null != solution, "BuildCurrentSolution() returned a null solution.");

            var csharpBasicFile = GetBasicFile(solution);

            Assert.True(null == csharpBasicFile, "Solution contained Basic Class File");
        }

        private CSharpFile GetBasicFile(Solution s)
        {
            return s.AllFiles
                .FirstOrDefault(f =>
                    f.FileName.Equals(MockSolutionFileContents.MainProject.ProjectItems.BasicClass.ClassFileName));

        }
    }
}