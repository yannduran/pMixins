﻿//----------------------------------------------------------------------- 
// <copyright file="IMixinMulticastRule.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Sunday, July 6, 2014 1:47:56 PM</date> 
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

namespace CopaceticSoftware.pMixins.TheorySandbox
{
    /// <summary>
    /// Basis for applying mulitcast rules.  Inheritors can be located anywhere,
    /// pMixin code generator will find them!
    /// </summary>
    public interface IMixinMulticastRule
    {
        IEnumerable<Type> MixinsForTypes(string typeFullName);
    }
}
