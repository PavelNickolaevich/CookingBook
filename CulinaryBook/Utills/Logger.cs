using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryBook.Utills
{
    internal static class Logger
    {
        public static void LogError(Exception ex)
        {
         
            Debug.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
