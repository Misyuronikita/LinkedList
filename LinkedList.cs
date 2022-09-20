using System;
using System.Collections;

namespace LinkedListByMisyuro
{
    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Количество элементов списка
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Очистить список 
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        
        /// <summary>
        /// Создать пустой список.
        /// </summary>
        public LinkedList()
        {
            Clear();
        }
        /// <summary>
        /// Объявление первого элемента списка
        /// </summary>
        private void CreateFirst(T data)
        {
            var item = new Item<T>(data);

            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Создать список с начальным элементом.
        /// </summary>
        public LinkedList(T data)
        {
            CreateFirst(data);
        }

        /// <summary>
        /// Добавить данные в начало списка
        /// </summary>
        public void AddToHead(T data)
        {
            var item = new Item<T>(data);

            item.Next = Head;
            Head = item;
            Count++;
        }

        /// <summary>
        /// Вставить данные после определенного значения
        /// </summary>
        public void AddBetween(T target, T data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);

                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                CreateFirst(data);
            }
        }

        /// <summary>
        /// Добавить данные в конец списка
        /// </summary>
        public void AddToTail(T data)
        {
            var item = new Item<T>(data);

            if (Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                Head = item;
                Tail = item;
                Count = 1;
            }
        }

        /// <summary>
        /// Удалить первое вхождение элемента в список.
        /// </summary>
        public void Delete(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    var item = new Item<T>(data);

                    Head= Head.Next;
                    Count--;
                    return;
                }
                var current = Head.Next;
                var previous = Head;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                CreateFirst(data);
            }
        }

        /// <summary>
        /// Получить перечисление всех элементов списка
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return $"Односвязный список имеет {Count} элементов";
        }
    }
}
