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

using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.TargetLevelCodeGenerator;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.ResolveAttributes.Infrastructure;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.ResolveMembers;
using ICSharpCode.NRefactory.CSharp;

namespace CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.MixinLevelCodeGenerator
{
    public class MixinLevelCodeGeneratorPipeline : IGenerateCodePipelineState
    {
        public MixinLevelCodeGeneratorPipeline(TargetLevelCodeGeneratorPipeline baseState)
        {
            CommonState = baseState.CommonState;
            ResolveMembersPipeline = baseState.ResolveMembersPipeline;
            CodeBehindSyntaxTree = baseState.CodeBehindSyntaxTree;

            TargetLevelCodeGeneratorPipeline = baseState;
        }

        #region IGenerateCodePipelineState

        public IPipelineCommonState CommonState { get; private set; }

        /// <summary>
        /// The State from the previous Resolve Members
        /// step.
        /// </summary>
        public IResolveMembersPipelineState ResolveMembersPipeline { get; private set; }
        
        public SyntaxTree CodeBehindSyntaxTree { get; private set; }
        #endregion

        public TargetLevelCodeGeneratorPipeline TargetLevelCodeGeneratorPipeline { get; set; }

        /// <summary>
        /// The Mixin this pipeline is running code for.
        /// </summary>
        public pMixinAttributeResolvedResult MixinResolvedResult { get; set; }
    }
}
