/*
 * Project : SenseFramework - Database module
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : Error Interceptor for repositories. 
 * 
 */
using System;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace SenseFramework.Data.EntityFramework.Attributes
{
    internal class CustomErrorHandlerInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public CustomErrorHandlerInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception error)
            {
                _logger.Error("Error has occured while in transaction",error);
                _logger.Error("Error has occured while in transaction",error.InnerException);
            }
        }
    }
}
