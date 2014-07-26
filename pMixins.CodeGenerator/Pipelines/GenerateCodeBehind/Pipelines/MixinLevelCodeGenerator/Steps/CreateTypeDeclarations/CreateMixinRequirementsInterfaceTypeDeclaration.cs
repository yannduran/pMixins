﻿//----------------------------------------------------------------------- 
// <copyright file="CreateMixinRequirementsInterfaceTypeDeclaration.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Friday, July 25, 2014 6:10:58 PM</date> 
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
using CopaceticSoftware.CodeGenerator.StarterKit.Extensions;
using CopaceticSoftware.Common.Patterns;
using CopaceticSoftware.pMixins.CodeGenerator.Infrastructure;
using CopaceticSoftware.pMixins.CodeGenerator.Infrastructure.CodeGeneratorProxy;
using ICSharpCode.NRefactory.CSharp;

namespace CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.MixinLevelCodeGenerator.Steps.CreateTypeDeclarations
{
    /// <summary>
    /// Creates the interface definition for the mixin specific
    /// Requirements Interfaces and assigns in to 
    /// <see cref="MixinLevelCodeGeneratorPipelineState.RequirementsInterface"/>.
    /// <code>
    /// <![CDATA[
    /// public interface IMixinRequirements {}
    /// ]]></code>
    /// </summary>
    public class CreateMixinRequirementsInterfaceTypeDeclaration : IPipelineStep<MixinLevelCodeGeneratorPipelineState>
    {
        public bool PerformTask(MixinLevelCodeGeneratorPipelineState manager)
        {
            var requirementsInterface = new TypeDeclaration
            {
                ClassType = ClassType.Interface,
                Modifiers = Modifiers.Public,
                Name = manager.MixinGenerationPlan.RequirementsInterfacePlan.RequirementsInterfaceName
            };

            //have requirementsInterface inherit from sharedRequirementsInterface
            requirementsInterface.BaseTypes.Add(
                new SimpleType(
                    (Identifier)
                        manager.TargetLevelCodeGeneratorPipelineState
                            .SharedRequirementsInterface.Descendants.OfType<Identifier>().First().Clone()));


            //Have CodeGeneratorProxy add the Code Generated attribute
            new CodeGeneratorProxy(requirementsInterface, true);

            //Add to Code Behind Syntax Tree
            manager.TargetLevelCodeGeneratorPipelineState.CodeBehindSyntaxTree
                .AddChildTypeDeclaration(
                    requirementsInterface,
                    manager.ExternalMixinSpecificAutoGeneratedNamespace);

            manager.RequirementsInterface = requirementsInterface;

            return true;
        }
    }
}