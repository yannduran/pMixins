﻿//----------------------------------------------------------------------- 
// <copyright file="MixinIsAbstractWithProtectedNonParameterlessConstructor.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Tuesday, February 4, 2014 5:31:15 PM</date> 
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

using System.Reflection;
using CopaceticSoftware.pMixins.Tests.Common.Extensions;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace CopaceticSoftware.pMixins.CodeGenerator.Tests.IntegrationTests.CompileTests.AdvancedMixinTypes
{
    //Exact copy of the Theory Sandbox test
    [TestFixture]
    public class MixinIsAbstractWithProtectedNonParameterlessConstructor : GenerateCodeAndCompileTestBase
    {
        protected override string SourceCode
        {
            get
            {
                return
                @"
                using Other.Namespace;
                using pMixins.AutoGenerated.Test.Target.Test.AbstractWithProtectedNonParameterlessConstructorMixin;
                using CopaceticSoftware.pMixins.Infrastructure;

                namespace Other.Namespace
                {
                    public class OtherMixin
                    {
                        public string OtherMixinMethod()
                        {
                            return ""Other Mixin Method"";
                        }
                    }
                }

                namespace Test
                {
                    public abstract class AbstractWithProtectedNonParameterlessConstructorMixin
                    {
                        protected AbstractWithProtectedNonParameterlessConstructorMixin(string s)
                        {
                            System.Console.WriteLine(s);
                        }

                        protected int ProtectedMethod()
                        {
                            return 42;
                        }

                        public abstract string PublicAbstractMethod();

                        protected abstract string ProtectedAbstractMethod();

                        public virtual string PublicVirtualMethod()
                        {
                            return ""Mixin's PublicVirtualMethod"";
                        }

                        protected virtual string ProtectedVirtualMethod(int i)
                        {
                            return ""Mixin's ProtectedVirtualMethod"";
                        }

                        public virtual string PublicVirtualProperty
                        {
                            get; set;
                        }

                        public string RegularMethod()
                        {
                            return ""Hello World"";
                        }
        
                        public static string PublicStaticMethod()
                        {
                            return ""public static method"";
                        }

                        protected static string ProtectedStaticMethod()
                        {
                            return ""protected static method"";
                        }        
                    }
                       
                    [CopaceticSoftware.pMixins.Attributes.pMixin(
                                Mixin = typeof (Test.AbstractWithProtectedNonParameterlessConstructorMixin),
                                ExplicitlyInitializeMixin=true)]
                    [CopaceticSoftware.pMixins.Attributes.pMixin(
                                Mixin = typeof (OtherMixin))]
                    public partial class Target
                    {
                        public Target()
                        {
                            __mixins.Test_AbstractWithProtectedNonParameterlessConstructorMixin.PublicVirtualMethodFunc = () => ""Target's Public Virtual Method"";
                        }                        
                    
                        string IAbstractWithProtectedNonParameterlessConstructorMixinRequirements.PublicAbstractMethodImplementation()
                        {
                            return ""Target-PublicAbstractMethod"";
                        }

                        string IAbstractWithProtectedNonParameterlessConstructorMixinRequirements.ProtectedAbstractMethodImplementation()
                        {
                            return ""Target-ProtectedAbstractMethod"";
                        }

                        AbstractWithProtectedNonParameterlessConstructorMixinAbstractWrapper 
                            IMixinConstructorRequirement<AbstractWithProtectedNonParameterlessConstructorMixinAbstractWrapper>.InitializeMixin()
                        {
                            return new AbstractWithProtectedNonParameterlessConstructorMixinAbstractWrapper(this, ""Initialized in Target-Protected"");
                        }
                    }

                    public class ChildClass : Target
                    {
                        public bool CanAccessAllProtectedMembers()
                        {
                            var result =
                                ProtectedAbstractMethod() +
                                ProtectedMethod() +
                                ProtectedStaticMethod() +
                                ProtectedVirtualMethod(1);

                            return true;
                        }

                        public override string PublicVirtualMethod()
                        {
                            return ""ChildVirtualMethod"";
                        }
                    }
                }";
            }
        }

        [Test]
        public void CanCallAllPublicMembers()
        {
            CompilerResults
                .ExecuteMethod<string>(
                    "Test.Target",
                    "PublicAbstractMethod")
                .ShouldEqual("Target-PublicAbstractMethod");

            CompilerResults
                .ExecuteMethod<string>(
                    "Test.Target",
                    "PublicVirtualMethod")
                .ShouldEqual("Target's Public Virtual Method");


            CompilerResults
               .ExecuteMethod<string>(
                   "Test.Target",
                   "RegularMethod")
               .ShouldEqual("Hello World");

            CompilerResults
                .ExecuteMethod<string>(
                    "Test.Target",
                    "PublicStaticMethod",
                    BindingFlags.Public | BindingFlags.Static)
                .ShouldEqual("public static method");

            CompilerResults
               .ExecuteMethod<string>(
                   "Test.Target",
                   "OtherMixinMethod")
               .ShouldEqual("Other Mixin Method");


            var targetInstance = 
                CompilerResults.TryLoadCompiledType("Test.Target");

            ReflectionHelper.ExecutePropertySet(
                targetInstance, 
                "PublicVirtualProperty",
                "Test");

            ReflectionHelper.ExecutePropertyGet<string>(
                targetInstance,
                "PublicVirtualProperty")
            .ShouldEqual("Test");
        }

        [Test]
        public void ChildClassCanAccessProtectedMembers()
        {
            CompilerResults
               .ExecuteMethod<bool>(
                   "Test.ChildClass",
                   "CanAccessAllProtectedMembers")
               .ShouldBeTrue();
        }

        [Test]
        public void ChildClassCanOverrideVirtualMember()
        {
            CompilerResults
               .ExecuteMethod<string>(
                   "Test.ChildClass",
                   "PublicVirtualMethod")
               .ShouldEqual("ChildVirtualMethod");
        }
    }
}
