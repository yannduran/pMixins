﻿//----------------------------------------------------------------------- 
// <copyright file="BasicInterceptorSpec.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Thursday, February 20, 2014 11:12:49 PM</date> 
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
using System.Collections.Generic;
using CopaceticSoftware.pMixins.CodeGenerator.Tests.IntegrationTests.CompileTests.Interceptors;

namespace CopaceticSoftware.pMixins.TheorySandbox.COVERED.Interceptors.InterceptorManipulatesReturnValue
{ //Can specify activator with attribute?
    /// <summary>
    /// Covered in 
    ///     <see cref="ManipulateReturnValueInterceptorTest"/>
    /// </summary>
    public class ManipulateValueInterceptor : MixinInterceptorBase
    {
        public override void OnAfterMethodInvocation(object sender, MethodEventArgs eventArgs)
        {
            eventArgs.ReturnValue += "_Interceptor";
        }
    }

//Can a mixin specify it's activator?
    public class Mixin
    {
        public string Method()
        {
            WasMethodCalled = true;

            return "Mixin";
        }

        public bool WasMethodCalled { get; private set; }
    }

    [BasicMixin(Target = typeof(Mixin), Interceptors = new Type[] { typeof(ManipulateValueInterceptor) })]
    public partial class InterceptorManipulatesReturnValueSpec
    {}

/*/////////////////////////////////////////
/// Generated Code
/////////////////////////////////////////*/

    public partial class InterceptorManipulatesReturnValueSpec
    {
        private class __pMixinAutoGenerated
        {
            public class CopaceticSoftware_pMixin_TheorySandbox_Interceptors_InterceptorManipulatesReturnValue_Mixin
            {
                //don't need protected wrapper

                //don't need abstract wrapper

                public sealed class MasterWrapper : MasterWrapperBase
                {
                    public readonly Mixin Mixin;

                    public MasterWrapper(InterceptorManipulatesReturnValueSpec target)
                    {
                        this.Mixin = new Mixin();

                        base.Initialize(target, Mixin,
                            new List<IMixinInterceptor>
                            {
                                //Need custom activator?
                                new DefaultMixinActivator().CreateInstance<ManipulateValueInterceptor>()
                            });
                    }

                    public string Method()
                    {
                        return base.ExecuteMethod(
                            "Method",
                            new List<Parameter>(),
                            () => Mixin.Method());
                    }

                    public bool WasMethodCalled
                    {
                        get
                        {
                            return base.ExecutePropertyGet("WasMethodCalled", () => Mixin.WasMethodCalled);
                        }
                    }
                }
            }
        }

        private sealed partial class __Mixins
        {
            public static readonly global::System.Object ____Lock = new global::System.Object();

            public readonly __pMixinAutoGenerated.CopaceticSoftware_pMixin_TheorySandbox_Interceptors_InterceptorManipulatesReturnValue_Mixin.MasterWrapper MixinMasterWrapper;

            public __Mixins(InterceptorManipulatesReturnValueSpec target)
            {
                this.MixinMasterWrapper =
                    new DefaultMixinActivator()
                        .CreateInstance<__pMixinAutoGenerated.CopaceticSoftware_pMixin_TheorySandbox_Interceptors_InterceptorManipulatesReturnValue_Mixin.MasterWrapper>(
                            target);
            }
        }

        private __Mixins _____mixins;
        private __Mixins ___mixins
        {
            get
            {
                if (null == _____mixins)
                {
                    lock (__Mixins.____Lock)
                    {
                        if (null == _____mixins)
                        {
                            _____mixins = new __Mixins(this);
                        }
                    }
                }
                return _____mixins;
            }
        }

        public string Method()
        {
            return ___mixins.MixinMasterWrapper.Method();
        }

        public bool WasMethodCalled
        {
            get { return ___mixins.MixinMasterWrapper.WasMethodCalled; }
        }
    }
}