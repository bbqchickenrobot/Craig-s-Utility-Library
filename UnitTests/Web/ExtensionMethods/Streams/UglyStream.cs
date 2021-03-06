﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Linq.Expressions;
using Utilities.Web.ExtensionMethods;
using System.Net;
using System.Collections.Specialized;
using Utilities.DataTypes.ExtensionMethods;
using Utilities.Compression.ExtensionMethods;

namespace UnitTests.Web.ExtensionMethods.Streams
{
    public class UglyStream
    {
        [Fact]
        public void Test()
        {
            using (MemoryStream Stream1 = new MemoryStream())
            {
                using (Utilities.Web.ExtensionMethods.Streams.UglyStream StreamUsing = new Utilities.Web.ExtensionMethods.Streams.UglyStream(Stream1, Utilities.Compression.ExtensionMethods.Enums.CompressionType.GZip))
                {
                    StreamUsing.Write("This is a test".ToByteArray(), 0, "This is a test".ToByteArray().Length);
                    StreamUsing.Flush();
                }
                Assert.Equal("This is a test", Stream1.ReadAllBinary().ToBase64String().Decompress(CompressionType: Utilities.Compression.ExtensionMethods.Enums.CompressionType.GZip));
            }
        }
    }
}
