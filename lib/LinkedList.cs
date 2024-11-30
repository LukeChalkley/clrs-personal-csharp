namespace lib;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class LinkedList<TKey, TValue>
{
    private LinkedListNode<TKey, TValue>? mHead;
    
    private LinkedListNode<TKey, TValue>? mTail;
    
    /// <summary>
    /// Gets the Head node of the linked list.
    /// </summary>
    public LinkedListNode<TKey, TValue> Head { get => mHead; }
    
    /// <summary>
    /// Gets the tail node of the linked list.
    /// </summary>
    public LinkedListNode<TKey, TValue> Tail { get => mTail; }

    /// <summary>
    /// Initialises a LinkedList with a collection of existing LinkedListNodes.
    /// </summary>
    /// <param name="nodesToInitialise"></param>
    public LinkedList(IEnumerable<LinkedListNode<TKey, TValue>> nodesToInitialise)
    {
        foreach (var nodeToInitialise in nodesToInitialise)
        {
            Prepend(nodeToInitialise);
        }
    }
    
    /// <summary>
    /// Performs a linear search on the linked list searching for the specified key value.
    /// </summary>
    /// /// <complexity>0(n).</complexity>
    /// <param name="key">Key value to search.</param>
    /// <returns>LinkedListNode for the matching key, or null if not found.</returns>
    public LinkedListNode<TKey, TValue>? Search(TKey key)
    {
        LinkedListNode<TKey, TValue>? current = mHead;

        while (current != null)
        {
            if (current.Key.Equals(key))
                return current;

            current = current.Next;
        }

        return null;
    }

    /// <summary>
    /// Prepends a LinkedListNode to the beginning of the LinkedList. 
    /// </summary>
    /// <complexity>0(1)</complexity>
    /// <param name="node">LinkedListNode with key and value already set.</param>
    public void Prepend(LinkedListNode<TKey, TValue> node)
    {
        node.Next = mHead;
        node.Previous = null;

        if (mHead != null)
            mHead.Previous = node;
        
        mHead = node;
    }
    
    /// <summary>
    /// Creates a LinkedListNode object from key/value and prepends it to the LinkedList.
    /// </summary>
    /// <param name="key">Key to assign to LinkedListNode.</param>
    /// <param name="value">Value to assign to LinkedListNode.</param>
    public void Prepend(TKey key, TValue value)
    {
        LinkedListNode<TKey, TValue> nodeToInsert = new LinkedListNode<TKey, TValue>(key, value);
        Prepend(nodeToInsert);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class LinkedListNode<TKey, TValue>
    {
        private LinkedListNode<TKey, TValue>? mNext;
        private LinkedListNode<TKey, TValue>? mPrevious;
        private TKey mKey;
        private TValue mValue;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public LinkedListNode(TKey key, TValue value)
        {
            mKey = key;
            mValue = value;
        }

        /// <summary>
        /// Insert a node immediately after a specified node.
        /// </summary>
        /// <complexity>0(1)</complexity> 
        /// <param name="nodeToInsert"></param>
        /// <param name="insertAfter"></param>
        public void Insert(LinkedListNode<TKey, TValue> nodeToInsert, LinkedListNode<TKey, TValue> insertAfter)
        {
            nodeToInsert.Next = insertAfter.Next;
            nodeToInsert.Previous = insertAfter.Previous;
            
            if (insertAfter.Next != null)
                insertAfter.Next.Previous = nodeToInsert;
            
            insertAfter.Next = nodeToInsert;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public TKey Key => mKey;
        
        /// <summary>
        /// 
        /// </summary>
        public TValue Value => mValue;
        
        /// <summary>
        /// 
        /// </summary>
        public LinkedListNode<TKey, TValue> Next { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public LinkedListNode<TKey, TValue> Previous { get; set; }
    }
}