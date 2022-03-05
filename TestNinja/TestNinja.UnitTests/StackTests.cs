using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Fundamentals.Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Fundamentals.Stack<string>();
        }

        [Test]
        public void Push_NullArgument_ThrowsArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void Push_ValidString_AddTheElementToTheList()
        {
            _stack.Push("Ema");
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_EmptyList_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_ListWithAtLeast1Item_RemoveAndReturnTheElement()
        {
            _stack.Push("Ema");

            Assert.That(_stack.Pop(), Is.EqualTo("Ema"));
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_EmptyList_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_ListWithAtLeast1Item_ReturnsTheLastElementOfTheList()
        {
            _stack.Push("Ema");
            

            Assert.That(_stack.Peek(), Is.EqualTo("Ema"));
        }

    }
}
