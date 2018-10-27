using System.Collections.Generic;
using DotNetify;
using DotNetify.Routing;

namespace WebApplication.ViewModels
{
   public class ChatRoomIndexVM : BaseVM, IRoutable
   {
      #region IRoutable Properties

      public RoutingState RoutingState { get; set; }

      #endregion

      public IEnumerable<object> ChatRooms { get; set; }

      public ChatRoomIndexVM()
      {
         this.RegisterRoutes(
            "ChatRoomIndex"
          , new List<RouteTemplate>
            {
               new RouteTemplate("ChatRoomList")
               {
                  UrlPattern = ""
               }
             , new RouteTemplate("ChatRoom")
               {
                  UrlPattern = "(/:id)"
                , VMType = typeof(ChatRoomVM)
               }
            }
         );

         ChatRooms = new List<object>
         {
            new
            {
               Id = 1
             , Route = this.GetRoute("ChatRoom", "1")
            }
          , new
            {
               Id = 2
             , Route = this.GetRoute("ChatRoom", "2")
            }
          , new
            {
               Id = 3
             , Route = this.GetRoute("ChatRoom", "3")
            }
          , new
            {
               Id = 4
             , Route = this.GetRoute("ChatRoom", "4")
            }
          , new
            {
               Id = 5
             , Route = this.GetRoute("ChatRoom", "5")
            }
         };
      }
   }
}