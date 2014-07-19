﻿//----------------------------------------------------------------------- 
// <copyright file="HomeController.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Friday, May 2, 2014 2:50:42 PM</date> 
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
using System.Web.Mvc;

namespace CopaceticSoftware.pMixins.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.Url.AbsoluteUri.ToLower().Contains("pmixins.apphb.com"))
            {
                var newUrlBuilder = 
                    new UriBuilder(
                        Request.Url.AbsoluteUri.ToLower().Replace(
                            "pmixins.apphb.com", "pmixins.com"))
                    {
                        Port = 80
                    };

                return RedirectPermanent(newUrlBuilder.Uri.AbsoluteUri);
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
