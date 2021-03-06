﻿//----------------------------------------------------------------------- 
// <copyright file="MixinGenerationPlan.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Saturday, July 26, 2014 12:21:02 PM</date> 
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

using System.Collections.Generic;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.GenerateCodeBehind.Pipelines.MixinLevelCodeGenerator.Steps.CreateTypeDeclarations;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.ResolveAttributes.Infrastructure;
using CopaceticSoftware.pMixins.ConversionOperators;
using CopaceticSoftware.pMixins.Infrastructure;
using ICSharpCode.NRefactory.CSharp;

namespace CopaceticSoftware.pMixins.CodeGenerator.Infrastructure.CodeGenerationPlan
{
    public class MixinGenerationPlan
    {
        /// <summary>
        /// The <see cref="CodeGenerationPlan"/> this <see cref="MixinGenerationPlan"/>
        /// is a part of.
        /// </summary>
        public CodeGenerationPlan CodeGenerationPlan { get; set; }

        public pMixinAttributeResolvedResult MixinAttribute { get; set; }

        public RequirementsInterfacePlan RequirementsInterfacePlan { get; set; }
        public ProtectedWrapperPlan ProtectedWrapperPlan { get; set; }
        public AbstractWrapperPlan AbstractWrapperPlan { get; set; }
        public MasterWrapperPlan MasterWrapperPlan { get; set; }

        //Keep all Members here and also reference in each wrapper plan
        public IEnumerable<MemberWrapper> Members { get; set; }

        /// <summary>
        /// The subset of <see cref="Members"/> that should be added in the 
        /// <see cref="SourceClass"/> (Target)'s Code-Behind
        /// </summary>
        public IEnumerable<MemberWrapper> MembersPromotedToTarget { get; set; } 

        public string ExternalMixinSpecificAutoGeneratedNamespaceName { get; set; }

        /// <summary>
        /// The Target's Source which is decorated with the Mixin
        /// this plan is for.
        /// </summary>
        public TypeDeclaration SourceClass { get; set; }

        /// <summary>
        /// Name for the Mixin Level Auto Generated Container Class.  
        /// Class is created in <see cref="CreateMixinLevelAutoGeneratedContainerClass"/>.
        /// <code>
        /// <![CDATA[
        /// private sealed class __pMixinAutoGenerated
        /// {
        ///    //Container for Mixin global::Namespace.MixinName
        ///    public sealed class Namespace_MixinName{}
        /// }    
        /// ]]>
        /// </code>
        /// </summary>
        public string MixinLevelAutoGeneratedContainerClass { get; set; }

        /// <summary>
        /// Indicates if an implementation of <see cref="IContainMixin{TMixin}"/>
        /// should be added to the 
        /// <see cref="TargetCodeBehindPlan"/> on behalf of this mixin.
        /// </summary>
        public bool AddAnIContainsMixinImplementation { get; set; }

        /// <summary>
        /// Indicates if the Target Code Behind should implement
        /// <see cref="IMixinConstructorRequirement{TMixin}"/>
        /// for this <see cref="MixinAttribute"/>
        /// </summary>
        public bool AddIMixinConstructorRequirementInterface { get; set; }
    }
}
