﻿//----------------------------------------------------------------------- 
// <copyright file="FileWrapper.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Tuesday, May 6, 2014 1:28:27 PM</date> 
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
using System.IO;
using System.Reflection;
using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure.Caching;
using log4net;

namespace CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure.IO
{
    public interface IFileWrapper
    {
        string ReadAllText(FilePath filename);
        bool Exists(FilePath filename);
        void Delete(FilePath filename);
        void WriteAllText(FilePath filename, string s);
    }

    public class FileWrapper : IFileWrapper
    {
        private readonly ICacheEventHelper _cacheEventHelper;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FileWrapper(ICacheEventHelper cacheEventHelper)
        {
            _cacheEventHelper = cacheEventHelper;
        }

        public virtual string ReadAllText(FilePath filename)
        {
            return File.ReadAllText(filename.FullPath);
        }

        public bool Exists(FilePath filename)
        {
            return File.Exists(filename.FullPath);
        }

        public void Delete(FilePath filename)
        {
            File.Delete(filename.FullPath);
        }

        private static readonly object _writeAllTextObject = new object();
        public void WriteAllText(FilePath filename, string s)
        {
            lock (_writeAllTextObject)
            {
                if (File.Exists(filename.FullPath))
                {
                    #region Don't write if the content is the same.
                    try
                    {
                        var originalText =
                            ReadAllText(filename)
                                .Replace(Environment.NewLine, "")
                                .Replace(" ", "");

                        var sComparisonText = 
                            s
                                .Replace(Environment.NewLine, "")
                                .Replace(" ", "");

                        if (originalText.Equals(sComparisonText,
                            StringComparison.InvariantCulture))
                        {
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        _log.Error("Exception Reading [" + filename + "].  Will overrite file.", e);
                    }
                    #endregion
                }

                File.WriteAllText(filename.FullPath, s);
            } 

            _cacheEventHelper.EvictFromCache(this, filename);
        }

    }
}
