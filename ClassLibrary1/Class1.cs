using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace BidirectionalList
{
    /// <summary>
    /// 
    /// </summary>
    public class ListItem
    {
        public ListItem nextItem { get; internal set; }
        public ListItem previousItem { get; internal set; }
        public int _value { get; private set; }

        public ListItem() { }

        public ListItem(int value)
        {
            this._value = value;
        }
    }

    public class LinkedLis : IEnumerable, IEnumerator
    {
        private ListItem _head;
        private ListItem _head_fr;
        private ListItem _tail;
        private int count = 0;
        private int index = -1;

        public LinkedLis() { }

        public LinkedLis(int value)
        {
            ListItem node = new ListItem(value);
            _head = node;
            _tail = node;
            count++;
        }

        public IEnumerator GetEnumerator()
        {
            _head_fr = _head;
            return this;
        }

        public bool MoveNext()
        {
            if (index == count - 1)
            {
                Reset();
                return false;
            }
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                if (index > 0)
                    _head_fr = _head_fr.nextItem;
                return _head_fr._value;
            }
        }

        /// <summary>
        /// Add value at end of the node
        /// </summary>
        /// <param name="value">Value of node</param>
        public void AddLast(int value)
        {
            ListItem node = new ListItem(value);

            if (count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.nextItem = node;
                node.previousItem = _tail;
            }

            _tail = node;
            count++;
        }

        /// <summary>
        /// Add value to the beginning of the node
        /// </summary>
        /// <param name="value">Value of node</param>
        public void AddFirst(int value)
        {
            ListItem node = new ListItem(value);
            ListItem temp = _head;

            _head = node;
            _head.nextItem = temp;

            if (count == 0)
            {
                _tail = _head;
            }
            else
            {
                temp.previousItem = _head;
            }

            count++;
        }

        /// <summary>
        ///  Adding an value after the specified value
        /// </summary>
        /// <param name="value">Value of node</param>
        /// <param name="after_value">After this value</param>
        public void AddAfterValue(int value, int after_value)
        {
            ListItem previous = null;
            ListItem current = _head;
            ListItem node = new ListItem(value);

            while (current != null)
            {
                if (current._value.Equals(after_value))
                {
                    if (current.nextItem == null)
                    {
                        _tail = node;
                    }

                    node.previousItem = current;
                    node.nextItem = current.nextItem;
                    current.nextItem = node;
                }

                previous = current;
                current = current.nextItem;
            }

            count++;
        }

        /// <summary>
        /// Adding an element by a given sequence number
        /// </summary>
        /// <param name="value">Value of node</param>
        /// <param name="number">Nomber of node</param>
        public void AddInNumber(int value, int number)
        {
            ListItem previous = null;
            ListItem current = _head;
            ListItem node = new ListItem(value);

            for (int i = 1; i <= count; i++)
            {
                if (i == number)
                {
                    if (current.previousItem == null)
                        _head = node;
                    else
                        previous.nextItem = node;

                    if (current.nextItem == null)
                    {

                    }

                    node.nextItem = current;
                    node.previousItem = previous;
                    current.previousItem = node;

                    count++;
                    break;
                }

                previous = current;
                current = current.nextItem;
            }
        }

        /// <summary>
        /// Deleting an element by value
        /// </summary>
        /// <param name="item">Value</param>
        /// <returns>True or false</returns>
        public bool RemoveByValue(int value)
        {
            ListItem previous = null;
            ListItem current = _head;

            while (current != null)
            {
                if (current._value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.nextItem = current.nextItem;

                        if (current.nextItem == null)
                        {
                            _tail = previous;
                        }
                        else
                        {
                            current.nextItem.previousItem = previous;
                        }

                        count--;
                    }
                    else
                    {
                        if (count != 0)
                        {
                            _head = _head.nextItem;

                            count--;

                            if (count == 0)
                            {
                                _tail = null;
                            }
                            else
                            {
                                _head.previousItem = null;
                            }
                        }
                    }

                    return true;
                }

                previous = current;
                current = current.nextItem;
            }

            return false;
        }

        /// <summary>
        /// Deleting an element by index
        /// </summary>
        /// <param name="item">Index of value</param>
        /// <returns>True or false</returns>
        public bool RemoveByIndex(int index)
        {
            ListItem previous = null;
            ListItem current = _head;

            for(int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    if (previous != null)
                    {
                        previous.nextItem = current.nextItem;

                        if (current.nextItem == null)
                        {
                            _tail = previous;
                        }
                        else
                        {
                            current.nextItem.previousItem = previous;
                        }

                        count--;
                    }
                    else
                    {
                        if (count != 0)
                        {
                            _head = _head.nextItem;

                            count--;

                            if (count == 0)
                            {
                                _tail = null;
                            }
                            else
                            {
                                _head.previousItem = null;
                            }
                        }
                    }

                    return true;
                }

                previous = current;
                current = current.nextItem;
            }

            return false;
        }

        /// <summary>
        /// Search for an item by its value
        /// </summary>
        /// <param name="value">Value for search</param>
        /// <returns>Found value or -1 if not found</returns>
        public int Contains(int value)
        {
            ListItem current = _head;
            while (current != null)
            {
                if (current._value.Equals(value))
                {
                    return current._value;
                }

                current = current.nextItem;
            }

            return -1;
        }

        /// <summary>
        /// Search for an item by its index
        /// </summary>
        /// <param name="index">Index of value</param>
        /// <returns>Found value or -1 if not found</returns>
        public int SearchByIndex(int index)
        {
            ListItem current = _head;
            
            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    return current._value;
                }
                current = current.nextItem;
            }

            return -1;
        }
    }
}