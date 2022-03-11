using System;
using System.Threading.Tasks;

namespace Util.Error
{
   public static class ExceptionUtil
    {
     //dump
     public static void Subscribe(Action action,Action<Exception> exceptionAction)
        {
            try
            {
                action();
            }
            catch (Exception exp)
            {

                exceptionAction(exp);
            }
           
        }
        public static void Subscribe(Action action, Action<Exception> exceptionAction, Action completed)
        {
            try
            {
                action();
            }
            catch (Exception exp)
            {

                exceptionAction(exp);
            }
            finally
            {
                completed();
            }
        }

        public static async Task  SubscribeAsync( Func<Task<Action>> action, Func<Exception,Task> exceptionAction,Func<Task>completed)
        {
            try
            {
              await  action();
            }
            catch (Exception exp)
            {

             await   exceptionAction(exp);
            }
            finally
            {
               await completed();
            }
        }
        // dump end
        public static R Subscribe<R>(this Func<R> func, Func<Exception, R> exceptionFunc)
        {
            try
            {
                return func();
            }
            catch (Exception exp)
            {

                return exceptionFunc(exp);
            }
        }
        public static async Task <R> SubscribeAsync<R>(this Func<Task<R>> func, Func<Exception, Task<R>> exceptionFunc)
        {
            try
            {
                return await func();
            }
            catch (Exception exp)
            {

                return await exceptionFunc(exp);
            }
        }
        public static R Subscribe<R>(this Func<R> func, Func<Exception, R> exceptionFunc,Action completed)
        {
            try
            {
                return func();
            }
            catch (Exception exp)
            {

                return exceptionFunc(exp);
            }
            finally
            {
                completed();
            }
        }
        public static async  Task<R>SubscribeAsync<R>(this Func<Task<R>> func, Func<Exception, Task<R>> exceptionFunc, Func<Task<Action>> completed)
        {
            try
            {
                return  await func();
            }
            catch (Exception exp)
            {

                return await exceptionFunc(exp);
            }
            finally
            {
               await completed();
            }
        }
    }
}
