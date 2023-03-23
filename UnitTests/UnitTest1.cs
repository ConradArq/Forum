using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forum.Core.Models.Messages;
using Forum.Repositories.Repositories.Messages;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
