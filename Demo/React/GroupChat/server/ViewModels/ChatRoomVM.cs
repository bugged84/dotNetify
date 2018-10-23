using System;
using DotNetify;
using DotNetify.Routing;

namespace WebApplication.ViewModels
{
   public class ChatRoomVM : MulticastVM, IRoutable
   {
      private readonly IHubCallerContextAccessor m_hubCallerContextAccessor;

      public string Name = DateTime.Now.ToLongTimeString();

      #region IRoutable Properties

      public RoutingState RoutingState { get; set; }

      #endregion

      public override string GroupName =>
         m_hubCallerContextAccessor
           .CallerContext
           .GetViewModelGroupName();

      public ChatRoomVM(IHubCallerContextAccessor hubCallerContextAccessor)
      {
         m_hubCallerContextAccessor = hubCallerContextAccessor
            ?? throw new ArgumentNullException(
               nameof(hubCallerContextAccessor)
            );

         this.OnRouted(
            (sender, e) =>
            {
               // handle user entry
            }
         );
      }
   }
}