using lib;

namespace test_xUnit;

public class LinkedListTests
{
    [Fact]
    public void TestInsertAndPrepend()
    {
        // Notes: As we insert using Prepend in constructor, the nodes below are in reverse order.
        var initialNodes = new List<lib.LinkedList<int, int>.LinkedListNode<int,int>>
        {
            new lib.LinkedList<int, int>.LinkedListNode<int, int>(1,1),
            new lib.LinkedList<int, int>.LinkedListNode<int, int>(4,4),
            new lib.LinkedList<int, int>.LinkedListNode<int, int>(16,16),
            new lib.LinkedList<int, int>.LinkedListNode<int, int>(9,9)
        };
        
        LinkedList<int, int> linkedList = new LinkedList<int, int>(initialNodes);
        
        var expectedHeadNode = initialNodes[3];
        
        Assert.Equal(expectedHeadNode, linkedList.Head);
        
        Assert.Equal(initialNodes[1], linkedList.Search(4));
    }
}