import React from 'react';
import dotnetify from 'dotnetify';
import { RouteLink } from 'dotnetify/dist/dotnetify-react';

class ChatRoomIndex extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            ChatRooms: []
        };

        this.vm = dotnetify.react.connect('ChatRoomIndexVM', this);

        this.vm.onRouteEnter = (path, template) => {
            console.log(path);
            console.log(template);
            template.Target = 'Content';
        };
    }

    componentWillUnmount() {
        this.vm.$destroy();
    }

    render() {
        const chatRooms = this.state.ChatRooms.map(
            chatRoom => (
                <RouteLink vm={this.vm} route={chatRoom.Route} key={chatRoom.Id}>
                    <div>Chat Room {chatRoom.Id}</div>
                </RouteLink>
            )
        );

        return (
            <div>
                <div>{chatRooms}</div>
                <div id="Content" />
            </div>
        );
    }
}

export default ChatRoomIndex;