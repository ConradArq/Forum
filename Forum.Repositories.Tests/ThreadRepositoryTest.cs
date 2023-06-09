// <copyright file="ThreadRepositoryTest.cs">Copyright ©  2017</copyright>
using System;
using Forum.Repositories.Repositories.Messages;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forum.Core.Models.Messages;

namespace Forum.Repositories.Repositories.Messages.Tests
{
    /// <summary>This class contains parameterized unit tests for ThreadRepository</summary>
    [PexClass(typeof(ThreadRepository))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ThreadRepositoryTest
    {
        public void TestMethod()
        {
            Thread thread = new Thread()
            {
                Name = "test",
                CategoryID = 1,
                ViewsCount = 0
            };

            ThreadRepository threadRepository = new ThreadRepository();

            threadRepository.Save(thread);
        }
        

    }
}
