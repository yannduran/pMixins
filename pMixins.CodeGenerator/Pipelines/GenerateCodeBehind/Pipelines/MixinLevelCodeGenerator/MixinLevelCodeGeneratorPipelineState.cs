﻿//----------------------------------------------------------------------- 
// <copyright file="MixinLEvelCodeGeneratorPipeline.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, July 23, 2014 1:38:56 PM</date> 
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

using CopaceticSoftware.pMixins.CodeGenerator.Infrastructure.CodeGenerationPlan;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.CreateCodeGenerationPlan;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.TargetLevelCodeGenerator;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.MixinLevelCodeGenerator.Steps.CreateTypeDeclarations;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.TargetLevelCodeGenerator.Steps;
using ICSharpCode.NRefactory.CSharp;

namespace CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.MixinLevelCodeGenerator
{
    public class MixinLevelCodeGeneratorPipelineState : IGenerateCodePipelineState
    {
        public MixinLevelCodeGeneratorPipelineState(TargetLevelCodeGeneratorPipelineState baseState)
        {
            CommonState = baseState.CommonState;
            CreateCodeGenerationPlanPipeline = baseState.CreateCodeGenerationPlanPipeline;
            CodeBehindSyntaxTree = baseState.CodeBehindSyntaxTree;

            TargetLevelCodeGeneratorPipelineState = baseState;
        }

        #region IGenerateCodePipelineState

        public IPipelineCommonState CommonState { get; private set; }

        /// <summary>
        /// The State from the previous Resolve Members
        /// step.
        /// </summary>
        public ICreateCodeGenerationPlanPipelineState CreateCodeGenerationPlanPipeline { get; private set; }
        
        public SyntaxTree CodeBehindSyntaxTree { get; private set; }
        #endregion

        /// <summary>
        /// State from the parent <see cref="TargetLevelCodeGenerator"/>.
        /// Set by <see cref="RunMixinLevelCodeGeneratorForEachMixin"/>
        /// </summary>
        public TargetLevelCodeGeneratorPipelineState TargetLevelCodeGeneratorPipelineState { get; set; }

        /// <summary>
        /// The <see cref="MixinGenerationPlan"/>this pipeline is running code for.
        /// </summary>
        public MixinGenerationPlan MixinGenerationPlan { get; set; }

        /// <summary>
        /// The namespace for placing auto generated objects outside of the 
        /// <see cref="Pipelines.TargetLevelCodeGenerator.TargetLevelCodeGeneratorPipelineState.TargetCodeBehindTypeDeclaration" />
        /// </summary>
        public NamespaceDeclaration ExternalMixinSpecificAutoGeneratedNamespace { get; set; }

        #region Type Declarations
        /// <summary>
        /// The mixin specific container for generated wrapper classes.
        /// Defined in <see cref="CreateMixinLevelAutoGeneratedContainerClass"/>.
        /// 
        /// Is nested inside
        /// <see cref="Pipelines.TargetLevelCodeGenerator.TargetLevelCodeGeneratorPipelineState.GlobalAutoGeneratedContainerClass"/>
        /// adds a Mixin specific container.
        /// </summary>
        public TypeDeclaration MixinAutoGeneratedContainerClass { get; set; }

        /// <summary>
        /// Set in <see cref="CreateAbstractWrapperTypeDeclaration"/>
        /// </summary>
        public TypeDeclaration AbstractMembersWrapper { get; set; }

        /// <summary>
        /// Set in <see cref="CreateProtectedWrapperTypeDeclaration"/>
        /// </summary>
        public TypeDeclaration ProtectedMembersWrapper { get; set; }

        public TypeDeclaration MasterWrapper { get; set; }

        /// <summary>
        /// Set in <see cref="CreateMixinRequirementsInterfaceTypeDeclaration"/>.
        /// </summary>
        public TypeDeclaration RequirementsInterface { get; set; }
        #endregion
    }
}
