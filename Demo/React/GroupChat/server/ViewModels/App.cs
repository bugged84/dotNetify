using System.Collections.Generic;
using DotNetify;
using DotNetify.Routing;

namespace WebApplication.ViewModels
{
   public class App : BaseVM, IRoutable
   {
      #region Link Nested Type

      public class Link
      {
         public string Caption { get; set; }
         public string Id => Route.TemplateId;
         public Route Route { get; set; }
      }

      #endregion

      #region IRoutable Properties

      public RoutingState RoutingState { get; set; }

      #endregion

      public List<Link> Links =>
         new List<Link>
         {
            new Link
            {
               Route = this.GetRoute("ChatRoomLobby")
             , Caption = "Chat Rooms"
            }
         };

      public App()
      {
         this.RegisterRoutes(
            ""
          , new List<RouteTemplate>
            {
               new RouteTemplate("Home")
               {
                  UrlPattern = ""
                , ViewUrl = "ChatRoomLobby"
               }
             , new RouteTemplate("ChatRoomLobby")
               {
                  UrlPattern = "chat-rooms"
                , VMType = typeof(ChatRoomLobbyVM)
               }
            }
         );
      }
   }
}