using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Code_Snippets
{
    public static class StackHelper
    {
        public static Stack Reverse(Stack inputStack)
        {
            Stack temp = new Stack();
            while(inputStack.Count != 0)
            {
                temp.Push(inputStack.Pop());
            }
            return temp;
        }

        public static Stack<T> GetNewStack<T>()
        {
            return new Stack<T>();
        }

        public static int GetLength(Stack stack)
        {
            return stack.Count;
        }

        public static void Push<T>(Stack<T> stack, T obj)
        {
            stack.Push(obj);
        }

        public static T Pop<T>(Stack<T> stack)
        {
            T result = default(T);
            if (stack.Any())
            {
                result = stack.Pop();
            }
            return result;

        }

        public static T Peek<T>(Stack<T> stack)
        {
            if (stack.Any())
            {
                return stack.Peek();
            }
            return default(T);
        }

        public static List<T> Traverse<T>(Stack<T> stack)
        {
            List<T> result = new List<T>();
            while(stack.Count > 0)
            {
                result.Append(stack.Pop());
            }
            return result;
        }
    }
}
