namespace Tree.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class TreeNodeTests
    {
        [TestMethod]
        public void TestTreeNodeEmptyConstructor_ShouldConstructObjectsCorrectly()
        {
            var treeNode = new TreeNode<int>();
            Assert.AreEqual(0, treeNode.Value);
        }

        [TestMethod]
        public void TestTreeNodeConstructor_ShouldSetChildren()
        {
            var treeNode2 = new TreeNode<int>(5);
            var treeNode3 = new TreeNode<int>(20);
            var children = new List<TreeNode<int>>() { treeNode2, treeNode3 };

            var treeNode = new TreeNode<int>(10, children);

            children.Add(new TreeNode<int>(33));
            CollectionAssert.AreEqual(treeNode.Children as IList, children);
        }
    }
}
