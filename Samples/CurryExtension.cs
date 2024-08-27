using System;
using Microsoft.FSharp.Core;

namespace Samples;


public static class CurryExtension
{
    public static Func<TInput1, TOutput> Curry<TInput1, TOutput>(this Func<TInput1, TOutput> f)
    {
        return x => f(x);
    }

    public static Func<TInput1, Func<TInput2, Func<TInput3, Func<TInput4, TOutput>>>>
        Curry<TInput1, TInput2, TInput3, TInput4, TOutput>(
            this Func<TInput1, TInput2, TInput3, TInput4, TOutput> f)
    {
        return w => x => y => z => f(w, x, y, z);
    }

    public static FSharpFunc<T1, R> Curry<T1, R>(this FSharpFunc<T1, FSharpFunc<T1, R>> func, T1 arg1)
    {
        return func.Invoke(arg1);
    }

    public static R Curry<T1, R>(this FSharpFunc<T1, R> func, T1 arg1)
    {
        return func.Invoke(arg1);
    }

    public static R Curry<T1, T2, R>(this FSharpFunc<T1, FSharpFunc<T2, R>> func, T1 arg1, T2 arg2)
    {
        return func.Invoke(arg1).Invoke(arg2);
    }

    public static R Curry<T1, T2, T3, R>(this FSharpFunc<T1, FSharpFunc<T2, FSharpFunc<T3, R>>> func, T1 arg1, T2 arg2,
        T3 arg3)
    {
        return func.Invoke(arg1).Invoke(arg2).Invoke(arg3);
    }

    public static R Curry<T1, T2, T3, T4, R>(
        this FSharpFunc<T1, FSharpFunc<T2, FSharpFunc<T3, FSharpFunc<T4, R>>>> func, T1 arg1,
        T2 arg2, T3 arg3, T4 arg4)
    {
        return func.Invoke(arg1).Invoke(arg2).Invoke(arg3).Invoke(arg4);
    }

    public static R Curry<T1, T2, T3, T4, T5, R>(
        this FSharpFunc<T1, FSharpFunc<T2, FSharpFunc<T3, FSharpFunc<T4, FSharpFunc<T5, R>>>>> func, T1 arg1,
        T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        return func.Invoke(arg1).Invoke(arg2).Invoke(arg3).Invoke(arg4).Invoke(arg5);
    }


    public static R Curry<T1, T2, T3, T4, T5, T6, R>(
        this FSharpFunc<T1, FSharpFunc<T2, FSharpFunc<T3, FSharpFunc<T4, FSharpFunc<T5, FSharpFunc<T6, R>>>>>> func,
        T1 arg1,
        T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        return func.Invoke(arg1).Invoke(arg2).Invoke(arg3).Invoke(arg4).Invoke(arg5).Invoke(arg6);
    }

    public static R Curry<T1, T2, T3, T4, T5, T6, T7, R>(
        this FSharpFunc<T1, FSharpFunc<T2,
            FSharpFunc<T3, FSharpFunc<T4, FSharpFunc<T5, FSharpFunc<T6, FSharpFunc<T7, R>>>>>>> func,
        T1 arg1,
        T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        return func.Invoke(arg1).Invoke(arg2).Invoke(arg3).Invoke(arg4).Invoke(arg5).Invoke(arg6).Invoke(arg7);
    }
}