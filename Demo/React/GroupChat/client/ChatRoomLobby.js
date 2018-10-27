import React from 'react';
import dotnetify from 'dotnetify';
import { RouteLink } from 'dotnetify/dist/dotnetify-react';

import ChatRoomList from './ChatRoomList';

class ChatRoomLobby extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            ChatRooms: [],
            showChatRoomList: true
        };

        this.vm = dotnetify.react.connect('ChatRoomLobbyVM', this);

        this.vm.onRouteEnter = (path, template) => {
            //console.log(path);
            //console.log(template);
            template.Target = 'ChatRoomContent';
            this.setState({ showChatRoomList: template.Id === 'ChatRoomList' });
        };
    }

    componentWillUnmount() {
        this.vm.$destroy();
    }

    render() {
        return (
            <div>
                {
                    this.state.showChatRoomList
                    &&
                    <ChatRoomList
                        vm={this.vm}
                        chatRooms={this.state.ChatRooms}
                    />
                }

                <div id="ChatRoomContent" />
            </div>
        );
    }
}

export default ChatRoomLobby;