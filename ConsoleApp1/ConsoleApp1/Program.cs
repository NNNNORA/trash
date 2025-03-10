using System;

namespace ConsoleApp1
{
    public class clas
    {
        private static void Swap(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }

        private static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }

        public static int[] CombSort(int[] array)
        {
            int length = array.Length;
            int step = length - 1;

            while (step > 1)
            {
                for (int i = 0; i + step < length; i++)
                {
                    if (array[i] > array[i + step])
                    {
                        Swap(ref array[i], ref array[i + step]);
                    }
                }
                step = GetNextStep(step);
            }

            BubbleSort(array);
            return array;
        }

        public static int FindElement(int[] array, int value)
        {
            foreach (int element in array)
            {
                if (element == value)
                {
                    return element;
                }
            }
            return -1; // Возвращаем -1, если элемент не найден
        }

        public static int[] ShellSort(int[] array)
        {
            int length = array.Length;
            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < length; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
            return array;
        }

        private static void BubbleSort(int[] array)
        {
            int length = array.Length;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < length; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        Swap(ref array[i - 1], ref array[i]);
                        swapped = true;
                    }
                }
                length--;
            } while (swapped);
        }

        public static string PrintArray(int[] array)
        {
            return string.Join(" ", array);
        }
    }
}
