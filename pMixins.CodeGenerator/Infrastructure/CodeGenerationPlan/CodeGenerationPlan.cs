﻿//----------------------------------------------------------------------- 
// <copyright file="CodeGenerationPlan.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Thursday, July 24, 2014 3:11:56 PM</date> 
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
using System.Linq;
using System.Runtime.InteropServices;
using CopaceticSoftware.pMixins.Attributes;
using CopaceticSoftware.pMixins.CodeGenerator.Pipelines.ResolveAttributes.Infrastructure;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;

namespace CopaceticSoftware.pMixins.CodeGenerator.Infrastructure.CodeGenerationPlan
{
    /// <summary>
    /// Contains plan for Target level members
    /// and links to wrapper specific plans
    /// </summary>
    public class CodeGenerationPlan
    {
        public CodeGenerationPlan()
        {
            MixinGenerationPlans = new Dictionary<pMixinAttributeResolvedResult, MixinGenerationPlan>();
        }

        public IDictionary<
            pMixinAttributeResolvedResult,
            MixinGenerationPlan> MixinGenerationPlans { get; set; }

        public TypeDeclaration SourceClass { get; set; }

        /// <summary>
        /// Collects all <see cref="MemberWrapper"/>s
        /// in <see cref="MixinGenerationPlans"/>.
        /// </summary>
        public IEnumerable<MemberWrapper> Members
        {
            get { return MixinGenerationPlans.SelectMany(x => x.Value.Members); }
        }
    }

    public class MixinGenerationPlan
    {
        public pMixinAttributeResolvedResult MixinAttribute { get; set; }

        public ProtectedWrapperPlan ProtectedWrapperPlan { get; set; }
        public AbstractWrapperPlan AbstractWrapperPlan { get; set; }
        public MasterWrapperPlan MasterWrapperPlan { get; set; }

        //Keep all Members here and also reference in each wrapper plan
        public IEnumerable<MemberWrapper> Members { get; set; }
    }

    public class AbstractWrapperPlan
    {
        /// <summary>
        /// Indicates if an Abstract Wrapper should be built
        /// for the given Mixin.
        /// </summary>
        public bool GenrateAbstractWrapper { get; set; }

        /// <summary>
        /// Indicates if all constructors should be wrapped by the 
        /// Abstract Wrapper, or if the Abstract Wrapper should have a 
        /// 'simple constructor'.  This is dictated by
        /// <see cref="pMixinAttribute.ExplicitlyInitializeMixin"/>
        /// or if <see cref="pMixinAttribute.Mixin"/> has a 
        /// parameterless constructor.
        /// </summary>
        /// <remarks>
        /// <code>
        /// <![CDATA[
        ///  var wrapAllConstructors =
        ///     manager.MixinResolvedResult.ExplicitlyInitializeMixin ||
        ///     !manager.MixinResolvedResult.Mixin.HasParameterlessConstructor();
        /// ]]>
        /// </code>
        /// </remarks>
        public bool WrapAllConstructors { get; set; }

        public IEnumerable<MemberWrapper> Members { get; set; }
    }

    public class ProtectedWrapperPlan
    {
        /// <summary>
        /// Indicates if an Abstract Wrapper should be built
        /// for the given Mixin.
        /// </summary>
        public bool GenrateProtectedWrapper { get; set; }

        public IEnumerable<MemberWrapper> Members { get; set; }

        public IEnumerable<IMethod> Constructors { get; set; }

        /// <summary>
        /// <c>True</c> to generate the Protected Wrapper in an 
        /// external namespace.  <c>False</c> to generate it inside
        /// of the Target.  If the Mixin is private, wrappers must be created
        /// inside the Target.
        /// </summary>
        public bool GenerateProtectedWrapperInExternalNamespace { get;set; }

        public string ProtectedWrapperClassName { get; set; }
    }

    public class MasterWrapperPlan
    {
        /// <summary>
        /// The variable name for the data member that holds a reference
        /// to the Mixin (with a type of IRequirements interface).
        /// </summary>
        public readonly string MixinInstanceDataMemberName = "_mixinInstance";

        public IEnumerable<MemberWrapper> StaticMembers { get; set; }

        public IEnumerable<MemberWrapper> ProtectedAbstractMembers { get; set; }

        public IEnumerable<MemberWrapper> VirtualMembers { get; set; }

        public IEnumerable<MemberWrapper> RegularMembers { get; set; }

        
    }
}