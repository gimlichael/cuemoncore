﻿using System;
using System.Collections.Generic;

namespace Cuemon.Collections.Generic
{
    /// <summary>
    /// This is an extension implementation of the most common methods on the <see cref="DictionaryUtility"/> class.
    /// </summary>
    public static class DictionaryUtilityExtension
    {
        /// <summary>
        /// Returns the first <typeparamref name="TValue"/> matching one of the specified <paramref name="keys"/> in a <see cref="IDictionary{TKey,TValue}"/>, or a default value if the <paramref name="source"/> contains no elements or no match was found.
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> of the key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the value.</typeparam>
        /// <param name="source">The <see cref="IDictionary{TKey, TValue}"/> to return a matching <typeparamref name="TValue"/> from.</param>
        /// <param name="keys">A variable number of keys to match in the specified <paramref name="source"/>.</param>
        /// <returns>default(TValue) if source is empty or no match was found; otherwise, the matching element in <paramref name="source"/>.</returns>
        /// <remarks>The default value for reference and nullable types is null.</remarks>
        public static TValue FirstMatchOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, params TKey[] keys)
        {
            return DictionaryUtility.FirstMatchOrDefault(source, keys);
        }
    }
}