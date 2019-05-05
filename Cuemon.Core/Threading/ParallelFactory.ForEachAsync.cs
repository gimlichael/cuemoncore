﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cuemon.Threading
{
    public static partial class ParallelFactory
    {
        /// <summary>
        /// Executes a parallel foreach loop.
        /// </summary>
        /// <typeparam name="TSource">The type of the data in the source.</typeparam>
        /// <param name="source">The sequence to iterate over parallel.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="setup">The <see cref="TaskFactoryOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static Task ForEachAsync<TSource>(IEnumerable<TSource> source, Action<TSource> worker, Action<TaskFactoryOptions> setup = null)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(worker, nameof(worker));
            var wf = ActionFactory.Create(worker, default);
            return ForEachCoreAsync(source, wf, setup);
        }

        /// <summary>
        /// Executes a parallel foreach loop.
        /// </summary>
        /// <typeparam name="TSource">The type of the data in the source.</typeparam>
        /// <typeparam name="T">The type of the parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="source">The sequence to iterate over parallel.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg">The parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="TaskFactoryOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static Task ForEachAsync<TSource, T>(IEnumerable<TSource> source, Action<TSource, T> worker, T arg, Action<TaskFactoryOptions> setup = null)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(worker, nameof(worker));
            var wf = ActionFactory.Create(worker, default, arg);
            return ForEachCoreAsync(source, wf, setup);
        }

        /// <summary>
        /// Executes a parallel foreach loop.
        /// </summary>
        /// <typeparam name="TSource">The type of the data in the source.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="source">The sequence to iterate over parallel.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="TaskFactoryOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static Task ForEachAsync<TSource, T1, T2>(IEnumerable<TSource> source, Action<TSource, T1, T2> worker, T1 arg1, T2 arg2, Action<TaskFactoryOptions> setup = null)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(worker, nameof(worker));
            var wf = ActionFactory.Create(worker, default, arg1, arg2);
            return ForEachCoreAsync(source, wf, setup);
        }

        /// <summary>
        /// Executes a parallel foreach loop.
        /// </summary>
        /// <typeparam name="TSource">The type of the data in the source.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="source">The sequence to iterate over parallel.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="TaskFactoryOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static Task ForEachAsync<TSource, T1, T2, T3>(IEnumerable<TSource> source, Action<TSource, T1, T2, T3> worker, T1 arg1, T2 arg2, T3 arg3, Action<TaskFactoryOptions> setup = null)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(worker, nameof(worker));
            var wf = ActionFactory.Create(worker, default, arg1, arg2, arg3);
            return ForEachCoreAsync(source, wf, setup);
        }

        /// <summary>
        /// Executes a parallel foreach loop.
        /// </summary>
        /// <typeparam name="TSource">The type of the data in the source.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="source">The sequence to iterate over parallel.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="TaskFactoryOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static Task ForEachAsync<TSource, T1, T2, T3, T4>(IEnumerable<TSource> source, Action<TSource, T1, T2, T3, T4> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Action<TaskFactoryOptions> setup = null)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(worker, nameof(worker));
            var wf = ActionFactory.Create(worker, default, arg1, arg2, arg3, arg4);
            return ForEachCoreAsync(source, wf, setup);
        }

        /// <summary>
        /// Executes a parallel foreach loop.
        /// </summary>
        /// <typeparam name="TSource">The type of the data in the source.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the delegate <paramref name="worker" />.</typeparam>
        /// <param name="source">The sequence to iterate over parallel.</param>
        /// <param name="worker">The delegate that is invoked once per iteration.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="arg5">The fifth parameter of the delegate <paramref name="worker" />.</param>
        /// <param name="setup">The <see cref="TaskFactoryOptions"/> which may be configured.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static Task ForEachAsync<TSource, T1, T2, T3, T4, T5>(IEnumerable<TSource> source, Action<TSource, T1, T2, T3, T4, T5> worker, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Action<TaskFactoryOptions> setup = null)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(worker, nameof(worker));
            var wf = ActionFactory.Create(worker, default, arg1, arg2, arg3, arg4, arg5);
            return ForEachCoreAsync(source, wf, setup);
        }

        private static async Task ForEachCoreAsync<TSource, TWorker>(IEnumerable<TSource> source, ActionFactory<TWorker> workerFactory, Action<TaskFactoryOptions> setup)
            where TWorker : Template<TSource>
        {
            var options = Patterns.Configure(setup);
            var exceptions = new ConcurrentBag<Exception>();
            var skip = 0;

            for (;;)
            {
                var workChunks = options.ChunkSize;
                var queue = new List<Task>();
                var partition = source.Skip(skip);
                foreach (var item in partition)
                {
                    var shallowWorkerFactory = workerFactory.Clone();
                    queue.Add(Task.Factory.StartNew(element =>
                    {
                        try
                        {
                            Interlocked.Decrement(ref workChunks);
                            Interlocked.Increment(ref skip);
                            shallowWorkerFactory.GenericArguments.Arg1 = (TSource)element;
                            shallowWorkerFactory.ExecuteMethod();
                        }
                        catch (Exception e)
                        {
                            exceptions.Add(e);
                        }
                    }, item, options.CancellationToken, options.CreationOptions, options.Scheduler));
                    if (workChunks == 0) { break; }
                }
                if (queue.Count == 0) { break; }
                await Task.WhenAll(queue).ConfigureAwait(false);
                if (workChunks > 1) { break; }
            }

            if (exceptions.Count > 0) { throw new AggregateException(exceptions); }
        }
    }
}