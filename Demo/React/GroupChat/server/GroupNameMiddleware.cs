using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetify;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace WebApplication
{
   public static class HubCallerContextExtensions
   {
      private static readonly string s_viewModelGroupNameKey
         = $"ViewModelGroupName_{Guid.NewGuid()}";

      public static string GetViewModelGroupName(this HubCallerContext context)
      {
         return context.Items.ContainsKey(s_viewModelGroupNameKey)
            ? (string)context.Items[s_viewModelGroupNameKey]
            : null;
      }

      public static void SetViewModelGroupName(
         this HubCallerContext context
       , string value
      )
      {
         context.Items[s_viewModelGroupNameKey] = value;
      }
   }

   public class GroupNameMiddleware : IMiddleware
   {
      #region IMiddleware Methods

      public Task Invoke(DotNetifyHubContext context, NextDelegate next)
      {
         if (context.Data is JObject data)
         {
            context
              .CallerContext
              .SetViewModelGroupName(GetRoute(data));
         }

         return next(context);
      }

      #endregion

      private static string GetRoute(JObject data)
      {
         return
            data
              .Properties()
              .FirstOrDefault(p => p.Name.StartsWith("RoutingState"))
             ?.Value
              .ToString();
      }
   }
}