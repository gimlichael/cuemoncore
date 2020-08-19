﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Cuemon.Reflection;

namespace Cuemon.Resilience
{
    public static partial class TransientOperation
    {
        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<TResult>(Func<Task<TResult>> faultSensitiveMethod, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create(_ => faultSensitiveMethod());
            return WithFuncAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg">The parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T, TResult>(Func<T, Task<TResult>> faultSensitiveMethod, T arg, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create((a, _) => faultSensitiveMethod(a), arg);
            return WithFuncAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, TResult>(Func<T1, T2, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create((a1, a2, _) => faultSensitiveMethod(a1, a2), arg1, arg2);
            return WithFuncAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create((a1, a2, a3, _) => faultSensitiveMethod(a1, a2, a3), arg1, arg2, arg3);
            return WithFuncAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create((a1, a2, a3, a4, _) => faultSensitiveMethod(a1, a2, a3, a4), arg1, arg2, arg3, arg4);
            return WithFuncAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg5">The fifth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>The result from the <paramref name="faultSensitiveMethod"/>.</returns>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create((a1, a2, a3, a4, a5, _) => faultSensitiveMethod(a1, a2, a3, a4, a5), arg1, arg2, arg3, arg4, arg5);
            return WithFuncAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>The result from the <paramref name="faultSensitiveMethod"/>.</returns>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<TResult>(Func<CancellationToken, Task<TResult>> faultSensitiveMethod, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create(faultSensitiveMethod);
            return WithFuncAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg">The parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>The result from the <paramref name="faultSensitiveMethod"/>.</returns>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T, TResult>(Func<T, CancellationToken, Task<TResult>> faultSensitiveMethod, T arg, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create(faultSensitiveMethod, arg);
            return WithFuncAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>The result from the <paramref name="faultSensitiveMethod"/>.</returns>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, TResult>(Func<T1, T2, CancellationToken, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create(faultSensitiveMethod, arg1, arg2);
            return WithFuncAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>The result from the <paramref name="faultSensitiveMethod"/>.</returns>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, T3, TResult>(Func<T1, T2, T3, CancellationToken, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create(faultSensitiveMethod, arg1, arg2, arg3);
            return WithFuncAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>The result from the <paramref name="faultSensitiveMethod"/>.</returns>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, CancellationToken, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create(faultSensitiveMethod, arg1, arg2, arg3, arg4);
            return WithFuncAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg5">The fifth parameter of the function delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>The result from the <paramref name="faultSensitiveMethod"/>.</returns>
        /// <returns>A task that represents the asynchronous operation. The task result contains the return value of the function delegate <paramref name="faultSensitiveMethod"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task<TResult> WithFuncAsync<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, CancellationToken, Task<TResult>> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskFuncFactory.Create(faultSensitiveMethod, arg1, arg2, arg3, arg4, arg5);
            return WithFuncAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync(Func<Task> faultSensitiveMethod, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create(_ => faultSensitiveMethod());
            return WithActionAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg">The parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which need to be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T>(Func<T, Task> faultSensitiveMethod, T arg, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create((a, _) => faultSensitiveMethod(a), arg);
            return WithActionAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2>(Func<T1, T2, Task> faultSensitiveMethod, T1 arg1, T2 arg2, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create((a1, a2, _) => faultSensitiveMethod(a1, a2), arg1, arg2);
            return WithActionAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2, T3>(Func<T1, T2, T3, Task> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create((a1, a2, a3, _) => faultSensitiveMethod(a1, a2, a3), arg1, arg2, arg3);
            return WithActionAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create((a1, a2, a3, a4, _) => faultSensitiveMethod(a1, a2, a3, a4), arg1, arg2, arg3, arg4);
            return WithActionAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg5">The fifth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, Task> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create((a1, a2, a3, a4, a5, _) => faultSensitiveMethod(a1, a2, a3, a4, a5), arg1, arg2, arg3, arg4, arg5);
            return WithActionAsyncCore(factory, setup, default);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync(Func<CancellationToken, Task> faultSensitiveMethod, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create(faultSensitiveMethod);
            return WithActionAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg">The parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T>(Func<T, CancellationToken, Task> faultSensitiveMethod, T arg, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create(faultSensitiveMethod, arg);
            return WithActionAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2>(Func<T1, T2, CancellationToken, Task> faultSensitiveMethod, T1 arg1, T2 arg2, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create(faultSensitiveMethod, arg1, arg2);
            return WithActionAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2, T3>(Func<T1, T2, T3, CancellationToken, Task> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create(faultSensitiveMethod, arg1, arg2, arg3);
            return WithActionAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2, T3, T4>(Func<T1, T2, T3, T4, CancellationToken, Task> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create(faultSensitiveMethod, arg1, arg2, arg3, arg4);
            return WithActionAsyncCore(factory, setup, ct);
        }

        /// <summary>
        /// Repetitively executes the specified <paramref name="faultSensitiveMethod"/> until the operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</typeparam>
        /// <param name="faultSensitiveMethod">The fault sensitive <see cref="Task"/> based function delegate that is invoked until an operation is successful, the amount of retry attempts has been reached, or a failed operation is not considered related to transient fault condition.</param>
        /// <param name="arg1">The first parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg2">The second parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg3">The third parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg4">The fourth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="arg5">The fifth parameter of the delegate <paramref name="faultSensitiveMethod"/>.</param>
        /// <param name="ct">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <param name="setup">The <see cref="TransientOperationOptions"/> which may be configured.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="faultSensitiveMethod"/> cannot be null.
        /// </exception>
        public static Task WithActionAsync<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, CancellationToken, Task> faultSensitiveMethod, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken ct = default, Action<TransientOperationOptions> setup = null)
        {
            Validator.ThrowIfNull(faultSensitiveMethod, nameof(faultSensitiveMethod));
            var factory = TaskActionFactory.Create(faultSensitiveMethod, arg1, arg2, arg3, arg4, arg5);
            return WithActionAsyncCore(factory, setup, ct);
        }

        private static async Task WithActionAsyncCore<TTuple>(TaskActionFactory<TTuple> factory, Action<TransientOperationOptions> setup, CancellationToken ct) where TTuple : Template
        {
            var options = Patterns.Configure(setup);
            if (!options.EnableRecovery)
            {
                await factory.ExecuteMethodAsync(ct).ConfigureAwait(false);
                return;
            }
            var timestamp = DateTime.UtcNow;
            var latency = TimeSpan.Zero;
            var totalWaitTime = TimeSpan.Zero;
            var lastWaitTime = TimeSpan.Zero;
            var isTransientFault = false;
            var throwExceptions = false;
            var aggregatedExceptions = new List<Exception>();
            for (var attempts = 0; ;)
            {
                var waitTime = options.RetryStrategy(attempts);
                try
                {
                    if (latency > options.MaximumAllowedLatency) { throw new LatencyException(string.Format(CultureInfo.InvariantCulture, "The latency of the operation exceeded the allowed maximum value of {0} seconds. Actual latency was: {1} seconds.", options.MaximumAllowedLatency.TotalSeconds, latency.TotalSeconds)); }
                    await factory.ExecuteMethodAsync(ct).ConfigureAwait(false);
                    break;
                }
                catch (Exception ex)
                {
                    try
                    {
                        lock (aggregatedExceptions) { aggregatedExceptions.Insert(0, ex); }
                        isTransientFault = options.DetectionStrategy(ex);
                        if (attempts >= options.RetryAttempts) { throw; }
                        if (!isTransientFault) { throw; }
                        lastWaitTime = waitTime;
                        totalWaitTime = totalWaitTime.Add(waitTime);
                        attempts++;
                        await Task.Delay(waitTime).ConfigureAwait(false);
                        latency = DateTime.UtcNow.Subtract(timestamp).Subtract(totalWaitTime);
                    }
                    catch (Exception)
                    {
                        throwExceptions = true;
                        if (isTransientFault)
                        {
                            var evidence = new TransientFaultEvidence(attempts, lastWaitTime, totalWaitTime, latency, new MethodDescriptor(factory.DelegateInfo).ToString());
                            aggregatedExceptions.InsertTransientFaultException(evidence);
                            FaultCallback?.Invoke(evidence);
                        }
                        break;
                    }
                }
            }
            if (throwExceptions) { throw new AggregateException(aggregatedExceptions); }
        }

        private static async Task<TResult> WithFuncAsyncCore<TTuple, TResult>(TaskFuncFactory<TTuple, TResult> factory, Action<TransientOperationOptions> setup, CancellationToken ct) where TTuple : Template
        {
            var options = Patterns.Configure(setup);
            if (!options.EnableRecovery) { return await factory.ExecuteMethodAsync(ct).ConfigureAwait(false); }
            var timestamp = DateTime.UtcNow;
            var latency = TimeSpan.Zero;
            var totalWaitTime = TimeSpan.Zero;
            var lastWaitTime = TimeSpan.Zero;
            var isTransientFault = false;
            var throwExceptions = false;
            var aggregatedExceptions = new List<Exception>();
            var result = default(TResult);
            for (var attempts = 0; ;)
            {
                var waitTime = options.RetryStrategy(attempts);
                try
                {
                    if (latency > options.MaximumAllowedLatency) { throw new LatencyException(string.Format(CultureInfo.InvariantCulture, "The latency of the operation exceeded the allowed maximum value of {0} seconds. Actual latency was: {1} seconds.", options.MaximumAllowedLatency.TotalSeconds, latency.TotalSeconds)); }
                    result = await factory.ExecuteMethodAsync(ct).ConfigureAwait(false);
                    break;
                }
                catch (Exception ex)
                {
                    try
                    {
                        lock (aggregatedExceptions) { aggregatedExceptions.Insert(0, ex); }
                        isTransientFault = options.DetectionStrategy(ex);
                        if (attempts >= options.RetryAttempts) { throw; }
                        if (!isTransientFault) { throw; }
                        lastWaitTime = waitTime;
                        totalWaitTime = totalWaitTime.Add(waitTime);
                        attempts++;
                        await Task.Delay(waitTime).ConfigureAwait(false);
                        latency = DateTime.UtcNow.Subtract(timestamp).Subtract(totalWaitTime);
                    }
                    catch (Exception)
                    {
                        throwExceptions = true;
                        if (isTransientFault)
                        {
                            var evidence = new TransientFaultEvidence(attempts, lastWaitTime, totalWaitTime, latency, new MethodDescriptor(factory.DelegateInfo).ToString());
                            aggregatedExceptions.InsertTransientFaultException(evidence);
                            FaultCallback?.Invoke(evidence);
                        }
                        break;
                    }
                }
                finally
                {
                    if (throwExceptions)
                    {
                        var disposable = result as IDisposable;
                        disposable?.Dispose();
                    }
                }
            }
            if (throwExceptions) { throw new AggregateException(aggregatedExceptions); }
            return result;
        }
    }
}