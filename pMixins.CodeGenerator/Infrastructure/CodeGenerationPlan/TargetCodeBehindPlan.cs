﻿//----------------------------------------------------------------------- 
// <copyright file="TargetCodeBehindPlan.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Monday, July 28, 2014 10:46:19 AM</date> 
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
using ICSharpCode.NRefactory.TypeSystem;

namespace CopaceticSoftware.pMixins.CodeGenerator.Infrastructure.CodeGenerationPlan
{
    /// <summary>
    /// Contains plan for Target level members
    /// </summary>
    public class TargetCodeBehindPlan
    {
        /// <summary>
        /// The parent <see cref="Infrastructure.CodeGenerationPlan.CodeGenerationPlan"/>.
        /// </summary>
        public CodeGenerationPlan CodeGenerationPlan { get; set; }

        /// <summary>
        /// Name for the container class for Auto Generated wrapper classes:
        /// <code>
        /// <![CDATA[
        /// public partial class Target
        /// {
        ///     private sealed class __pMixinAutoGenerated { }    
        /// }
        /// ]]>
        /// </code>
        /// </summary>
        public const string GlobalAutoGeneratedContainerClassName = "__pMixinAutoGenerated";

        /// <summary>
        /// Collection of <see cref="ImplicitConversionPlan"/>s for
        /// generating  implicit conversion operators:
        /// <code>
        /// <![CDATA[
        /// public static implicit operator ExampleMixin(BasicConceptSpec spec)
        /// {
        ///     return spec.__mixins._ExampleMixin.Value;
        /// }
        /// ]]>
        /// </code>
        /// </summary>
        public IEnumerable<ImplicitConversionPlan> ImplicitCoversionPlans { get; set; }

        /// <summary>
        /// The collection of interfaces Mixins implement that the 
        /// Target should implement as well.
        /// </summary>
        public IEnumerable<IType> MixinInterfaces { get; set; } 
        
        /// <summary>
        /// Collection of <see cref="IAttribute"/> to add to the
        /// Target.
        /// </summary>
        public IEnumerable<IAttribute> MixinAttributes { get; set; } 

        #region Mixins Class
        /// <summary>
        /// The private property name for the accessor to the __Mixins class:
        /// <code>
        /// <![CDATA[
        /// private __Mixins __mixins {get;set;}
        /// ]]>
        /// </code>
        /// </summary>
        public string MixinsPropertyName { get; set; }

        /// <summary>
        /// Class name for the __Mixins class:
        /// <code>
        /// <![CDATA[
        /// public partial class Target
        /// {
        ///     private sealed class __Mixins{}
        /// }
        /// ]]>
        /// </code>
        /// </summary>
        public string MixinsClassName { get; set; }

        /// <summary>
        /// Static lock data member inside <see cref="MixinsClassName"/>:
        /// <code>
        /// <![CDATA[
        /// private sealed class __Mixins{
        ///     private static object ____Lock = new object();
        /// }
        /// ]]></code>
        /// </summary>
        public string MixinsLockVariableName { get; set; }

        /// <summary>
        /// Activate Mixin Dependencies method inside <see cref="MixinsClassName"/>:
        /// <code>
        /// <![CDATA[
        /// private sealed class __Mixins{
        ///     public void __ActivateMixinDependencies (Target target)
        ///     {
        ///     }
        /// }
        /// ]]></code>
        /// </summary>
        public string MixinsActivateMixinDependenciesMethodName { get; set; }
        #endregion
    }
}
