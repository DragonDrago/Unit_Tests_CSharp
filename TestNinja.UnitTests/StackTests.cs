using System.Collections;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgumentIsNull_ArgumentNullExecption()
        {
            var stack = new Stack<string>();
            Assert.That(()=>stack.Push(null),Throws.ArgumentNullException);
        }
        [Test]
        public void Push_ValidArgument_ArgumentToTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            Assert.That(stack.Count,Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();
            Assert.That(stack.Count,Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationExeption()
        {
            var stack = new Stack<string>();
            Assert.That(()=>stack.Pop(),Throws.InvalidOperationException);
            
        }
        [Test]
        public void Pop_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();
            Assert.That(result,Is.EqualTo("c"));
        }
        [Test]
        public void Pop_StackWithFewObjects_RemoveObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Pop();
            Assert.That(stack.Count,Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.That(()=>stack.Peek(),Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ResturnObjectIOnTheTopOfTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            var result = stack.Peek();
            Assert.That(result,Is.EqualTo("b"));
        }

        [Test]
        public void Peek_StackWithObject_DoesNotRemoveTheObjectOnTheTopOfTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Peek();
            Assert.That(stack.Count,Is.EqualTo(2));
        }
    }
}